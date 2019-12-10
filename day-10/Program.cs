using System;
using System.IO;

namespace day_10
{
    class Program
    {

        static void Main(string[] args)
        {
            var input_sample = File.ReadAllLines("input_sample.txt");
            int lines = input_sample.Length;
            int cols = input_sample[0].Length;
            char[,] blocking = new char[lines, cols];

            for (int l = 0; l < lines; l++)
                for (int c = 0; c < cols; c++)
                {
                    blocking[l, c] = input_sample[l][c];
                }

            var ld = 4;
            var cd = 3;

            char[,] b = new char[lines, cols];
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

                    var abs_diffl = Math.Abs(ld - l);
                    var abs_diffc = Math.Abs(cd - c);

                    var max = Math.Max(Math.Abs(abs_diffl), Math.Abs(abs_diffc));

                    for (int i = 2; i <= max; i++)
                        if (Math.Truncate(1.0 * abs_diffl / i) == abs_diffl / i && abs_diffl / i > 0
                            && Math.Truncate(1.0 * abs_diffc / i) == abs_diffc / i && abs_diffc / i > 0)
                        {
                            abs_diffl = abs_diffl / i;

                            abs_diffc = abs_diffc / i;
                        }

                    if (abs_diffl == 0 && abs_diffc == 0)
                        continue;



                    var first = true;
                    for (int bl = ld - l; 0 <= bl && bl < lines; bl -= abs_diffl)
                        for (int bc = cd - c; 0 <= bc && bc < cols; bc -= abs_diffc)
                        {
                            if (first)
                            {
                                first = false;
                                continue;
                            }
                            b[bl, bc] = 'x';
                        }
                }
            Show(lines, cols, b, $"{ld}{cd}");
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
