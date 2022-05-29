using System.Text.RegularExpressions;
using Mars_Rover_Project.Models.Mars;

namespace Mars_Rover_Project.Models.Validation;

public class ValidateChecker
{
    public static bool CommandValidator(string inputCommand)=>Regex.IsMatch(inputCommand, @"^[LRM]+$");
    public static bool AxisValidator(int axis)=>axis >= 0;
    public static bool DirectionValidator(string direction)=>direction.ToUpper() == "N" || 
                                                             direction.ToUpper() == "S" || 
                                                             direction.ToUpper() == "E" ||
                                                             direction.ToUpper() == "W";
    
    public static bool DeploymentPositionValidator(int xCoordinate, int yCoordinate, MarsPlateau plateau)=>
        xCoordinate >= 0 && xCoordinate <= plateau.Lenght_X && yCoordinate >= 0 && yCoordinate <= plateau.Width_Y;
    public static bool RectangularPlateauValidator(string plateauSize) => Regex.IsMatch(plateauSize, @"^[0-9]{1,2} [0-9]{1,2}$");

}