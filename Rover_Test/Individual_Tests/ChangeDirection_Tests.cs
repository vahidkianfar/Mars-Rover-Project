using Mars_Rover_Project.Models.Mars;
using Mars_Rover_Project.Models.Position;
using NUnit.Framework;

namespace MarsRover_Test.Individual_Tests;

public class ChangeDirectionTests
{
    [Test]
    public void ChangeDirection_Should_Change_The_Direction_Of_The_Rover_90_Degrees_To_Right()
    {
        //Arrange
        var rover = new MarsRover("1 2 N");
        var expected = ChangeDirection.Direction.E;
        var directionChanger = new ChangeDirection();
        
        //Act
        directionChanger.TurnRight(rover);
      
        //Assert
        Assert.AreEqual(expected, rover.roverDirection);
    }
    [Test]
    public void ChangeDirection_Should_Change_The_Direction_Of_The_Rover_90_Degrees_To_Left()
    {
        //Arrange
        var rover = new MarsRover("1 2 N");
        var expected = ChangeDirection.Direction.W;
        var directionChanger = new ChangeDirection();
        
        //Act
        directionChanger.TurnLeft(rover);
      
        //Assert
        Assert.AreEqual(expected, rover.roverDirection);
    }
    
    [Test]
    public void ChangeDirection_Should_Change_The_Direction_Of_The_Rover_180_Degrees()
    {
        //Arrange
        var rover = new MarsRover("1 2 N");
        var expected = ChangeDirection.Direction.S;
        var directionChanger = new ChangeDirection();
        
        //Act
        directionChanger.TurnAround(rover);
      
        //Assert
        Assert.AreEqual(expected, rover.roverDirection);
    }

}