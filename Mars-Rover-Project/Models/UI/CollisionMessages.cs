﻿namespace Mars_Rover_Project.Models.UI;

public class CollisionMessages
{
    public static void CollisionMessageForSamePosition()
    {
        Console.WriteLine("\nSystem Message:--> Collision detected: Both the Rovers have been deployed at the same position. <--\n");
        SOSMorseCode();
    }

    public static void CollisionMessageForDeploymentSecondRover()
    {
        Console.WriteLine("\nSystem Message:--> Collision detected: Rover2 cannot be deployed over Rover1's block. <--\n");
        SOSMorseCode();
    }

    public static void CollisionMessageForSameDestination()
    {
        
        Console.WriteLine("\nSystem Message:--> Collision detected: Rover1 and Rover2 cannot have the same destination. <--\n");
        SOSMorseCode();
    }
    
    
    private static void SOSMorseCode()
    {
        var sequence = Enumerable.Range(0, 3).ToList();

        Console.WriteLine("\n ▄ ▄ ▄ ▄▄▄ ▄▄▄ ▄▄▄ ▄ ▄ ▄ SOS code has been sent to the Mars Rover Team.  ▄ ▄ ▄ ▄▄▄ ▄▄▄ ▄▄▄ ▄ ▄ ▄  \n");

        sequence.ForEach(e => Console.Beep(650, 50));

        Thread.Sleep(100);

        sequence.ForEach(e => Console.Beep(650, 200));

        Thread.Sleep(100);

        sequence.ForEach(e => Console.Beep(650, 50));

        Thread.Sleep(500);

    }
}