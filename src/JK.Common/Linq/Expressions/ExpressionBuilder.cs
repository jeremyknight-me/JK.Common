using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace JK.Common.Linq.Expressions
{
    public class ExpressionBuilder<T>
    {
        private const string missingFiltersErrorMessage = "Filters must be setup before this method can be used.";
        private readonly ParameterExpression parameterExpression;
        private readonly BinaryExpressionBuilder binaryExpressionBuilder;
        private readonly MethodCallExpressionBuilder methodCallExpressionBuilder;

        public ExpressionBuilder()
        {
            this.parameterExpression = Expression.Parameter(typeof(T), "x");
            this.binaryExpressionBuilder = new BinaryExpressionBuilder();
            this.methodCallExpressionBuilder = new MethodCallExpressionBuilder();
        }

        public Expression<Func<T, bool>> GetExpression(IList<ExpressionFilter<T>> filters)
        {
            if (filters is null)
            {
                throw new ArgumentNullException(nameof(filters), missingFiltersErrorMessage);
            }

            if (!filters.Any())
            {
                throw new InvalidOperationException(missingFiltersErrorMessage);
            }

            var expression = this.BuildSinglePartExpression(filters[0]);
            for (var i = 1; i < filters.Count(); i++)
            {
                var currentFilter = filters[i];
                var rightExpression = this.BuildSinglePartExpression(currentFilter);
                expression = currentFilter.CompositeType switch
                {
                    ExpressionCompositeType.And => Expression.Add(expression, rightExpression),
                    ExpressionCompositeType.Or => Expression.Or(expression, rightExpression),
                    _ => throw new ArgumentOutOfRangeException(),
                };
            }

            return Expression.Lambda<Func<T, bool>>(expression, this.parameterExpression);
        }

        private Expression BuildSinglePartExpression(ExpressionFilter<T> filter)
        {
            switch (filter.FilterType)
            {
                case ExpressionFilterType.Equals:
                    return this.binaryExpressionBuilder.GetEqualsExpression(filter.MemberExpression, filter.Value);
                case ExpressionFilterType.BetweenInclusive:
                    return this.binaryExpressionBuilder.GetBetweenInclusiveExpression(filter.MemberExpression, filter.Value, filter.ValueTwo);
                case ExpressionFilterType.BetweenExclusive:
                    return this.binaryExpressionBuilder.GetBetweenExclusiveExpression(filter.MemberExpression, filter.Value, filter.ValueTwo);
                case ExpressionFilterType.LessThan:
                    return this.binaryExpressionBuilder.GetLessThanExpression(filter.MemberExpression, filter.Value);
                case ExpressionFilterType.LessThanOrEqual:
                    return this.binaryExpressionBuilder.GetLessThanOrEqualExpression(filter.MemberExpression, filter.Value);
                case ExpressionFilterType.GreaterThan:
                    return this.binaryExpressionBuilder.GetGreaterThanExpression(filter.MemberExpression, filter.Value);
                case ExpressionFilterType.GreaterThanOrEqual:
                    return this.binaryExpressionBuilder.GetGreaterThanOrEqualExpression(filter.MemberExpression, filter.Value);
                case ExpressionFilterType.Contains:
                    return this.methodCallExpressionBuilder.GetContainsExpression(filter.MemberExpression, filter.Value.ToString());
                case ExpressionFilterType.StartsWith:
                    return this.methodCallExpressionBuilder.GetStartsWithExpression(filter.MemberExpression, filter.Value.ToString());
                case ExpressionFilterType.EndsWith:
                    return this.methodCallExpressionBuilder.GetEndsWithExpression(filter.MemberExpression, filter.Value.ToString());
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
