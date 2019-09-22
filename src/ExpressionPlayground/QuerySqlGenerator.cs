using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace ExpressionPlayground
{
    public class QuerySqlGenerator
    {

        public QuerySqlGenerator(SelectExpression selectExpression)
        {
            SelectExpression = selectExpression;
        }

        public SelectExpression SelectExpression { get; }

        public string GenerateSql()
        {
            var sqlBuilder = new StringBuilder("SELECT ");

            if (SelectExpression.IsDistinct)
            {
                sqlBuilder.Append("DISTINCT ");
            }

            if (SelectExpression.Limit != null && 
                SelectExpression.Limit.NodeType == ExpressionType.Constant)
            {
                sqlBuilder.Append("TOP(");

                //get limit from expression
                var constantLimit = (ConstantExpression)SelectExpression.Limit;
                sqlBuilder.Append(constantLimit.Value);

                sqlBuilder.Append(") ");
            }

            if (SelectExpression.IsProjectStar)
            {
                sqlBuilder.Append("* ");
            }

            sqlBuilder.Append("FROM ");

            sqlBuilder.Append("dbo.Example"); //need to refactor at some point
            return sqlBuilder.ToString();
        }
    }
}
