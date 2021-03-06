using Mars_Rover_Project.Models.PositionAndMovement;

namespace Mars_Rover_Project.Models.General_Interfaces;

public interface IVehicle
{
    public ChangeDirection.Direction roverDirection { get; set; }
    public int GetAxisX();
    public int GetAxisY();
    public void TurnAround();
    public void TurnLeft();
    public void TurnRight();
    public void MoveForward();
    public void MoveBackward();
    public void ExecuteCommand(string? getMovement);
    public Enum? GetDirection();
    public void GetCurrentPositionForConsole();
    public string GetCurrentPositionForFile();
    public void SetAxisX(int axisX);
    public void SetAxisY(int axisY);
}