using Mars_Rover_Project.Models.General_Interfaces;

namespace Mars_Rover_Project.Models.Navigation;

public class NavigationInterpreter
{
    public static readonly Dictionary<string, INavigation> NavigationDictionary = new()
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