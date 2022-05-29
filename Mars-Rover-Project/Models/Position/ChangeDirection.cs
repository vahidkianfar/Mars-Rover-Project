using Mars_Rover_Project.Models.Mars;
namespace Mars_Rover_Project.Models.Position;

public static class ChangeDirection
{
    public static void TurnLeft(MarsRover marsRover)
    {
        if(marsRover.GetDirection()=="N") marsRover.SetDirection("W");
        else if(marsRover.GetDirection()=="E") marsRover.SetDirection("N");
        else if(marsRover.GetDirection()=="S") marsRover.SetDirection("E");
        else if(marsRover.GetDirection()=="W") marsRover.SetDirection("S");
        // marsRover.direction = marsRover.direction switch
        // {
        //     "N" => "W",
        //     "E" => "N",
        //     "S" => "E",
        //     "W" => "S",
        //     _ => marsRover.direction
        // };
    }
    
    public static void TurnRight(MarsRover marsRover)
    {
        if(marsRover.GetDirection()=="N") marsRover.SetDirection("E");
        else if(marsRover.GetDirection()=="E") marsRover.SetDirection("S");
        else if(marsRover.GetDirection()=="S") marsRover.SetDirection("W");
        else if(marsRover.GetDirection()=="W") marsRover.SetDirection("N");
    }
}