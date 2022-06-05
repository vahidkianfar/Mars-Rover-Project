using System;
using Mars_Rover_Project.Models.Mars;
using Mars_Rover_Project.Models.Position;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace MarsRover_Test;

public class RoverTests
{
    private MarsRover rover;
    [SetUp]
    
    public void Setup()
    {
        rover = new MarsRover("1 1 N");
    }
    
    [Test]
    public void Rover_Should_Be_Created_With_Correct_Deploy_Coordinate()
    {
        // It just Test the rover itself without PLATEAU.
        Assert.AreEqual(1, rover.GetAxisX());
        Assert.AreEqual(1, rover.GetAxisY());
        Assert.AreEqual(ChangeDirection.Direction.N, rover.roverDirection);
    }
    [Test]
    public void Rover_Should_Throws_Argument_Exception_For_Negative_Deploy_Coordinate()
    {
        Assert.Throws<ArgumentException>(() => new MarsRover("-1 -1 N"));
    }
    [Test]
    public void Rover_Should_Throws_Argument_Exception_For_Invalid_Direction()
    {
        Assert.Throws<ArgumentException>(() => new MarsRover("5 5 G"));
    }
    
    [Test]
    public void Rover_Should_Change_Its_Direction_by_Single_Command()
    {
        //Rover's Direction is N
        rover.TurnLeft();
        Assert.AreEqual(ChangeDirection.Direction.W, rover.roverDirection);
        
    } 
    [Test]
    public void Rover_Should_Change_Its_Direction_by_Multiple_Command()
    {
        rover.TurnLeft(); // W
        rover.TurnAround(); // E
        Assert.AreEqual(ChangeDirection.Direction.E, rover.roverDirection);
    }
    
}