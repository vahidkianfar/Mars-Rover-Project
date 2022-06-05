using Mars_Rover_Project.Command;
using Mars_Rover_Project.Models.Mars;
using Mars_Rover_Project.Models.Position;
using Mars_Rover_Project.Models.UI;
using Mars_Rover_Project.Models.Validation;
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
            
            if (!File.Exists(readFile.directoryInfo + "\\Command\\Instructions.txt"))
            {
                ForegroundColor = ConsoleColor.Yellow;
                WriteLine("Instruction File doesn't exist, you need to create it for the first time");
                ForegroundColor = ConsoleColor.Green;
                WriteLine("Creating the Instructions File...!");
                ResetColor();
                GetInstructionsSaveOnFile();
            }
            
            var lines = readFile.Read();
            var instructions = lines.ToList();
            DeployTheRoversForFile(instructions, missionControl);
            var roverCounterFromFile= ExecuteInstructionsForFile(instructions, missionControl);
            UserGuideline.BeepSoundForSuccess();
            PrintPositionsAndWriteOnOutputFile(readFile, missionControl);
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
                if(Validator.NumberOfRoversValidator(roverCounter, UserInputs.userPlateau!.Lenght_X * UserInputs.userPlateau.Width_Y))
                             throw new ArgumentException("Number of Rovers cannot be more than Plateau's Blocks or less than 1");
                var roverCounterForTable=roverCounter;
                WriteLine();
                DeployTheRovers(roverCounter, missionControl, user);
                UserGuideline.ProgressBar();
                ExecuteInstructions(missionControl,user);
                UserGuideline.BeepSoundForSuccess();
                PrintPositions(missionControl);
                var drawTable= new DrawPlateauAndRovers();
                
                await drawTable.LiveTable
                    (
                    UserInputs.userPlateau.Lenght_X, 
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

void DeployTheRoversForFile(List<string?> instructions, MissionControl missionControl)
{
    var plateau = new MarsPlateau(instructions[0]);
    for(var deployLineCounter = 1; deployLineCounter < instructions.Count; deployLineCounter+=2)
    {
        var rover = new MarsRover(instructions[deployLineCounter]);
        missionControl.DeployRover(rover, plateau);
    }
}

int ExecuteInstructionsForFile(List<string?> instructions, MissionControl missionControl)
{
    var simpleCounter = 0;
    var commandLineCounter = 2;
    while (commandLineCounter < instructions.Count)
    {
        missionControl.ExecuteCommand(simpleCounter,instructions[commandLineCounter]);
        /* if (MissionControl.CollisionInnerDetection(MissionControl.RoverList!))
             {
                 CollisionMessages.CollisionMessageForDeploymentOtherRovers();
                 break;
            }*/
                    
        commandLineCounter += 2;
        simpleCounter++;
    }
    if (missionControl.CollisionInnerDetection(missionControl.RoverList!))
        CollisionMessages.CollisionMessageForSameDestination();
    return simpleCounter;
}

void PrintPositionsAndWriteOnOutputFile(ReadFromFile readFile, MissionControl missionControl)
{
    var positions = new List<string>(); 
    for(var printPositionCounter=0; printPositionCounter<missionControl.RoverList!.Count; printPositionCounter++) 
    { 
        Write("Rover " + (printPositionCounter+1) + " "); 
        missionControl.RoverList[printPositionCounter]?.GetCurrentPositionForConsole(); 
        positions.Add(missionControl.RoverList[printPositionCounter]!.GetCurrentPositionForFile());
    } 
    var writer = new WriteOnFile(readFile.directoryInfo + "\\Command\\FinalPosition.txt",positions); 
    writer.Write();
}

void DeployTheRovers(int roverCounter, MissionControl missionControl, UserInputs user)
{
    while (roverCounter>0)
    {
        UserGuideline.InputExampleForDeploymentPosition();
        UserInputs.GrabRoverPositionFromUser();
        missionControl.DeployRover(UserInputs.userRover, UserInputs.userPlateau);
        UserGuideline.InputExampleForInstructionFirstRover();
        user.GrabMovementInstructionsFromUser();

        roverCounter--;
    }
}

void ExecuteInstructions(MissionControl missionControl,UserInputs user)
{
    for(var commandCounter=0; commandCounter<user.userCommands!.Count; commandCounter++)
    {
        missionControl.ExecuteCommand(commandCounter,user.userCommands![commandCounter]);
        /* if (MissionControl.CollisionInnerDetection(MissionControl.RoverList!))
         {
             CollisionMessages.CollisionMessageForDeploymentOtherRovers();
             break;
         }*/
    }
    if (missionControl.CollisionInnerDetection(missionControl.RoverList!)) 
        CollisionMessages.CollisionMessageForSameDestination();
}

void PrintPositions(MissionControl missionControl)
{
    for(var printPositionCounter=0; printPositionCounter<missionControl.RoverList!.Count; printPositionCounter++)
    {
        Write("Rover " + (printPositionCounter+1) + " ");
        missionControl.RoverList[printPositionCounter]?.GetCurrentPositionForConsole();
    }
}