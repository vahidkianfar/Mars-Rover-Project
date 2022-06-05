using System;
using Mars_Rover_Project.Models.Mars;
using Mars_Rover_Project.Models.Position;
using Mars_Rover_Project.Models.UI;
using NUnit.Framework;

namespace MarsRover_Test;

public class MissionControlTests
{
    private MissionControl _missionControl;
    [SetUp]
    public void Setup()
    {
    }
    
    [Test]
    public void MissionControl_Constructor_Should_Create_Instance()
    {
        _missionControl = new MissionControl();
        Assert.IsNotNull(_missionControl);
    }
    [Test]
    public void MissionControl_Should_Store_The_Plateau_and_Rover_Deploy_Coordinates()
    {
        MarsPlateau plateau = new("5 5");
        MarsRover rover = new("2 2 N");
        var missionControl = new MissionControl();
        missionControl.DeployRover(rover,plateau);
        
        Assert.AreEqual(missionControl.GetRoverDetails(0)!.GetAxisX(),2);
        Assert.AreEqual(missionControl.GetRoverDetails(0)!.GetAxisY(),2);
        Assert.AreEqual(missionControl.GetRoverDetails(0)!.GetDirection(),ChangeDirection.Direction.N);
    }
    [Test]
    public void MissionControl_Should_Change_The_Direction_Of_The_Rover_by_The_Given_Command()
    {
        MarsPlateau plateau = new("5 5");
        MarsRover rover = new("2 2 N");
        var missionControl = new MissionControl();
        missionControl.DeployRover(rover,plateau);
        missionControl.ExecuteCommand(0,"R");
        Assert.AreEqual(missionControl.GetRoverDetails(0)!.GetDirection(), ChangeDirection.Direction.E);
    }
    [Test]
    public void MissionControl_Should_Move_The_Rover_Then_Turn_Right_by_The_Given_Command()
    {
        MarsPlateau plateau = new("5 5");
        MarsRover rover = new("2 2 N");
        var missionControl = new MissionControl();
        missionControl.DeployRover(rover,plateau);
        missionControl.ExecuteCommand(0,"MR");
        
        Assert.AreEqual(missionControl.GetRoverDetails(0)!.GetAxisX(), 2);
        Assert.AreEqual(missionControl.GetRoverDetails(0)!.GetAxisY(), 3);
        Assert.AreEqual(missionControl.GetRoverDetails(0)!.GetDirection(), ChangeDirection.Direction.E);
    }
    [Test]
    public void MissionControl_Should_Handle_The_Boundaries_of_Plateau()
    {
        MarsPlateau plateau = new("5 5");
        MarsRover rover = new("2 2 N");
        var missionControl = new MissionControl();
        missionControl.DeployRover(rover,plateau);
        Assert.Throws<ArgumentException>(() =>missionControl.ExecuteCommand(0,"MMMMMMMR"));
    }
    [Test]
    public void MissionControl_Should_Accept_Multiple_Rovers_Deployment()
    {
        MarsPlateau plateau = new("5 5");
        MarsRover rover1 = new("2 2 N");
        MarsRover rover2 = new("3 3 E");
        MarsRover rover3 = new("4 4 W");
        
        var missionControl = new MissionControl();
        
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
    
}