namespace Mars_Rover_Project.Models.General_Interfaces;

public interface IVehicle
{
    public int GetAxisX();
    public int GetAxisY();
    public void TurnAround();
    public void TurnLeft();
    public void TurnRight();
    public void Move();
    public void ExecuteCommand(string getMovement);
    public Enum? GetDirection();
    public void GetCurrentPositionForConsole();
    public string GetCurrentPositionForFile();
}