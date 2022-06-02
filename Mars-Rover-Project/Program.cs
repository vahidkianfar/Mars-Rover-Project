﻿using Mars_Rover_Project.Command;
using Mars_Rover_Project.Models.Mars;
using Mars_Rover_Project.Models.UI;

Console.WriteLine("\n*** Mars Rover Controller ***");
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
            InstructionExample.ProgressBar();

            var readFile = new ReadFromFile();
            var lines = readFile.Read();
            var instructions = lines.ToList();

            var plateau = new MarsPlateau(instructions[0]);
            var rover1 = new MarsRover(instructions[1]);
         
            var missionControl = new MissionControl();
            missionControl.DeployRover(rover1, plateau);
            
            var rover2 = new MarsRover(instructions[3]);
            
            missionControl.DeployRover(rover2, plateau);
            
            if (MissionControl.CollisionDetection(rover1, rover2))
                CollisionMessages.CollisionMessageForSamePosition();
            
            else
            {
                missionControl.ExecuteCommand(0,instructions[2].ToString());
                if (MissionControl.CollisionDetection(rover1, rover2))
                    CollisionMessages.CollisionMessageForDeploymentSecondRover();
                
                else
                {
                    missionControl.ExecuteCommand(1,instructions[4].ToString());
                    if (MissionControl.CollisionDetection(rover1, rover2))
                        CollisionMessages.CollisionMessageForSameDestination();
                    
                    else
                    {
                        InstructionExample.BeepSoundForSuccess();
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
            InstructionExample.BeepSoundForError();
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
                UserInputs.GrabPlateauSize();

                InstructionExample.InputExampleForDeploymentPosition();
                var rover1Deployment = Console.ReadLine()!;
                var rover1 = new MarsRover(rover1Deployment);

                var missionControl = new MissionControl();
                missionControl.DeployRover(rover1, UserInputs.userPlateau);
              
               // var drawTable= new DrawPlateau();
               // var table = drawTable.CreateLiveTable(plateau.Lenght_X, plateau.Width_Y, rover1.GetAxisX(),rover1.GetAxisY());
               // AnsiConsole.Write(table);
               
                InstructionExample.InputExampleForInstructionFirstRover();
                var rover1Movement = Console.ReadLine()!;

                InstructionExample.InputExampleForSecondDeploymentPosition();
                var rover2Deployment = Console.ReadLine()!;
                var rover2 = new MarsRover(rover2Deployment);
              
                
                missionControl.DeployRover(rover2, UserInputs.userPlateau);
                InstructionExample.InputExampleForInstructionSecondRover();
                var rover2Movement = Console.ReadLine()!;
                InstructionExample.ProgressBar();

                if (MissionControl.CollisionDetection(rover1, rover2))
                    CollisionMessages.CollisionMessageForSamePosition();
                
                else
                {
                    missionControl.ExecuteCommand(0,rover1Movement);
                    if (MissionControl.CollisionDetection(rover1, rover2))
                        CollisionMessages.CollisionMessageForDeploymentSecondRover();
                    

                    else
                    {
                        missionControl.ExecuteCommand(1,rover2Movement);
                        if (MissionControl.CollisionDetection(rover1, rover2))
                            CollisionMessages.CollisionMessageForSameDestination();
                        
                        else
                        {
                            InstructionExample.BeepSoundForSuccess();
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
                //InstructionExample.BeepSoundForError();
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
                if (int.TryParse(args[0], out _))
                    throw new Exception("Invalid choice, please enter a valid number");
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid choice, please enter a valid number");
            }
            break;
}
else
{
    Console.WriteLine("Invalid choice, please enter a valid number");
}

 