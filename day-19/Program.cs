using System;
using System.Collections.Generic;
using Xunit;

namespace day_19
{
    class day_19
    {
        static void Main(string[] args)
        {

            var program = new long[] { 109, 424, 203, 1, 21101, 0, 11, 0, 1105, 1, 282, 21101, 18, 0, 0, 1105, 1, 259, 1202, 1, 1, 221, 203, 1, 21102, 1, 31, 0, 1106, 0, 282, 21102, 38, 1, 0, 1106, 0, 259, 21002, 23, 1, 2, 22102, 1, 1, 3, 21102, 1, 1, 1, 21102, 1, 57, 0, 1105, 1, 303, 2102, 1, 1, 222, 20101, 0, 221, 3, 21001, 221, 0, 2, 21102, 259, 1, 1, 21102, 1, 80, 0, 1106, 0, 225, 21102, 62, 1, 2, 21101, 91, 0, 0, 1105, 1, 303, 2101, 0, 1, 223, 21001, 222, 0, 4, 21101, 0, 259, 3, 21101, 0, 225, 2, 21101, 0, 225, 1, 21101, 0, 118, 0, 1105, 1, 225, 20102, 1, 222, 3, 21101, 94, 0, 2, 21102, 133, 1, 0, 1105, 1, 303, 21202, 1, -1, 1, 22001, 223, 1, 1, 21101, 0, 148, 0, 1105, 1, 259, 1202, 1, 1, 223, 20101, 0, 221, 4, 21001, 222, 0, 3, 21102, 17, 1, 2, 1001, 132, -2, 224, 1002, 224, 2, 224, 1001, 224, 3, 224, 1002, 132, -1, 132, 1, 224, 132, 224, 21001, 224, 1, 1, 21101, 195, 0, 0, 105, 1, 109, 20207, 1, 223, 2, 20101, 0, 23, 1, 21102, -1, 1, 3, 21101, 214, 0, 0, 1106, 0, 303, 22101, 1, 1, 1, 204, 1, 99, 0, 0, 0, 0, 109, 5, 2101, 0, -4, 249, 22102, 1, -3, 1, 22101, 0, -2, 2, 21201, -1, 0, 3, 21102, 1, 250, 0, 1106, 0, 225, 22101, 0, 1, -4, 109, -5, 2105, 1, 0, 109, 3, 22107, 0, -2, -1, 21202, -1, 2, -1, 21201, -1, -1, -1, 22202, -1, -2, -2, 109, -3, 2106, 0, 0, 109, 3, 21207, -2, 0, -1, 1206, -1, 294, 104, 0, 99, 22101, 0, -2, -2, 109, -3, 2106, 0, 0, 109, 5, 22207, -3, -4, -1, 1206, -1, 346, 22201, -4, -3, -4, 21202, -3, -1, -1, 22201, -4, -1, 2, 21202, 2, -1, -1, 22201, -4, -1, 1, 21201, -2, 0, 3, 21101, 343, 0, 0, 1106, 0, 303, 1105, 1, 415, 22207, -2, -3, -1, 1206, -1, 387, 22201, -3, -2, -3, 21202, -2, -1, -1, 22201, -3, -1, 3, 21202, 3, -1, -1, 22201, -3, -1, 2, 22102, 1, -4, 1, 21102, 384, 1, 0, 1105, 1, 303, 1105, 1, 415, 21202, -4, -1, -4, 22201, -4, -3, -4, 22202, -3, -2, -2, 22202, -2, -4, -4, 22202, -3, -2, -3, 21202, -4, -1, -2, 22201, -3, -2, 1, 21201, 1, 0, -4, 109, -5, 2105, 1, 0 };
            Assert.Equal(223, Solve1(program));
            Assert.Equal(223, Solve1_version2(program));
            //Solve2(program, 50);
        }

        private static int Solve1(long[] program)
        {
            var cnt = 0;
            for (int i = 0; i < 50; i++)
                for (int j = 0; j < 50; j++)
                    if (Computer.Process(program, new string[] { i.ToString(), j.ToString() }) == "1")
                        cnt++;
            Console.WriteLine(cnt);
            return cnt;
        }
        
        private static int Solve1_version2(long[] program)
        {
            List<Tuple<int, int>> beam = DetectBeam(program, 50);
            var cnt = 0;
            for (int i = 0; i < beam.Count; i++)
            {
                //Console.WriteLine($"{beam[i].Item1}-{beam[i].Item2}");
                if (i < 50)
                    if (beam[i].Item1 != -1)
                        cnt += beam[i].Item2 - beam[i].Item1 + 1;
            }
            Console.WriteLine(cnt);
            return cnt;
        }

        private static int Solve2(long[] program, int squaresize)
        {
            List<Tuple<int, int>> beam = DetectBeam(program, squaresize);
            var cnt = 0;
            for (int i = 0; i < beam.Count; i++)
            {
                Console.WriteLine($"{beam[i].Item1}-{beam[i].Item2}");
                if (i < 50)
                    if (beam[i].Item1 != -1)
                        cnt += beam[i].Item2 - beam[i].Item1 + 1;
            }
            Console.WriteLine(cnt);
            return cnt;
        }

        private static List<Tuple<int, int>> DetectBeam(long[] program, int squaresize)
        {
            var beam = new List<Tuple<int, int>>();

            var l = 0;
            var c = 0;
            while (l < squaresize)
            {
                c = 0;
                var encountered = false;
                var start = -1;
                var end = -1;
                while (c < squaresize)
                {
                    var pulled = Computer.Process(program, new string[] { l.ToString(), c.ToString() }) == "1";
                    if (pulled)
                    {
                        if (!encountered)
                            start = c;
                        encountered = true;
                        end = c;
                    }
                    if (!pulled)
                    {
                        if (encountered)
                        {
                            break;
                        }
                    }
                    c++;
                }
                var t = new Tuple<int, int>(start, end);
                beam.Add(t);
                //Console.WriteLine($"{l}:{t.Item1}-{t.Item2}");

                l++;
            }

            return beam;
        }
    }
}
