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
        Assert.AreEqual(1, rover.axisX);
        Assert.AreEqual(2, rover.axisY);
        Assert.AreEqual("N", rover.direction);
    }
    
    [Test]
    public void Change_Rover_Direction()
    {
        MarsRover rover = new("1 2 N");
        rover.TurnLeft();
        Assert.AreEqual("W", rover.direction);
    }
    
    [Test]
    public void Move_Rover_Forward()
    {
        MarsRover rover = new("1 2 N");
        rover.Move();
        Assert.AreEqual(1, rover.axisX);
        Assert.AreEqual(3, rover.axisY);
    }
    
    [Test]
    public void Rover_Must_Go_To_Point_0_0_and_Direction_South()
    {
        MarsRover rover = new("1 2 N");
        rover.TurnLeft();
        rover.Move();
        rover.TurnLeft();
        rover.Move();
        rover.Move();
        Assert.AreEqual(0, rover.axisX);
        Assert.AreEqual(0, rover.axisY);
        Assert.AreEqual("S", rover.direction);
    }
    
    [Test]
    public void ExecuteCommand_Must_Interpret_Command_Correctly()
    {
        MarsRover rover = new("1 2 N");
        rover.ExecuteCommand("LLL");
        Assert.AreEqual("E", rover.direction);
    }
}