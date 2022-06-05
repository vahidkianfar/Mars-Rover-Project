using System;
using Mars_Rover_Project.Models.Mars;
using NUnit.Framework;

namespace MarsRover_Test;

public class PlateauTests
{
    
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Create_Rectangular_Plateau_With_Specific_Size()
    {
        MarsPlateau plateau = new("7 3");
        Assert.AreEqual(7, plateau.Lenght_X);
        Assert.AreEqual(3, plateau.Width_Y);
    }
    
    [Test]
    public void Create_Rectangular_Plateau_With_Invalid_Size_Should_Throws_Argument_Exception()
    {
        Assert.Throws<ArgumentException>(() => new MarsPlateau("5 5 5"));
        Assert.Throws<ArgumentException>(() => new MarsPlateau("5"));
    }
    
    [Test]
    public void Create_Plateau_With_Negative_Size_Should_Throws_Argument_Exception()
    {
        Assert.Throws<ArgumentException>(() => new MarsPlateau("-5 8"));
    }
    
   
 
}
