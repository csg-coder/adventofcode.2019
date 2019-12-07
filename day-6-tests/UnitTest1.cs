using day_6_lib;
using System;
using Xunit;
using Xunit.Abstractions;

namespace day_6_tests
{
    public class UnitTest1
    {
        private readonly ITestOutputHelper output;

        public UnitTest1(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact]
        public void Test1()
        {

            var c = new Class1();
            var ret = c.ret(3);
            Assert.Equal(false, ret); ;
        }

        [Fact]
        public void TheTest()
        {
            var c = new Day6();
            c.read("input.txt");
            this.output.WriteLine("2");

        }

    }

    public class Day6
    {
        public string[] read(string filename)
        {

            return null;
        }
    }
}
