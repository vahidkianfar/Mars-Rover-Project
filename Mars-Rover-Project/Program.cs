using Mars_Rover_Project.Command;
using Mars_Rover_Project.Models.Mars;
using System.Drawing;
using Mars_Rover_Project.Models.Position;
using Mars_Rover_Project.Models.UI;
using Spectre.Console;
using Color = System.Drawing.Color;

Console.WriteLine("*** Mars Rover Controller ***");
Console.WriteLine("\nPlease choice an option:");
Console.WriteLine("1. Read instructions from file");
Console.WriteLine("2. Read instructions from console (manually)");
Console.Write("\nEnter your choice: ");
if(int.TryParse(Console.ReadLine(), out var choice))

    switch (choice)
{
    case 1:
    {
        try
        {
            
            //Instruction text file is in Project folder --> ...\Command\Instructions.text
            Console.Write("\nLoading ");
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
         
            var missionControl1 = new MissionControl();
            missionControl1.DeployRover(rover1, plateau);
            
            var rover2 = new MarsRover(instructions[3]);
            
            var missionControl2 = new MissionControl();
            missionControl2.DeployRover(rover2, plateau);
            
            if (MissionControl.CollisionDetection(rover1, rover2))
            {
                
                throw new Exception(
                    "Collision detected: Rovers cannot be deployed on the same position, Mission aborted!");
            }
            else
            {
                rover1.ExecuteCommand(instructions[2]);
                if (MissionControl.CollisionDetection(rover1, rover2))
                    throw new Exception(
                        "Collision detected: Rover2 cannot be deployed over Rover1's block, Mission aborted!");
                else
                {
                    rover2.ExecuteCommand(instructions[4]);
                    if (MissionControl.CollisionDetection(rover1, rover2))
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
                InstructionExample.InputExampleForPlateauSize();
                var plateauSize = Console.ReadLine()!;
                var plateau = new MarsPlateau(plateauSize);

                InstructionExample.InputExampleForDeploymentPosition();
                var rover1Deployment = Console.ReadLine()!;
                var rover1 = new MarsRover(rover1Deployment);
               
               var missionControl1 = new MissionControl();
               missionControl1.DeployRover(rover1, plateau);
              
               // var drawTable= new DrawPlateau();
               // var table = drawTable.CreateLiveTable(plateau.Lenght_X, plateau.Width_Y, rover1.GetAxisX(),rover1.GetAxisY());
               // AnsiConsole.Write(table);
               
                InstructionExample.InputExampleForInstructionFirstRover();
                var roverMovement = Console.ReadLine()!;

                InstructionExample.InputExampleForSecondDeploymentPosition();
                var rover2Deployment = Console.ReadLine()!;
                var rover2 = new MarsRover(rover2Deployment);
              
                var missionControl2 = new MissionControl();
                missionControl2.DeployRover(rover2, plateau);
                InstructionExample.InputExampleForInstructionSecondRover();
                var rover2Movement = Console.ReadLine()!;
                Console.Write("\nLoading");
                for(var loadingCounter = 0; loadingCounter < 10; loadingCounter++)
                {
                    Thread.Sleep(100);
                    Console.Write("==");
                }
                Console.Write(" Done!\n");

                if (MissionControl.CollisionDetection(rover1, rover2))
                {
                    throw new Exception(
                        "Collision detected: Rovers cannot be deployed on the same position, Mission aborted!");
                }
                else
                {
                    rover1.ExecuteCommand(roverMovement);
                    if (MissionControl.CollisionDetection(rover1, rover2))
                        throw new Exception(
                            "Collision detected: Rover2 cannot be deployed over Rover1's block, Mission aborted!");

                    else
                    {
                        rover2.ExecuteCommand(rover2Movement);
                        if (MissionControl.CollisionDetection(rover1, rover2))
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
    default:
            try
            {
                if (int.TryParse(args[0], out var number))
                    throw new Exception("Invalid choice, please enter a valid number");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            break;
}
else Console.WriteLine("Invalid choice, please enter a valid number");