using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;



class infoTable
{
    static void title()
    {

        const int maxProgressBarLength = 28;
        const string progressBarElement = "█";
        //int progressBarElement =1;
        string start = progressBarElement + "Cavalier's Sudoku" + progressBarElement;
        StringBuilder startSB = new StringBuilder(progressBarElement + "Cavalier's Sudoku" + progressBarElement);
        StringBuilder titleSB = new StringBuilder(progressBarElement + "Cavalier's Sudoku" + progressBarElement);



        do
        {
            titleSB.Insert(0, progressBarElement);
            titleSB.Append(progressBarElement);
            titleSB.ToString();
            //Console.WriteLine(titleSB);
            //Console.WriteLine("title{0} start {1}= {2}",titleSB.Length,startSB.Length,titleSB.Length-startSB.Length);


            if (titleSB.Length > maxProgressBarLength)
            {
                //progressBarElement += 1;
                titleSB = new StringBuilder(start);

                //if (progressBarElement >= 10)
                //{
                //    progressBarElement = 1;
                //}
                //titleSB = startSB;
                //Console.WriteLine(new string('$', 50));
            }

            //PrintStringAtPosition(30,10,titleSB);
            Console.Title = titleSB.ToString();
            //Console.Title = "Cavalier";

            Thread.Sleep(160);
        } while (true);

    }

    static void FieldSelector()
    {
        int[,] sudoku = new int[9, 9]; //user numbers + random guess
        //grid dimensions to be set
        int gridTop = 6;
        int gridBottom = 77;
        int gridLeft = 3;
        int gridRight = 77;
        int stepX = 6;
        int stepY = 6;
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
                    case ConsoleKey.LeftArrow:
                        if (x % 22 == 0 || x % 41 == 0)//corections for the grid jumps
                        {
                            x -= 1;
                        }
                        if (x - stepX >= gridLeft)  // Move a position to the left.   
                        {
                            Console.SetCursorPosition(x -= stepX, y);

                            j--;
                        }
                        break;
                    case ConsoleKey.RightArrow:  
                        if (x % 15 == 0||x%34==0)//corections for the grid jumps
                        {
                            x += 1;
                        }

                        if (x + stepX <= gridRight) // Move a position to the right.    
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
                            TheNumber(inputValue, x, y);


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
    static void PrintAtPosition(int x, int y, char symbol, ConsoleColor color)
    {
        Console.SetCursorPosition(x, y);
        Console.ForegroundColor = color;
        Console.Write(symbol);
    }

    static void PrintStringAtPosition(int x, int y, string text, ConsoleColor color)
    {
        Console.SetCursorPosition(x, y);
        Console.ForegroundColor = color;
        Console.Write(text);
    }

    struct Unit
    {
        public int x;
        public int y;
        public ConsoleColor color;
        public char symbol;
    }

    static void VerticalMain(int number, int offset)
    {

        for (int i = offset; i < 17 + offset; i++)
        {
            for (int k = number; k < 59; k += 19)
            {
                PrintStringAtPosition(k, i, "||", ConsoleColor.White);

            }

        }
        // Console.WriteLine("||" + new string(' ', 23) + "||" + new string(' ', 23) + "||" + new string(' ', 23) + "||");

    }
    static void HorizontalInner(int number)
    {

        for (int i = 0; i < number; i++)
        {
            PrintStringAtPosition(i, 0, "|", ConsoleColor.Green);
        }
    }
    static void GridMain(int horizontal, int vertical)
    {

        //vertical left lines
        PrintAtPosition(horizontal, vertical, '=', ConsoleColor.White);


        //Console.Write(new string('=', 59));
        //HorizontalInner(9);
        //VerticalMain(9);
    }
    static void InnerGrid(int number, int offset)
    {
        //vertical inner
        for (int i = offset; i < 17 + offset; i++)
        {
            //for (int k = number; k < 59; k += 25)
            //{
                PrintStringAtPosition(number, i, "|", ConsoleColor.DarkGray);
                PrintStringAtPosition(number + 6, i, "|", ConsoleColor.DarkGray);

            //}
            //horizontal inner
            for (int j = 0; j < number+13; j++)
            {
                PrintStringAtPosition(j, offset + 5, "-", ConsoleColor.DarkGray);
                PrintStringAtPosition(j, offset + 11, "-", ConsoleColor.DarkGray);
              
            }

        }
    }

    static void TheNumber(int number, int horisontal, int vertical)
    {

        char sign = '█';
        switch (number)
        {
            case 1:
                PrintStringAtPosition(horisontal, vertical + 1, "  " + sign, ConsoleColor.Green);
                PrintStringAtPosition(horisontal, vertical + 2, "  " + sign, ConsoleColor.Green);
                PrintStringAtPosition(horisontal, vertical + 3, "  " + sign, ConsoleColor.Green);
                PrintStringAtPosition(horisontal, vertical + 4, "  " + sign, ConsoleColor.Green);
                PrintStringAtPosition(horisontal, vertical + 5, "  " + sign, ConsoleColor.Green);

                break;
            case 2:
                PrintStringAtPosition(horisontal, vertical + 1, new string(sign, 3), ConsoleColor.Green);
                PrintStringAtPosition(horisontal, vertical + 2, "  " + sign, ConsoleColor.Green);
                PrintStringAtPosition(horisontal, vertical + 3, new string(sign, 3), ConsoleColor.Green);
                PrintStringAtPosition(horisontal, vertical + 4, sign + "  ", ConsoleColor.Green);
                PrintStringAtPosition(horisontal, vertical + 5, new string(sign, 3), ConsoleColor.Green);

                break;
            case 3:
                PrintStringAtPosition(horisontal, vertical + 1, new string(sign, 3), ConsoleColor.Green);
                PrintStringAtPosition(horisontal, vertical + 2, "  " + sign, ConsoleColor.Green);
                PrintStringAtPosition(horisontal, vertical + 3, " " + new string(sign, 2), ConsoleColor.Green);
                PrintStringAtPosition(horisontal, vertical + 4, "  " + sign, ConsoleColor.Green);
                PrintStringAtPosition(horisontal, vertical + 5, new string(sign, 3), ConsoleColor.Green);

                break;
            case 4:
                PrintStringAtPosition(horisontal, vertical + 1, sign + " " + sign, ConsoleColor.Green);
                PrintStringAtPosition(horisontal, vertical + 2, sign + " " + sign, ConsoleColor.Green);
                PrintStringAtPosition(horisontal, vertical + 3, new string(sign, 3), ConsoleColor.Green);
                PrintStringAtPosition(horisontal, vertical + 4, "  " + sign, ConsoleColor.Green);
                PrintStringAtPosition(horisontal, vertical + 5, "  " + sign, ConsoleColor.Green);

                break;
            case 5:
                PrintStringAtPosition(horisontal, vertical + 1, new string(sign, 3), ConsoleColor.Green);
                PrintStringAtPosition(horisontal, vertical + 2, sign + "  ", ConsoleColor.Green);
                PrintStringAtPosition(horisontal, vertical + 3, new string(sign, 3), ConsoleColor.Green);
                PrintStringAtPosition(horisontal, vertical + 4, "  " + sign, ConsoleColor.Green);
                PrintStringAtPosition(horisontal, vertical + 5, new string(sign, 3), ConsoleColor.Green);
                break;
            case 6:
                PrintStringAtPosition(horisontal, vertical + 1, new string(sign, 3), ConsoleColor.Green);
                PrintStringAtPosition(horisontal, vertical + 2, sign + "  ", ConsoleColor.Green);
                PrintStringAtPosition(horisontal, vertical + 3, new string(sign, 3), ConsoleColor.Green);
                PrintStringAtPosition(horisontal, vertical + 4, sign + " " + sign, ConsoleColor.Green);
                PrintStringAtPosition(horisontal, vertical + 5, new string(sign, 3), ConsoleColor.Green);

                break;
            case 7:
                PrintStringAtPosition(horisontal, vertical + 1, new string(sign, 3), ConsoleColor.Green);
                PrintStringAtPosition(horisontal, vertical + 2, sign + " " + sign, ConsoleColor.Green);
                PrintStringAtPosition(horisontal, vertical + 3, "  " + sign, ConsoleColor.Green);
                PrintStringAtPosition(horisontal, vertical + 4, "  " + sign, ConsoleColor.Green);
                PrintStringAtPosition(horisontal, vertical + 5, "  " + sign, ConsoleColor.Green);

                break;
            case 8:
                PrintStringAtPosition(horisontal, vertical + 1, new string(sign, 3), ConsoleColor.Green);
                PrintStringAtPosition(horisontal, vertical + 2, sign + " " + sign, ConsoleColor.Green);
                PrintStringAtPosition(horisontal, vertical + 3, new string(sign, 3), ConsoleColor.Green);
                PrintStringAtPosition(horisontal, vertical + 4, sign + " " + sign, ConsoleColor.Green);
                PrintStringAtPosition(horisontal, vertical + 5, new string(sign, 3), ConsoleColor.Green);

                break;
            case 9:
                PrintStringAtPosition(horisontal, vertical + 1, new string(sign, 3), ConsoleColor.Green);
                PrintStringAtPosition(horisontal, vertical + 2, sign + " " + sign, ConsoleColor.Green);
                PrintStringAtPosition(horisontal, vertical + 3, new string(sign, 3), ConsoleColor.Green);
                PrintStringAtPosition(horisontal, vertical + 4, "  " + sign, ConsoleColor.Green);
                PrintStringAtPosition(horisontal, vertical + 5, new string(sign, 3), ConsoleColor.Green);

                break;

           

            default: Console.WriteLine(" dsa"); break;


        }




    }
    static void Main()
    {
        Console.WindowWidth = 59;
        var startTime = DateTime.Now;
        new Thread(title).Start();
        var count = 22;
        while (true)
        {
            for (int i = 0; i < Console.WindowWidth; i++) // Score Divider
            {
                PrintStringAtPosition(i, 5, "-", ConsoleColor.Gray);
                PrintStringAtPosition(i, 0, "-", ConsoleColor.Gray);
                //vertical left
                for (int g = 1; g < 5; g++)
                {
                    PrintStringAtPosition(0, g, "|", ConsoleColor.Gray);
                }

                //vertical right
                PrintAtPosition(Console.WindowWidth - 1, 1, '|', ConsoleColor.Gray);
                PrintAtPosition(Console.WindowWidth - 1, 2, '|', ConsoleColor.Gray);
                PrintAtPosition(Console.WindowWidth - 1, 3, '|', ConsoleColor.Gray);
                PrintAtPosition(Console.WindowWidth - 1, 4, '|', ConsoleColor.Gray);

                GridMain(i, 6);
                GridMain(i, 6 + 18); // +9 to skip the cell spaces
                GridMain(i, 6 + 18 * 2); // +9 to skip the cell spaces
                GridMain(i, 6 + 18 * 3); // +9 to skip the cell spaces
                
                
            }

           
            //first column
            InnerGrid(5 + 2, 7);
            InnerGrid(5 + 2, 25);
            InnerGrid(5 + 2, 43);
            //first column END

            //second column
            InnerGrid(19 + 5 + 2, 7);
            InnerGrid(19 + 5 + 2, 25);
            InnerGrid(19+ 5 + 2, 43);
            //second column END
            //thurd column
            InnerGrid(38 + 5 + 2, 7);
            InnerGrid(38 + 5 + 2, 25);
            InnerGrid(38 + 5 + 2, 43);
            //thurd column END
            //VerticalMain 
            VerticalMain(0, 7);
            VerticalMain(0, 7 + 17);
            VerticalMain(0, 7 + 17 * 2);
            VerticalMain(0, 7 + 18 * 2);
            //VerticalMain  END

            PrintStringAtPosition(5, 1, "Team Cavalier Sudoku: ", ConsoleColor.Green);

            PrintStringAtPosition(15, 3, "Entered " + count + "/81: ", ConsoleColor.Blue);

            var dateTwo = DateTime.Now;
            var diff = dateTwo.Subtract(startTime);
            var res = String.Format("{0} min. and ->{1} seconds", diff.Minutes, diff.Seconds);
            PrintStringAtPosition(15, 4, "Played Time: " + (res), ConsoleColor.Green);

            FieldSelector();

        }
    }

}

