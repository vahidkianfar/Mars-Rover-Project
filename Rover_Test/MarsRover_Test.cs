using Mars_Rover_Project.Models.Mars;
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
}