using System;
using System.Collections.Generic;
using System.IO;
using Xunit;

namespace day_14
{
    class Reaction
    {
        public string Result { get; set; }
        public long Quantity { get; set; }
        public Dictionary<string, long> Raw { get; set; }
    }
    class Program
    {

        static void Main(string[] args)
        {
            Assert.Equal(31, Solve1("sample1.txt"));
            Assert.Equal(165, Solve1("sample2.txt"));
            Assert.Equal(13312, Solve1("large-sample1.txt"));
            Assert.Equal(180697, Solve1("large-sample2.txt"));
            Assert.Equal(2210736, Solve1("large-sample3.txt"));
            Assert.Equal(374457, Solve1("input.txt"));

            Assert.Equal(82892753, Solve2("large-sample1.txt", 990 * (long)1000000000));
            Assert.Equal(5586022, Solve2("large-sample2.txt", 990 * (long)1000000000));
            Assert.Equal(460664, Solve2("large-sample3.txt", 990 * (long)1000000000));
            Assert.Equal(3568888, Solve2("input.txt", 990 * (long)1000000000));

        }

        static Dictionary<string, long> Raw { get; set; }
        static Dictionary<string, Reaction> reactions { get; set; }
        static long ore;

        private static long Solve1(string input)
        {
            reactions = Read(input);
            Raw = new Dictionary<string, long>();
            foreach (var compound in reactions)
            {
                Raw[compound.Key] = 0;
            }

            ore = 0;

            Consume("FUEL", 1);
            Console.WriteLine(ore);
            return ore;
        }
        private static long Solve2(string input, long bulk_ore)
        {
            reactions = Read(input);
            Raw = new Dictionary<string, long>();
            foreach (var compound in reactions)
            {
                Raw[compound.Key] = 0;
            }

            ore = 0;

            var fuel = 0;
            var multiplier = 10000;

            while (ore < 1000000000000)
            {
                if (ore > bulk_ore)
                    multiplier = 1;

                if (fuel % 100000 == 0)
                    //Console.WriteLine($"{ore}=>{fuel}");
                    Console.Write($".");
                Consume("FUEL", multiplier);
                fuel += multiplier;
            }
            fuel -= multiplier;
            Console.WriteLine(fuel);
            return fuel;
        }
        static void Reaction(string compound, long needed)
        {
            var instances = (long)Math.Ceiling(1.0 * needed / reactions[compound].Quantity);
            //var instances = 1;

            foreach (var raw in reactions[compound].Raw)
            {
                if (raw.Key == "ORE")
                    ore += raw.Value * instances;
                else
                {
                    Consume(raw.Key, raw.Value * instances);
                }
            }
            //produced
            Raw[compound] += reactions[compound].Quantity * instances;

        }

        static void Consume(string compound, long quantity)
        {
            ////Produce while not not have enough
            //while (quantity > Raw[compound])
            //{
            //    Reaction(compound, quantity);
            //}
            if (quantity > Raw[compound])
            {
                Reaction(compound, quantity - Raw[compound]);
            }

            //Consume
            Raw[compound] -= quantity;
            //if (quantity < Raw[compound])
            //{
            //    Console.Write("!");
            //}
            return;

        }

        private static Dictionary<string, Reaction> Read(string input)
        {
            var lines = File.ReadAllLines(input);
            var reactions = new Dictionary<string, Reaction>();
            foreach (var item in lines)
            {
                var s = item.Split("=>");
                var sr = s[1].Trim().Split(" ");
                var qty = long.Parse(sr[0]);
                var res = sr[1];
                var reaction = new Reaction
                {
                    Result = res,
                    Quantity = qty,
                    Raw = new Dictionary<string, long>()
                };
                var sl = s[0].Trim().Split(",");
                foreach (var raw in sl)
                {
                    var sraw = raw.Trim().Split(" ");
                    var rqty = long.Parse(sraw[0]);
                    var rres = sraw[1];
                    reaction.Raw.Add(rres, rqty);
                }
                reactions.Add(res, reaction);
            }

            return reactions;
        }
    }
}
