using Mars_Rover_Project.Models.General_Interfaces;
using Mars_Rover_Project.Models.Validation;

namespace Mars_Rover_Project.Models.Mars;

public class MarsPlateau:ISurface
{
    public int Lenght_X { get; set; }
    public int Width_Y { get; set; }
    public MarsPlateau(string? gridSize)
    {
        if(!Validator.RectangularPlateauValidator(gridSize))
            throw new ArgumentException("Invalid grid size for Rectangular Plateau");
        var marsGrids = gridSize!.Split(' ');
        Lenght_X = int.Parse(marsGrids[0]);
        Width_Y = int.Parse(marsGrids[1]);
    }
    public int GetLenght()=> Lenght_X;
    public int GetWidth()=> Width_Y;
}