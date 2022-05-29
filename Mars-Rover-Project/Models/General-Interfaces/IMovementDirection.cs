using Mars_Rover_Project.Models.Mars;

namespace Mars_Rover_Project.Models.General_Interfaces;

public interface IMovementDirection
{
    public void MoveForward(MarsRover marsRover);
    public void MoveBackward(MarsRover marsRover);
    
    public void MoveLeft(MarsRover marsRover);
    public void MoveRight(MarsRover marsRover);
}