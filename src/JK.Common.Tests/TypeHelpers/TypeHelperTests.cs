using System.Collections.Generic;
using JK.Common.TypeHelpers;

namespace JK.Common.Tests.TypeHelpers;

public class TypeHelperTests
{
    [Theory]
    [MemberData(nameof(IsNullable_Data))]
    public void IsNullable_Tests(Type type, bool expected)
    {
        var actual = TypeHelper.IsNullable(type);
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void IsNullableT_False()
    {
        var actual = TypeHelper.IsNullable<int>();
        Assert.False(actual);
    }

    [Fact]
    public void IsNullableT_True()
    {
        var actual = TypeHelper.IsNullable<int?>();
        Assert.True(actual);
    }

    public static IEnumerable<object[]> IsNullable_Data()
        => new List<object[]>
        {
                new object[] { typeof(int), false },
                new object[] { typeof(int?), true },
                new object[] { typeof(ComplexObject), false }
        };
}
