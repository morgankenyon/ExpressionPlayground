using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ExpressionPlayground.Test
{
    
    public class MathExpressionsTests
    {

        [Theory]
        [InlineData(1, 2, 3)]
        [InlineData(3, 3, 6)]
        [InlineData(3, -3, 0)]
        [InlineData(0, 0, 0)]
        public void Test_SumNumbers(int a, int b, int expected)
        {
            var result = MathExpressions.Sum(a, b);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(1, 2, 2)]
        [InlineData(10, 2, 10)]
        [InlineData(-1, 2, 2)]
        [InlineData(100, -2, 100)]
        public void Test_Max(int a, int b, int expected)
        {
            var max = MathExpressions.Max(a, b);

            Assert.Equal(expected, max);
        }

        [Theory]
        [InlineData(15, 8, 10, 7, 0.2)]
        [InlineData(0, 0, 1, 1, 1.0)]
        [InlineData(0, 0, 1, 2, 2.0)]
        public void Test_CalculateSlope(int x1, int y1, int x2, int y2, double expected)
        {
            var slope = MathExpressions.CalculateSlope(x1, y1, x2, y2);

            Assert.Equal(expected, slope);
        }
    }
}
