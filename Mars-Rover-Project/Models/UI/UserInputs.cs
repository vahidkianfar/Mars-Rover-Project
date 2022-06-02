using Mars_Rover_Project.Models.General_Interfaces;
using Mars_Rover_Project.Models.Mars;

namespace Mars_Rover_Project.Models.UI;

public class UserInputs
{
    public static MarsPlateau? userPlateau{get;set;}
    public static MarsRover? userRover{get;set;}
    public static void GrabPlateauSize()
    {
        var plateauSize = Console.ReadLine()!;
        var plateau = new MarsPlateau(plateauSize);
        userPlateau=plateau;
    }
    
    public static void GrabRoverPosition()
    {
        var roverPosition = Console.ReadLine()!;
        var rover = new MarsRover(roverPosition);
        userRover=rover;
    }
}