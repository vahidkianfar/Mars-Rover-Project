using System.Diagnostics.CodeAnalysis;

namespace Mars_Rover_Project.Models.UI;

[SuppressMessage("Interoperability", "CA1416:Validate platform compatibility")]
public class CollisionMessages
{
    public static void CollisionMessageForSamePosition()
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("\nSystem Message:--> Collision detected: Rovers have been deployed at the same position. <--\n");
        SOSMorseCode();
    }

    public static void CollisionMessageForDeploymentOtherRovers()
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("\nSystem Message:--> Collision detected: Rovers cannot be deployed over other Rover's block. <--\n");
        SOSMorseCode();
    }

    public static void CollisionMessageForSameDestination()
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("\nSystem Message:--> Collision detected: Rovers cannot have the same destination. <--\n");
        SOSMorseCode();
        Environment.Exit(0);
    }
    
    private static void SOSMorseCode()
    {
        var sequence = Enumerable.Range(0, 3).ToList();
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("\n ▄ ▄ ▄ ▄▄▄ ▄▄▄ ▄▄▄ ▄ ▄ ▄ SOS code has been sent to the Rover Team.  ▄ ▄ ▄ ▄▄▄ ▄▄▄ ▄▄▄ ▄ ▄ ▄  \n");
        Console.ForegroundColor = ConsoleColor.White;
        sequence.ForEach(_ => Console.Beep(650, 50));
        Thread.Sleep(100);
        sequence.ForEach(_ => Console.Beep(650, 200));
        Thread.Sleep(100);
        sequence.ForEach(_ => Console.Beep(650, 50));
        Thread.Sleep(500);
        
    }
}