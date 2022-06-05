using System;
using Mars_Rover_Project.Models.Mars;
using Mars_Rover_Project.Models.Position;
using NUnit.Framework;

namespace MarsRover_Test.Individual_Tests;

public class RoverTests
{
    [SetUp]
    
    public void Setup()
    {
    }
    
    [Test]
    public void Rover_Should_Be_Created_With_Correct_Deploy_Coordinate()
    {
        // It just Test the rover itself without PLATEAU.
        
        MarsRover rover = new ("1 1 N");
        Assert.AreEqual(1, rover.GetAxisX());
        Assert.AreEqual(1, rover.GetAxisY());
        Assert.AreEqual(ChangeDirection.Direction.N, rover.roverDirection);
    }
    [Test]
    public void Rover_Should_Throws_Argument_Exception_For_Negative_Deploy_Coordinate()
    {
        Assert.Throws<ArgumentException>(() => new MarsRover("-1 -1 N"));
        Assert.Throws<ArgumentException>(() => new MarsRover("-3 10 N"));
    }
    [Test]
    public void Rover_Should_Throws_Argument_Exception_For_Invalid_Direction()
    {
        Assert.Throws<ArgumentException>(() => new MarsRover("5 5 G"));
        Assert.Throws<ArgumentException>(() => new MarsRover("5 5 WG"));
        Assert.Throws<ArgumentException>(() => new MarsRover("5 5 5"));
    }
    
    [Test]
    public void Rover_Should_Change_Its_Direction_by_Single_Command()
    {
        //Rover's Direction is N
        MarsRover rover = new ("1 1 N");
        rover.TurnLeft();
        Assert.AreEqual(ChangeDirection.Direction.W, rover.roverDirection);
        
    } 
    [Test]
    public void Rover_Should_Change_Its_Direction_by_Multiple_Command()
    {
        MarsRover rover = new ("1 1 N");
        rover.TurnLeft(); // W
        Assert.AreEqual(ChangeDirection.Direction.W, rover.roverDirection);
        rover.TurnAround(); // E
        Assert.AreEqual(ChangeDirection.Direction.E, rover.roverDirection);
       
    }
    
}