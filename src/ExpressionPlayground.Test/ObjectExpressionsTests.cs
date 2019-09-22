using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ExpressionPlayground.Test
{
    public class ObjectExpressionsTests
    {
        [Theory]
        [InlineData(1)]
        [InlineData(10)]
        [InlineData(25)]
        public void Test_ExtractOrderId(int orderId)
        {
            var order = new Order()
            {
                OrderId = orderId,
            };

            var actualOrderId = OrderExpressions.ExtractOrderId(order);

            Assert.Equal(orderId, actualOrderId);
        }

        [Theory]
        [InlineData(2, 2, 4)]
        public void Test_AddOrderCosts(decimal cost1, decimal cost2, decimal expected)
        {
            var order1 = new Order()
            {
                Cost = cost1
            };
            var order2 = new Order()
            {
                Cost = cost2
            };

            var sumOfOrderCosts = OrderExpressions.SumOrderCosts(order1, order2);

            Assert.Equal(expected, sumOfOrderCosts);
        }
    }
}
