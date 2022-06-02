namespace Mars_Rover_Project.Models.UI;

public class InstructionExample
{
    public static void InputExampleForPlateauSize() => Console.Write("Enter the Plateau size (e.g \"5 5\"): ");

    public static void InputExampleForDeploymentPosition() =>
        Console.Write("Enter the Deployment Position of first Rover (e.g \"1 2 N\"): ");

    public static void InputExampleForSecondDeploymentPosition() =>
        Console.Write("Enter the Deployment Position of second Rover (e.g \"3 3 E\"): ");

    public static void InputExampleForInstructionFirstRover() =>
        Console.Write("Enter movement instructions for the first Rover (e.g \"LMLMLMLMM\"): ");

    public static void InputExampleForInstructionSecondRover() =>
        Console.Write("Enter movement instructions for second Rover (e.g \"MMRMMRMRRM\"): ");

    public static void ProgressBar()
    {
        Console.Clear();
        Console.Write("\nLoading");
        for (var loadingCounter = 0; loadingCounter < 10; loadingCounter++)
        {
            Thread.Sleep(100);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write(" ▄ ");
        }
        Console.ForegroundColor = ConsoleColor.Green;

        Console.Write(" Done!\n");
        Console.ForegroundColor = ConsoleColor.White;
    }

    public static void BeepSoundForError()
    {
        const int freq = 200;
        const int duration = 500;
        var counter = 0;
        while (counter < 3)
        {
            Console.Beep(freq, duration);
            counter++;
        }
    }

    public static void BeepSoundForSuccess()
    {
        const int freq = 4000;
        const int duration = 500;
        Console.Beep(freq, duration);
    }
    
   

}