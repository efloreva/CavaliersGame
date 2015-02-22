using System;



    class printNumber
    {

        static string TheNumber(int number)
        {

            string sign = "#";
            switch (number)
            {
                case 1:
                    PrintStringAtPosition(5, 1, ".." + sign, ConsoleColor.Green);
                    PrintStringAtPosition(5, 2, ".." + sign, ConsoleColor.Green);
                    PrintStringAtPosition(5, 3, ".." + sign, ConsoleColor.Green);
                    PrintStringAtPosition(5, 4, ".." + sign, ConsoleColor.Green);
                    PrintStringAtPosition(5, 5, ".." + sign, ConsoleColor.Green);
                     "\n.." + sign + "\n.." + sign + "\n.." + sign + "\n.." + sign
                    break;
                case 2:
                    Console.WriteLine(@"..|
                                        ..|
                                        ..|
                                        ..|
                                        ..|");
                    break;


                default: Console.WriteLine(" dsa"); break;


            }

        
        
        
        }
        static void Main()
        {
            int input=1;
            char sign='|';


            

        }
    }

