using System;
using System.IO;
using Xunit;


namespace day_17
{
    class Program
    {

        static void Main(string[] args)
        {
            Solve("sample2.txt");

            //Assert.Equal(8, Solve("sample1.txt"));
            //Assert.Equal(86, Solve("sample2.txt"));
            //Assert.Equal(132, Solve("sample3.txt"));
            //Assert.Equal(136, Solve("sample4.txt"));
            //Assert.Equal(81, Solve("sample5.txt"));
            //Solve("input.txt");
        }

        static int Solve(string inputfile)
        {
            var lines = File.ReadAllLines(inputfile);

            var matrix = ToChars(lines);

            Run(matrix);

            Print(matrix.Copy());
            return 0;
        }

        static void Run(char[,] matrix)
        {
            Pos cpos = new Pos { l = -1, c = -1 };
            matrix.Op((Pos pos) =>
             {
                 if (matrix.At(pos) == '@')
                     cpos = pos;
             });

            Console.WriteLine($"start at {cpos.l},{cpos.c}");

        }

        static char[,] ToChars(string[] lines)
        {
            char[,] matrix = new char[lines.Length, lines[0].Length];

            for (int i = 0; i < lines.Length; i++)
            {
                for (int j = 0; j < lines[i].Length; j++)
                    matrix[i, j] = lines[i][j];
            }

            return matrix;
        }

        static void Print(char[,] matrix)
        {
            matrix.Op((Pos pos) =>
             {
                 Console.Write(matrix.At(pos));
                 if (pos.c == matrix.GetLength(1) - 1)
                     Console.WriteLine();
             });
        }
    }
}
