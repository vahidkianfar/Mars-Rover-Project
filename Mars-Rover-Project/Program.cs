using Mars_Rover_Project.Command;
using Mars_Rover_Project.Models.Mars;
using Mars_Rover_Project.Models.Position;
using Mars_Rover_Project.Models.UI;
using static System.Console;

ForegroundColor = ConsoleColor.Blue;
WriteLine("\n*** Rover Controller ***");
ResetColor();
WriteLine("\nPlease choose an option:\n");
WriteLine("1. Put instructions into file (Read/Write)");
WriteLine("2. Put instructions into console (manually)");
Write("\nEnter your choice: ");

if(int.TryParse(ReadLine(), out var choice))

    switch (choice)
{
    case 1:
    {
        try
        {
            //Instruction text file is in Project folder --> ...\Command\Instructions.text
            
            
            Write("Do you want to edit the instructions file? (y/n): ");
            var edit = ReadLine()!;
            
            if (edit.ToLower() == "y") 
                GetInstructionsSaveOnFile();
            
            UserGuideline.ProgressBar();
            var missionControl = new MissionControl();
            var readFile = new ReadFromFile();
            var lines = readFile.Read();
            var instructions = lines.ToList();
            
            
            DeployTheRovers(instructions, missionControl);
            //**** I Assumed that the rovers are deployed and moved one by one.****
            //But I create CollisionDetection for Same Deployment Position (JUST IN CASE)
            
            /* if(MissionControl.CollisionInnerDetection(MissionControl.roverList!))
                 CollisionMessages.CollisionMessageForSamePosition();
             else
              */
            var roverCounterFromFile= ExecuteInstructions(instructions, missionControl);
            if (MissionControl.CollisionInnerDetection(MissionControl.roverList!))
                CollisionMessages.CollisionMessageForSameDestination();
            
            UserGuideline.BeepSoundForSuccess();
            
            PrintPositionsAndWriteOnOutputFile(readFile);
            
            var drawTable= new DrawPlateauAndRovers(); 
            await drawTable.LiveTable
                (
                Convert.ToInt32(instructions[0]!.Split(' ')[0]),
                Convert.ToInt32(instructions[0]!.Split(' ')[1]), 
                missionControl, 
                roverCounterFromFile
                );
        }
        catch (Exception ex)
        {
            UserGuideline.BeepSoundForError();
            ForegroundColor = ConsoleColor.Red;
            WriteLine("\nSystem Message:--> {0} <--", ex.Message);
            ForegroundColor = ConsoleColor.White;
           
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
                Write("\nHow many Rover do you want to add? ");
                
                var roverCounter = Convert.ToInt32(ReadLine()!);
                if (roverCounter < 1 || roverCounter >= UserInputs.userPlateau?.Lenght_X * UserInputs.userPlateau?.Width_Y)
                    throw new ArgumentException("Number of Rovers cannot be more than Plateau's Blocks or less than 1");
                
                var roverCounterForTable=roverCounter;
                WriteLine();
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
                //But I created CollisionDetection for Same Deployment Position (JUST IN CASE)

                /* if(MissionControl.CollisionInnerDetection(MissionControl.roverList!))
                //     CollisionMessages.CollisionMessageForSamePosition();
                else*/
                
                for(var commandCounter=0; commandCounter<user.userCommands!.Count; commandCounter++)
                {
                    missionControl.ExecuteCommand(commandCounter,user.userCommands![commandCounter]);
                        /* if (MissionControl.CollisionInnerDetection(MissionControl.roverList!))
                         {
                             CollisionMessages.CollisionMessageForDeploymentOtherRovers();
                             break;
                         }*/
                }
                if (MissionControl.CollisionInnerDetection(MissionControl.roverList!)) 
                    CollisionMessages.CollisionMessageForSameDestination();
                
                UserGuideline.BeepSoundForSuccess();

                for(var printPositionCounter=0; printPositionCounter<MissionControl.roverList!.Count; printPositionCounter++)
                {
                    Write("\nRover " + (printPositionCounter+1) + " ");
                    MissionControl.roverList[printPositionCounter]?.GetCurrentPositionForConsole();
                }
                    
                var drawTable= new DrawPlateauAndRovers();
                await drawTable.LiveTable
                    (
                    UserInputs.userPlateau!.Lenght_X, 
                    UserInputs.userPlateau.Width_Y, 
                    missionControl,
                    roverCounterForTable
                    );

                WriteLine("\nPress any key to continue... or press \'q\' to exit");
                if (ReadKey().Key == ConsoleKey.Q)
                    Environment.Exit(0);
            }
            
            catch (Exception ex)
            {
                UserGuideline.BeepSoundForError();
                ForegroundColor = ConsoleColor.Red;
                WriteLine("\nSystem Message:--> {0} <--", ex.Message);
                ResetColor();
                WriteLine("\nPress any key to continue... or press \'q\' to exit");
                if (ReadKey().Key == ConsoleKey.Q)
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
                WriteLine("Invalid choice, please enter a valid number");
            }
            break;
}
else
{
    WriteLine("Invalid choice, please enter a valid number");
}

void GetInstructionsSaveOnFile()
{
    var openFile = new ReadFromFile();
    var userInstructions = new List<string>();
    Write("\nHow many Rover do you want to add? ");
    var numberOfRover = int.Parse(ReadLine()!);
    if (numberOfRover < 1)
        throw new ArgumentException("Number of Rovers cannot be more than Plateau's Blocks or less than One");
    WriteLine("\nPlease enter the Plateau size and Instructions:\n");
    for(var instructionCounter=0; instructionCounter<numberOfRover*2+1; instructionCounter++)
        userInstructions.Add(ReadLine()!);

    File.WriteAllLines(openFile.directoryInfo + "\\Command\\Instructions.txt",userInstructions);
    ForegroundColor = ConsoleColor.Green;
    WriteLine("\nNew instructions have been saved to file.");
    ResetColor();
}

void DeployTheRovers(List<string?> instructions, MissionControl missionControl)
{
    var plateau = new MarsPlateau(instructions[0]);
    for(var deployLineCounter = 1; deployLineCounter < instructions.Count; deployLineCounter+=2)
    {
        var rover = new MarsRover(instructions[deployLineCounter]);
        missionControl.DeployRover(rover, plateau);
    }
}

int ExecuteInstructions(List<string?> instructions, MissionControl missionControl)
{
    var simpleCounter = 0;
    var commandLineCounter = 2;
    while (commandLineCounter < instructions.Count)
    {
        missionControl.ExecuteCommand(simpleCounter,instructions[commandLineCounter]);
        /* if (MissionControl.CollisionInnerDetection(MissionControl.roverList!))
             {
                 CollisionMessages.CollisionMessageForDeploymentOtherRovers();
                 break;
            }*/
                    
        commandLineCounter += 2;
        simpleCounter++;
    }

    return simpleCounter;
}

void PrintPositionsAndWriteOnOutputFile(ReadFromFile readFile)
{
    var positions = new List<string>(); 
    for(var printPositionCounter=0; printPositionCounter<MissionControl.roverList!.Count; printPositionCounter++) 
    { 
        Write("Rover " + (printPositionCounter+1) + " "); 
        MissionControl.roverList[printPositionCounter]?.GetCurrentPositionForConsole(); 
        positions.Add(MissionControl.roverList[printPositionCounter]!.GetCurrentPositionForFile());
    } 
    var writer = new WriteOnFile(readFile.directoryInfo + "\\Command\\FinalPosition.txt",positions); 
    writer.Write();
}