// See https://aka.ms/new-console-template for more information


using Mars_Rover_Project.Models.Mars;
using Mars_Rover_Project.Models.Validation;
Console.WriteLine("\n***Mars Rover Controller***\n");
while (true)
{
    
    try
    {
        
        Console.Write("Please enter plateau size (e.g \"5 5\"): ");
        var plateauSize = Console.ReadLine()!;
        var plateau = new MarsPlateau(plateauSize);
        Console.Write("Please enter rover deployment position (e.g \"1 2 N\"): ");
        var roverDeployment = Console.ReadLine()!;
        var rover = new MarsRover(roverDeployment);
        rover.SetPlateau(plateau);
        Console.Write("Please enter rover movement instructions (e.g \"LMLMLMLMM\"): ");
        var roverMovement = Console.ReadLine()!;
        rover.ExecuteCommand(roverMovement);
        rover.GetCurrentPosition();

    }
    catch (Exception ex)
    {
        Console.WriteLine("\n---> System Message: {0} <---" , ex.Message);
        Console.WriteLine("\nPress any key to continue... or press \'q\' to exit");
        if (Console.ReadKey().Key == ConsoleKey.Q)
             Environment.Exit(0);
    }
    
}