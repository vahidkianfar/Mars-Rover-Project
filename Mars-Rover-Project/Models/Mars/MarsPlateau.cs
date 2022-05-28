using Mars_Rover_Project.Models.General_Interfaces;
namespace Mars_Rover_Project.Models.Mars;

public class MarsPlateau:ISurface
{
    public int Lenght_X { get; set; }
    public int Width_Y { get; set; }

    public MarsPlateau(string gridSize)
    {
        var marsGrids = gridSize.Split(' ');
        Lenght_X = int.Parse(marsGrids[0]);
        Width_Y = int.Parse(marsGrids[1]);
    }
}