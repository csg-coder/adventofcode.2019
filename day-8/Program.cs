using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace day_8
{
    class Program
    {
        public static void Main(string[] args)
        {
            var input = File.ReadAllText("input.txt");
            //var input = File.ReadAllText("input-test.txt");
            var ret = Problem1.Run(input, 6, 25);
            Console.WriteLine(ret); //1206

            Problem2.Run(input, 6, 25);//EJRGP
            //Problem2.Run(input, 2, 2);
        }
    }
}

