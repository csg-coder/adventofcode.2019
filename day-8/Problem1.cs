using System;
using System.IO;
using System.Linq;

namespace day_8
{
    class Problem1
    {
        public static int Run(string input, int lmax, int cmax)
        {
            int pos = 0;
            int minzeros = input.Length;
            int mones = 0;
            int mtwos = 0;
            while (pos < input.Length)
            {
                var r = input.Substring(pos, cmax * lmax);
                var zeros = r.Where(c => c == '0').Count();
                var ones = r.Where(c => c == '1').Count();
                var twos = r.Where(c => c == '2').Count();
                if (zeros < minzeros)
                {
                    (mones, mtwos, minzeros) = (ones, twos, zeros);
                }
                pos += cmax * lmax;
            }
            return mones * mtwos;

        }
    }
}
