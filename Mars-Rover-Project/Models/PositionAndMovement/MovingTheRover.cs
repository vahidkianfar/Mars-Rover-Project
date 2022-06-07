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
        switch (rover.GetDirection())
                {
                    case ChangeDirection.Direction.N:
                        MovingBackwardWhenDirectionIsNorth(rover);
                        break;
                    case ChangeDirection.Direction.E:
                        MovingBackwardWhenDirectionIsEast(rover);
                        break;
                    case ChangeDirection.Direction.S:
                        MovingBackwardWhenDirectionIsSouth(rover);
                        break;
                    case ChangeDirection.Direction.W:
                        MovingBackwardWhenDirectionIsWest(rover);
                        break;
                    case ChangeDirection.Direction.NE:
                        MovingBackwardWhenDirectionIsNorthEast(rover);
                        break;
                    case ChangeDirection.Direction.NW:
                        MovingBackwardWhenDirectionIsNorthWest(rover);
                        break;
                    case ChangeDirection.Direction.SE:
                        MovingBackwardWhenDirectionIsSouthEast(rover);
                        break;
                    case ChangeDirection.Direction.SW:
                        MovingBackwardWhenDirectionIsSouthWest(rover);
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

    private static void BoundaryError()
    {
        throw new ArgumentException("Movement failed!, Rover should not go further than plateau boundaries");
    }
    // Methods for moving forward for different Direction
    private static void MovingForwardWhenDirectionIsNorth(IVehicle rover)
    {
        if(rover.GetAxisY() < MissionControl.GetPlateauDetails()!.Width_Y)
            rover.SetAxisY(rover.GetAxisY() + 1);
        else
        {
            BoundaryError();
        }
    }
    private static void MovingForwardWhenDirectionIsEast(IVehicle rover)
    {
        if(rover.GetAxisX() < MissionControl.GetPlateauDetails()!.Lenght_X)
            rover.SetAxisX(rover.GetAxisX()+1);
        else
        {
            BoundaryError();
        }
    }
    private static void MovingForwardWhenDirectionIsSouth(IVehicle rover)
    {
        if(rover.GetAxisY() > 0)
            rover.SetAxisY(rover.GetAxisY() - 1);
        else
        {
            BoundaryError();
        }
    }
    private static void MovingForwardWhenDirectionIsWest(IVehicle rover)
    {
        if(rover.GetAxisX() > 0)
            rover.SetAxisX(rover.GetAxisX()-1);
        else
        {
            BoundaryError();
        }
    }

    private static void MovingForwardWhenDirectionIsNorthEast(IVehicle rover)
    {
        if (rover.GetAxisY() < MissionControl.GetPlateauDetails()!.Width_Y && rover.GetAxisX()
            < MissionControl.GetPlateauDetails()!.Lenght_X)
        {
            rover.SetAxisY(rover.GetAxisY()+1);
            rover.SetAxisX(rover.GetAxisX()+1);
        }
        else
        {
            BoundaryError();
        }
    }
    private static void MovingForwardWhenDirectionIsNorthWest(IVehicle rover)
    {
        if (rover.GetAxisY() < MissionControl.GetPlateauDetails()!.Width_Y && rover.GetAxisX() > 0)
        {
            rover.SetAxisY(rover.GetAxisY()+1);
            rover.SetAxisX(rover.GetAxisX()-1);
        }
        else
        {
            BoundaryError();
        }
    }

    private static void MovingForwardWhenDirectionIsSouthEast(IVehicle rover)
    {
        if (rover.GetAxisY() > 0 && rover.GetAxisX() < MissionControl.GetPlateauDetails()!.Lenght_X)
        {
            rover.SetAxisY(rover.GetAxisY()-1);
            rover.SetAxisX(rover.GetAxisX()+1);
        }
        else
        {
            BoundaryError();
        }
            
    }
    private static void MovingForwardWhenDirectionIsSouthWest(IVehicle rover)
    {
        if (rover.GetAxisY() > 0 && rover.GetAxisX() > 0)
        {
            rover.SetAxisY(rover.GetAxisY()-1);
            rover.SetAxisX(rover.GetAxisX()-1);
        }
        else
        {
            BoundaryError();
        }
    }
    
    // Methods for moving backward for different Direction
    
    private static void MovingBackwardWhenDirectionIsNorth(IVehicle rover)
    {
        if(rover.GetAxisY() > 0)
            rover.SetAxisY(rover.GetAxisY() - 1);
        else
        {
            BoundaryError();
        }
    }

    private static void MovingBackwardWhenDirectionIsEast(IVehicle rover)
    {
        if(rover.GetAxisX() > 0)
            rover.SetAxisX(rover.GetAxisX() - 1);
        else
        {
            BoundaryError();
        }
    }
    private static void MovingBackwardWhenDirectionIsSouth(IVehicle rover)
    {
        if(rover.GetAxisY() < MissionControl.GetPlateauDetails()!.Width_Y)
            rover.SetAxisY(rover.GetAxisY() + 1);
        else
        {
            BoundaryError();
        }
    }
    private static void MovingBackwardWhenDirectionIsWest(IVehicle rover)
    {
        if(rover.GetAxisX() < MissionControl.GetPlateauDetails()!.Lenght_X)
            rover.SetAxisX(rover.GetAxisX() + 1);
        else
        {
            BoundaryError();
        }
    }
    private static void MovingBackwardWhenDirectionIsNorthEast(IVehicle rover)
    {
        if (rover.GetAxisY() > 0 && rover.GetAxisX() > 0)
        {
            rover.SetAxisY(rover.GetAxisY() - 1);
            rover.SetAxisX(rover.GetAxisX() - 1);
        }
        else
        {
            BoundaryError();
        }
        
    }
    private static void MovingBackwardWhenDirectionIsNorthWest(IVehicle rover)
    {
        if (rover.GetAxisY() > 0 && rover.GetAxisX() < MissionControl.GetPlateauDetails()!.Lenght_X)
        {
            rover.SetAxisY(rover.GetAxisY() - 1);
            rover.SetAxisX(rover.GetAxisX() + 1);
        }
        else
        {
            BoundaryError();
        }
        
    }
    private static void MovingBackwardWhenDirectionIsSouthEast(IVehicle rover)
    {
        if (rover.GetAxisY() < MissionControl.GetPlateauDetails()!.Width_Y && rover.GetAxisX() > 0)
        {
            rover.SetAxisY(rover.GetAxisY() + 1);
            rover.SetAxisX(rover.GetAxisX() - 1);
        }
        else
        {
            BoundaryError();
        }
        
    }
    private static void MovingBackwardWhenDirectionIsSouthWest(IVehicle rover)
    {
        if (rover.GetAxisY() < MissionControl.GetPlateauDetails()!.Width_Y &&
            rover.GetAxisX() < MissionControl.GetPlateauDetails()!.Lenght_X)
        {
            rover.SetAxisY(rover.GetAxisY() + 1);
            rover.SetAxisX(rover.GetAxisX() + 1);
        }
        else
        {
            BoundaryError();
        }
        
    }
    
}