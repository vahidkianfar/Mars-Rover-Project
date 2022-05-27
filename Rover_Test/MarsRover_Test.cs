using Mars_Rover_Project.Models.Mars;
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
    
    public void PositionInterpreter_Should_Interpret_Direction_Correctly()
    {
        var roverPosition = new PositionInterpreter("1 2 N");
        Assert.AreEqual('N', roverPosition.initialDirection);
    }
    
    [Test]
    public void PositionInterpreter_Should_Interpret_Position_Correctly()
    {
        var roverPosition = new PositionInterpreter("1 2 N");
        Assert.AreEqual(1, roverPosition.initialPosition[0]);
        Assert.AreEqual(2, roverPosition.initialPosition[1]);
    }
    [Test]
    
    public void Create_Rover_With_Specific_Position()
    {
        MarsRover rover = new("1 2 N");
        Assert.AreEqual(1, rover.axisX);
        Assert.AreEqual(2, rover.axisY);
        Assert.AreEqual('N', rover.direction);
    }
}