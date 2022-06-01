using Mars_Rover_Project.Models.Mars;
namespace Mars_Rover_Project.Models.Position;

public class ChangeDirection
{
    public enum Direction
    {
        N=1,
        E,
        S,
        W
    } 
    public void TurnLeft(MarsRover marsRover)
    {
        switch (marsRover.GetDirection())
        {
            case Direction.N:
                marsRover._direction+=3;
                break;
            case Direction.E:
                marsRover._direction--;
                break;
            case Direction.S:
                marsRover._direction--;
                break;
            case Direction.W:
                marsRover._direction--;
                break;
        }
    }
    
    public void TurnRight(MarsRover marsRover)
    {
        switch (marsRover.GetDirection())
        {
            case Direction.N:
                marsRover._direction++;
                break;
            case Direction.E:
                marsRover._direction++;
                break;
            case Direction.S:
                marsRover._direction++;
                break;
            case Direction.W:
                marsRover._direction-=3;
                break;
        }
    }
    
    public void TurnAround(MarsRover marsRover)
    {
        switch (marsRover.GetDirection())
        {
            case Direction.N:
                marsRover._direction += 2;
                break;
            case Direction.E:
                marsRover._direction += 2;
                break;
            case Direction.S:
                marsRover._direction += 2;
                break;
            case Direction.W:
                marsRover._direction += 2;
                break;
        }
    }
}