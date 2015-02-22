using System;
using System.IO;
using System.Text;

namespace Sudoku
{
    class Sudoku
    {
        // Arrays with Sudoku - unsolved and solved
        static int[,] sudokuTask = new int[9, 9];
        static int[,] sudokuSolved = new int[9, 9];
        // Bool array with locked positions corresponding to the numbers in the unsolved Sudoku 
        static bool[,] isPositionLocked = new bool[9, 9];

        static void ReadSudoku()
        {
            // Using Random to create a random number corresponding to a file with Sudoku
            Random rand = new Random();
            int fileNumber = rand.Next(1, 3);

            // Using StringBuilder to create a filePath to the file with Sudoku
            StringBuilder filePath = new StringBuilder();
            filePath.Append(@"..\..\sudoku");
            filePath.Append(fileNumber);
            filePath.Append(".txt");

            try
            {
                // Using StreamReader to read Sudoku from the randomly selected file
                StreamReader reader = new StreamReader(filePath.ToString());
                using (reader)
                {
                    // Fill sudokuTask array from the first 9 rows of the file
                    for (int i = 0; i < 9; i++)
                    {
                        string line = reader.ReadLine();

                        for (int j = 0; j < 9; j++)
                        {
                            if (line[j] == '-')
                            {
                                sudokuTask[i, j] = 0;
                            }
                            else
                            {
                                sudokuTask[i, j] = line[j] - '0';
                                isPositionLocked[i, j] = true;
                            }
                        }
                    }

                    // Fill sudokuSolved array from the next 9 rows of the file
                    for (int i = 0; i < 9; i++)
                    {
                        string line = reader.ReadLine();

                        for (int j = 0; j < 9; j++)
                        {
                            sudokuSolved[i, j] = line[j] - '0';
                        }
                    }
                }
            }
            // Exception handling in case file not found
            catch (FileNotFoundException fnf)
            {
                Console.WriteLine(fnf.Message);
            }
            
        }

        static void PrintSudoku(int[,] sudoku)
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Console.Write("{0}", sudoku[i, j]);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        static void Main()
        {
            ReadSudoku();
            PrintSudoku(sudokuTask);
            PrintSudoku(sudokuSolved);
        }
    }
}
