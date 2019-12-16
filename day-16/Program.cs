using System;
using System.Threading.Tasks;
using Xunit;

namespace day_16
{
    class Program
    {
        static void Main(string[] args)
        {
            var puzzle = "59728776137831964407973962002190906766322659303479564518502254685706025795824872901465838782474078135479504351754597318603898249365886373257507600323820091333924823533976723324070520961217627430323336204524247721593859226704485849491418129908885940064664115882392043975997862502832791753443475733972832341211432322108298512512553114533929906718683734211778737511609226184538973092804715035096933160826733751936056316586618837326144846607181591957802127283758478256860673616576061374687104534470102346796536051507583471850382678959394486801952841777641763547422116981527264877636892414006855332078225310912793451227305425976335026620670455240087933409";

            //Assert.Equal("01029498", Solve1("12345678", 4));
            //Assert.Equal("24176176", Solve1("80871224585914546619083218645595", 100));
            //Assert.Equal("73745418", Solve1("19617804207202209144916044189917", 100));
            //Assert.Equal("52432133", Solve1("69317163492948606335995924319873", 100));
            //Assert.Equal("76795888", Solve1(puzzle, 100));

            Assert.Equal("84462026", Solve2("03036732577212944063491565474664", 100));
            Assert.Equal("78725270", Solve2("02935109699940807407585447034323", 100));
            Assert.Equal("53553731", Solve2("03081770884921959731165446850517", 100));
            //Solve2(puzzle, 100);

        }

        static string Solve1(string input, int phases)
        {
            byte[] num = new byte[input.Length];
            for (int i = 0; i < input.Length; i++)
            {
                num[i] = byte.Parse(input[i].ToString());
            }

            for (int i = 0; i < phases; i++)
                Run1(num, 0);

            string output = tostring(num, 8);
            Console.WriteLine(output);
            return output;
        }

        static string Solve2(string input, int phases)
        {
            var repeatinput = 10000;

            byte[] num = new byte[input.Length * repeatinput];
            long[] occ = new long[input.Length * repeatinput];

            for (int i = 0; i < input.Length; i++)
            {
                byte val = byte.Parse(input[i].ToString());
                for (int rep = 0; rep < repeatinput; rep++)
                    num[i + rep * input.Length] = val;
            }

            var offset = int.Parse(tostring(num, 7));
            Console.WriteLine($"offset={offset}");

            for (int i = 0; i < phases; i++)
            {
                Console.WriteLine($"phase {i}");
                Run2(num, occ, offset);
            }

            string output = tostring(num, 8, offset);
            Console.WriteLine(output);
            return output;
        }

        private static string tostring(byte[] num, int len, int offset = 0)
        {
            var output = "";
            for (int i = 0; i < len; i++)
            {
                output += num[i + offset].ToString();
            }

            return output;
        }
        private static void Run1(byte[] num, int start)
        {
            byte[] origin = num.Clone() as byte[];

            var reporting = 1000;
            Console.WriteLine($"total: {(num.Length - start) / reporting} times start at {DateTime.Now}");
            Parallel.For(start, num.Length, (int i) =>
            {

                int sum1 = 0;
                int sum2 = 0;
                var rep = i + 1;

                //find the patterns with 1
                for (int pos = i; pos < num.Length; pos += rep * 4)
                    for (int idx = 0; idx < rep; idx++)
                        if (pos + idx < num.Length)
                            sum1 += origin[pos + idx];

                //find the patterns with -1
                for (int pos = i + rep * 2; pos < num.Length; pos += rep * 4)
                    for (int idx = 0; idx < rep; idx++)
                        if (pos + idx < num.Length)
                            sum2 += origin[pos + idx];

                num[i] = (byte)(Math.Abs((sum1 - sum2) % 10));
                if (i % reporting == 0)
                    Console.Write(".");
            });
            Console.WriteLine($"ended at {DateTime.Now}");

        }

        private static void Run2(byte[] num, long[] occ, int start)
        {
            long[] origin = occ.Clone() as long[];

            var reporting = 1000;
            var now = DateTime.Now;
            Console.Write($"{(num.Length - start) / reporting} at {now}:");
            Parallel.For(start, num.Length, (int i) =>
            {

                if (i % reporting == 0)
                    Console.Write(".");
            });
            Console.WriteLine($"ended in {(DateTime.Now - now).TotalSeconds} seconds");

        }
    }
}
