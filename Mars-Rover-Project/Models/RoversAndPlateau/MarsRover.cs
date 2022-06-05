using Mars_Rover_Project.Models.General_Interfaces;
using Mars_Rover_Project.Models.Navigation;
using Mars_Rover_Project.Models.PositionAndMovement;
using Mars_Rover_Project.Models.UI;
using Mars_Rover_Project.Models.Validation;

namespace Mars_Rover_Project.Models.RoversAndPlateau;

public class MarsRover: IVehicle
{
    private int _axisX { get; set; }
    private int _axisY { get; set; }
    public ChangeDirection.Direction roverDirection { get; set; }
    public MarsRover(string? getInitialPosition)
    {
        var roverPosition = new PositionInterpreter(getInitialPosition);
        SetAxisX(roverPosition.InitialPosition[0]);
        SetAxisY(roverPosition.InitialPosition[1]);
        SetDirection(roverPosition.initialDirection!);
    }
    
    public void TurnLeft()=>ChangeDirection.TurnLeft(this);
    public void TurnRight()=>ChangeDirection.TurnRight(this);
    public void TurnAround()=>ChangeDirection.TurnAround(this);
    public void MoveForward()=>MovingTheRover.MoveForward(this);
    public void MoveBackward()=>MovingTheRover.MoveBackward(this);
    public void MoveLeft()=>MovingTheRover.MoveLeft(this);
    public void MoveRight()=>MovingTheRover.MoveRight(this);
    public void ExecuteCommand(string? getMovement)
    {
        if (!Validator.CommandValidator(getMovement)) 
            throw new ArgumentException("Invalid movement Command");
        
        foreach (var executable in getMovement!.ToUpper().Select(NavigationInterpreter.SetNavigation))
             executable.RunCommand(this);
    }
    public void SetAxisX(int axisX)
    {
        if(!Validator.AxisValidator(axisX) && axisX<=MissionControl.Plateau?.Lenght_X)
            throw new ArgumentException("Invalid Axis X");
        _axisX = axisX;
    }
    public void SetAxisY(int axisY)
    {
        if(!Validator.AxisValidator(axisY) && axisY<=MissionControl.Plateau?.Width_Y)
            throw new ArgumentException("Invalid Axis Y");
        _axisY = axisY;
    }
    private void SetDirection(string direction)
    {
        if (!Validator.DirectionValidator(direction))
            throw new ArgumentException("Invalid Direction");
        
        roverDirection = Enum.Parse(typeof(ChangeDirection.Direction), direction.ToUpper()) is ChangeDirection.Direction 
            ? (ChangeDirection.Direction)Enum.Parse(typeof(ChangeDirection.Direction), direction.ToUpper()) : 0;
    }
    public int GetAxisX()=>_axisX;
    public int GetAxisY()=>_axisY;
    public Enum GetDirection()=>roverDirection;
    public void GetCurrentPositionForConsole()=>Console.WriteLine($"position: {GetAxisX()} {GetAxisY()} {GetDirection()}");
    public string GetCurrentPositionForFile()=>$"position: {GetAxisX()} {GetAxisY()} {GetDirection()}";
}