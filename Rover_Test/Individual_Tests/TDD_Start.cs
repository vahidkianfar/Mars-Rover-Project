using System;
using Mars_Rover_Project.Models.PositionAndMovement;
using Mars_Rover_Project.Models.RoversAndPlateau;
using Mars_Rover_Project.Models.UI;
using NUnit.Framework;

namespace MarsRover_Test.Individual_Tests;

public class TDDTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Create_Plateau_With_Specific_Size()
    {
        RectangularPlateau plateau = new("5 5");
        Assert.AreEqual(5, plateau.Lenght_X);
        Assert.AreEqual(5, plateau.Width_Y);
    }
    
    [Test]
    public void PositionInterpreter_Should_Interpret_Position_Correctly()
    {
        var roverPosition = new PositionInterpreter("1 2 N");
        Assert.AreEqual(1, roverPosition.InitialPosition[0]);
        Assert.AreEqual(2, roverPosition.InitialPosition[1]);
        Assert.AreEqual("N", roverPosition.initialDirection);
    }
    [Test]
    
    public void Create_Rover_With_Specific_Position()
    {
        MarsRover rover = new("1 2 N");
        Assert.AreEqual(1, rover.GetAxisX());
        Assert.AreEqual(2, rover.GetAxisY());
        Assert.AreEqual(ChangeDirection.Direction.N, rover.GetDirection());
    }
    
    [Test]
    public void Change_Rover_Direction()
    {
        MarsRover rover = new("1 2 N");
        rover.TurnLeft();
        Assert.AreEqual(ChangeDirection.Direction.W, rover.GetDirection());
    }
    
    [Test]
    public void Move_Rover_Forward()
    {
        RectangularPlateau plateau = new("5 5");
        MarsRover rover = new("1 2 N");
        MissionControl.Plateau = plateau;
        
        rover.MoveForward();
        Assert.AreEqual(1, rover.GetAxisX());
        Assert.AreEqual(3, rover.GetAxisY());
    }
    
    [Test]
    public void Rover_Must_Go_To_Point_0_0_and_Direction_South_With_Details()
    {
        RectangularPlateau plateau3 = new("6 6");
        MarsRover rover3 = new("1 2 N");
        MissionControl.Plateau = plateau3;
        Console.WriteLine(rover3.GetAxisX() + " " + rover3.GetAxisY() + " " + rover3.GetDirection());
        rover3.TurnLeft();
        Console.WriteLine(rover3.GetAxisX() + " " + rover3.GetAxisY() + " " + rover3.GetDirection());
        rover3.MoveForward();
        Console.WriteLine(rover3.GetAxisX() + " " + rover3.GetAxisY() + " " + rover3.GetDirection());
        rover3.TurnLeft();
        Console.WriteLine(rover3.GetAxisX() + " " + rover3.GetAxisY() + " " + rover3.GetDirection());
        rover3.MoveForward();
        Console.WriteLine(rover3.GetAxisX() + " " + rover3.GetAxisY() + " " + rover3.GetDirection());
        rover3.MoveForward();
        
        Console.WriteLine(rover3.GetAxisX() + " " + rover3.GetAxisY() + " " + rover3.GetDirection());
        Assert.AreEqual(0, rover3.GetAxisX());
        Assert.AreEqual(0, rover3.GetAxisY());
        Assert.AreEqual(ChangeDirection.Direction.S, rover3.GetDirection());
    }
    
    [Test]
    public void ExecuteCommand_Must_Interpret_Command_Only_Direction_Correctly()
    {
        MarsRover rover = new("1 2 N");
        rover.ExecuteCommand("LLL");
        Assert.AreEqual(ChangeDirection.Direction.E, rover.GetDirection());
    }
    [Test]
    public void ExecuteCommand_Must_Interpret_Command_With_Movement_Correctly_For_First_Rover()
    {
        RectangularPlateau plateau = new("5 5");
        MarsRover rover = new("1 2 N");
        MissionControl.Plateau = plateau;
        rover.ExecuteCommand("LMLMLMLMM");
        Assert.AreEqual(ChangeDirection.Direction.N, rover.GetDirection());
        Assert.AreEqual(1, rover.GetAxisX());
        Assert.AreEqual(3, rover.GetAxisY());
    }
    [Test]
    public void ExecuteCommand_Must_Interpret_Command_With_Movement_Correctly_For_Second_Rover()
    {
        RectangularPlateau plateau = new("5 5");
        MarsRover rover = new("3 3 E");
        var missionControl = new MissionControl();
        missionControl.DeployRover(rover,plateau);
        rover.ExecuteCommand("MMRMMRMRRM");
        Assert.AreEqual(ChangeDirection.Direction.E, missionControl.GetRoverDetails(0)?.GetDirection());
        Assert.AreEqual(5, rover.GetAxisX());
        Assert.AreEqual(1, rover.GetAxisY());
    }
    [Test]
    public void Rover_Should_Handle_Out_of_Boundaries_Error()
    {
        RectangularPlateau plateau = new("5 5");
        MarsRover rover = new("1 2 N");
        var missionControl = new MissionControl();
        missionControl.DeployRover(rover,plateau);
        Assert.Throws<ArgumentException>(() => missionControl.GetRoverDetails(0)?.ExecuteCommand("LMLMLMLMMMMMMMMM"));
    }
    
    [Test]
    public void MissionControl_Should_Turn_The_Rover_Direction()
    {
        RectangularPlateau plateau = new("5 5");
        MarsRover rover = new("1 2 N");
        var missionControl = new MissionControl();
        missionControl.DeployRover(rover,plateau);
        missionControl.GetRoverDetails(0)?.ExecuteCommand("L");
        Assert.AreEqual(ChangeDirection.Direction.W, missionControl.GetRoverDetails(0)?.GetDirection());
    }
    
    [Test]
    public void MissionControl_Should_Turn_The_Rover_Direction_and_Move_The_Rover_Correctly()
    {
        RectangularPlateau plateau = new("5 5");
        MarsRover rover = new("1 2 N");
        var missionControl = new MissionControl();
        missionControl.DeployRover(rover,plateau);
        missionControl.GetRoverDetails(0)?.ExecuteCommand("LM");
        Assert.AreEqual(ChangeDirection.Direction.W, missionControl.GetRoverDetails(0)?.GetDirection());
        Assert.AreEqual(0, rover.GetAxisX());
        Assert.AreEqual(2, rover.GetAxisY());
    }

    [Test]
    
    public void MissionControl_Should_Execute_Command_For_Rover()
    {
            RectangularPlateau plateau = new("5 5");
            MarsRover rover = new("1 2 N");
            var missionControl = new MissionControl();
            missionControl.DeployRover(rover,plateau);
            
            missionControl.ExecuteCommand(0,"LMLMLMLMM");
            Assert.AreEqual(ChangeDirection.Direction.N, missionControl.GetRoverDetails(0)?.GetDirection());
            Assert.AreEqual(1, rover.GetAxisX());
            Assert.AreEqual(3, rover.GetAxisY());
    }
        
    [Test]
    
    public void MarsRover_Should_Turn_180_Degree()
    {
        MarsRover rover = new("1 2 N");
        rover.TurnAround();
        Assert.AreEqual(ChangeDirection.Direction.S, rover.roverDirection);
    } 
    
    [Test]
    
    public void MarsRover_Should_Turn_180_Degree_With_B_Command()
    {
        MarsRover rover = new("1 2 N");
        rover.ExecuteCommand("B");
        Assert.AreEqual(ChangeDirection.Direction.S, rover.roverDirection);
    }
    [Test]
    
    public void MissionControl_Should_Turn_The_Rover_180_Degree_With_B_Command()
    {
        RectangularPlateau plateau = new("5 5");
        MarsRover rover = new("1 2 N");
        var missionControl = new MissionControl();
        missionControl.DeployRover(rover,plateau);
        missionControl.ExecuteCommand(0,"B");
        Assert.AreEqual(ChangeDirection.Direction.S, missionControl.GetRoverDetails(0)?.GetDirection());
    }
}