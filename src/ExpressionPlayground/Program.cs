using System;
using System.Linq.Expressions;

namespace ExpressionPlayground
{
    class Program
    {
        static void Main(string[] args)
        {
            //TestQueryGenerator test = new TestQueryGenerator();
            //test.Test();
            PrintExpressions.HelloWorld();
            //PrintNumber(7);
            //PrintMessage("Hello");
            //SumHardcodedNumbers();
            //SumNumbers(10, 10);
            //SumComplexExpression(5, 5, 3, 4);
            Console.ReadLine();
        }
        public int Sum(int a, int b)
        {
            Func<int, int, int> sum = (x, y) => x + y;
            return sum(a, b);
        }

        static void SumHardcodedNumbers()
        {

            var one = Expression.Constant(1, typeof(int));
            var two = Expression.Constant(2, typeof(int));

            var addition = Expression.Add(one, two);

            var lambda = Expression.Lambda<Func<int>>(addition);
            var compiledLambda = lambda.Compile();
            var sum = compiledLambda();

            Console.WriteLine(sum);
        }

        static void PrintMessage(string message)
        {
            ParameterExpression param = Expression.Parameter(typeof(string));

            MethodCallExpression methodCall = Expression.Call(
                typeof(Console).GetMethod("WriteLine", new Type[] { typeof(string) }), param);

            Action<string> printString = Expression.Lambda<Action<string>>(
                methodCall,
                new ParameterExpression[] { param }).Compile();

            printString(message);
        }

        static void PrintNumber(int a)
        {
            ParameterExpression param = Expression.Parameter(typeof(int));

            MethodCallExpression methodCall = Expression.Call(
                typeof(Console).GetMethod("WriteLine", new Type[] { typeof(int) }), param);

            Action<int> printInt = Expression.Lambda<Action<int>>(
                methodCall,
                new ParameterExpression[] { param }).Compile();

            printInt(a);
        }

        static void SumNumbers(int a, int b)
        {

            ParameterExpression param1 = Expression.Parameter(typeof(int));
            ParameterExpression param2 = Expression.Parameter(typeof(int));


            BinaryExpression addition = Expression.Add(param1, param2);

            Expression<Func<int, int, int>> additionLambda = Expression.Lambda<Func<int, int, int>>(addition, param1, param2);

            Func<int, int, int> compiledAddition = additionLambda.Compile();

            var sum = compiledAddition(a, b);

            Console.WriteLine(sum);
        }

        static void SumComplexExpression(int a, int b, int c, int d)
        {
            //writing an expression that computers ((a + b) * c) - d)

            ParameterExpression paramA = Expression.Parameter(typeof(int));
            ParameterExpression paramB = Expression.Parameter(typeof(int));
            ParameterExpression paramC = Expression.Parameter(typeof(int));
            ParameterExpression paramD = Expression.Parameter(typeof(int));

            BinaryExpression addition = Expression.Add(paramA, paramB);
            BinaryExpression multiplication = Expression.Multiply(addition, paramC);
            BinaryExpression subtraction = Expression.Subtract(multiplication, paramD);

            Expression<Func<int, int, int, int, int>> complexLambda = Expression.Lambda<Func<int, int, int, int, int>>(subtraction, paramA, paramB, paramC, paramD);

            Func<int, int, int, int, int> complexExpression = complexLambda.Compile();

            var result = complexExpression(a, b, c, d);
            Console.WriteLine(result);
        }
    }
}
