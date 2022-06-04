using Mars_Rover_Project.Models.General_Interfaces;
using Mars_Rover_Project.Models.Mars;

namespace Mars_Rover_Project.Models.UI;

public class UserInputs
{
    public static ISurface? userPlateau { get; private set; }
    public static IVehicle? userRover { get; private set; }
    public List<string?>? userCommands;
    public UserInputs()=> userCommands = new List<string?>();
    
    public static void GrabPlateauSizeFromUser()
    {
        var plateauSize = Console.ReadLine()!;
        var plateau = new MarsPlateau(plateauSize);
        userPlateau = plateau;
    }

    public static void GrabRoverPositionFromUser()
    {
        var roverPosition = Console.ReadLine()!;
        var rover = new MarsRover(roverPosition);
        userRover = rover;
    }
    
    public void GrabMovementInstructionsFromUser()
    {
        var commands = Console.ReadLine()!;
        userCommands?.Add(commands.ToUpper());
    }
    
}