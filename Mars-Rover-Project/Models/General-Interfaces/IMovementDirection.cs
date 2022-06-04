using Mars_Rover_Project.Models.Mars;

namespace Mars_Rover_Project.Models.General_Interfaces;

public interface IMovementDirection
{
    public void MoveForward(IVehicle rover);
    public void MoveBackward(IVehicle rover);
    
    public void MoveLeft(IVehicle rover);
    public void MoveRight(IVehicle rover);
}