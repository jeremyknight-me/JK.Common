using System;
using System.Collections.Generic;
using System.Linq;
using JK.Common.Linq.Expressions;
using Xunit;

namespace JK.Common.Tests.Linq.Expressions
{
    public class ExpressionBuilderTests
    {
        [Fact]
        public void GetExpression_NullFilters_ArgumentNullException()
        {
            var builder = new ExpressionBuilder<SimpleObject>();
            Assert.Throws<ArgumentNullException>(() => builder.GetExpression(null));
        }

        [Fact]
        public void GetExpression_NoFilters_InvalidOperationException()
        {
            var builder = new ExpressionBuilder<SimpleObject>();
            var filters = new List<ExpressionFilter<SimpleObject>>();
            Assert.Throws<InvalidOperationException>(() => builder.GetExpression(filters));
        }
    }
}
