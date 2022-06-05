using System;
using Mars_Rover_Project.Models.Navigation;
using NUnit.Framework;

namespace MarsRover_Test.Individual_Tests;

public class NavigationTests
{
    [Test]
    public void NavigationInterpreter_Should_Interpret_Command_L_Into_Executable_Tasks()
    {
        var navigateLeft= NavigationInterpreter.SetNavigation('L');
        Assert.AreEqual(NavigationInterpreter.NavigationDictionary["L"],navigateLeft );
        
    }
    [Test]
    public void NavigationInterpreter_Should_Interpret_Command_R_Into_Executable_Tasks()
    {
        var navigateRight = NavigationInterpreter.SetNavigation('R');
        Assert.AreEqual(NavigationInterpreter.NavigationDictionary["R"], navigateRight);

    }
    [Test]
    public void NavigationInterpreter_Should_Interpret_Command_M_Into_Executable_Tasks()
    {
        var move = NavigationInterpreter.SetNavigation('M');
        Assert.AreEqual(NavigationInterpreter.NavigationDictionary["M"], move);

    }
    [Test]
    public void NavigationInterpreter_Should_Interpret_Command_B_Into_Executable_Tasks()
    {
        var navigateBack = NavigationInterpreter.SetNavigation('B');
        Assert.AreEqual(NavigationInterpreter.NavigationDictionary["B"], navigateBack);

    }
    [Test]
    public void NavigationInterpreter_Should_Throws_Exception_For_Invalid_Command()
    {
        Assert.Throws<ArgumentException>(() => NavigationInterpreter.SetNavigation('X'));
        Assert.Throws<ArgumentException>(() => NavigationInterpreter.SetNavigation('1'));
        Assert.Throws<ArgumentException>(() => NavigationInterpreter.SetNavigation('@'));
        Assert.Throws<ArgumentException>(() => NavigationInterpreter.SetNavigation('#'));
        Assert.Throws<ArgumentException>(() => NavigationInterpreter.SetNavigation('Z'));
        Assert.Throws<ArgumentException>(() => NavigationInterpreter.SetNavigation('0'));
    }
}