using Mars_Rover_Project.Models.General_Interfaces;
using Mars_Rover_Project.Models.Navigation;
using Mars_Rover_Project.Models.Position;
using Mars_Rover_Project.Models.UI;
using Mars_Rover_Project.Models.Validation;

namespace Mars_Rover_Project.Models.Mars;

public class MarsRover: IVehicle
{
    private int _axisX { get; set; }
    private int _axisY { get; set; }
    private MovingTheRover _movingTheRover { get; }
    private ChangeDirection _changeDirection { get; }
    public ChangeDirection.Direction roverDirection { get; set; }
    public MarsRover(string? getInitialPosition)
    {
        var roverPosition = new PositionInterpreter(getInitialPosition);
        SetAxisX(roverPosition.initialPosition[0]);
        SetAxisY(roverPosition.initialPosition[1]);
        SetDirection(roverPosition.initialDirection!);
         _movingTheRover = new MovingTheRover();
         _changeDirection= new ChangeDirection();
    }
    
    public void TurnLeft()=>_changeDirection.TurnLeft(this);
    public void TurnRight()=>_changeDirection.TurnRight(this);
    public void TurnAround()=>_changeDirection.TurnAround(this);
    public void Move()=>_movingTheRover.MoveForward(this);
    public void ExecuteCommand(string? getMovement)
    {
        if (!Validator.CommandValidator(getMovement)) 
            throw new ArgumentException("Invalid movement Command");
        
        foreach (var executable in getMovement!.ToUpper().Select(NavigationInterpreter.SetNavigation))
             executable.RunCommand(this);
    }
    public void SetAxisX(int axisX)
    {
        if(MissionControl.Plateau != null && !Validator.AxisValidator(axisX) && axisX<=MissionControl.Plateau.Lenght_X)
            throw new ArgumentException("Invalid Axis X");
        _axisX = axisX;
    }
    public void SetAxisY(int axisY)
    {
        if(MissionControl.Plateau != null && !Validator.AxisValidator(axisY) && axisY<=MissionControl.Plateau.Width_Y)
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