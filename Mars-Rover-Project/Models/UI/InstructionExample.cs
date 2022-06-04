using System.Diagnostics.CodeAnalysis;
using static System.Console;

namespace Mars_Rover_Project.Models.UI;

[SuppressMessage("Interoperability", "CA1416:Validate platform compatibility")]
public class InstructionExample
{
    public static void InputExampleForPlateauSize() => Write("Enter the Plateau size (e.g \"5 5\"): ");

    public static void InputExampleForDeploymentPosition() =>
        Write("Enter the Deployment Position of the Rover (e.g \"1 1 N\"): ");
    
    public static void InputExampleForInstructionFirstRover() =>
        Write("Enter movement instructions for the Rover (e.g \"RLMB\"): ");

    public static void ProgressBar()
    {
        //Clear();
        ForegroundColor = ConsoleColor.DarkRed;
        Write("\nLoading");
        for (var loadingCounter = 0; loadingCounter < 10; loadingCounter++)
        {
            Thread.Sleep(100);
            ForegroundColor = ConsoleColor.Blue;
            Write(" ▄ ");
        }
        ForegroundColor = ConsoleColor.Green;

        Write(" Done!\n\n");
        ResetColor();
    }

    public static void BeepSoundForError()
    {
        const int freq = 200;
        const int duration = 400;
        var counter = 0;
        while (counter < 3)
        {
            Beep(freq, duration);
            counter++;
        }
    }

    public static void BeepSoundForSuccess()
    {
        const int freq = 2000;
        const int duration = 500;
        Beep(freq, duration);
    }
    
   

}