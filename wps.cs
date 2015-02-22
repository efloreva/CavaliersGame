using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;


class Program
{
    static void Main()
    {
        int[,] sudoku = new int[9, 9]; //user numbers + random guess
        //grid dimensions to be set
        int gridTop = 10;
        int gridBottom = 18;
        int gridLeft = 1;
        int gridRight = 18;
        int stepX = 4;
        int stepY = 2;
        int inputValue, x = gridLeft, y = gridTop, i = 0, j = 0; // 'x' and 'y' cursor position, 'i' and 'j' matrix row and column

        Console.SetCursorPosition(x, y);
        while (true)
            while (Console.KeyAvailable)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);

                switch (key.Key)
                {
                    case ConsoleKey.Backspace:
                    case ConsoleKey.Delete:   // Delete the number in this position.                        
                        Console.SetCursorPosition(x + 1, y);
                        Console.Write("\b \b");
                        if (sudoku[i, j] != 0)
                        {
                            inputValue = sudoku[i, j];
                            sudoku[i, j] = 0;
                        }
                        break;
                    case ConsoleKey.LeftArrow:  // Move a position to the left.                        
                        if (x - stepX >= gridLeft)
                        {
                            Console.SetCursorPosition(x -= stepX, y);
                            j--;
                        }
                        break;
                    case ConsoleKey.RightArrow:  // Move a position to the right.                        
                        if (x + stepX <= gridRight)
                        {
                            Console.SetCursorPosition(x += stepX, y);
                            j++;
                        }
                        break;
                    case ConsoleKey.UpArrow:  // Move a position upwards.                        
                        if (y - stepY >= gridTop)
                        {
                            Console.SetCursorPosition(x, y -= stepY);
                            i--;
                        }
                        break;
                    case ConsoleKey.DownArrow:  // Move a position downwards.                        
                        if (y + stepY <= gridBottom)
                        {
                            Console.SetCursorPosition(x, y += stepY);
                            i++;
                        }
                        break;
                    case ConsoleKey.Escape:  // Finish the program.                        
                        Environment.Exit(0);
                        break;
                    default:
                        if (key.KeyChar >= '1' && key.KeyChar <= '9')
                        {
                            inputValue = int.Parse(key.KeyChar.ToString());
                            sudoku[i, j] = inputValue;

                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write(inputValue);

                            Console.SetCursorPosition(x, y);
                        }
                        else
                        {
                            Console.SetCursorPosition(gridRight, gridBottom);
                            Console.Write("Invalid input");
                        }
                        break;
                }
            }
    }
}
