using System;
using System.IO;
using Xunit;
using System.Linq;

namespace day_1
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = File.ReadAllLines("input.txt").Select(o => int.Parse(o));

            Func<int, int> fuel = (int mass) => { return (int)Math.Truncate(mass / 3.0) - 2; };
            Assert.Equal(33583, fuel(100756));

            var res=numbers.Select(o => fuel(o)).Sum();
            Assert.Equal(3550236, res);
            Console.WriteLine(res);
        }
    }
}
