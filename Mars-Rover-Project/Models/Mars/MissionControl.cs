using Mars_Rover_Project.Models.Position;
using Mars_Rover_Project.Models.Validation;

namespace Mars_Rover_Project.Models.Mars;

public class MissionControl
{
    public bool IsMissionComplete { get; set; }
    public static MarsRover? Rover { get; set; }
    public static MarsPlateau? Plateau { get; set; }
    public ChangeDirection.Direction roverDirection { get; set; }
    private MovingTheRover _movingTheRover { get; set; }
    
    public MissionControl()
    {
        //Rover = rover;
        //Plateau = plateau;
        _movingTheRover = new MovingTheRover();
    }
    public static bool CollisionDetection(MarsRover? rover1, MarsRover? rover2) =>
        rover2 != null && rover1 != null && rover1.GetAxisX() == rover2.GetAxisX() && rover1.GetAxisY() == rover2.GetAxisY();
    public void DeployRover(MarsRover? rover, MarsPlateau? marsPlateau)
    {
        if (rover != null && !Validator.DeploymentPositionValidator(rover.GetAxisX(), rover.GetAxisY(), marsPlateau))
            throw new ArgumentException("Deployment Positions are not Valid");
        Plateau = marsPlateau;
        Rover = rover;
    }
    public static MarsPlateau? GetMarsPlateauDetails()=>Plateau;
    public static MarsRover? GetMarsRoverDetails()=>Rover;
    public void TurnLeft()=>Rover!.TurnLeft();
    public void TurnRight()=>Rover!.TurnRight();
    public void TurnAround()=>Rover!.TurnAround();
    public void Move()=>Rover!.Move();
    public void ExecuteCommand(string getMovement)=>Rover!.ExecuteCommand(getMovement);
}