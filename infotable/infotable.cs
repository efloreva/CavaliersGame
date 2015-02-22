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

        const int maxProgressBarLength = 40;
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

    static void TheNumber(int number,int horisontal,int vertical)
        {

            char sign = '#';
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
                    PrintStringAtPosition(horisontal,vertical + 1,  new string (sign,3), ConsoleColor.Green);
                    PrintStringAtPosition(horisontal,vertical + 2, "  " + sign, ConsoleColor.Green);
                    PrintStringAtPosition(horisontal,vertical + 3, new string(sign, 3), ConsoleColor.Green);
                    PrintStringAtPosition(horisontal,vertical + 4, sign+ "  " , ConsoleColor.Green);
                    PrintStringAtPosition(horisontal,vertical + 5, new string(sign, 3), ConsoleColor.Green);
                    
                    break;
                case 3:
                    PrintStringAtPosition(horisontal, vertical + 1, new string(sign, 3), ConsoleColor.Green);
                    PrintStringAtPosition(horisontal, vertical + 2, "  " + sign, ConsoleColor.Green);
                    PrintStringAtPosition(horisontal, vertical + 3, " "+new string(sign, 2), ConsoleColor.Green);
                    PrintStringAtPosition(horisontal, vertical + 4, "  "+ sign , ConsoleColor.Green);
                    PrintStringAtPosition(horisontal, vertical + 5, new string(sign, 3), ConsoleColor.Green);

                    break;
                case 4:
                    PrintStringAtPosition(horisontal, vertical + 1, sign+" "+ sign, ConsoleColor.Green);
                    PrintStringAtPosition(horisontal, vertical + 2, sign + " " + sign, ConsoleColor.Green);
                    PrintStringAtPosition(horisontal, vertical + 3,  new string(sign, 3), ConsoleColor.Green);
                    PrintStringAtPosition(horisontal, vertical + 4, "  " + sign, ConsoleColor.Green);
                    PrintStringAtPosition(horisontal, vertical + 5, "  " + sign, ConsoleColor.Green);

                    break;
                case 5:
                    PrintStringAtPosition(horisontal, vertical + 1, new string(sign, 3), ConsoleColor.Green);
                    PrintStringAtPosition(horisontal, vertical + 2, sign + "  ", ConsoleColor.Green);
                    PrintStringAtPosition(horisontal, vertical + 3, new string(sign, 3), ConsoleColor.Green);
                    PrintStringAtPosition(horisontal, vertical + 4,  "  "+ sign , ConsoleColor.Green);
                    PrintStringAtPosition(horisontal, vertical + 5, new string(sign, 3), ConsoleColor.Green);
                    break;
                case 6:
                    PrintStringAtPosition(horisontal, vertical + 1, new string(sign, 3), ConsoleColor.Green);
                    PrintStringAtPosition(horisontal, vertical + 2, sign + "  ", ConsoleColor.Green);
                    PrintStringAtPosition(horisontal, vertical + 3, new string(sign, 3), ConsoleColor.Green);
                    PrintStringAtPosition(horisontal, vertical + 4,  sign + " "+ sign , ConsoleColor.Green);
                    PrintStringAtPosition(horisontal, vertical + 5, new string(sign, 3), ConsoleColor.Green);

                    break;
                case 7:
                    PrintStringAtPosition(horisontal, vertical + 1, new string(sign, 3), ConsoleColor.Green);
                    PrintStringAtPosition(horisontal, vertical + 2, sign + " "+sign, ConsoleColor.Green);
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
        var startTime = DateTime.Now;
        new Thread(title).Start();
        var count = 22;
        while (true)
        {
            for (int i = 0; i < Console.WindowWidth; i++) // Score Divider
            {
                PrintAtPosition(i, 5, '-', ConsoleColor.Gray);
                PrintAtPosition(i, 0, '-', ConsoleColor.Gray);
                //vertical left
                PrintAtPosition(0, 1, '|', ConsoleColor.Gray);
                PrintAtPosition(0, 2, '|', ConsoleColor.Gray);
                PrintAtPosition(0, 3, '|', ConsoleColor.Gray);
                PrintAtPosition(0, 4, '|', ConsoleColor.Gray);
                //vertical right
                PrintAtPosition(Console.WindowWidth-1, 1, '|', ConsoleColor.Gray);
                PrintAtPosition(Console.WindowWidth-1, 2, '|', ConsoleColor.Gray);
                PrintAtPosition(Console.WindowWidth-1, 3, '|', ConsoleColor.Gray);
                PrintAtPosition(Console.WindowWidth-1, 4, '|', ConsoleColor.Gray);
            }
            PrintStringAtPosition(5, 1, "Team Cavalier Sudoku: ", ConsoleColor.Green);
            TheNumber(8, 5,7);
            TheNumber(9, 9,12);


            PrintStringAtPosition(15, 3, "Entered "+ count+"/81: ", ConsoleColor.Blue);

            var dateTwo = DateTime.Now;
            var diff = dateTwo.Subtract(startTime);
            var res = String.Format("{0} min. and ->{1} seconds", diff.Minutes, diff.Seconds);
            PrintStringAtPosition(15, 4, "Played Time: " + (res), ConsoleColor.Green);



        }
    }

}

