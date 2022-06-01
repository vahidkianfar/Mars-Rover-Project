using Mars_Rover_Project.Models.General_Interfaces;
using Mars_Rover_Project.Models.Position;

namespace Mars_Rover_Project.Models.Mars;

public class MovingTheRover:IMovementDirection
{
    public void MoveForward(MarsRover marsRover)
    {
        switch (marsRover.GetDirection())
        {
            case ChangeDirection.Direction.N when marsRover.GetAxisY() < MissionControl.GetMarsPlateauDetails()!.Width_Y:
                marsRover.SetAxisY(marsRover.GetAxisY() + 1);
                break;
            case ChangeDirection.Direction.E when marsRover.GetAxisX() < MissionControl.GetMarsPlateauDetails()!.Lenght_X:
                marsRover.SetAxisX(marsRover.GetAxisX()+1);
                break;
            case ChangeDirection.Direction.S when marsRover.GetAxisY() > 0: marsRover.SetAxisY(marsRover.GetAxisY() - 1);
                break;
            case ChangeDirection.Direction.W when marsRover.GetAxisX() > 0: marsRover.SetAxisX(marsRover.GetAxisX()-1);
                break;
            default:
                throw new ArgumentException("Movement failed!, Rover should not go further than plateau boundaries");
        }
    }

    public void MoveBackward(MarsRover marsRover)
    {
        throw new NotImplementedException();
    }
    public void MoveLeft(MarsRover marsRover)
    {
        throw new NotImplementedException();
    }
    public void MoveRight(MarsRover marsRover)
    {
        throw new NotImplementedException();
    }
}