﻿namespace Mars_Rover_Project.Models.General_Interfaces;

public interface IVehicle
{
    public void TurnAround();
    public void TurnLeft();
    public void TurnRight();
    public void Move();
}