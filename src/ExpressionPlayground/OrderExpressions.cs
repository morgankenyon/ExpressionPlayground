using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace ExpressionPlayground
{
    public static class OrderExpressions
    {
        public static int ExtractOrderId(Order order)
        {
            ParameterExpression orderEx = Expression.Parameter(typeof(Order), "o");
            MemberExpression memberEx = Expression.Property(orderEx, "OrderId");

            Expression<Func<Order, int>> extractLambda = 
                Expression.Lambda<Func<Order, int>>(memberEx, new[] { orderEx });

            Func<Order, int> extractOrderId = extractLambda.Compile();

            return extractOrderId(order);
        }

        public static decimal SumOrderCosts(Order order1, Order order2)
        {
            ParameterExpression orderEx1 = Expression.Parameter(typeof(Order), "o1");
            ParameterExpression orderEx2 = Expression.Parameter(typeof(Order), "o2");
            MemberExpression memberEx1 = Expression.Property(orderEx1, typeof(Order), "Cost");
            MemberExpression memberEx2 = Expression.Property(orderEx2, typeof(Order), "Cost");

            BinaryExpression sumCost = Expression.Add(memberEx1, memberEx2);

            Expression<Func<Order, Order, decimal>> costLambda =
                Expression.Lambda<Func<Order, Order, decimal>>(sumCost, new[] { orderEx1, orderEx2 });

            Func<Order, Order, decimal> cost = costLambda.Compile();

            return cost(order1, order2);
        }
    }
}
