using System;
using Xunit;
using Program;

namespace Test
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            Assert.Equal(false, Util.Contains7(5));
        }

        [Fact]
        public void Test2()
        {
            Assert.Equal(true, Util.Contains7(7));
        }

    }
}
