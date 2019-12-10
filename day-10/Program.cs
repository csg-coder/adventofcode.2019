using System;
using System.IO;

namespace day_10
{
    class Program
    {

        static void Main(string[] args)
        {
            var input_sample = File.ReadAllLines("input_sample.txt");//8
            //var input_sample = File.ReadAllLines("input_sample_1.txt");//33
            //var input_sample = File.ReadAllLines("input_sample_2.txt");//35
            //var input_sample = File.ReadAllLines("input_sample_last.txt");//210
            int lines = input_sample.Length;
            int cols = input_sample[0].Length;
            char[,] blocking = new char[lines, cols];

            for (int l = 0; l < lines; l++)
                for (int c = 0; c < cols; c++)
                {
                    blocking[l, c] = input_sample[l][c];
                }
            int[,] res = new int[lines, cols];
            for (int l = 0; l < lines; l++)
                for (int c = 0; c < cols; c++)
                {
                    res[l, c] = 0;
                }

            //var ld = 4;
            //var cd = 3;
            for (int ld = 0; ld < lines; ld++)
                for (int cd = 0; cd < cols; cd++)
                    visibility(lines, cols, blocking, res, ld, cd);

            Show(lines, cols, res, "visibility");
        }

        private static void visibility(int lines, int cols, char[,] blocking, int[,] res, int ld, int cd)
        {
            char[,] b = new char[lines, cols];
            if (blocking[ld, cd] != '#')
                return;


            for (int l = 0; l < lines; l++)
                for (int c = 0; c < cols; c++)
                {
                    b[l, c] = blocking[l, c];
                }

            for (int l = 0; l < lines; l++)
                for (int c = 0; c < cols; c++)
                {
                    if (b[l, c] != '#')
                        continue;

                    var diffl = ld - l;
                    var diffc = cd - c;

                    var max = Math.Max(Math.Abs(diffl), Math.Abs(diffc));

                    for (int i = 2; i <= max; i++)
                        if (Math.Truncate(1.0 * diffl / i) == diffl / i && diffl / i != 0
                            && Math.Truncate(1.0 * diffc / i) == diffc / i && diffc / i != 0)
                        {
                            diffl = diffl / i;

                            diffc = diffc / i;
                        }

                    if (diffl == 0 && diffc == 0)
                        continue;

                    if (diffl == 0)
                        diffc = diffc / Math.Abs(diffc);

                    if (diffc == 0)
                        diffl = diffl / Math.Abs(diffl);


                    int bl = l - diffl;
                    int bc = c - diffc;
                    while (0 <= bl && bl < lines && 0 <= bc && bc < cols)
                    {
                        b[bl, bc] = b[bl, bc] == '#' ? 'x' : 'b';
                        bl -= diffl;
                        bc -= diffc;
                    }
                    //Show(lines, cols, b, $"blocked by {l}{c}");
                    //Console.ReadLine();
                }
            for (int l = 0; l < lines; l++)
                for (int c = 0; c < cols; c++)
                    if (b[l, c] == '#' && !(l == ld && c == cd))
                        res[ld, cd]++;

            //Show(lines, cols, b, $"{ld}{cd}");
        }
        private static void Show(int lines, int cols, int[,] b, string msg)
        {
            var max = 0;
            Console.WriteLine(msg);
            for (int l = 0; l < lines; l++)
            {
                for (int c = 0; c < cols; c++)
                {
                    Console.Write(b[l, c] + " ");
                    max = Math.Max(max, b[l, c]);
                }

                Console.WriteLine();
            }
            Console.WriteLine($"max is {max}");
        }
        private static void Show(int lines, int cols, char[,] b, string msg)
        {
            Console.WriteLine(msg);
            for (int l = 0; l < lines; l++)
            {
                for (int c = 0; c < cols; c++)
                {
                    Console.Write(b[l, c]);
                }
                Console.WriteLine();
            }
        }
    }
}
