using Mars_Rover_Project.Models.General_Interfaces;
using Mars_Rover_Project.Models.Position;

namespace Mars_Rover_Project.Models.Mars;

public class MarsRover: IVehicle
{
    public int axisX { get; set; }
    public int axisY { get; set; }
    public string direction { get; set; }
    
    public MarsRover(string getInitialPosition)
    {
        var roverPosition = new PositionInterpreter(getInitialPosition);
        axisX = roverPosition.initialPosition[0];
        axisY = roverPosition.initialPosition[1];
        SetDirection(roverPosition.initialDirection);
    }

    private void SetDirection(char getDirection)
    {
        direction = getDirection switch
        {
            'N' => "North",
            'E' => "East",
            'S' => "South",
            'W' => "West",
            _ => direction
        };
    }
    
}