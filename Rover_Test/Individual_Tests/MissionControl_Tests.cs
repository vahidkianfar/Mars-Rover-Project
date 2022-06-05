using System;
using Mars_Rover_Project.Models.PositionAndMovement;
using Mars_Rover_Project.Models.RoversAndPlateau;
using Mars_Rover_Project.Models.UI;
using NUnit.Framework;

namespace MarsRover_Test.Individual_Tests;

public class MissionControlTests
{
   
    [SetUp]
    public void Setup()
    {
    }
    
    [Test]
    public void MissionControl_Constructor_Should_Create_Instance()
    {
        MissionControl missionControl = new();
        Assert.IsNotNull(missionControl);
    }
    [Test]
    public void MissionControl_Should_Store_The_Plateau_and_Rover_Deploy_Coordinates()
    {
        RectangularPlateau plateau = new("5 5");
        MarsRover rover = new("2 2 N");
        MissionControl missionControl = new ();
        missionControl.DeployRover(rover,plateau);
        
        Assert.AreEqual(missionControl.GetRoverDetails(0)!.GetAxisX(),2);
        Assert.AreEqual(missionControl.GetRoverDetails(0)!.GetAxisY(),2);
        Assert.AreEqual(missionControl.GetRoverDetails(0)!.GetDirection(),ChangeDirection.Direction.N);
    }
    [Test]
    public void MissionControl_Should_Change_The_Direction_Of_The_Rover_by_The_Given_Command()
    {
        RectangularPlateau plateau = new("5 5");
        MarsRover rover = new("2 2 N");
        MissionControl missionControl = new();
        missionControl.DeployRover(rover,plateau);
        missionControl.ExecuteCommand(0,"R");
        Assert.AreEqual(missionControl.GetRoverDetails(0)!.GetDirection(), ChangeDirection.Direction.E);
    }
    [Test]
    public void MissionControl_Should_Move_The_Rover_Then_Turn_Right_by_The_Given_Command()
    {
        RectangularPlateau plateau = new("5 5");
        MarsRover rover = new("2 2 N");
        MissionControl missionControl = new();
        missionControl.DeployRover(rover,plateau);
        missionControl.ExecuteCommand(0,"MR");
        
        Assert.AreEqual(missionControl.GetRoverDetails(0)!.GetAxisX(), 2);
        Assert.AreEqual(missionControl.GetRoverDetails(0)!.GetAxisY(), 3);
        Assert.AreEqual(missionControl.GetRoverDetails(0)!.GetDirection(), ChangeDirection.Direction.E);
    }
    
    [Test]
    public void MissionControl_Should_Accept_Multiple_Rovers_Deployment()
    {
        RectangularPlateau plateau = new("5 5");
        
        MarsRover rover1 = new("2 2 N");
        MarsRover rover2 = new("3 3 E");
        MarsRover rover3 = new("4 4 W");
        
        MissionControl missionControl = new();
        
        missionControl.DeployRover(rover1,plateau);
        missionControl.DeployRover(rover2,plateau);
        missionControl.DeployRover(rover3,plateau);
        
        Assert.AreEqual(missionControl.GetRoverDetails(0)!.GetAxisX(),2);
        Assert.AreEqual(missionControl.GetRoverDetails(0)!.GetAxisY(),2);
        Assert.AreEqual(missionControl.GetRoverDetails(0)!.GetDirection(),ChangeDirection.Direction.N);
        
        Assert.AreEqual(missionControl.GetRoverDetails(1)!.GetAxisX(),3);
        Assert.AreEqual(missionControl.GetRoverDetails(1)!.GetAxisY(),3);
        Assert.AreEqual(missionControl.GetRoverDetails(1)!.GetDirection(),ChangeDirection.Direction.E);
        
        Assert.AreEqual(missionControl.GetRoverDetails(2)!.GetAxisX(),4);
        Assert.AreEqual(missionControl.GetRoverDetails(2)!.GetAxisY(),4);
        Assert.AreEqual(missionControl.GetRoverDetails(2)!.GetDirection(),ChangeDirection.Direction.W);
    }
    
    [Test]
    public void MissionControl_Should_Accept_Multiple_Rovers_Deployment_And_Execute_Commands()
    {
        RectangularPlateau plateau = new("5 5");
        
        MarsRover rover1 = new("2 2 N");
        MarsRover rover2 = new("3 3 E");
        MarsRover rover3 = new("4 4 W");
        
        MissionControl missionControl = new();
        
        missionControl.DeployRover(rover1,plateau);
        missionControl.DeployRover(rover2,plateau);
        missionControl.DeployRover(rover3,plateau);
        
        missionControl.ExecuteCommand(0,"MMR");
        missionControl.ExecuteCommand(1,"BMM");
        missionControl.ExecuteCommand(2,"MMMLM");
        
        Assert.AreEqual(missionControl.GetRoverDetails(0)!.GetAxisX(),2);
        Assert.AreEqual(missionControl.GetRoverDetails(0)!.GetAxisY(),4);
        Assert.AreEqual(missionControl.GetRoverDetails(0)!.GetDirection(),ChangeDirection.Direction.E);
        
        Assert.AreEqual(missionControl.GetRoverDetails(1)!.GetAxisX(),1);
        Assert.AreEqual(missionControl.GetRoverDetails(1)!.GetAxisY(),3);
        Assert.AreEqual(missionControl.GetRoverDetails(1)!.GetDirection(),ChangeDirection.Direction.W);
        
        Assert.AreEqual(missionControl.GetRoverDetails(2)!.GetAxisX(),1);
        Assert.AreEqual(missionControl.GetRoverDetails(2)!.GetAxisY(),3);
        Assert.AreEqual(missionControl.GetRoverDetails(2)!.GetDirection(),ChangeDirection.Direction.S);
    }
    [Test]
    public void MissionControl_Should_Check_For_Boundaries_of_Plateau()
    {
        RectangularPlateau plateau = new("5 5");
        MarsRover rover = new("2 2 N");
        MissionControl missionControl = new();
        missionControl.DeployRover(rover,plateau);
        Assert.Throws<ArgumentException>(() =>missionControl.ExecuteCommand(0,"MMMMMMMR"));
    }

    [Test]
    public void MissionControl_Should_Throws_Exception_When_Rover_Go_Further_Than_Plateau_Boundaries()
    {
        RectangularPlateau plateau = new("5 5");
        
        MarsRover rover1 = new("2 2 N");
        MarsRover rover2 = new("3 3 E");
        MarsRover rover3 = new("4 4 W");
        
        MissionControl missionControl = new();
        
        missionControl.DeployRover(rover1,plateau);
        missionControl.DeployRover(rover2,plateau);
        missionControl.DeployRover(rover3,plateau);
        
        Assert.Throws<ArgumentException>(() =>missionControl.ExecuteCommand(0,"MMMMMMMR"));
        Assert.Throws<ArgumentException>(() =>missionControl.ExecuteCommand(1,"BMMMMMMMR"));
        Assert.Throws<ArgumentException>(() =>missionControl.ExecuteCommand(2,"LMMMMMMMR"));
    }

    [Test]
    public void MissionControl_Should_Return_TRUE_When_Collision_Happened()
    {
        RectangularPlateau plateau = new("5 5");
        
        MarsRover rover1 = new("2 2 N");
        MarsRover rover2 = new("3 3 E");
        MarsRover rover3 = new("4 4 W");
        
        MissionControl missionControl = new();
        
        missionControl.DeployRover(rover1,plateau);
        missionControl.DeployRover(rover2,plateau);
        missionControl.DeployRover(rover3,plateau);
        
        missionControl.ExecuteCommand(0, "L");
        missionControl.ExecuteCommand(1, "BMLM");
        missionControl.ExecuteCommand(2, "RLM");
        
        Assert.AreEqual(true,missionControl.CollisionInnerDetection(missionControl.RoverList!));
    }

    [Test]
    public void MissionControl_Should_Throws_Exception_When_Deployment_Coordinates_Not_In_The_Plateau_Boundaries()
    {
        RectangularPlateau plateau = new("5 5");
        MarsRover rover = new("6 6 N");
        MissionControl missionControl = new();
        Assert.Throws<ArgumentException>(() =>missionControl.DeployRover(rover,plateau));
    }
    [Test]
    public void MissionControl_Should_Throws_Exception_When_The_Number_Of_Rovers_More_Than_Available_Blocks()
    {
        RectangularPlateau plateau = new("2 2");
        MarsRover rover1 = new("1 1 N");
        MarsRover rover2 = new("1 2 N");
        MarsRover rover3 = new("2 1 N");
        MarsRover rover4 = new("2 2 N");
        MarsRover rover5 = new("2 2 N");
        
        MissionControl missionControl = new();
        
        missionControl.DeployRover(rover1,plateau);
        missionControl.DeployRover(rover2,plateau);
        missionControl.DeployRover(rover3,plateau);
        missionControl.DeployRover(rover4,plateau);
        
        //When the user tries to deploy more than the available blocks
        Assert.Throws<ArgumentException>(() =>missionControl.DeployRover(rover5,plateau));
    }
    
    [Test]
    public void MissionControl_Should_Move_The_Rover_With_Diagonal_Direction()
    {
        RectangularPlateau plateau = new("5 5");
        MarsRover rover = new("1 1 NE");
        MissionControl missionControl = new();
        missionControl.DeployRover(rover,plateau);
        missionControl.ExecuteCommand(0,"MMB");
        
        Assert.AreEqual(missionControl.GetRoverDetails(0)!.GetAxisX(), 3);
        Assert.AreEqual(missionControl.GetRoverDetails(0)!.GetAxisY(), 3);
        Assert.AreEqual(missionControl.GetRoverDetails(0)!.GetDirection(), ChangeDirection.Direction.SW);
    }
    
}