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
            Console.Write("\nLoading");
            for(var loadingCounter = 0; loadingCounter < 10; loadingCounter++)
            {
                Thread.Sleep(100);
                Console.Write("==");
            }
            Console.Write(" Done!\n");

            var readFile = new ReadFromFile();
            var lines = readFile.Read();
            var instructions = lines.ToList();

            var plateau = new MarsPlateau(instructions[0]);
            var rover1 = new MarsRover(instructions[1]);
            rover1.SetPlateau(plateau);


            var rover2 = new MarsRover(instructions[3]);
            rover2.SetPlateau(plateau);

            if (MissionControl.CollisionDetected(rover1, rover2))
            {
                
                throw new Exception(
                    "Collision detected: Rovers cannot be deployed on the same position, Mission aborted!");
            }
            else
            {
                rover1.ExecuteCommand(instructions[2]);
                if (MissionControl.CollisionDetected(rover1, rover2))
                    throw new Exception(
                        "Collision detected: Rover2 cannot be deployed over Rover1's block, Mission aborted!");
                else
                {
                    rover2.ExecuteCommand(instructions[4]);
                    if (MissionControl.CollisionDetected(rover1, rover2))
                        throw new Exception("Collision detected: Rover 1 and Rover 2 cannot have the same destination, Mission aborted!");

                    else
                    {
                        Console.Beep();
                        Console.Write("\nFirst ");
                        rover1.GetCurrentPositionForConsole();

                        Console.Write("Second ");
                        rover2.GetCurrentPositionForConsole();

                        var writer = new WriteOnFile(readFile.directoryInfo + "\\Command\\Output.txt",
                            "First Rover " + rover1.GetCurrentPositionForFile() + "\n" + "Second Rover " +
                            rover2.GetCurrentPositionForFile());
                        writer.Write();

                        Console.WriteLine("\nOutput file has been created!");
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.Beep();
            Console.Beep();
            Console.Beep();
            Console.Beep();
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


                Console.Write("Enter the Deployment Position of second Rover (e.g \"3 3 E\"): ");
                var rover2Deployment = Console.ReadLine()!;
                var rover2 = new MarsRover(rover2Deployment);
                rover2.SetPlateau(plateau);
                Console.Write("Enter movement instructions for second Rover (e.g \"MMRMMRMRRM\"): ");
                var rover2Movement = Console.ReadLine()!;
                Console.Write("\nLoading");
                for(var loadingCounter = 0; loadingCounter < 10; loadingCounter++)
                {
                    Thread.Sleep(100);
                    Console.Write("==");
                }
                Console.Write(" Done!\n");

                if (MissionControl.CollisionDetected(rover1, rover2))
                {
                    throw new Exception(
                        "Collision detected: Rovers cannot be deployed on the same position, Mission aborted!");
                }
                else
                {
                    rover1.ExecuteCommand(roverMovement);
                    if (MissionControl.CollisionDetected(rover1, rover2))
                        throw new Exception(
                            "Collision detected: Rover2 cannot be deployed over Rover1's block, Mission aborted!");

                    else
                    {
                        rover2.ExecuteCommand(rover2Movement);
                        if (MissionControl.CollisionDetected(rover1, rover2))
                            throw new Exception(
                                "Collision detected: Rover1 and Rover2 cannot have the same destination, Mission aborted!");
                        else
                        {
                            Console.Beep();
                            Console.Write("\nFirst ");
                            rover1.GetCurrentPositionForConsole();

                            Console.Write("Second ");
                            rover2.GetCurrentPositionForConsole();
                            Console.WriteLine("\nPress any key to continue... or press \'q\' to exit");
                            if (Console.ReadKey().Key == ConsoleKey.Q)
                                Environment.Exit(0);
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                Console.Beep();
                Console.Beep();
                Console.Beep();
                Console.Beep();
                Console.WriteLine("\nSystem Message:--> {0} <--", ex.Message);
                Console.WriteLine("\nPress any key to continue... or press \'q\' to exit");
                if (Console.ReadKey().Key == ConsoleKey.Q)
                    Environment.Exit(0);
            }
        }
    }
}