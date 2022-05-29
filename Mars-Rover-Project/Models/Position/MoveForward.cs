using Mars_Rover_Project.Models.Mars;
using Mars_Rover_Project.Models.Navigation;

namespace Mars_Rover_Project.Models.Position;

public class MoveForward
{
    public static void RunCommand(MarsRover marsRover)
    {
        switch (marsRover.GetDirection())
        {
            case "N" when marsRover.GetAxisY() < marsRover.GetMarsPlateau().Width_Y:
                marsRover.SetAxisY(marsRover.GetAxisY() + 1);
                break;
            case "E" when marsRover.GetAxisX() < marsRover.GetMarsPlateau().Lenght_X:
                marsRover.SetAxisX(marsRover.GetAxisX()+1);
                break;
            case "S" when marsRover.GetAxisY() > 0: marsRover.SetAxisY(marsRover.GetAxisY() - 1);
                break;
            case "W" when marsRover.GetAxisX() > 0: marsRover.SetAxisX(marsRover.GetAxisX()-1);
                break;
            default:
                throw new ArgumentException("Out of Boundary", nameof(marsRover.GetDirection));
        }
    }
}