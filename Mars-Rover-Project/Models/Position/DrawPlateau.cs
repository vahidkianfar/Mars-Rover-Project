using Spectre.Console;

namespace Mars_Rover_Project.Models.Position;

public class DrawPlateau
{
  public Table CreateLiveTable(int plateauLenght, int plateauWidth, int roverLenght, int roverWidth)
  {
    var table = new Table
    {
      Border = TableBorder.Rounded,
      
    };
    
    for (var column = 0; column <= plateauLenght; column++)
    {
      table.AddColumn($"{column}");
    }
    
    for (var row = plateauWidth; row >=0; row--)
    {
      table.AddRow($"{row}");
    }

    table.Columns[roverLenght].LeftAligned();

    table.Caption = new TableTitle("The position of Rovers");
    table.Title = new TableTitle("\nPlateau");
    
 
    
    return table;
  }
  public Panel CreatePanel(int lenght, int width)
  {
    var panel = new Panel("R1");
    panel.Border = BoxBorder.Rounded;

    return panel;
  }
}