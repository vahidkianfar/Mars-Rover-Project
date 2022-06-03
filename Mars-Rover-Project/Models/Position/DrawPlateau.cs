using Spectre.Console;
using static Spectre.Console.BoxBorder;

namespace Mars_Rover_Project.Models.Position;

public class DrawPlateau
{
  public Table CreateSurfaceTable(int plateauLenght, int plateauWidth, int rover1Lenght, int rover1Width, int rover2Lenght, int rover2Width)
 
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
  
  // public async Task<Table> CreateTable()
  // {
  //   var table = new Table().Centered();
  //   var stringarr = " ";
  //   var delay = 200;
  //   await AnsiConsole.Live(table)
  //     .AutoClear(false)
  //     .StartAsync(async ctx =>
  //     {
  //       table.AddColumn(" ");
  //       ctx.Refresh();
  //       await Task.Delay(delay);
  //
  //       table.AddColumn(" ");
  //       ctx.Refresh();
  //       await Task.Delay(delay);
  //
  //       table.AddColumn(" ");
  //       ctx.Refresh();
  //       await Task.Delay(delay);
  //
  //       table.AddColumn(" ");
  //       ctx.Refresh();
  //       await Task.Delay(delay);
  //
  //       table.AddColumn(" ");
  //       ctx.Refresh();
  //       await Task.Delay(delay);
  //
  //       table.AddColumn(" ");
  //       ctx.Refresh();
  //       await Task.Delay(delay);
  //
  //       table.AddColumn(" ");
  //       ctx.Refresh();
  //       await Task.Delay(delay);
  //
  //
  //       table.AddRow("5");
  //       ctx.Refresh();
  //       await Task.Delay(delay);
  //
  //       table.AddRow("4");
  //       ctx.Refresh();
  //       await Task.Delay(delay);
  //
  //       table.AddRow("3", " ", "[green]Rover[/]");
  //       ctx.Refresh();
  //       await Task.Delay(delay);
  //
  //        table.AddRow("2");
  //       
  //       ctx.Refresh();
  //       await Task.Delay(delay);
  //
  //       table.AddRow("1");
  //       ctx.Refresh();
  //       await Task.Delay(delay);
  //
  //       table.AddRow("0");
  //       ctx.Refresh();
  //       await Task.Delay(delay);
  //
  //       table.AddRow(" ", "0", "1", "2", "3", "4", "5");
  //       ctx.Refresh();
  //       await Task.Delay(delay);
  //     });
  //   
  //   return table;
  //
  // }
}
