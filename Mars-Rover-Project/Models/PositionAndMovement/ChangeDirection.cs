using Mars_Rover_Project.Models.General_Interfaces;

namespace Mars_Rover_Project.Models.PositionAndMovement;

public class ChangeDirection
{
    public enum Direction
    {
        N=1,
        E,
        S,
        W,
        NW,
        NE,
        SW,
        SE
    } 
    public static void TurnLeft(IVehicle rover)
    {
        switch (rover.GetDirection())
        {
            case Direction.N: rover.roverDirection = Direction.W;
                break;
            case Direction.E: rover.roverDirection = Direction.N;
                break;
            case Direction.S: rover.roverDirection = Direction.E;
                break;
            case Direction.W: rover.roverDirection = Direction.S;
                break;
            case Direction.NW: rover.roverDirection=Direction.SW;
                break;
            case Direction.NE: rover.roverDirection = Direction.NW;
                break;
            case Direction.SW: rover.roverDirection=Direction.SE;
                break;
            case Direction.SE: rover.roverDirection=Direction.NE;
                break;
            
        }
    }
    
    public static void TurnRight(IVehicle rover)
    {
        switch (rover.GetDirection())
        {
            case Direction.N: rover.roverDirection=Direction.E;
                break;
            case Direction.E: rover.roverDirection=Direction.S;
                break;
            case Direction.S: rover.roverDirection=Direction.W;
                break;
            case Direction.W: rover.roverDirection=Direction.N;
                break;
            case Direction.NW: rover.roverDirection=Direction.NE;
                break;
            case Direction.NE: rover.roverDirection=Direction.SE;
                break;
            case Direction.SW: rover.roverDirection=Direction.NW;
                break;
            case Direction.SE: rover.roverDirection=Direction.SW;
                break;
        }
    }
    
    public static void TurnAround(IVehicle rover)
    {
        switch (rover.GetDirection())
        {
            case Direction.N: rover.roverDirection=Direction.S;
                break;
            case Direction.E: rover.roverDirection=Direction.W;
                break;
            case Direction.S: rover.roverDirection=Direction.N;
                break;
            case Direction.W: rover.roverDirection=Direction.E;
                break;
            case Direction.NW: rover.roverDirection=Direction.SE;
                break;
            case Direction.NE: rover.roverDirection=Direction.SW;
                break;
            case Direction.SW: rover.roverDirection=Direction.NE;
                break;
            case Direction.SE: rover.roverDirection=Direction.NW;
                break;
        }
    }
}

