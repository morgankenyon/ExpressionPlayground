using System;
using System.Linq.Expressions;

namespace ExpressionPlayground
{
    public static class PrintExpressions
    {

        public static void HelloWorld()
        {
            ConstantExpression constant = Expression.Constant("Hello World", typeof(string));

            MethodCallExpression writeLine = Expression.Call(
                typeof(Console).GetMethod("WriteLine", new Type[] { typeof(string) }), constant);

            Expression<Action> helloWorldExpression = Expression.Lambda<Action>(writeLine);

            Action helloWorld = helloWorldExpression.Compile();

            helloWorld();
        }

        public static void PrintMessage(string message)
        {
            ParameterExpression param = Expression.Parameter(typeof(string));

            MethodCallExpression methodCall = Expression.Call(
                typeof(Console).GetMethod("WriteLine", new Type[] { typeof(string) }), param);

            Expression<Action<string>> printStringExpression = Expression.Lambda<Action<string>>(
                methodCall,
                new ParameterExpression[] { param });

            Action<string> printString = printStringExpression.Compile();

            printString(message);
        }

        public static void PrintNumber(int a)
        {
            ParameterExpression param = Expression.Parameter(typeof(int));

            MethodCallExpression methodCall = Expression.Call(
                typeof(Console).GetMethod("WriteLine", new Type[] { typeof(int) }), param);

            Action<int> printInt = Expression.Lambda<Action<int>>(
                methodCall,
                new ParameterExpression[] { param }).Compile();

            printInt(a);
        }

    }
}
