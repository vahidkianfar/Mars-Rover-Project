namespace Mars_Rover_Project.Models.UI;

public class ConsoleHelper
{
    public static int MultipleChoice(bool canCancel, params string[] options)
    {
        const int startX = 0;
        const int startY = 13;
        const int optionsPerLine = 1;
        const int spacingPerLine = 14;

        int currentSelection = 0;

        ConsoleKey key;

        Console.CursorVisible = false;

        do
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write(RoverBanner.design);
            Console.ResetColor();

            for (var optionCounter = 0; optionCounter < options.Length; optionCounter++)
            {
                Console.SetCursorPosition(startX + (optionCounter % optionsPerLine) * spacingPerLine, startY + optionCounter / optionsPerLine);

                if(optionCounter == currentSelection)
                    Console.ForegroundColor = ConsoleColor.DarkCyan;

                Console.Write(options[optionCounter]);

                Console.ResetColor();
            }

            key = Console.ReadKey(true).Key;

            switch (key)
            {
                case ConsoleKey.LeftArrow:
                {
                    if (currentSelection % optionsPerLine > 0)
                        currentSelection--;
                    break;
                }
                case ConsoleKey.RightArrow:
                {
                    if (currentSelection % optionsPerLine < optionsPerLine - 1)
                        currentSelection++;
                    break;
                }
                case ConsoleKey.UpArrow:
                {
                    if (currentSelection >= optionsPerLine)
                        currentSelection -= optionsPerLine;
                    break;
                }
                case ConsoleKey.DownArrow:
                {
                    if (currentSelection + optionsPerLine < options.Length)
                        currentSelection += optionsPerLine;
                    break;
                }
                case ConsoleKey.Escape:
                {
                    if (canCancel)
                        return -1;
                    break;
                }
            }
            Console.Clear();
        } while (key != ConsoleKey.Enter);

        Console.CursorVisible = true;

        return currentSelection;
    }
}