using Mars_Rover_Project.Models.PositionAndMovement;
using Mars_Rover_Project.Models.RoversAndPlateau;
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
        
        //Act
        ChangeDirection.TurnRight(rover);
      
        //Assert
        Assert.AreEqual(expected, rover.roverDirection);
    }
    [Test]
    public void ChangeDirection_Should_Change_The_Direction_Of_The_Rover_90_Degrees_To_Left()
    {
        //Arrange
        var rover = new MarsRover("1 2 N");
        var expected = ChangeDirection.Direction.W;
        
        //Act
        ChangeDirection.TurnLeft(rover);
      
        //Assert
        Assert.AreEqual(expected, rover.roverDirection);
    }
    
    [Test]
    public void ChangeDirection_Should_Change_The_Direction_Of_The_Rover_180_Degrees()
    {
        //Arrange
        var rover = new MarsRover("1 2 N");
        var expected = ChangeDirection.Direction.S;
        
        //Act
        ChangeDirection.TurnAround(rover);
      
        //Assert
        Assert.AreEqual(expected, rover.roverDirection);
    }
    [Test]
    public void ChangeDirection_Should_Change_The_Direction_Of_The_Rover_90_Degrees_Left_For_Diagonal_Direction()
    {
        //Arrange
        var rover = new MarsRover("1 2 NE");
        var expected = ChangeDirection.Direction.NW;
        
        //Act
        ChangeDirection.TurnLeft(rover);
      
        //Assert
        Assert.AreEqual(expected, rover.roverDirection);
    }
    [Test]
    public void ChangeDirection_Should_Change_The_Direction_Of_The_Rover_90_Degrees_Right_For_Diagonal_Direction()
    {
        //Arrange
        var rover = new MarsRover("1 2 NE");
        var expected = ChangeDirection.Direction.SE;
        
        //Act
        ChangeDirection.TurnRight(rover);
      
        //Assert
        Assert.AreEqual(expected, rover.roverDirection);
    }
    [Test]
    public void ChangeDirection_Should_Change_The_Direction_Of_The_Rover_180_Degrees_For_Diagonal_Direction()
    {
        //Arrange
        var rover = new MarsRover("1 2 NE");
        var expected = ChangeDirection.Direction.SW;
        
        //Act
        ChangeDirection.TurnAround(rover);
      
        //Assert
        Assert.AreEqual(expected, rover.roverDirection);
    }

}