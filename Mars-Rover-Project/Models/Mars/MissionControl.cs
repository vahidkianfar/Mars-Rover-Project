namespace Mars_Rover_Project.Models.Mars;

public class MissionControl
{
    public bool IsMissionComplete { get; set; }
    public MarsRover Rover { get; set; }
    public MarsPlateau Plateau { get; set; }
    public string MissionInstructions { get; set; }


    public static bool CollisionDetected(MarsRover rover1, MarsRover rover2) =>
        rover1.GetAxisX() == rover2.GetAxisX() && rover1.GetAxisY() == rover2.GetAxisY();
}