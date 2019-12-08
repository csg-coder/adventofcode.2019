using System;
using System.IO;
using Xunit;

namespace day_8
{
    class Program
    {
        public static void Main(string[] args)
        {
            var input_sample = File.ReadAllText("input-test.txt");
            var input = File.ReadAllText("input.txt");

            var ret = Problem1.Run(input, 6, 25);
            Console.WriteLine(ret);
            Assert.Equal(1206, ret);

            var imgret2 = Problem2.Run(input_sample, 2, 2);
            var expected = @"0110";
            Console.WriteLine(imgret2);
            Assert.Equal(expected, imgret2.Combine());

            var imgret = Problem2.Run(input, 6, 25);
            var sln = @"111100011011100011001110010000000101001010010100101110000010100101000010010100000001011100101101110010000100101010010010100001111001100100100111010000";
            imgret.ShowMatrix(6, 25);
            imgret.DrawMatrix(6, 25);
            Console.WriteLine(imgret.Combine());
            Assert.Equal(sln, imgret.Combine());
        }
    }
}

