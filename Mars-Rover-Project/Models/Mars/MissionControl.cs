using Mars_Rover_Project.Models.Validation;

namespace Mars_Rover_Project.Models.Mars;

public class MissionControl
{
    public bool IsMissionComplete { get; set; }
    public static MarsRover Rover { get; set; }
    public static MarsPlateau Plateau { get; set; }
    
    public MissionControl(MarsRover rover, MarsPlateau plateau)
    {
        Rover = rover;
        Plateau = plateau;
    }

    public static bool CollisionDetection(MarsRover rover1, MarsRover rover2) =>
        rover1.GetAxisX() == rover2.GetAxisX() && rover1.GetAxisY() == rover2.GetAxisY();
    
    public void DeployRover(MarsRover rover, MarsPlateau plateau)
    {
        Rover = rover;
        Plateau = plateau;
    }
    
    public void SetMissionPlateau(MarsRover rover, MarsPlateau marsPlateau)
    {
        if (!Validator.DeploymentPositionValidator(rover.GetAxisX(), rover.GetAxisY(), marsPlateau))
            throw new ArgumentException("Deployment Positions are not Valid");
        Plateau = marsPlateau;
    }
    public static MarsPlateau GetMarsPlateau()=>Plateau;
    
}