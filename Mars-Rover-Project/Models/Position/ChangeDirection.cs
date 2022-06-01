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
                marsRover.roverDirection+=3;
                break;
            case Direction.E:
                marsRover.roverDirection--;
                break;
            case Direction.S:
                marsRover.roverDirection--;
                break;
            case Direction.W:
                marsRover.roverDirection--;
                break;
        }
    }
    
    public void TurnRight(MarsRover marsRover)
    {
        switch (marsRover.GetDirection())
        {
            case Direction.N:
                marsRover.roverDirection++;
                break;
            case Direction.E:
                marsRover.roverDirection++;
                break;
            case Direction.S:
                marsRover.roverDirection++;
                break;
            case Direction.W:
                marsRover.roverDirection-=3;
                break;
        }
    }
    
    public void TurnAround(MarsRover marsRover)
    {
        switch (marsRover.GetDirection())
        {
            case Direction.N:
                marsRover.roverDirection += 2;
                break;
            case Direction.E:
                marsRover.roverDirection += 2;
                break;
            case Direction.S:
                marsRover.roverDirection += 2;
                break;
            case Direction.W:
                marsRover.roverDirection += 2;
                break;
        }
    }
}