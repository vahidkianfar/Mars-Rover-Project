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
    case 0x1:
    {
        try
        {
            //Instruction text file is in Project folder --> ...\Command\Instructions.text
            InstructionExample.ProgressBar();

            var readFile = new ReadFromFile();
            var lines = readFile.Read();
            var instructions = lines.ToList();

            var plateau = new MarsPlateau(instructions[0x0]);
            var rover1 = new MarsRover(instructions[0x1]);
         
            var missionControl = new MissionControl();
            missionControl.DeployRover(rover1, plateau);
            
            var rover2 = new MarsRover(instructions[0x3]);
            
            missionControl.DeployRover(rover2, plateau);
            
            if (MissionControl.CollisionDetection(rover1, rover2))
                CollisionMessages.CollisionMessageForSamePosition();
            
            else
            {
                missionControl.ExecuteCommand(0x0,instructions[0x2]);
                if (MissionControl.CollisionDetection(missionControl.GetRoverDetails(0x0), missionControl.GetRoverDetails(0x1)))
                    CollisionMessages.CollisionMessageForDeploymentSecondRover();
                
                else
                {
                    missionControl.ExecuteCommand(0x1,instructions[0x4]);
                    if (MissionControl.CollisionDetection(missionControl.GetRoverDetails(0x0), missionControl.GetRoverDetails(0x1)))
                        CollisionMessages.CollisionMessageForSameDestination();
                    
                    else
                    {
                        InstructionExample.BeepSoundForSuccess();
                        Console.Write("\nFirst ");
                        missionControl.GetRoverDetails(0x0)?.GetCurrentPositionForConsole();

                        Console.Write("Second ");
                        missionControl.GetRoverDetails(0x1)?.GetCurrentPositionForConsole();

                        var writer = new WriteOnFile(readFile.directoryInfo + "\\Command\\Output.txt",
                            "First Rover " + missionControl.GetRoverDetails(0x0)?.GetCurrentPositionForFile() + "\n" + "Second Rover " +
                            missionControl.GetRoverDetails(0x1)?.GetCurrentPositionForFile());
                        writer.Write();

                        Console.WriteLine("\nOutput file has been created!");
                        
                        var drawTable= new DrawPlateau();
                        var plateauLenght = Convert.ToInt32(instructions[0].Split(' ')[0]);
                        var plateauWidth = Convert.ToInt32(instructions[0].Split(' ')[1]);
                        var rover1Lenght = missionControl.GetRoverDetails(0)!.GetAxisX();
                        var rover1Width = missionControl.GetRoverDetails(0)!.GetAxisY();
                        var rover2Lenght = missionControl.GetRoverDetails(1)!.GetAxisX();
                        var rover3Width = missionControl.GetRoverDetails(1)!.GetAxisY();
                        var table = drawTable.CreateSurfaceTable(plateauLenght, plateauWidth, rover1Lenght, rover1Width, rover2Lenght, rover3Width);
                        AnsiConsole.Write(table);

                        // var calendar = new Calendar(2022,6);
                        // AnsiConsole.Render(calendar);
                        //var table = new DrawPlateau();
                        //await table.CreateTable();
                        //AnsiConsole.Write(table.CreateSimpleTable());

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

    case 0x2:
    {
        while (true)
        {
            try
            {
                InstructionExample.InputExampleForPlateauSize();
                UserInputs.GrabPlateauSize();

                InstructionExample.InputExampleForDeploymentPosition();
                
                UserInputs.GrabRoverPosition();

                var missionControl = new MissionControl();
                missionControl.DeployRover(UserInputs.userRover, UserInputs.userPlateau);
                
               
                InstructionExample.InputExampleForInstructionFirstRover();
                var rover1Movement = Console.ReadLine()!;

                InstructionExample.InputExampleForSecondDeploymentPosition();
                UserInputs.GrabRoverPosition();
              
                
                missionControl.DeployRover(UserInputs.userRover, UserInputs.userPlateau);
                InstructionExample.InputExampleForInstructionSecondRover();
                var rover2Movement = Console.ReadLine()!;
                InstructionExample.ProgressBar();

                if (MissionControl.CollisionDetection(missionControl.GetRoverDetails(0x0), missionControl.GetRoverDetails(0x1)))
                    CollisionMessages.CollisionMessageForSamePosition();
                
                else
                {
                    missionControl.ExecuteCommand(0x0,rover1Movement);
                    if (MissionControl.CollisionDetection(missionControl.GetRoverDetails(0x0), missionControl.GetRoverDetails(0x1)))
                        CollisionMessages.CollisionMessageForDeploymentSecondRover();
                    

                    else
                    {
                        missionControl.ExecuteCommand(0x1,rover2Movement);
                        if (MissionControl.CollisionDetection(missionControl.GetRoverDetails(0x0), missionControl.GetRoverDetails(0x1)))
                            CollisionMessages.CollisionMessageForSameDestination();
                        
                        else
                        {
                            InstructionExample.BeepSoundForSuccess();
                            Console.Write("\nFirst ");
                            missionControl.GetRoverDetails(0x0)?.GetCurrentPositionForConsole();

                            Console.Write("Second ");
                            missionControl.GetRoverDetails(0x1)?.GetCurrentPositionForConsole();

                            Console.WriteLine("\nPress any key to continue... or press \'q\' to exit");
                            if (Console.ReadKey().Key == ConsoleKey.Q)
                                Environment.Exit(0x0);
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
                    Environment.Exit(0x0);
            }
        }
    }
    default:
            try
            {
                if (int.TryParse(args[0x0], out _))
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