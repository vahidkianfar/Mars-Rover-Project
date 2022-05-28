namespace Mars_Rover_Project.Models.Position;

public class PositionInterpreter:IPosition
{
    public List<int> initialPosition { get; set; }
    public string initialDirection { get; private set; }
    public PositionInterpreter(string getPositionAndDirection)=>SetPosition(getPositionAndDirection);

    private void SetPosition(string getPositionAndDirection)
    {
       //CheckValidation
        var positionArray = getPositionAndDirection.Split(" ");
        initialPosition = new List<int>
        {
            Convert.ToInt32(positionArray[0]),
            Convert.ToInt32(positionArray[1])
        };
        initialDirection = positionArray[2];
        
    }
}