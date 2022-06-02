using Mars_Rover_Project.Models.General_Interfaces;
using Mars_Rover_Project.Models.Position;
using Mars_Rover_Project.Models.Validation;

namespace Mars_Rover_Project.Models.Mars;

public class MissionControl
{
    public bool IsMissionComplete { get; set; }
    public static List<IVehicle?>? Rover;
    public static MarsPlateau? Plateau { get; set; }

    public MissionControl()=>Rover = new List<IVehicle?>();
    
    public static bool CollisionDetection(MarsRover? rover1, MarsRover? rover2) =>
        rover2 != null && rover1 != null && rover1.GetAxisX() == rover2.GetAxisX() 
        && rover1.GetAxisY() == rover2.GetAxisY();
    public void DeployRover(MarsRover? rover, MarsPlateau? marsPlateau)
    {
        if (rover != null && !Validator.DeploymentPositionValidator(rover.GetAxisX(), rover.GetAxisY(), marsPlateau))
            throw new ArgumentException("Deployment Positions are not Valid");
        Plateau = marsPlateau;
        Rover?.Add(rover);
    }
    public static MarsPlateau? GetMarsPlateauDetails()=>Plateau;
    public IVehicle? GetMarsRoverDetails(int roverNumber) => Rover?[roverNumber];
    public void TurnLeft(int roverNumber)=>Rover?[roverNumber].TurnLeft();
    public void TurnRight(int roverNumber)=>Rover?[roverNumber].TurnRight();
    public void TurnAround(int roverNumber)=>Rover?[roverNumber].TurnAround();
    public void Move(int roverNumber)=>Rover?[roverNumber].Move();
    public void ExecuteCommand(int roverNumber, string getMovement)=>Rover?[roverNumber].ExecuteCommand(getMovement);
}