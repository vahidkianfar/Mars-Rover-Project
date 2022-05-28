using Mars_Rover_Project.Models.General_Interfaces;
namespace Mars_Rover_Project.Models.Navigation;

public class MoveForward:INavigation
{
    public void RunCommand(IVehicle marsRover)=>marsRover.MoveForward();
    
}