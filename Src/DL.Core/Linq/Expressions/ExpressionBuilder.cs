using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DL.Core.Linq.Expressions
{
    public class ExpressionBuilder<T>
    {
        private readonly ParameterExpression parameterExpression;

        private readonly BinaryExpressionBuilder binaryExpressionBuilder;

        private readonly MethodCallExpressionBuilder methodCallExpressionBuilder;

        public ExpressionBuilder()
        {
            this.Filters = new List<ExpressionFilter<T>>();
            this.parameterExpression = Expression.Parameter(typeof(T), "x");

            this.binaryExpressionBuilder = new BinaryExpressionBuilder();
            this.methodCallExpressionBuilder = new MethodCallExpressionBuilder();
        }

        public ExpressionBuilder(IEnumerable<ExpressionFilter<T>> filters)
            : this()
        {
            this.Filters.AddRange(filters);
        }

        public List<ExpressionFilter<T>> Filters { get; set; }

        public Expression<Func<T, bool>> GetExpression()
        {
            if (this.Filters.Count == 0)
            {
                throw new InvalidOperationException("Filters must be setup before this method can be used.");
            }

            Expression expression = this.BuildSinglePartExpression(this.Filters[0]);

            for (int i = 1; i < this.Filters.Count; i++)
            {
                ExpressionFilter<T> currentFilter = this.Filters[i];
                Expression rightExpression = this.BuildSinglePartExpression(currentFilter);

                switch (currentFilter.CompositeType)
                {
                    case ExpressionCompositeType.And:
                        expression = Expression.Add(expression, rightExpression);
                        break;
                    case ExpressionCompositeType.Or:
                        expression = Expression.Or(expression, rightExpression);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
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
