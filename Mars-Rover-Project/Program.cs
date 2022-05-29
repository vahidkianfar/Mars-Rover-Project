using Mars_Rover_Project.Command;
using Mars_Rover_Project.Models.Mars;

Console.WriteLine("\n***Mars Rover Controller***\n");

Console.WriteLine("Please choice an option:");
Console.WriteLine("1. Read instructions from file");
Console.WriteLine("2. Read instructions from console (manually)");
Console.Write("\nEnter your choice: ");
var choice = Convert.ToInt32(Console.ReadLine());

switch (choice)
{
    case 1:
    {
        try
        { 
            //Instruction text file is in Project folder --> ...\Command\Instructions.text
            
            var readFile = new ReadFromFile();
            var lines = readFile.Read();
            var instructions = lines.ToList();

            var plateau = new MarsPlateau(instructions[0]);
            var rover1 = new MarsRover(instructions[1]);
            rover1.SetPlateau(plateau);
            rover1.ExecuteCommand(instructions[2]);

            var rover2 = new MarsRover(instructions[3]);
            rover2.SetPlateau(plateau);
            rover2.ExecuteCommand(instructions[4]);

            Console.Write("First ");
            rover1.GetCurrentPosition();

            Console.Write("Second ");
            rover2.GetCurrentPosition();
            
            var writer = new WriteOnFile(readFile.directoryInfo + "\\Command\\Output.txt",
                "First Rover "+rover1.GetCurrentPositionForFile() + "\n" + "Second Rover "+rover2.GetCurrentPositionForFile());
            writer.Write();
            
            Console.WriteLine("\nOutput file has been created!");
            
        }
        catch (Exception ex)
        {
            Console.WriteLine("\nSystem Message:--> {0} <--", ex.Message);
        } 
        break;
    }
    
    case 2:
    {
        while (true)
        {
            try
            {
                Console.Write("Enter the Plateau size (e.g \"5 5\"): ");
                var plateauSize = Console.ReadLine()!;
                var plateau = new MarsPlateau(plateauSize);
                Console.Write("Enter the Deployment Position of first Rover (e.g \"1 2 N\"): ");
                var rover1Deployment = Console.ReadLine()!;
                var rover1 = new MarsRover(rover1Deployment);
                rover1.SetPlateau(plateau);
                Console.Write("Enter movement instructions for first Rover (e.g \"LMLMLMLMM\"): ");
                var roverMovement = Console.ReadLine()!;
                rover1.ExecuteCommand(roverMovement);
                Console.Write("Enter the Deployment Position of second Rover (e.g \"3 3 E\"): ");
                var rover2Deployment = Console.ReadLine()!;
                var rover2 = new MarsRover(rover2Deployment);
                rover2.SetPlateau(plateau);
                Console.Write("Enter movement instructions for second Rover (e.g \"MMRMMRMRRM\"): ");
                var rover2Movement = Console.ReadLine()!;
                Console.Write("First ");
                rover1.GetCurrentPosition();
                rover2.ExecuteCommand(rover2Movement);
                Console.Write("Second ");
                rover2.GetCurrentPosition();
                Console.WriteLine("\nPress any key to continue... or press \'q\' to exit");
                if (Console.ReadKey().Key == ConsoleKey.Q)
                    Environment.Exit(0);
            }
            catch (Exception ex)
            {
                Console.WriteLine("\nSystem Message:--> {0} <--" , ex.Message);
                Console.WriteLine("\nPress any key to continue... or press \'q\' to exit");
                if (Console.ReadKey().Key == ConsoleKey.Q)
                    Environment.Exit(0);
            }
        }
    }
}