using System;
using System.Linq.Expressions;

namespace JK.Common.Linq.Expressions
{
    internal class MethodCallExpressionBuilder
    {
        public MethodCallExpression GetContainsExpression(MemberExpression memberExpression, string compareValue)
            => this.BuildStringMethodCallExpression("Contains", memberExpression, compareValue);

        public MethodCallExpression GetEndsWithExpression(MemberExpression memberExpression, string compareValue)
            => this.BuildStringMethodCallExpression("EndsWith", memberExpression, compareValue);

        public MethodCallExpression GetStartsWithExpression(MemberExpression memberExpression, string compareValue)
            => this.BuildStringMethodCallExpression("StartsWith", memberExpression, compareValue);

        private MethodCallExpression BuildStringMethodCallExpression(string methodName, MemberExpression memberExpression, string compareValue)
        {
            if (memberExpression.Type != typeof(string))
            {
                throw new ArgumentException("The type of property contained within 'memberExpression' must be string.", nameof(memberExpression));
            }

            var stringType = typeof(string);
            return this.BuildMethodCallExpression(stringType, methodName, new[] { stringType }, memberExpression, compareValue);
        }

        private MethodCallExpression BuildMethodCallExpression(Type methodOwningType, string methodName, Type[] parameterTypes, MemberExpression memberExpression, string compareValue)
        {
            var constantExpression = Expression.Constant(compareValue);
            var method = methodOwningType.GetMethod(methodName, parameterTypes);
            return Expression.Call(memberExpression, method, constantExpression);
        }
    }
}
