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
            Assert.False(Util.Contains7(5));
        }

        [Fact]
        public void Test2()
        {
            Assert.True(Util.Contains7(7));
        }

        [Fact]
        public void Test3()
        {
            Assert.Equal(7, Util.GetNoDelivered(10));
        }

        [Fact]
        public void Test4()
        {
            Assert.Equal(9, Util.GetNoDelivered(20));
        }

        [Fact]
        public void Test5()
        {
            Assert.Equal(32, Util.GetNoDelivered(10000));
        }
    }
}
