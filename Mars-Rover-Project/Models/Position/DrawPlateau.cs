using Spectre.Console;
using static Spectre.Console.BoxBorder;

namespace Mars_Rover_Project.Models.Position;

public class DrawPlateau
{
  public Table SurfaceTable(int plateauLenght, int plateauWidth, int rover1Lenght, int rover1Width, int rover2Lenght, int rover2Width)
 
  {
    var table = new Table().Border(TableBorder.Square).BorderColor(Color.Blue).SafeBorder();
    table.AddColumn(" ");
    for (var column = 0; column <= plateauLenght; column++)
     table.AddColumn($"{column}");
    

    for(var row = plateauWidth; row >=0; row--)
      table.AddRow($"{row}");
    
    table.UpdateCell(plateauWidth-rover1Width, rover1Lenght+1, "[red]R1[/]");
    table.UpdateCell(plateauWidth-rover2Width, rover2Lenght+1, "[red]R2[/]");

    table.Caption = new TableTitle("Plateau");
    table.Title = new TableTitle("\nFinal position of Rovers");
    
    
    return table;
  }
  
  public async Task<Table> LiveTable(int plateauLenght, int plateauWidth, int rover1Lenght, int rover1Width, int rover2Lenght, int rover2Width)
  {
    var table = new Table().LeftAligned().BorderColor(Color.Aquamarine3);
    var delay = 100;
    await AnsiConsole.Live(table)
      .AutoClear(false)
      .StartAsync(async ctx =>
      {
        table.AddColumn(" ");
        for (var column = 0; column <= plateauLenght; column++)
        {
          table.AddColumn($"{column}");
          ctx.Refresh();
          await Task.Delay(delay);
        }
          
  
        for (var row = plateauWidth; row >=0; row--)
        {
          table.AddRow($"{row}");
          ctx.Refresh();
          await Task.Delay(delay);
        }
        
        table.UpdateCell(plateauWidth-rover1Width, rover1Lenght+1, "[red]R1[/]");
        ctx.Refresh();
        await Task.Delay(delay);
        
        table.UpdateCell(plateauWidth-rover2Width, rover2Lenght+1, "[red]R2[/]");
        ctx.Refresh();
        await Task.Delay(delay);
      });
    
    return table;
  
  }
}
