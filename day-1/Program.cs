using System;
using System.IO;
using Xunit;
using System.Linq;
using System.Collections.Generic;

namespace day_1
{
    class Program
    {
        static Func<int, int> fuelcalc = (int mass) => { return (int)Math.Truncate(mass / 3.0) - 2; };

        static void Main(string[] args)
        {
            var numbers = File.ReadAllLines("input.txt").Select(o => int.Parse(o));

            Assert.Equal(33583, fuelcalc(100756));
            Assert.Equal(966, fuelcalc_rec(1969));
            Assert.Equal(50346, fuelcalc_rec(100756));

            Assert.Equal(3550236, Problem1(numbers));
            Assert.Equal(5322455, Problem2(numbers));

        }

        private static int Problem1(IEnumerable<int> numbers)
        {
            var res = numbers.Select(o => fuelcalc(o)).Sum();
            Console.WriteLine(res);
            return res;
        }

        private static int Problem2(IEnumerable<int> numbers)
        {
            var res = numbers.Select(o => fuelcalc_rec(o)).Sum();
            Console.WriteLine(res);
            return res;
        }

        static int fuelcalc_rec(int mass)
        {
            int fuelfuel = fuelcalc(mass);

            if (fuelfuel <= 0)
                return 0;

            return fuelfuel + fuelcalc_rec(fuelfuel);
        }
    }
}
