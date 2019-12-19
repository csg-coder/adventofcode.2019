using System;
using System.Collections.Generic;
using System.IO;
using Xunit;


namespace day_18
{
    struct PosMin
    {
        public Pos Pos { get; set; }
        public int Distance { get; set; }

        public char Letter { get; set; }
    }

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

        static Dictionary<char, Pos> keysPos;
        static Dictionary<char, Pos> doorsPos;

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

            keysPos = new Dictionary<char, Pos>();
            doorsPos = new Dictionary<char, Pos>();

            //detect keys
            matrix.Op((Pos pos) =>
            {
                var c = matrix.At(pos);
                if ('a' <= c && c <= 'z')
                    keysPos[c] = pos;
            });
            //detect doors
            matrix.Op((Pos pos) =>
            {
                var c = matrix.At(pos);
                if ('A' <= c && c <= 'Z')
                    doorsPos[c] = pos;
            });

            

            Console.WriteLine($"start at {cpos.l},{cpos.c}");
            Console.WriteLine($"{keysPos.Count} keys");
            foreach (var item in keysPos)
                Console.WriteLine($"{item.Key} at {item.Value.ToString()}");
            Console.WriteLine($"{doorsPos.Count} doors");
            foreach (var item in doorsPos)
                Console.WriteLine($"{item.Key} at {item.Value.ToString()}");

            List<PosMin> keysPosMin = EatKey(matrix, new List<PosMin>(), cpos, '@');

        }

        private static List<PosMin> EatKey(char[,] matrix, List<PosMin> list, Pos cpos, char letter)
        {
            var work_matrix = matrix.Copy();
            var work_list = new List<PosMin>(list);

            //eat key
            var key = new PosMin { Pos = cpos, Letter = letter };
            if (letter == '@')
                key.Distance = 0;
            else
            {
                work_matrix[key.Pos.l, key.Pos.c] = '.';
            }
            //work_list.Add(new PosMin { Letter=letter,Pos cpos,}



            List<PosMin> nextkeys = CalcMinRoadsToVisibleKeys(work_matrix, cpos);

            //foreach (var key in nextkeys)
            //{


            //}

            throw new NotImplementedException();

        }

        private static List<PosMin> CalcMinRoadsToVisibleKeys(char[,] matrix, Pos cpos)
        {
            throw new NotImplementedException();
        }

        static char[,] Shortest(char[,] matrix, Pos pos)
        {
            var work = matrix.Copy();

            return work;
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
