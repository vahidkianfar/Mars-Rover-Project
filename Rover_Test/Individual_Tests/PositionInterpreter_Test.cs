using Mars_Rover_Project.Models.Position;
using NUnit.Framework;

namespace MarsRover_Test.Individual_Tests;

public class PositionInterpreterTest
{
    [Test]
    public void PositionInterpreter_Should_BreakDown_The_InputString()
    {
        
        var positionAndDirection = new PositionInterpreter("1 2 N");
        string expectedDirection = "N";
        int expectedaxisX = 1;
        int expectedaxisY = 2;
       
        
        Assert.AreEqual(expectedaxisX, positionAndDirection.initialPosition[0]);
        Assert.AreEqual(expectedaxisY, positionAndDirection.initialPosition[1]);
        Assert.AreEqual(expectedDirection, positionAndDirection.initialDirection);
    }
}