using System;
using System.Collections.Generic;
using System.IO;

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
            var input = "sample1.txt";
            int count = Solve(input);
            Console.WriteLine(count);
        }

        private static int Solve(string input)
        {
            Dictionary<string, Reaction> reactions = Read(input);
            int count = reactions.Count;
            return count;
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
