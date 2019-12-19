using System;
using System.Collections.Generic;
using System.Text;

namespace day_19
{
    class Computer
    {
        public static string Process(long[] puzzleinput, string[] inputs)
        {
            var puzzle = new long[1000000];

            var inputcursor = 0;
            puzzleinput.CopyTo(puzzle, 0);

            long currentrel = 0;
            long l = puzzle.Length;
            long i = 0;
            var ret = "";

            while (i < l)
            {
                puzzle.print(100, 16);
                long opcode = puzzle[i] % 100;

                var modes = (puzzle[i] - opcode) / 100;
                var mode1 = modes % 10;
                modes = (modes - mode1) / 10;
                var mode2 = modes % 10;
                modes = (modes - mode2) / 10;
                var mode3 = modes % 10;

                long rel1 = 0;
                if (mode1 == 2)
                    rel1 = currentrel;
                long rel2 = 0;
                if (mode2 == 2)
                    rel2 = currentrel;
                long rel3 = 0;
                if (mode3 == 2)
                    rel3 = currentrel;

                if (opcode == 1)
                {
                    long poz1 = puzzle[i + 1] + rel1;
                    long poz2 = puzzle[i + 2] + rel2;
                    long pozr = puzzle[i + 3] + rel3;

                    if (mode1 == 1)
                        poz1 = i + 1;
                    if (mode2 == 1)
                        poz2 = i + 2;
                    if (mode3 == 1)
                        // pozr=i+3;
                        throw new Exception("immediate cannotbe for opcode1");

                    puzzle[pozr] = puzzle[poz1] + puzzle[poz2];
                    i += 4;
                }
                else if (opcode == 2)
                {
                    long poz1 = puzzle[i + 1] + rel1;
                    long poz2 = puzzle[i + 2] + rel2;
                    long pozr = puzzle[i + 3] + rel3;

                    if (mode1 == 1)
                        poz1 = i + 1;
                    if (mode2 == 1)
                        poz2 = i + 2;
                    if (mode3 == 1)
                        // pozr=i+3;
                        throw new Exception("immediate cannotbe for opcode2");

                    puzzle[pozr] = puzzle[poz1] * puzzle[poz2]; ;
                    i += 4;
                }
                else if (opcode == 3)
                {

                    //Console.Write("give a number:");
                    //var inputs = Console.ReadLine();
                    var input = int.Parse(inputs[inputcursor++]);
                    System.Console.WriteLine($"{input} was read");
                    long poz1 = puzzle[i + 1] + rel1;

                    if (mode1 == 1)
                        // poz1=i+1;
                        throw new Exception("immediate cannotbe for opcode3");



                    puzzle[poz1] = input;


                    i += 2;

                }
                else if (opcode == 4)
                {

                    long poz1 = puzzle[i + 1] + rel1;

                    if (mode1 == 1)
                        poz1 = i + 1;

                    Console.Write(puzzle[poz1]);
                    ret += puzzle[poz1];

                    i += 2;
                }
                else if (opcode == 5)
                {//jump-if-true

                    long poz1 = puzzle[i + 1] + rel1;
                    long pozr = puzzle[i + 2] + rel2;

                    if (mode1 == 1)
                        poz1 = i + 1;

                    if (mode2 == 1)
                        pozr = i + 2;

                    if (puzzle[poz1] != 0)
                        i = puzzle[pozr];
                    else
                        i += 3;
                }
                else if (opcode == 6)
                {//jump-if-false

                    long poz1 = puzzle[i + 1] + rel1;
                    long pozr = puzzle[i + 2] + rel2;

                    if (mode1 == 1)
                        poz1 = i + 1;

                    if (mode2 == 1)
                        pozr = i + 2;

                    if (puzzle[poz1] == 0)
                        i = puzzle[pozr];
                    else
                        i += 3;
                }
                else if (opcode == 7)
                {//is-less-than
                    long poz1 = puzzle[i + 1] + rel1;
                    long poz2 = puzzle[i + 2] + rel2;
                    long pozr = puzzle[i + 3] + rel3;

                    if (mode1 == 1)
                        poz1 = i + 1;
                    if (mode2 == 1)
                        poz2 = i + 2;
                    if (mode3 == 1)
                        // pozr=i+3;
                        throw new Exception("immediate cannotbe for opcode7");

                    puzzle[pozr] = puzzle[poz1] < puzzle[poz2] ? 1 : 0; ;
                    i += 4;
                }
                else if (opcode == 8)
                {//is-equal
                    long poz1 = puzzle[i + 1] + rel1;
                    long poz2 = puzzle[i + 2] + rel2;
                    long pozr = puzzle[i + 3] + rel3;

                    if (mode1 == 1)
                        poz1 = i + 1;
                    if (mode2 == 1)
                        poz2 = i + 2;
                    if (mode3 == 1)
                        // pozr=i+3;
                        throw new Exception("immediate cannotbe for opcode8");

                    puzzle[pozr] = puzzle[poz1] == puzzle[poz2] ? 1 : 0; ;
                    i += 4;

                }
                else if (opcode == 9)//set rel
                {

                    long poz1 = puzzle[i + 1] + rel1;

                    if (mode1 == 1)
                        poz1 = i + 1;

                    currentrel += puzzle[poz1];

                    i += 2;
                }
                else if (opcode == 99)
                {

                    Console.WriteLine();
                    System.Console.WriteLine($"halt at {i} with ret={ret}");
                    return ret;
                }
                else
                {
                    throw new Exception($"{i} contains unexpected opcode - {opcode}");
                }

            }

            return ret;
        }
    }
}
