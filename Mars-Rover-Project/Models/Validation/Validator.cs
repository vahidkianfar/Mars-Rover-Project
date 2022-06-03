﻿using System.Text.RegularExpressions;
using Mars_Rover_Project.Models.General_Interfaces;
using Mars_Rover_Project.Models.Mars;

namespace Mars_Rover_Project.Models.Validation;

public class Validator
{
    public static bool CommandValidator(string? inputCommand)=>Regex.IsMatch(inputCommand.ToUpper(), @"^[LRMB]+$");
    public static bool AxisValidator(int axis)=>axis >= 0;
    public static bool DirectionValidator(string direction)=>direction.ToUpper() == "N" || 
                                                             direction.ToUpper() == "S" || 
                                                             direction.ToUpper() == "E" ||
                                                             direction.ToUpper() == "W";
    public static bool DeploymentPositionValidator(int xCoordinate, int yCoordinate, ISurface? plateau)=>
        plateau != null && xCoordinate >= 0 && xCoordinate <= plateau.Lenght_X && yCoordinate >= 0 && yCoordinate <= plateau.Width_Y;
    public static bool RectangularPlateauValidator(string? plateauSize) => Regex.IsMatch(plateauSize, @"^[0-9]{1,2} [0-9]{1,2}$");

}