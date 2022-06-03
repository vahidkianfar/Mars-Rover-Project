using Mars_Rover_Project.Models.General_Interfaces;

namespace Mars_Rover_Project.Models.Navigation;

public class NavigateLeft:INavigation
{
    public void RunCommand(IVehicle marsRover)=>marsRover.TurnLeft();
}