using day_8;
using System;
using System.IO;
using Xunit;

namespace day_8_tests
{
    public class Runs
    {
        [Fact]
        public void Problem1Run()
        {
            var input = File.ReadAllText("input.txt");
            Assert.Equal(1206, Problem1.Run(input, 6, 25));
        }

        [Fact]
        public void Problem2Run()
        {
            var input = File.ReadAllText("input-test.txt");
            Assert.Equal(1206, Problem2.Run(input, 6, 25));
        }
    }
}
