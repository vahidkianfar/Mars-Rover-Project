using Mars_Rover_Project.Command;
using Mars_Rover_Project.Models.Mars;
using Mars_Rover_Project.Models.Position;
using Mars_Rover_Project.Models.UI;

Console.ForegroundColor = ConsoleColor.Blue;
Console.WriteLine("\n*** Rover Controller ***");
Console.ResetColor();
Console.WriteLine("\nPlease choose an option:\n");
Console.WriteLine("1. Put instructions into file (Read/Write)");
Console.WriteLine("2. Put instructions into console (manually)");
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
            Console.Write("Do you want to edit the instructions file? (y/n): ");
            var edit = Console.ReadLine()!;
            if (edit.ToLower() == "y")
            {
                var openFile = new ReadFromFile();
                var userInstructions = new List<string>();
                Console.Write("\nHow many Rover do you want to add? ");
                var numberOfRover = int.Parse(Console.ReadLine()!);
                
                Console.WriteLine("\nPlease enter the Plateau size and Instructions:\n");
                for(var instructionCounter=0; instructionCounter<numberOfRover*2+1; instructionCounter++)
                    userInstructions.Add(Console.ReadLine()!);

                File.WriteAllLines(openFile.directoryInfo + "\\Command\\Instructions.txt",userInstructions);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nNew instructions have been saved to file.");
                Console.ResetColor();
            }
            UserGuideline.ProgressBar();
            var readFile = new ReadFromFile();
            var lines = readFile.Read();
            var instructions = lines.ToList();
            var plateau = new MarsPlateau(instructions[0]);
            for(var deployLineCounter = 1; deployLineCounter < instructions.Count; deployLineCounter+=2)
            {
                var rover = new MarsRover(instructions[deployLineCounter]);
                missionControl.DeployRover(rover, plateau);
            }
            //**** I Assumed that the rovers are deployed and moved one by one.****
            //But I create CollisionDetection for Same Deployment Position (JUST IN CASE)
            
            /* if(MissionControl.CollisionInnerDetection(MissionControl._roverList!))
                 CollisionMessages.CollisionMessageForSamePosition();
             else
              */
                var commandLineCounter = 2;
                var simpleCounter = 0;
                while (commandLineCounter < instructions.Count)
                {
                    missionControl.ExecuteCommand(simpleCounter,instructions[commandLineCounter]);
                    /* if (MissionControl.CollisionInnerDetection(MissionControl._roverList!))
                         {
                             CollisionMessages.CollisionMessageForDeploymentOtherRovers();
                             break;
                        }*/
                    if (MissionControl.CollisionInnerDetection(MissionControl._roverList!))
                    {
                        CollisionMessages.CollisionMessageForSameDestination();
                    }
                    commandLineCounter += 2;
                    simpleCounter++;
                }
                
                UserGuideline.BeepSoundForSuccess();
                var positions = new List<string?>();
                for(var printPositionCounter=0; printPositionCounter<MissionControl._roverList!.Count; printPositionCounter++)
                {
                    Console.Write("Rover " + (printPositionCounter+1) + " ");
                    MissionControl._roverList[printPositionCounter]?.GetCurrentPositionForConsole();
                    positions.Add(MissionControl._roverList[printPositionCounter]?.GetCurrentPositionForFile());
                }
                var writer = new WriteOnFile(readFile.directoryInfo + "\\Command\\FinalPosition.txt",positions);
                writer.Write();
                
                var drawTable= new DrawPlateauAndRovers();
                await drawTable.LiveTable
                (
                    Convert.ToInt32(instructions[0]!.Split(' ')[0]),
                    Convert.ToInt32(instructions[0]!.Split(' ')[1]),
                    missionControl,
                    simpleCounter
                );
        }
        catch (Exception ex)
        {
            UserGuideline.BeepSoundForError();
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
                UserGuideline.InputExampleForPlateauSize();
                UserInputs.GrabPlateauSizeFromUser();
                Console.Write("\nEnter the number of Rovers: ");
                var roverCounter = Convert.ToInt32(Console.ReadLine()!);
                var roverCounterForTable=roverCounter;
                Console.WriteLine();
                while (roverCounter>0)
                {
                    UserGuideline.InputExampleForDeploymentPosition();
                    UserInputs.GrabRoverPositionFromUser();
                
                    missionControl.DeployRover(UserInputs.userRover, UserInputs.userPlateau);
                
                    UserGuideline.InputExampleForInstructionFirstRover();
                    user.GrabMovementInstructionsFromUser();

                    roverCounter--;
                }
                
                UserGuideline.ProgressBar();
                
                //**** I Assumed that the rovers are deployed and moved one by one.****
                //But I create CollisionDetection for Same Deployment Position (JUST IN CASE)

                /* if(MissionControl.CollisionInnerDetection(MissionControl._roverList!))
                //     CollisionMessages.CollisionMessageForSamePosition();
                else*/
                
                for(var commandCounter=0; commandCounter<user.userCommands!.Count; commandCounter++)
                {
                    missionControl.ExecuteCommand(commandCounter,user.userCommands![commandCounter]);
                        /* if (MissionControl.CollisionInnerDetection(MissionControl._roverList!))
                         {
                             CollisionMessages.CollisionMessageForDeploymentOtherRovers();
                             break;
                         }*/
                    if (MissionControl.CollisionInnerDetection(MissionControl._roverList!)) 
                        CollisionMessages.CollisionMessageForSameDestination();
                
                }
                UserGuideline.BeepSoundForSuccess();

                for(var printPositionCounter=0; printPositionCounter<MissionControl._roverList!.Count; printPositionCounter++)
                {
                    Console.Write("\nRover " + (printPositionCounter+1) + " ");
                    MissionControl._roverList[printPositionCounter]?.GetCurrentPositionForConsole();
                }
                    
                var drawTable= new DrawPlateauAndRovers();
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
            
            catch (Exception ex)
            {
                UserGuideline.BeepSoundForError();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nSystem Message:--> {0} <--", ex.Message);
                Console.ResetColor();
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