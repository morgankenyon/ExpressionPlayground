using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace ExpressionPlayground
{
    public class SelectExpression
    {
        private const string SubqueryAliasPrefix = "t";
        private const string ColumnAliasPrefix = "c";
        public Expression Limit;

        public bool IsDistinct;
        public bool IsProjectStar;
    }
}
