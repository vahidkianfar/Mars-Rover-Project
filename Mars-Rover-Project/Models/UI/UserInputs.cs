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
        var selectedOption = ConsoleHelper.MultipleChoice(true, "Rectangular Plateau",
            "Circular Plateau (Not yet implemented)");
        switch (selectedOption)
        {
            case 0:
                Console.ForegroundColor = ConsoleColor.Blue;
                UserGuideline.InputExampleForPlateauSize();
                var plateauSize = Console.ReadLine()!;
                var plateau = new RectangularPlateau(plateauSize);
                userPlateau = plateau;
                break;
            
            case 1:
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