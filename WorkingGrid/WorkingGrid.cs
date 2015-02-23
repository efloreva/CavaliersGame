using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class WorkingGrid
{
    //Uses the PrintAtPosition and PrintStringAtPosition methods from infotable.cs
    static void VerticalMain(int number, int offset)
    {

        for (int i = offset; i < 17 + offset; i++)
        {
            for (int k = number; k < 59; k += 19)
            {
                PrintStringAtPosition(k, i, "||", ConsoleColor.White);

            }
        }
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

    }
    static void InnerGrid(int number, int offset)
    {
        //vertical inner
        for (int i = offset; i < 17 + offset; i++)
        {
            PrintStringAtPosition(number, i, "|", ConsoleColor.DarkGray);
            PrintStringAtPosition(number + 6, i, "|", ConsoleColor.DarkGray);

            //horizontal inner
            for (int j = 0; j < number + 13; j++)
            {
                PrintStringAtPosition(j, offset + 5, "-", ConsoleColor.DarkGray);
                PrintStringAtPosition(j, offset + 11, "-", ConsoleColor.DarkGray);

            }

        }
    }
    static void Main(string[] args)
    {
        //other main code here
        while (true)
        {
            for (int i = 0; i < Console.WindowWidth; i++) // Score Divider of Marin
            {

                //other main code here
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
            InnerGrid(19 + 5 + 2, 43);
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

            //other main code here
        }
    }
}