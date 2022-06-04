using Mars_Rover_Project.Models.General_Interfaces;

namespace Mars_Rover_Project.Models.Navigation;

public class NavigateBack:INavigation
{
    public void RunCommand(IVehicle rover) => rover.TurnAround();
}