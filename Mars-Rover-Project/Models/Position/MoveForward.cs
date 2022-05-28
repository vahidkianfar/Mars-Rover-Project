using Mars_Rover_Project.Models.Mars;
using Mars_Rover_Project.Models.Navigation;

namespace Mars_Rover_Project.Models.Position;

public class MoveForward
{
    public static void RunCommand(MarsRover marsRover)
    {
        switch (marsRover.direction)
        {
            case "N" when marsRover.axisY < marsRover.marsPlateau.Width_Y:
                marsRover.axisY++;
                break;
            case "E" when marsRover.axisX < marsRover.marsPlateau.Lenght_X:
                marsRover.axisX++;
                break;
            case "S" when marsRover.axisY > 0: marsRover.axisY--;
                break;
            case "W" when marsRover.axisX > 0: marsRover.axisX--;
                break;
            default:
                throw new ArgumentException("Out of Boundary", nameof(marsRover.direction));
        }
    }
}