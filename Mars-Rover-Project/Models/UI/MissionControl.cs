using Mars_Rover_Project.Models.General_Interfaces;
using Mars_Rover_Project.Models.Mars;
using Mars_Rover_Project.Models.Validation;

namespace Mars_Rover_Project.Models.UI;

public class MissionControl
{
    public bool IsMissionComplete { get; set; }
    private static List<IVehicle?>? _roverList;
    public static ISurface? Plateau { get; set; }

    public MissionControl()=>_roverList = new List<IVehicle?>();
    
    public static bool CollisionDetection(IVehicle? rover1, IVehicle? rover2) =>
        rover2 != null && rover1 != null && rover1.GetAxisX() == rover2.GetAxisX() 
        && rover1.GetAxisY() == rover2.GetAxisY();
    
    public void DeployRover(IVehicle? rover, ISurface? marsPlateau)
    {
        if (rover != null && !Validator.DeploymentPositionValidator(rover.GetAxisX(), rover.GetAxisY(), marsPlateau))
            throw new ArgumentException("Deployment Positions are not Valid");
        Plateau = marsPlateau;
        _roverList?.Add(rover);
    }
    public static ISurface? GetPlateauDetails()=>Plateau;
    public IVehicle? GetRoverDetails(int roverNumber) => _roverList?[roverNumber];
    public void TurnLeft(int roverNumber)=>_roverList?[roverNumber]?.TurnLeft();
    public void TurnRight(int roverNumber)=>_roverList?[roverNumber]?.TurnRight();
    public void TurnAround(int roverNumber)=>_roverList?[roverNumber]?.TurnAround();
    public void Move(int roverNumber)=>_roverList?[roverNumber]?.Move();
    public void ExecuteCommand(int roverNumber, string? getMovement)=>_roverList?[roverNumber]?.ExecuteCommand(getMovement?.ToUpper());
}