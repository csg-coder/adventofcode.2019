using System;
using System.IO;
using System.Linq;

namespace day_8
{
    class Program1
    {
        static void Main(string[] args)
        {
            var input = File.ReadAllText("input.txt");
            //Console.WriteLine(input);
            int pos = 0;
            int minzeros = 1000000;
            int mones = 0;
            int mtwos = 0;
            //Console.WriteLine(input.Length);
            while (pos < input.Length)
            {
                var r = input.Substring(pos, 25 * 6);
                var zeros = r.Where(c => c == '0').Count();
                var ones = r.Where(c => c == '1').Count();
                var twos = r.Where(c => c == '2').Count();
                if (zeros < minzeros)
                {
                    //Console.WriteLine(zeros);
                    mones = ones;
                    mtwos = twos;
                    minzeros = zeros;
                }
                pos += 25 * 6;
            }
            Console.WriteLine(mones * mtwos);
        }
    }
}
