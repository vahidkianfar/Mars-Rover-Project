using Mars_Rover_Project.Models.General_Interfaces;
using Mars_Rover_Project.Models.Validation;

namespace Mars_Rover_Project.Models.UI;

public class MissionControl
{
    public bool IsMissionComplete { get; set; }
    public static List<IVehicle?>? roverList;
    public static ISurface? Plateau { get; set; }
    public MissionControl()=>roverList = new List<IVehicle?>();
    public static ISurface? GetPlateauDetails()=>Plateau;
    public IVehicle? GetRoverDetails(int roverNumber) => roverList?[roverNumber];
    public void ExecuteCommand(int roverNumber, string? getMovement)=>roverList?[roverNumber]?.ExecuteCommand(getMovement);
    public void DeployRover(IVehicle? rover, ISurface? marsPlateau)
    {
        if (rover != null && !Validator.DeploymentPositionValidator(rover.GetAxisX(), rover.GetAxisY(), marsPlateau))
            throw new ArgumentException("Deployment Positions are not Valid");
        Plateau = marsPlateau;
        roverList?.Add(rover);
    }
    
    public static bool CollisionInnerDetection(List<IVehicle> rovers)
    {
        for (var firstCounter = 0; firstCounter < rovers.Count; firstCounter++)
        {
            for (var secondCounter = firstCounter + 1; secondCounter < rovers.Count; secondCounter++)
            {
                if (CollisionDetection(rovers[firstCounter], rovers[secondCounter]))
                {
                    return true;
                }
            }
        }
        return false;
    }
    private static bool CollisionDetection(IVehicle? rover1, IVehicle? rover2) => rover1!.GetAxisX() == rover2!.GetAxisX() 
        && rover1.GetAxisY() == rover2.GetAxisY();
}