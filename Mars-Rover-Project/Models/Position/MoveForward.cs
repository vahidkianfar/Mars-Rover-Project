using Mars_Rover_Project.Models.Mars;

namespace Mars_Rover_Project.Models.Position;

public class MoveForward
{
    public static void RunCommand(MarsRover marsRover)
    {
        switch (marsRover.direction)
        {
            case "N": marsRover.axisY++;
                break;
            case "E": marsRover.axisX++;
                break;
            case "S": marsRover.axisY--;
                break;
            case "W": marsRover.axisX--;
                break;
        }
    }
}