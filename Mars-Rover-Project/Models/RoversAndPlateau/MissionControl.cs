using Mars_Rover_Project.Models.General_Interfaces;
using Mars_Rover_Project.Models.Validation;

namespace Mars_Rover_Project.Models.RoversAndPlateau;

public class MissionControl
{
    public bool IsMissionComplete { get; set; }
    public List<IVehicle?>? RoverList;
    public static ISurface? Plateau { get; set; }
    public MissionControl()=>RoverList = new List<IVehicle?>();
    public static ISurface? GetPlateauDetails()=> Plateau;
    public IVehicle? GetRoverDetails(int roverNumber)=> RoverList?[roverNumber];

    public void ExecuteCommand(int roverNumber, string? getMovement) =>
        RoverList?[roverNumber]?.ExecuteCommand(getMovement);
    
    public void DeployRover(IVehicle? rover, ISurface? marsPlateau)
    {
        if (rover != null && !Validator.DeploymentPositionValidator(rover.GetAxisX(), rover.GetAxisY(), marsPlateau))
            throw new ArgumentException("Deployment Positions are not Valid");
        
        Plateau = marsPlateau;
        RoverList?.Add(rover);
        CheckNumberOfRoversOnSpecificPlateau(RoverList);
    }
    
    public bool CollisionInnerDetection(List<IVehicle> rovers)
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

    private void CheckNumberOfRoversOnSpecificPlateau(List<IVehicle?>? roverList)
    {
        if (roverList?.Count > Plateau?.Lenght_X * Plateau?.Width_Y || roverList?.Count < 1)
            throw new ArgumentException("Number of Rovers on Plateau is greater than the number of available positions");
    }
}