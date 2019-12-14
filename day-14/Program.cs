using System;
using System.Collections.Generic;
using System.IO;
using Xunit;

namespace day_14
{
    class Reaction
    {
        public string Result { get; set; }
        public int Quantity { get; set; }
        public Dictionary<string, int> Raw { get; set; }
    }
    class Program
    {

        static void Main(string[] args)
        {
            Assert.Equal(31, Solve("sample1.txt"));
            Assert.Equal(165, Solve("sample2.txt"));
            Assert.Equal(13312, Solve("large-sample1.txt"));
            Assert.Equal(180697, Solve("large-sample2.txt"));
            Assert.Equal(2210736, Solve("large-sample3.txt"));
            Assert.Equal(374457, Solve("input.txt"));
        }

        static Dictionary<string, int> Raw { get; set; }
        static Dictionary<string, Reaction> reactions { get; set; }
        static int ore;

        private static int Solve(string input)
        {
            reactions = Read(input);
            Raw = new Dictionary<string, int>();
            foreach (var compound in reactions)
            {
                Raw[compound.Key] = 0;
            }

            ore = 0;

            Consume("FUEL", 1);
            Console.WriteLine(ore);
            return ore;
        }

        static void Reaction(string compound)
        {
            foreach (var raw in reactions[compound].Raw)
            {
                if (raw.Key == "ORE")
                    ore += raw.Value;
                else
                {
                    Consume(raw.Key, raw.Value);
                }
            }
            //produced
            Raw[compound] += reactions[compound].Quantity;

        }

        static void Consume(string compound, int quantity)
        {
            //Produce while not not have enough
            while (quantity > Raw[compound])
            {
                Reaction(compound);
            }

            //Consume
            Raw[compound] -= quantity;
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
                var qty = int.Parse(sr[0]);
                var res = sr[1];
                var reaction = new Reaction
                {
                    Result = res,
                    Quantity = qty,
                    Raw = new Dictionary<string, int>()
                };
                var sl = s[0].Trim().Split(",");
                foreach (var raw in sl)
                {
                    var sraw = raw.Trim().Split(" ");
                    var rqty = int.Parse(sraw[0]);
                    var rres = sraw[1];
                    reaction.Raw.Add(rres, rqty);
                }
                reactions.Add(res, reaction);
            }

            return reactions;
        }
    }
}
