using Mars_Rover_Project.Models.General_Interfaces;
using Mars_Rover_Project.Models.Mars;
using Mars_Rover_Project.Models.Validation;

namespace Mars_Rover_Project.Models.UI;

public class MissionControl
{
    public bool IsMissionComplete { get; set; }
    private static List<IVehicle?>? Rover;
    public static ISurface? Plateau { get; set; }

    public MissionControl()=>Rover = new List<IVehicle?>();
    
    public static bool CollisionDetection(IVehicle? rover1, IVehicle? rover2) =>
        rover2 != null && rover1 != null && rover1.GetAxisX() == rover2.GetAxisX() 
        && rover1.GetAxisY() == rover2.GetAxisY();
    
    public void DeployRover(IVehicle? rover, MarsPlateau? marsPlateau)
    {
        if (rover != null && !Validator.DeploymentPositionValidator(rover.GetAxisX(), rover.GetAxisY(), marsPlateau))
            throw new ArgumentException("Deployment Positions are not Valid");
        Plateau = marsPlateau;
        Rover?.Add(rover);
    }
    public static ISurface? GetPlateauDetails()=>Plateau;
    public IVehicle? GetRoverDetails(int roverNumber) => Rover?[roverNumber];
    public void TurnLeft(int roverNumber)=>Rover?[roverNumber]?.TurnLeft();
    public void TurnRight(int roverNumber)=>Rover?[roverNumber]?.TurnRight();
    public void TurnAround(int roverNumber)=>Rover?[roverNumber]?.TurnAround();
    public void Move(int roverNumber)=>Rover?[roverNumber]?.Move();
    public void ExecuteCommand(int roverNumber, string getMovement)=>Rover?[roverNumber]?.ExecuteCommand(getMovement);
}