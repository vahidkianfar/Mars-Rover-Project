namespace Mars_Rover_Project.Models.UI;

public class InstructionExample
{
    public static void InputExampleForPlateauSize() => Console.Write("Enter the Plateau size (e.g \"5 5\"): ");
    public static void InputExampleForDeploymentPosition() => Console.Write("Enter the Deployment Position of first Rover (e.g \"1 2 N\"): ");
    
    public static void InputExampleForSecondDeploymentPosition() => Console.Write("Enter the Deployment Position of second Rover (e.g \"3 3 E\"): ");
    public static void InputExampleForInstructionFirstRover() => Console.Write("Enter movement instructions for the first Rover (e.g \"LMLMLMLMM\"): ");
    public static void InputExampleForInstructionSecondRover() => Console.Write("Enter movement instructions for second Rover (e.g \"MMRMMRMRRM\"): ");
}