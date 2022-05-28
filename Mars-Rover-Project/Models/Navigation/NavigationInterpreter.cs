namespace Mars_Rover_Project.Models.Navigation;

public class NavigationInterpreter
{
    public static Dictionary<string, INavigation> NavigationDictionary = new()
    {
        { "L", new MoveLeft() },
        { "R", new MoveRight() },
        { "M", new MoveForward() }
    };
   
}