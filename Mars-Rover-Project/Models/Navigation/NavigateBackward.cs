using System.ComponentModel.Design.Serialization;
using Mars_Rover_Project.Models.General_Interfaces;

namespace Mars_Rover_Project.Models.Navigation;

public class NavigateBackward:INavigation
{
    public void RunCommand(IVehicle rover) => rover.MoveBackward();
}