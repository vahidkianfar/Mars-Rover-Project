using Mars_Rover_Project.Models.RoversAndPlateau;
using Spectre.Console;

namespace Mars_Rover_Project.Models.UI;

public class DrawPlateauAndRovers
{
  public async Task<Table> LiveTable(int plateauLenght, int plateauWidth, MissionControl missionControl, int roverCounter)
  {
    var table = new Table().LeftAligned().BorderColor(Color.Blue);
    var delayTable = 100;
    var delayRover = 200;
    await AnsiConsole.Live(table)
      .AutoClear(false)
      .StartAsync(async ctx =>
      {
        table.AddColumn(" ");
        
        for (var column = 0; column <= plateauLenght; column++)
        {
          table.AddColumn($"{column}");
          ctx.Refresh();
          await Task.Delay(delayTable);
        }
        
        for (var row = plateauWidth; row >=0; row--)
        {
          table.AddRow($"{row}");
          ctx.Refresh();
          await Task.Delay(delayTable);
        }
        
        var counter = 0;
        
        while(counter<roverCounter)
        {
          table.UpdateCell(plateauWidth - missionControl.GetRoverDetails(counter)!.GetAxisY(),
            missionControl.GetRoverDetails(counter)!.GetAxisX()+1, $"[red]R{counter+1}[/] [green]{missionControl.GetRoverDetails(counter)!.roverDirection}[/]");
          ctx.Refresh();
          await Task.Delay(delayRover);
          counter++;
        }
        
        table.Title = new TableTitle("\nFinal position of Rovers");
        table.Caption = new TableTitle("Plateau");
      });
    return table;
  }
}