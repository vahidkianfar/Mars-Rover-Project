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
    public void TurnLeft()=>ChangeDirection.TurnLeft(this);
    public void TurnRight()=>ChangeDirection.TurnRight(this);
    public void Move()=>MoveForward.RunCommand(this);
    public void ExecuteCommand(string getMovement)
    {
        foreach (var executable in getMovement.Select(NavigationInterpreter.SetNavigation))
            executable.RunCommand(this);
    }
}