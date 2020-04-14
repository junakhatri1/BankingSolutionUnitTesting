using System;
using Xunit;

namespace BankingTest
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            int a = 10, b = 20;
            int answer = a + b;
            Assert.Equal(30, answer);
        }

        [Theory]
        [InlineData(2, 2, 4)]
        [InlineData(5, 10, 15)]
        public void CanDoAddition(int a, int b, int expected)
        {
            var answer = a + b;
            Assert.Equal(expected, answer);
        }

    }
}
