using System.ComponentModel.Design;
using System.Security.Cryptography;
using Mars_Rover_Project.Models.General_Interfaces;
using Mars_Rover_Project.Models.Mars;
using Mars_Rover_Project.Models.Position;

namespace Mars_Rover_Project.Models.Navigation;

public class NavigationInterpreter
{
    private static readonly Dictionary<string, INavigation> NavigationDictionary = new()
    {
        { "L", new NavigateLeft() },
        { "R", new NavigateRight() },
        { "B", new NavigateBack() },
        { "M", new NavigateForward() }
    };

    public static INavigation SetNavigation(char navCommands)
    {
        if (NavigationDictionary.ContainsKey(navCommands.ToString()))
        {
            return NavigationDictionary[navCommands.ToString()];
        }
        throw new ArgumentException("Invalid Navigation Command");
    }
}