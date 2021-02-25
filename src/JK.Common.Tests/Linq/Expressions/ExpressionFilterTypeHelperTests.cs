using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JK.Common.Linq.Expressions;
using Xunit;

namespace JK.Common.Tests.Linq.Expressions
{
    public class ExpressionFilterTypeHelperTests
    {
        [Theory]
        [MemberData(nameof(GetTitle_Theories_Data))]
        public void GetTitle_Theories(ExpressionFilterType filterType, string expected)
        {
            var actual = ExpressionFilterTypeHelper.GetTitle(filterType);
            Assert.Equal(expected, actual);
        }

        public static IEnumerable<object[]> GetTitle_Theories_Data =>
            new List<object[]>
            {
                new object[] { ExpressionFilterType.BetweenExclusive, "Between (Exclusive)" },
                new object[] { ExpressionFilterType.BetweenInclusive, "Between (Inclusive)" },
                new object[] { ExpressionFilterType.Contains, "Contains" },
                new object[] { ExpressionFilterType.EndsWith, "End With" },
                new object[] { ExpressionFilterType.Equals, "Equals" },
                new object[] { ExpressionFilterType.GreaterThan, "Greater Than" },
                new object[] { ExpressionFilterType.GreaterThanOrEqual, "Greater Than or Equal" },
                new object[] { ExpressionFilterType.LessThan, "Less Than" },
                new object[] { ExpressionFilterType.LessThanOrEqual, "Less Than or Equal" },
                new object[] { ExpressionFilterType.StartsWith, "Starts With" }
            };
    }
}
