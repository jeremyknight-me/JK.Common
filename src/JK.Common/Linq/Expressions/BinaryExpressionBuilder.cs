using System.Linq.Expressions;

namespace JK.Common.Linq.Expressions
{
    internal class BinaryExpressionBuilder
    {
        public BinaryExpression GetBetweenExclusiveExpression(MemberExpression memberExpression, object leftCompareValue, object rightCompareValue)
        {
            var leftExpression = this.GetGreaterThanExpression(memberExpression, leftCompareValue);
            var rightExpression = this.GetLessThanExpression(memberExpression, rightCompareValue);
            return Expression.And(leftExpression, rightExpression);
        }

        public BinaryExpression GetBetweenInclusiveExpression(MemberExpression memberExpression, object leftCompareValue, object rightCompareValue)
        {
            var leftExpression = this.GetGreaterThanOrEqualExpression(memberExpression, leftCompareValue);
            var rightExpression = this.GetLessThanOrEqualExpression(memberExpression, rightCompareValue);
            return Expression.And(leftExpression, rightExpression);
        }

        public BinaryExpression GetEqualsExpression(MemberExpression memberExpression, object compareValue)
        {
            var constantExpression = this.BuildConstantExpression(compareValue);
            return Expression.Equal(memberExpression, constantExpression);
        }

        public BinaryExpression GetGreaterThanExpression(MemberExpression memberExpression, object compareValue)
        {
            var constantExpression = this.BuildConstantExpression(compareValue);
            return Expression.GreaterThan(memberExpression, constantExpression);
        }

        public BinaryExpression GetGreaterThanOrEqualExpression(MemberExpression memberExpression, object compareValue)
        {
            var constantExpression = this.BuildConstantExpression(compareValue);
            return Expression.GreaterThanOrEqual(memberExpression, constantExpression);
        }

        public BinaryExpression GetLessThanExpression(MemberExpression memberExpression, object compareValue)
        {
            var constantExpression = this.BuildConstantExpression(compareValue);
            return Expression.LessThan(memberExpression, constantExpression);
        }

        public BinaryExpression GetLessThanOrEqualExpression(MemberExpression memberExpression, object compareValue)
        {
            var constantExpression = this.BuildConstantExpression(compareValue);
            return Expression.LessThanOrEqual(memberExpression, constantExpression);
        }

        private ConstantExpression BuildConstantExpression(object value) => Expression.Constant(value);
    }
}
