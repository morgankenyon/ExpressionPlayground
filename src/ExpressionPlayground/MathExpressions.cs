using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace ExpressionPlayground
{
    public static class MathExpressions
    {
        public static int SumHardcodedNumbers()
        {
            ConstantExpression one = Expression.Constant(1, typeof(int));
            ConstantExpression two = Expression.Constant(2, typeof(int));

            BinaryExpression addition = Expression.Add(one, two);

            Expression<Func<int>> lambda = Expression.Lambda<Func<int>>(addition);
            Func<int> compiledLambda = lambda.Compile();
            return compiledLambda();
        }

        public static int Sum(int a, int b)
        {
            //defining expression
            ParameterExpression param1 = Expression.Parameter(typeof(int));
            ParameterExpression param2 = Expression.Parameter(typeof(int));
            BinaryExpression sum = Expression.Add(param1, param2);
            Expression<Func<int, int, int>> sumLambda = Expression.Lambda<Func<int, int, int>>(sum, param1, param2);

            //compiling expression
            Func<int, int, int> compiledSum = sumLambda.Compile();

            //running expression
            return compiledSum(a, b);
        }

        public static int Max(int a, int b)
        {
            ParameterExpression param1 = Expression.Parameter(typeof(int));
            ParameterExpression param2 = Expression.Parameter(typeof(int));

            MethodCallExpression mathMaxExpression = Expression.Call(
                typeof(Math).GetMethod("Max", new Type[] { typeof(int), typeof(int) }), param1, param2);

            Func<int, int, int> mathMaxMethod = Expression.Lambda<Func<int, int, int>>(
                mathMaxExpression,
                new ParameterExpression[] { param1, param2 }).Compile();

            return mathMaxMethod(a, b);
        }

        public static double CalculateSlope(double x1, double y1, double x2, double y2)
        {

            ParameterExpression paramX1 = Expression.Parameter(typeof(double));
            ParameterExpression paramY1 = Expression.Parameter(typeof(double));
            ParameterExpression paramX2 = Expression.Parameter(typeof(double));
            ParameterExpression paramY2 = Expression.Parameter(typeof(double));

            BinaryExpression ySub = Expression.Subtract(paramY2, paramY1);
            BinaryExpression xSub = Expression.Subtract(paramX2, paramX1);
            BinaryExpression div = Expression.Divide(ySub, xSub);

            Expression<Func<double, double, double, double, double>> slopeCalculate = 
                Expression.Lambda<Func<double, double, double, double, double>>(div, paramY2, paramY1, paramX2, paramX1);

            return slopeCalculate.Compile()(y2, y1, x2, x1);
        }
    }
}
