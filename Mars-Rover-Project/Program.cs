using Mars_Rover_Project.Command;
using Mars_Rover_Project.Models.Mars;
using Mars_Rover_Project.Models.Position;
using Mars_Rover_Project.Models.UI;
using Spectre.Console;

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
            var missionControl = new MissionControl();
            InstructionExample.ProgressBar();
            var readFile = new ReadFromFile();
            var lines = readFile.Read();
            var instructions = lines.ToList();
            var plateau = new MarsPlateau(instructions[0]);
            var rover1 = new MarsRover(instructions[1]);
            missionControl.DeployRover(rover1, plateau);
            var rover2 = new MarsRover(instructions[3]);
            missionControl.DeployRover(rover2, plateau);
            if (MissionControl.CollisionDetection(rover1, rover2))
                CollisionMessages.CollisionMessageForSamePosition();
            else
            {
                missionControl.ExecuteCommand(0,instructions[2]?.ToUpper());
                if (MissionControl.CollisionDetection(missionControl.GetRoverDetails(0), missionControl.GetRoverDetails(1)))
                    CollisionMessages.CollisionMessageForDeploymentSecondRover();
                else
                {
                    missionControl.ExecuteCommand(1,instructions[4]?.ToUpper());
                    if (MissionControl.CollisionDetection(missionControl.GetRoverDetails(0), missionControl.GetRoverDetails(1)))
                        CollisionMessages.CollisionMessageForSameDestination();
                    else
                    {
                        InstructionExample.BeepSoundForSuccess();
                        Console.Write("\nFirst ");
                        missionControl.GetRoverDetails(0)?.GetCurrentPositionForConsole();

                        Console.Write("Second ");
                        missionControl.GetRoverDetails(1)?.GetCurrentPositionForConsole();

                        var writer = new WriteOnFile(readFile.directoryInfo + "\\Command\\Output.txt",
                            "First Rover " + missionControl.GetRoverDetails(0)?.GetCurrentPositionForFile() + "\n" + "Second Rover " +
                            missionControl.GetRoverDetails(1)?.GetCurrentPositionForFile());
                        writer.Write();

                        Console.WriteLine("\nOutput file has been created!");

                        var drawTable= new DrawPlateau();
                        await drawTable.LiveTable
                        (
                            Convert.ToInt32(instructions[0]!.Split(' ')[0]),
                            Convert.ToInt32(instructions[0]!.Split(' ')[1]),
                            missionControl.GetRoverDetails(0)!.GetAxisX(),
                            missionControl.GetRoverDetails(0)!.GetAxisY(), 
                            missionControl.GetRoverDetails(1)!.GetAxisX(),
                            missionControl.GetRoverDetails(1)!.GetAxisY()
                        );

                    }
                }
            }
        }
        catch (Exception ex)
        {
            InstructionExample.BeepSoundForError();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nSystem Message:--> {0} <--", ex.Message);
            Console.ForegroundColor = ConsoleColor.White;
        }

        break;
    }

    case 2:
    {
        while (true)
        {
            try
            {
                var missionControl = new MissionControl();
                var user = new UserInputs();
                InstructionExample.InputExampleForPlateauSize();
                UserInputs.GrabPlateauSize();

                InstructionExample.InputExampleForDeploymentPosition();
                UserInputs.GrabRoverPosition();
                
                missionControl.DeployRover(UserInputs.userRover, UserInputs.userPlateau);
                
                InstructionExample.InputExampleForInstructionFirstRover();
                user.GrabMovementInstructions();
                
                InstructionExample.InputExampleForSecondDeploymentPosition();
                UserInputs.GrabRoverPosition();
                
                missionControl.DeployRover(UserInputs.userRover, UserInputs.userPlateau);
                
                InstructionExample.InputExampleForInstructionSecondRover();
                user.GrabMovementInstructions();
                
                InstructionExample.ProgressBar();

                if (MissionControl.CollisionDetection(missionControl.GetRoverDetails(0), missionControl.GetRoverDetails(1)))
                    CollisionMessages.CollisionMessageForSamePosition();
                
                else
                {
                    missionControl.ExecuteCommand(0,user.userCommands?[0]);
                    if (MissionControl.CollisionDetection(missionControl.GetRoverDetails(0), missionControl.GetRoverDetails(1)))
                        CollisionMessages.CollisionMessageForDeploymentSecondRover();
                    
                    else
                    {
                        missionControl.ExecuteCommand(1,user.userCommands?[1]);
                        if (MissionControl.CollisionDetection(missionControl.GetRoverDetails(0), missionControl.GetRoverDetails(1)))
                            CollisionMessages.CollisionMessageForSameDestination();
                        
                        else
                        {
                            InstructionExample.BeepSoundForSuccess();
                            Console.Write("\nFirst ");
                            missionControl.GetRoverDetails(0)?.GetCurrentPositionForConsole();

                            Console.Write("Second ");
                            missionControl.GetRoverDetails(1)?.GetCurrentPositionForConsole();
                            
                            var drawTable= new DrawPlateau();
                            await drawTable.LiveTable
                                (
                                UserInputs.userPlateau!.Lenght_X, 
                                UserInputs.userPlateau.Width_Y, 
                                missionControl.GetRoverDetails(0)!.GetAxisX(),
                                missionControl.GetRoverDetails(0)!.GetAxisY(),
                                missionControl.GetRoverDetails(1)!.GetAxisX(),
                                missionControl.GetRoverDetails(1)!.GetAxisY()
                                );

                            Console.WriteLine("\nPress any key to continue... or press \'q\' to exit");
                            if (Console.ReadKey().Key == ConsoleKey.Q)
                                Environment.Exit(0);
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                InstructionExample.BeepSoundForError();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nSystem Message:--> {0} <--", ex.Message);
                Console.ForegroundColor = ConsoleColor.White;
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