﻿using Mars_Rover_Project.Models.General_Interfaces;
using Mars_Rover_Project.Models.Navigation;
using Mars_Rover_Project.Models.Position;
using Mars_Rover_Project.Models.Validation;

namespace Mars_Rover_Project.Models.Mars;

public class MarsRover: IVehicle
{
    private int _axisX { get; set; }
    private int _axisY { get; set; }
    private string _direction { get; set; }
    private MarsPlateau _marsPlateau { get; set; }
    private MovingTheRover _movingTheRover { get; set; }
    private ChangeDirection _changeDirection { get; set; }
    public MarsRover(string getInitialPosition)
    {
        var roverPosition = new PositionInterpreter(getInitialPosition);
        SetAxisX(roverPosition.initialPosition[0]);
        SetAxisY(roverPosition.initialPosition[1]);
        SetDirection(_direction=roverPosition.initialDirection);
        _movingTheRover = new MovingTheRover();
        _changeDirection= new ChangeDirection();
    }
    
    public void TurnLeft()=>_changeDirection.TurnLeft(this);
    public void TurnRight()=>_changeDirection.TurnRight(this);
    public void Move()=>_movingTheRover.MoveForward(this);
    public void ExecuteCommand(string getMovement)
    {
        if (!Validator.CommandValidator(getMovement)) 
            throw new ArgumentException("Invalid movement Command", nameof(getMovement));
        
        foreach (var executable in getMovement.Select(NavigationInterpreter.SetNavigation))
             executable.RunCommand(this);
    }

    public void SetPlateau(MarsPlateau marsPlateau)
    {
        if (!Validator.DeploymentPositionValidator(GetAxisX(), GetAxisY(), marsPlateau))
            throw new ArgumentException("Deployment Positions are not Valid");
        _marsPlateau = marsPlateau;
    }
    
    public void SetAxisX(int axisX)
    {
        if(!Validator.AxisValidator(axisX) && axisX<=_marsPlateau.Lenght_X)
            throw new ArgumentException("Invalid Axis X", nameof(axisX));
        _axisX = axisX;
    }
    public void SetAxisY(int axisY)
    {
        if(!Validator.AxisValidator(axisY) && axisY<=_marsPlateau.Width_Y)
            throw new ArgumentException("Invalid Axis Y", nameof(axisY));
        _axisY = axisY;
    }

    public void SetDirection(string direction)
    {
        if(!Validator.DirectionValidator(direction))
            throw new ArgumentException("Invalid Direction", nameof(direction));
        _direction = direction;
    }
    
    public int GetAxisX()=>_axisX;
    public int GetAxisY()=>_axisY;
    public string GetDirection()=>_direction;
    public MarsPlateau GetMarsPlateau()=>_marsPlateau;
    public void GetCurrentPosition()=>Console.WriteLine($"Rover position: {GetAxisX()} {GetAxisY()} {GetDirection()}");
}