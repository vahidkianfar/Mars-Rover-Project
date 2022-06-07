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
        var selectPlateau = ConsoleHelper.MultipleChoice(true, "1. Rectangular Plateau",
            "2. Circular Plateau (Not yet implemented)");
        switch (selectPlateau)
        {
            case 0:
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write(RoverBanner.Design);
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                UserGuideline.InputExampleForPlateauSize();
                var plateauSize = Console.ReadLine()!;
                var plateau = new RectangularPlateau(plateauSize);
                userPlateau = plateau;
                break;
            
            case 1:
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write(RoverBanner.Design);
                Console.ResetColor();
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