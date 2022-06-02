using System.Diagnostics.CodeAnalysis;
using static System.Console;

namespace Mars_Rover_Project.Models.UI;

[SuppressMessage("Interoperability", "CA1416:Validate platform compatibility")]
public class InstructionExample
{
    public static void InputExampleForPlateauSize() => Write("Enter the Plateau size (e.g \"5 5\"): ");

    public static void InputExampleForDeploymentPosition() =>
        Write("Enter the Deployment Position of first Rover (e.g \"1 2 N\"): ");

    public static void InputExampleForSecondDeploymentPosition() =>
        Write("Enter the Deployment Position of second Rover (e.g \"3 3 E\"): ");

    public static void InputExampleForInstructionFirstRover() =>
        Write("Enter movement instructions for the first Rover (e.g \"LMLMLMLMM\"): ");

    public static void InputExampleForInstructionSecondRover() =>
        Write("Enter movement instructions for second Rover (e.g \"MMRMMRMRRM\"): ");

    public static void ProgressBar()
    {
        //Clear();
        Write("\nLoading");
        for (var loadingCounter = 0; loadingCounter < 10; loadingCounter++)
        {
            Thread.Sleep(100);
            ForegroundColor = ConsoleColor.Blue;
            Write(" ▄ ");
        }
        ForegroundColor = ConsoleColor.Green;

        Write(" Done!\n");
        ForegroundColor = ConsoleColor.White;
    }

    public static void BeepSoundForError()
    {
        const int freq = 200;
        const int duration = 500;
        var counter = 0;
        while (counter < 3)
        {
            Beep(freq, duration);
            counter++;
        }
    }

    public static void BeepSoundForSuccess()
    {
        const int freq = 4000;
        const int duration = 500;
        Beep(freq, duration);
    }
    
   

}