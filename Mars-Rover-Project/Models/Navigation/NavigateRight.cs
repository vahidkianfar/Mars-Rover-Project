using Mars_Rover_Project.Models.General_Interfaces;

namespace Mars_Rover_Project.Models.Navigation;

public class NavigateRight:INavigation
{
    public void RunCommand(IVehicle rover)=>rover.TurnRight();
}