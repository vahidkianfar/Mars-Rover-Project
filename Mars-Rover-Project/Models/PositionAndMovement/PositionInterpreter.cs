using Mars_Rover_Project.Models.General_Interfaces;

namespace Mars_Rover_Project.Models.PositionAndMovement;
public class PositionInterpreter:IPosition
{
    public List<int> InitialPosition { get; set; }
    public string? initialDirection { get; private set; }

    public PositionInterpreter(string? getPositionAndDirection)
    {
        var positionArray = getPositionAndDirection!.Split(" ");

        InitialPosition = new List<int>
        {
            Convert.ToInt32(positionArray[0]),
            Convert.ToInt32(positionArray[1])
        };
        initialDirection = positionArray[2];
    }
}