using Mars_Rover_Project.Models.General_Interfaces;
using Mars_Rover_Project.Models.RoversAndPlateau;

namespace Mars_Rover_Project.Models.UI;

public class UserInputs
{
    public static ISurface? userPlateau { get; private set; }
    public static IVehicle? userRover { get; private set; }
    public List<string?>? userCommands;
    public UserInputs()=> userCommands = new List<string?>();
    
    public static void GrabPlateauSizeFromUser()
    {
        Console.WriteLine("\nPlease choose a Plateau shape:\n");
        Console.WriteLine("1. Rectangular Plateau");
        Console.WriteLine("2. Circular Plateau (Not yet implemented)");
        Console.Write("\nEnter your choice: ");
        var choice = Convert.ToInt32(Console.ReadLine()!);
        switch (choice)
        {
            case 1:
                UserGuideline.InputExampleForPlateauSize();
                var plateauSize = Console.ReadLine()!;
                var plateau = new RectangularPlateau(plateauSize);
                userPlateau = plateau;
                break;
            
            case 2:
                throw new NotImplementedException();
        }

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