using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace ExpressionPlayground
{
    public class TestQueryGenerator
    {
        public void Test()
        {
            var selectExpression = new SelectExpression()
            {
                IsDistinct = true,
                IsProjectStar = true,
                Limit = Expression.Constant(1)
            };

            var querySqlGenerator = new QuerySqlGenerator(selectExpression);

            var sql = querySqlGenerator.GenerateSql();


        }
    }
}
