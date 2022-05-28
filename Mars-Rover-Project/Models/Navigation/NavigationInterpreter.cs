using System.ComponentModel.Design;
using Mars_Rover_Project.Models.General_Interfaces;
using Mars_Rover_Project.Models.Mars;
using Mars_Rover_Project.Models.Position;

namespace Mars_Rover_Project.Models.Navigation;

public class NavigationInterpreter
{
    private static readonly Dictionary<string, INavigation> NavigationDictionary = new()
    {
        { "L", new MoveLeft() },
        { "R", new MoveRight() },
        { "M", new NavigateForward() }
    };

    public static INavigation SetNavigation(string navCommands)=>NavigationDictionary[navCommands];
    

} 