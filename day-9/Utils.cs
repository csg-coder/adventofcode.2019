using System;
using System.Collections.Generic;
using System.Text;

namespace day_9
{
    public static class Utils
    {
        public static void print(this long[] ar, int start, int maxlength)
        {
            return;
            Console.Write("\n>");
            for (int i = start; i < maxlength + start; i++)
            {
                Console.Write("{0,5}:", ar[i]);
            }

            Console.WriteLine();
        }
    }
}
