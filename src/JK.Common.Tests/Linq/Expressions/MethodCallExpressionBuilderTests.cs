using System;
using System.Collections.Generic;
using JK.Common.Linq.Expressions;
using Xunit;

namespace JK.Common.Tests.Linq.Expressions
{
    public class MethodCallExpressionBuilderTests
    {
        #region GetContainsExpression Tests

        [Fact]
        public void GetContainsExpression_InvalidValueType_ArgumentException()
        {
            var filter = this.GetIdFilter("2");
            var sut = new MethodCallExpressionBuilder();
            Assert.Throws<ArgumentException>(() => sut.GetContainsExpression(filter.MemberExpression, filter.Value.ToString()));            
        }

        [Fact]
        public void GetContainsExpression_ValidPropertyAndFilterData_ValidExpresssion()
        {
            var filter = this.GetTitleFilter("2");
            var sut = new MethodCallExpressionBuilder();
            var expression = sut.GetContainsExpression(filter.MemberExpression, filter.Value.ToString());
            Assert.Equal("x.Title.Contains(\"2\")", expression.ToString());
        }

        #endregion

        #region GetEndsWithExpression Tests

        [Fact]
        public void GetEndsWithExpression_InvalidValueType_ArgumentException()
        {
            var filter = this.GetIdFilter("2");
            var sut = new MethodCallExpressionBuilder();
            Assert.Throws<ArgumentException>(() => sut.GetEndsWithExpression(filter.MemberExpression, filter.Value.ToString()));
        }

        [Fact]
        public void GetEndsWithExpression_ValidPropertyAndFilterData_ValidExpresssion()
        {
            var filter = this.GetTitleFilter("2");
            var sut = new MethodCallExpressionBuilder();
            var expression = sut.GetEndsWithExpression(filter.MemberExpression, filter.Value.ToString());
            Assert.Equal("x.Title.EndsWith(\"2\")", expression.ToString());
        }

        #endregion

        #region GetStartsWithExpression Tests

        [Fact]
        public void GetStartsWithExpression_InvalidValueType_ArgumentException()
        {
            var filter = this.GetIdFilter("2");
            var sut = new MethodCallExpressionBuilder();
            Assert.Throws<ArgumentException>(() => sut.GetStartsWithExpression(filter.MemberExpression, filter.Value.ToString()));
        }

        [Fact]
        public void GetStartsWithExpression_ValidPropertyAndFilterData_ValidExpresssion()
        {
            var filter = this.GetTitleFilter("Title 2");
            var sut = new MethodCallExpressionBuilder();
            var expression = sut.GetStartsWithExpression(filter.MemberExpression, filter.Value.ToString());
            Assert.Equal("x.Title.StartsWith(\"Title 2\")", expression.ToString());
        }

        #endregion

        private ExpressionFilter<SimpleObject> GetIdFilter(string compareValue)
        {
            var filter = new ExpressionFilter<SimpleObject> { Value = compareValue };
            filter.SetMemberExpression(x => x.Id);
            return filter;
        }

        private ExpressionFilter<SimpleObject> GetTitleFilter(string compareValue)
        {
            var filter = new ExpressionFilter<SimpleObject> { Value = compareValue };
            filter.SetMemberExpression(x => x.Title);
            return filter;
        }
    }
}
