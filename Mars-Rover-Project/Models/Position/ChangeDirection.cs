using Mars_Rover_Project.Models.General_Interfaces;
using Mars_Rover_Project.Models.Mars;

namespace Mars_Rover_Project.Models.Position;

public static class ChangeDirection
{
    public static void TurnLeft(MarsRover marsRover)
    {
        marsRover.direction = marsRover.direction switch
        {
            "N" => "W",
            "E" => "N",
            "S" => "E",
            "W" => "S",
            _ => marsRover.direction
        };
    }
    
    public static void TurnRight(MarsRover marsRover)
    {
        marsRover.direction = marsRover.direction switch
        {
            "N" => "E",
            "E" => "S",
            "S" => "W",
            "W" => "N",
            _ => marsRover.direction
        };
    }
    
}