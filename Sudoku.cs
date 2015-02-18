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
