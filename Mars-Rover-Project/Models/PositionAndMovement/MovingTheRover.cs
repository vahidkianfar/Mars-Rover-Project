using Mars_Rover_Project.Models.General_Interfaces;
using Mars_Rover_Project.Models.UI;

namespace Mars_Rover_Project.Models.PositionAndMovement;

public class MovingTheRover
{
    public static void MoveForward(IVehicle rover)
    {
        switch (rover.GetDirection())
        {
            case ChangeDirection.Direction.N when rover.GetAxisY() < MissionControl.GetPlateauDetails()!.Width_Y:
                rover.SetAxisY(rover.GetAxisY() + 1);
                break;
            case ChangeDirection.Direction.E when rover.GetAxisX() < MissionControl.GetPlateauDetails()!.Lenght_X:
                rover.SetAxisX(rover.GetAxisX()+1);
                break;
            case ChangeDirection.Direction.S when rover.GetAxisY() > 0:
                rover.SetAxisY(rover.GetAxisY() - 1);
                break;
            case ChangeDirection.Direction.W when rover.GetAxisX() > 0:
                rover.SetAxisX(rover.GetAxisX()-1);
                break;
            default:
                throw new ArgumentException("Movement failed!, Rover should not go further than plateau boundaries");
        }
    }

    public static void  MoveBackward(IVehicle rover)
    {
        switch (rover.GetDirection())
                {
                    case ChangeDirection.Direction.N when rover.GetAxisY() > 0:
                        rover.SetAxisY(rover.GetAxisY() - 1);
                        break;
                    case ChangeDirection.Direction.E when rover.GetAxisX() > 0:
                        rover.SetAxisX(rover.GetAxisX() - 1);
                        break;
                    case ChangeDirection.Direction.S when rover.GetAxisY() < MissionControl.GetPlateauDetails()!.Width_Y:
                        rover.SetAxisY(rover.GetAxisY() + 1);
                        break;
                    case ChangeDirection.Direction.W when rover.GetAxisX() < MissionControl.GetPlateauDetails()!.Lenght_X:
                        rover.SetAxisX(rover.GetAxisX() + 1);
                        break;
                    default:
                        throw new ArgumentException("Movement failed!, Rover should not go further than plateau boundaries");
                }
    }
    public static void MoveLeft(IVehicle rover)
    {
        throw new NotImplementedException();
    }
    public static void MoveRight(IVehicle rover)
    {
        throw new NotImplementedException();
    }
}