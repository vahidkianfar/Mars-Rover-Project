using System;
using Mars_Rover_Project.Models.Mars;
using Mars_Rover_Project.Models.Navigation;
using Mars_Rover_Project.Models.Position;
using NUnit.Framework;

namespace MarsRover_Test;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Create_Plateau_With_Specific_Size()
    {
        MarsPlateau plateau = new("5 5");
        Assert.AreEqual(5, plateau.Lenght_X);
        Assert.AreEqual(5, plateau.Width_Y);
    }
    
    [Test]
    public void PositionInterpreter_Should_Interpret_Position_Correctly()
    {
        var roverPosition = new PositionInterpreter("1 2 N");
        Assert.AreEqual(1, roverPosition.initialPosition[0]);
        Assert.AreEqual(2, roverPosition.initialPosition[1]);
        Assert.AreEqual("N", roverPosition.initialDirection);
    }
    [Test]
    
    public void Create_Rover_With_Specific_Position()
    {
        MarsRover rover = new("1 2 N");
        Assert.AreEqual(1, rover.GetAxisX());
        Assert.AreEqual(2, rover.GetAxisY());
        Assert.AreEqual("N", rover.GetDirection());
    }
    
    [Test]
    public void Change_Rover_Direction()
    {
        MarsRover rover = new("1 2 N");
        rover.TurnLeft();
        Assert.AreEqual("W", rover.GetDirection());
    }
    
    [Test]
    public void Move_Rover_Forward()
    {
        MarsPlateau plateau = new("5 5");
        MarsRover rover = new("1 2 N");
        rover.SetPlateau(plateau);
        rover.Move();
        Assert.AreEqual(1, rover.GetAxisX());
        Assert.AreEqual(3, rover.GetAxisY());
    }
    
    [Test]
    public void Rover_Must_Go_To_Point_0_0_and_Direction_South()
    {
        MarsPlateau plateau3 = new("6 6");
        MarsRover rover3 = new("1 2 N");
        rover3.SetPlateau(plateau3);
        Console.WriteLine(rover3.GetAxisX() + " " + rover3.GetAxisY() + " " + rover3.GetDirection());
        rover3.TurnLeft();
        Console.WriteLine(rover3.GetAxisX() + " " + rover3.GetAxisY() + " " + rover3.GetDirection());
        rover3.Move();
        Console.WriteLine(rover3.GetAxisX() + " " + rover3.GetAxisY() + " " + rover3.GetDirection());
        rover3.TurnLeft();
        Console.WriteLine(rover3.GetAxisX() + " " + rover3.GetAxisY() + " " + rover3.GetDirection());
        rover3.Move();
        Console.WriteLine(rover3.GetAxisX() + " " + rover3.GetAxisY() + " " + rover3.GetDirection());
        rover3.Move();
        
        Console.WriteLine(rover3.GetAxisX() + " " + rover3.GetAxisY() + " " + rover3.GetDirection());
        Assert.AreEqual(0, rover3.GetAxisX());
        Assert.AreEqual(0, rover3.GetAxisY());
        Assert.AreEqual("S", rover3.GetDirection());
    }
    
    [Test]
    public void ExecuteCommand_Must_Interpret_Command_Only_Direction_Correctly()
    {
        MarsRover rover = new("1 2 N");
        rover.ExecuteCommand("LLL");
        Assert.AreEqual("E", rover.GetDirection());
    }
    [Test]
    public void ExecuteCommand_Must_Interpret_Command_With_Movement_Correctly()
    {
        MarsPlateau plateau = new("5 5");
        MarsRover rover = new("1 2 N");
        rover.SetPlateau(plateau);
        rover.ExecuteCommand("LMLMLMLMM");
        Assert.AreEqual("N", rover.GetDirection());
        Assert.AreEqual(1, rover.GetAxisX());
        Assert.AreEqual(3, rover.GetAxisY());
    }
    [Test]
    public void Rover_Should_Handle_Out_of_Boundaries_Error()
    {
        MarsPlateau plateau = new("5 5");
        MarsRover rover = new("1 2 N");
        rover.SetPlateau(plateau);

        Assert.Throws<ArgumentException>(() => rover.ExecuteCommand("LMLMLMLMMMMMMMMM"));
    }
}