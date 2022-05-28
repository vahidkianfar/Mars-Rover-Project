using Mars_Rover_Project.Models.General_Interfaces;
using Mars_Rover_Project.Models.Navigation;
using Mars_Rover_Project.Models.Position;

namespace Mars_Rover_Project.Models.Mars;

public class MarsRover: IVehicle
{
    public int axisX { get; set; }
    public int axisY { get; set; }
    public string direction { get; set; }
    
    
    public MarsRover(string getInitialPosition)
    {
        var roverPosition = new PositionInterpreter(getInitialPosition);
        axisX = roverPosition.initialPosition[0];
        axisY = roverPosition.initialPosition[1];
        direction=roverPosition.initialDirection;
    }
    
    // public void Move(string getMovement)
    // {
    //     var movement = new NavigationInterpreter(getMovement);
    //     var movementList = movement.movementList;
    //     foreach (var movementItem in movementList)
    //     {
    //         switch (movementItem)
    //         {
    //             case "L":
    //                 TurnLeft();
    //                 break;
    //             case "R":
    //                 TurnRight();
    //                 break;
    //             case "M":
    //                 MoveForward();
    //                 break;
    //         }
    //     }
    // }

    public void TurnLeft()
    {
        switch (direction)
        {
            case "N":
                direction = "W";
                break;
            case "E":
                direction = "N";
                break;
            case "S":
                direction = "E";
                break;
            case "W":
                direction = "S";
                break;
        }
    }
    
    public void TurnRight()
    {
        switch (direction)
        {
            case "N":
                direction = "E";
                break;
            case "E":
                direction = "S";
                break;
            case "S":
                direction = "W";
                break;
            case "W":
                direction = "N";
                break;
        }
    }
    
    public void MoveForward()
    {
        switch (direction)
        {
            case "N":
                axisY++;
                break;
            case "E":
                axisX++;
                break;
            case "S":
                axisY--;
                break;
            case "W":
                axisX--;
                break;
        }
    }
}