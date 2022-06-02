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
            Console.Write("==");
        }

        Console.Write(" Done!\n");
    }

    

    public static void BeepSoundForError()
    {
        var freq = 200;
        var duration = 500;
        var counter = 0;
        while (counter < 3)
        {
            Console.Beep(freq, duration);
            counter++;
        }
    }

    public static void BeepSoundForSuccess()
    {
        Console.Beep(4000, 500);
    }
    
   

}