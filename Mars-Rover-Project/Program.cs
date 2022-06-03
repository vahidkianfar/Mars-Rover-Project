using Mars_Rover_Project.Command;
using Mars_Rover_Project.Models.Mars;
using Mars_Rover_Project.Models.Position;
using Mars_Rover_Project.Models.UI;


Console.WriteLine("\n*** Mars Rover Controller ***");
Console.WriteLine("\nPlease choice an option:\n");
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
            for(var deployLineCounter = 1; deployLineCounter < instructions.Count; deployLineCounter+=2)
            {
                var rover = new MarsRover(instructions[deployLineCounter]);
                missionControl.DeployRover(rover, plateau);
            }
            if(MissionControl.CollisionInnerDetection(MissionControl._roverList!))
                CollisionMessages.CollisionMessageForSamePosition();
            else
            {
                var commandLineCounter = 2;
                var simpleCounter = 0;
                while (commandLineCounter < instructions.Count)
                {
                    missionControl.ExecuteCommand(simpleCounter,instructions[commandLineCounter]);
                    if (MissionControl.CollisionInnerDetection(MissionControl._roverList!))
                    {
                        CollisionMessages.CollisionMessageForDeploymentSecondRover();
                        break;
                    }
                    if (MissionControl.CollisionInnerDetection(MissionControl._roverList!))
                    {
                        CollisionMessages.CollisionMessageForSameDestination();
                        break;
                    }
                    commandLineCounter += 2;
                    simpleCounter++;
                }
                
                InstructionExample.BeepSoundForSuccess();
                var positions = new List<string?>();
                for(var printPositionCounter=0; printPositionCounter<MissionControl._roverList!.Count; printPositionCounter++)
                {
                    Console.Write("Rover " + (printPositionCounter+1) + " ");
                    MissionControl._roverList[printPositionCounter]?.GetCurrentPositionForConsole();
                    positions.Add(MissionControl._roverList[printPositionCounter]?.GetCurrentPositionForFile());
                }
                var writer = new WriteOnFile(readFile.directoryInfo + "\\Command\\FinalPosition.txt",positions);
                writer.Write();
                
                
                
                var drawTable= new DrawPlateau();
                await drawTable.LiveTable
                (
                    Convert.ToInt32(instructions[0]!.Split(' ')[0]),
                    Convert.ToInt32(instructions[0]!.Split(' ')[1]),
                    missionControl,
                    simpleCounter
                );
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
                Console.Write("\nEnter the number of Rovers: ");
                var roverCounter = Convert.ToInt32(Console.ReadLine()!);
                var roverCounterForTable=roverCounter;
                while (roverCounter>0)
                {
                    InstructionExample.InputExampleForDeploymentPosition();
                    UserInputs.GrabRoverPosition();
                
                    missionControl.DeployRover(UserInputs.userRover, UserInputs.userPlateau);
                
                    InstructionExample.InputExampleForInstructionFirstRover();
                    user.GrabMovementInstructions();

                    roverCounter--;
                }
                
                InstructionExample.ProgressBar();

                if(MissionControl.CollisionInnerDetection(MissionControl._roverList!))
                    CollisionMessages.CollisionMessageForSamePosition();
                else
                {
                    for(var commandCounter=0; commandCounter<user.userCommands!.Count; commandCounter++)
                    {
                        missionControl.ExecuteCommand(commandCounter,user.userCommands![commandCounter]);
                        if (MissionControl.CollisionInnerDetection(MissionControl._roverList!))
                        {
                            CollisionMessages.CollisionMessageForDeploymentSecondRover();
                            break;
                        }
                        if (MissionControl.CollisionInnerDetection(MissionControl._roverList!))
                        {
                            CollisionMessages.CollisionMessageForSameDestination();
                            break;
                        }
                    }
                    InstructionExample.BeepSoundForSuccess();

                    for(var printPositionCounter=0; printPositionCounter<MissionControl._roverList!.Count; printPositionCounter++)
                    {
                        Console.Write("\nRover " + (printPositionCounter+1) + " ");
                        MissionControl._roverList[printPositionCounter]?.GetCurrentPositionForConsole();
                    }
                    
                    var drawTable= new DrawPlateau();
                    await drawTable.LiveTable
                        (
                        UserInputs.userPlateau!.Lenght_X, 
                        UserInputs.userPlateau.Width_Y, 
                        missionControl,
                        roverCounterForTable
                        );

                    Console.WriteLine("\nPress any key to continue... or press \'q\' to exit");
                    if (Console.ReadKey().Key == ConsoleKey.Q)
                        Environment.Exit(0);
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