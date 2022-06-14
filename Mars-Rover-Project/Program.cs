using Mars_Rover_Project.Models.ReadWriteFiles;
using Mars_Rover_Project.Models.RoversAndPlateau;
using Mars_Rover_Project.Models.UI;
using Mars_Rover_Project.Models.Validation;
using static System.Console;
StartMenu:
var selectInstructionOption = ConsoleHelper.MultipleChoice(true, "1. Put instructions into file (Read/Write)",
    "2. Put instructions into console (manually)", "3. Exit");
ForegroundColor = ConsoleColor.Blue;

while (true)
{
    switch (selectInstructionOption)
    {
        case 0:
        {
            try
            {
                
                /*
                 Hi Everyone,
                     NOT a good idea to use Try/Catch and Hardcoded menu here (I didn't have enough time, but I will change it)
                    :D (good old Yahoo Messenger Emoticons)
                     I Know my main menu is a mess.
                */
                
                //Instruction text file is in Project folder --> ...\Command\Instructions.text
                ForegroundColor = ConsoleColor.DarkYellow;
                Write(RoverBanner.Design);
                ResetColor();
                ForegroundColor = ConsoleColor.DarkCyan;
                Write("\nDo you want to edit the instructions file? (y/n): ");
                var edit = ReadLine()!;

                if (edit.ToLower() == "y")
                    GetInstructionsSaveOnFile();

                UserGuideline.ProgressBar();
                var missionControl = new MissionControl();
                var readFile = new ReadFromFile();

                if (!File.Exists(readFile.DirectoryInfo + "\\Command\\Instructions.txt"))
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
                var roverCounterFromFile = ExecuteInstructionsForFile(instructions, missionControl);
                UserGuideline.BeepSoundForSuccess();
                PrintPositionsAndWriteOnOutputFile(readFile, missionControl);
                var drawTable = new DrawPlateauAndRovers();

                await drawTable.LiveTable
                (
                    Convert.ToInt32(instructions[0]!.Split(' ')[0]),
                    Convert.ToInt32(instructions[0]!.Split(' ')[1]),
                    missionControl,
                    roverCounterFromFile
                );
                WriteLine("\nPress any key to back to Main Menu... or press \'q\' to exit");
                if (ReadKey().Key == ConsoleKey.Q)
                    Environment.Exit(0);
                goto StartMenu; // OLD SCHOOL PASCAL-C-STYLE GOTO (it's a BAD idea to use it)
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
        case 1:
        {
            try
            {
                    var missionControl = new MissionControl();
                    var user = new UserInputs();
                    UserInputs.GrabPlateauSizeFromUser();
                    Write("\nHow many Rover do you want to add? ");
                    var roverCounter = Convert.ToInt32(ReadLine()!);
                    if (Validator.NumberOfRoversValidator(roverCounter,
                            UserInputs.userPlateau!.Lenght_X * UserInputs.userPlateau.Width_Y))
                        throw new ArgumentException(
                            "Number of Rovers cannot be more than Plateau's Blocks or less than 1");
                    var roverCounterForTable = roverCounter;
                    DeployTheRovers(roverCounter, missionControl, user);
                    UserGuideline.ProgressBar();
                    ExecuteInstructions(missionControl, user);
                    UserGuideline.BeepSoundForSuccess();
                    PrintPositions(missionControl);
                    var drawTable = new DrawPlateauAndRovers();

                    await drawTable.LiveTable
                    (
                        UserInputs.userPlateau.Lenght_X,
                        UserInputs.userPlateau.Width_Y,
                        missionControl,
                        roverCounterForTable
                    );

                    DeployRovers:
                    ForegroundColor = ConsoleColor.Blue;
                    Write("\nDo you want to deploy another rover? (y/n) ");
                    var deployRover = ReadLine()!;
                    if (deployRover.ToLower() == "y")
                    {
                        roverCounterForTable++;
                        await DeployLastRover(roverCounterForTable, missionControl, user);
                        goto DeployRovers;
                    }
                        
                    WriteLine("\nPress any key to back to Main Menu... or press \'q\' to exit");
                    if (ReadKey().Key == ConsoleKey.Q)
                        Environment.Exit(0);
                    goto StartMenu;
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
            //}
            break;
        }
        case 2:
            WriteLine(RoverBanner.GoodbyeMessage);
            Environment.Exit(0);
            break;

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

    File.WriteAllLines(openFile.DirectoryInfo + "\\Command\\Instructions.txt",userInstructions);
    ForegroundColor = ConsoleColor.Green;
    WriteLine("\nNew instructions have been saved to file.");
    ResetColor();
}

void DeployTheRoversForFile(List<string?> instructions, MissionControl missionControl)
{
    var plateau = new RectangularPlateau(instructions[0]);
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
    var writer = new WriteOnFile(readFile.DirectoryInfo + "\\Command\\FinalPosition.txt",positions); 
    writer.Write();
}

void DeployTheRovers(int roverCounter, MissionControl missionControl, UserInputs user)
{
    while (roverCounter>0)
    {
        UserGuideline.InputExampleForDeploymentPosition();
        UserInputs.GrabRoverPositionFromUser();
        missionControl.DeployRover(UserInputs.userRover, UserInputs.userPlateau);
        if (missionControl.CollisionInnerDetection(missionControl.RoverList!))
            CollisionMessages.CollisionMessageForDeploymentOtherRovers();
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
        WriteLine();
        Write("Rover " + (printPositionCounter+1) + " ");
        missionControl.RoverList[printPositionCounter]?.GetCurrentPositionForConsole();
    }
}
void ExecuteInstructionsForLastRover(MissionControl missionControl,UserInputs user)
{
    missionControl.ExecuteCommand(missionControl.RoverList!.Count-1,user.userCommands![user.userCommands.Count-1]);
    if (missionControl.CollisionInnerDetection(missionControl.RoverList!)) 
        CollisionMessages.CollisionMessageForSameDestination();
}

async Task DeployLastRover(int roverCounterForTable, MissionControl missionControl, UserInputs user)
{
    DeployTheRovers(1, missionControl, user);
    UserGuideline.ProgressBar();
    ExecuteInstructionsForLastRover(missionControl,user);
    UserGuideline.BeepSoundForSuccess();
    PrintPositions(missionControl);
    var drawTable1= new DrawPlateauAndRovers();
                
    await drawTable1.LiveTable
    (
        UserInputs.userPlateau!.Lenght_X, 
        UserInputs.userPlateau.Width_Y, 
        missionControl,
        roverCounterForTable
    );
}