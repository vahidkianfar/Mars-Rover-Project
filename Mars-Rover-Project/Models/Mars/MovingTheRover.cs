using Mars_Rover_Project.Models.General_Interfaces;
using Mars_Rover_Project.Models.Position;
using Mars_Rover_Project.Models.UI;

namespace Mars_Rover_Project.Models.Mars;

public class MovingTheRover:IMovementDirection
{
    public void MoveForward(MarsRover marsRover)
    {
        switch (marsRover.GetDirection())
        {
            case ChangeDirection.Direction.N when marsRover.GetAxisY() < MissionControl.GetPlateauDetails()!.Width_Y:
                marsRover.SetAxisY(marsRover.GetAxisY() + 1);
                break;
            case ChangeDirection.Direction.E when marsRover.GetAxisX() < MissionControl.GetPlateauDetails()!.Lenght_X:
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