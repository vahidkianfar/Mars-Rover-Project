using Mars_Rover_Project.Models.General_Interfaces;

namespace Mars_Rover_Project.Models.PositionAndMovement;

public class ChangeDirection
{
    public enum Direction
    {
        N=1,
        E,
        S,
        W
    } 
    public static void TurnLeft(IVehicle rover)
    {
        switch (rover.GetDirection())
        {
            case Direction.N:
                rover.roverDirection+=3;
                break;
            case Direction.E:
                rover.roverDirection--;
                break;
            case Direction.S:
                rover.roverDirection--;
                break;
            case Direction.W:
                rover.roverDirection--;
                break;
        }
    }
    
    public static void TurnRight(IVehicle rover)
    {
        switch (rover.GetDirection())
        {
            case Direction.N:
                rover.roverDirection++;
                break;
            case Direction.E:
                rover.roverDirection++;
                break;
            case Direction.S:
                rover.roverDirection++;
                break;
            case Direction.W:
                rover.roverDirection-=3;
                break;
        }
    }
    
    public static void TurnAround(IVehicle rover)
    {
        switch (rover.GetDirection())
        {
            case Direction.N:
                rover.roverDirection += 2;
                break;
            case Direction.E:
                rover.roverDirection += 2;
                break;
            case Direction.S:
                rover.roverDirection -= 2;
                break;
            case Direction.W:
                rover.roverDirection -= 2;
                break;
        }
    }
}

