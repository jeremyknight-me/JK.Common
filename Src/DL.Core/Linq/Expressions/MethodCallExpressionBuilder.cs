using System;
using System.Linq.Expressions;
using System.Reflection;

namespace DL.Core.Linq.Expressions
{
    public class MethodCallExpressionBuilder
    {
        public MethodCallExpression GetContainsExpression(MemberExpression memberExpression, object compareValue)
        {
            return this.BuildStringMethodCallExpression("Contains", memberExpression, compareValue);        
        }

        public MethodCallExpression GetEndsWithExpression(MemberExpression memberExpression, object compareValue)
        {
            return this.BuildStringMethodCallExpression("EndsWith", memberExpression, compareValue);
        }

        public MethodCallExpression GetStartsWithExpression(MemberExpression memberExpression, object compareValue)
        {
            return this.BuildStringMethodCallExpression("StartsWith", memberExpression, compareValue);
        }

        private MethodCallExpression BuildStringMethodCallExpression(string methodName, MemberExpression memberExpression, object compareValue)
        {
            if (memberExpression.Type != typeof(string))
            {
                throw new ArgumentException("The type of property contained within 'memberExpression' must be string.", "memberExpression");
            }

            if (!(compareValue is string))
            {
                throw new ArgumentException("The value of 'compareValue' must be a string.", "compareValue");
            }

            Type stringType = typeof(string);
            return this.BuildMethodCallExpression(stringType, methodName, new[] { stringType }, memberExpression, compareValue.ToString());
        }

        private MethodCallExpression BuildMethodCallExpression(
            Type methodOwningType, string methodName, Type[] parameterTypes, MemberExpression memberExpression, string compareValue)
        {
            ConstantExpression constantExpression = Expression.Constant(compareValue);

            MethodInfo method = methodOwningType.GetMethod(methodName, parameterTypes);
            return Expression.Call(memberExpression, method, constantExpression);
        }
    }
}
