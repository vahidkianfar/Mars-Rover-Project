using Mars_Rover_Project.Models.General_Interfaces;
using Mars_Rover_Project.Models.RoversAndPlateau;

namespace Mars_Rover_Project.Models.PositionAndMovement;

public class MovingTheRover
{
    public static void MoveForward(IVehicle rover)
    {
        switch (rover.GetDirection())
        {
            case ChangeDirection.Direction.N: 
                MovingForwardWhenDirectionIsNorth(rover);
                break;
            case ChangeDirection.Direction.E:
                MovingForwardWhenDirectionIsEast(rover);
                break;
            case ChangeDirection.Direction.S:
                MovingForwardWhenDirectionIsSouth(rover);
                break;
            case ChangeDirection.Direction.W:
                MovingForwardWhenDirectionIsWest(rover);
                break;
            case ChangeDirection.Direction.NE:
                MovingForwardWhenDirectionIsNorthEast(rover);
                break;
            case ChangeDirection.Direction.NW:
                MovingForwardWhenDirectionIsNorthWest(rover);
                break;
            case ChangeDirection.Direction.SE:
                MovingForwardWhenDirectionIsSouthEast(rover);
                break;
            case ChangeDirection.Direction.SW:
                MovingForwardWhenDirectionIsSouthWest(rover);
                break;
            default:
                throw new ArgumentException("Movement failed!, Rover should not go further than plateau boundaries");
        }
    }

    public static void  MoveBackward(IVehicle rover)
    {
        //****Too Complex, I'll change it****
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
                    case ChangeDirection.Direction.NE when rover.GetAxisY() > 0 && rover.GetAxisX() > 0:
                        rover.SetAxisY(rover.GetAxisY() - 1);
                        rover.SetAxisX(rover.GetAxisX() - 1);
                        break;
                    case ChangeDirection.Direction.NW when rover.GetAxisY() > 0 && rover.GetAxisX() < MissionControl.GetPlateauDetails()!.Lenght_X:
                        rover.SetAxisY(rover.GetAxisY() - 1);
                        rover.SetAxisX(rover.GetAxisX() + 1);
                        break;
                    case ChangeDirection.Direction.SE when rover.GetAxisY() < MissionControl.GetPlateauDetails()!.Width_Y && rover.GetAxisX() > 0:
                        rover.SetAxisY(rover.GetAxisY() + 1);
                        rover.SetAxisX(rover.GetAxisX() - 1);
                        break;
                    case ChangeDirection.Direction.SW when rover.GetAxisY() < MissionControl.GetPlateauDetails()!.Width_Y && rover.GetAxisX() < MissionControl.GetPlateauDetails()!.Lenght_X:
                        rover.SetAxisY(rover.GetAxisY() + 1);
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

    private static void MovingForwardWhenDirectionIsNorth(IVehicle rover)
    {
        if(rover.GetAxisY() < MissionControl.GetPlateauDetails()!.Width_Y)
            rover.SetAxisY(rover.GetAxisY() + 1);
    }
    private static void MovingForwardWhenDirectionIsEast(IVehicle rover)
    {
        if(rover.GetAxisX() < MissionControl.GetPlateauDetails()!.Lenght_X)
            rover.SetAxisX(rover.GetAxisX()+1);
    }
    private static void MovingForwardWhenDirectionIsSouth(IVehicle rover)
    {
        if(rover.GetAxisY() > 0)
            rover.SetAxisY(rover.GetAxisY() - 1);
    }
    private static void MovingForwardWhenDirectionIsWest(IVehicle rover)
    {
        if(rover.GetAxisX() > 0)
            rover.SetAxisX(rover.GetAxisX()-1);
    }

    private static void MovingForwardWhenDirectionIsNorthEast(IVehicle rover)
    {
        if (rover.GetAxisY() < MissionControl.GetPlateauDetails()!.Width_Y && rover.GetAxisX()
            < MissionControl.GetPlateauDetails()!.Lenght_X)
        {
            rover.SetAxisY(rover.GetAxisY()+1);
            rover.SetAxisX(rover.GetAxisX()+1);
        }
    }
    private static void MovingForwardWhenDirectionIsNorthWest(IVehicle rover)
    {
        if (rover.GetAxisY() < MissionControl.GetPlateauDetails()!.Width_Y && rover.GetAxisX() > 0)
        {
            rover.SetAxisY(rover.GetAxisY()+1);
            rover.SetAxisX(rover.GetAxisX()-1);
        }
    }

    private static void MovingForwardWhenDirectionIsSouthEast(IVehicle rover)
    {
        if (rover.GetAxisY() > 0 && rover.GetAxisX() < MissionControl.GetPlateauDetails()!.Lenght_X)
        {
            rover.SetAxisY(rover.GetAxisY()-1);
            rover.SetAxisX(rover.GetAxisX()+1);
        }
            
    }
    private static void MovingForwardWhenDirectionIsSouthWest(IVehicle rover)
    {
        if (rover.GetAxisY() > 0 && rover.GetAxisX() > 0)
        {
            rover.SetAxisY(rover.GetAxisY()-1);
            rover.SetAxisX(rover.GetAxisX()-1);
        }
    }
}