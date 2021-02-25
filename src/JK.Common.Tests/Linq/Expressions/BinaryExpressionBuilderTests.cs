using JK.Common.Linq.Expressions;
using Xunit;

namespace JK.Common.Tests.Linq.Expressions
{
    public class BinaryExpressionBuilderTests
    {
        [Fact]
        public void GetEqualsExpression_ValidPropertyAndFilterData_ValidExpresssion()
        {
            var filter = new ExpressionFilter<SimpleObject> { Value = 2 };
            filter.SetMemberExpression(x => x.Id);
            var builder = new BinaryExpressionBuilder();
            var expression = builder.GetEqualsExpression(filter.MemberExpression, filter.Value);
            Assert.Equal("(x.Id == 2)", expression.ToString());
        }

        [Fact]
        public void GetGreaterThanExpression_ValidPropertyAndFilterData_ValidExpresssion()
        {
            var filter = new ExpressionFilter<SimpleObject> { Value = 2 };
            filter.SetMemberExpression(x => x.Id);
            var builder = new BinaryExpressionBuilder();
            var expression = builder.GetGreaterThanExpression(filter.MemberExpression, filter.Value);
            Assert.Equal("(x.Id > 2)", expression.ToString());
        }

        [Fact]
        public void GetGreaterThanOrEqualExpression_ValidPropertyAndFilterData_ValidExpresssion()
        {
            var filter = new ExpressionFilter<SimpleObject> { Value = 10 };
            filter.SetMemberExpression(x => x.Id);
            var builder = new BinaryExpressionBuilder();
            var expression = builder.GetGreaterThanOrEqualExpression(filter.MemberExpression, filter.Value);
            Assert.Equal("(x.Id >= 10)", expression.ToString());
        }

        [Fact]
        public void GetLessThanExpression_ValidPropertyAndFilterData_ValidExpresssion()
        {
            var filter = new ExpressionFilter<SimpleObject> { Value = 0 };
            filter.SetMemberExpression(x => x.Id);
            var builder = new BinaryExpressionBuilder();
            var expression = builder.GetLessThanExpression(filter.MemberExpression, filter.Value);
            Assert.Equal("(x.Id < 0)", expression.ToString());
        }

        [Fact]
        public void GetLessThanOrEqualExpression_ValidPropertyAndFilterData_ValidExpresssion()
        {
            var filter = new ExpressionFilter<SimpleObject> { Value = 0 };
            filter.SetMemberExpression(x => x.Id);
            var builder = new BinaryExpressionBuilder();
            var expression = builder.GetLessThanOrEqualExpression(filter.MemberExpression, filter.Value);
            Assert.Equal("(x.Id <= 0)", expression.ToString());
        }

        [Fact]
        public void GetBetweenExclusiveExpression_ValidPropertyAndFilterData_ValidExpresssion()
        {
            var filter = new ExpressionFilter<SimpleObject> { Value = 10, ValueTwo = 20 };
            filter.SetMemberExpression(x => x.Id);
            var builder = new BinaryExpressionBuilder();
            var expression = builder.GetBetweenExclusiveExpression(filter.MemberExpression, filter.Value, filter.ValueTwo);
            Assert.Equal("((x.Id > 10) And (x.Id < 20))", expression.ToString());
        }

        [Fact]
        public void GetBetweenInclusiveExpression_ValidPropertyAndFilterData_ValidExpresssion()
        {
            var filter = new ExpressionFilter<SimpleObject> { Value = 10, ValueTwo = 20 };
            filter.SetMemberExpression(x => x.Id);
            var builder = new BinaryExpressionBuilder();
            var expression = builder.GetBetweenInclusiveExpression(filter.MemberExpression, filter.Value, filter.ValueTwo);
            Assert.Equal("((x.Id >= 10) And (x.Id <= 20))", expression.ToString());
        }
    }
}
