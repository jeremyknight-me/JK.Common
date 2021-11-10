using System.Collections.Generic;
using JK.Common.Extensions;

namespace JK.Common.Tests.Extensions;

public class TypeExtensionsTests
{
    #region DoesImplement<T>() Tests

    [Fact]
    public void DoesImplement_NonInterface_Exception()
    {
        var ex = Assert.Throws<ArgumentException>(() => typeof(TestWithInterface).DoesImplement<NotAnInterface>());
    }

    [Fact]
    public void DoesImplement_WithInterface_True()
    {
        var actual = typeof(TestWithInterface).DoesImplement<IInterface>();
        Assert.True(actual);
    }

    [Fact]
    public void DoesImplement_WithoutInterface_False()
    {
        var actual = typeof(TestWithoutInterface).DoesImplement<IInterface>();
        Assert.False(actual);
    }

    #endregion

    #region IsNullable

    [Theory]
    [MemberData(nameof(IsNullable_Data))]
    public void IsNullable_Tests(Type type, bool expected)
    {
        var actual = type.IsNullable();
        Assert.Equal(expected, actual);
    }

    public static IEnumerable<object[]> IsNullable_Data()
        => new List<object[]>
        {
                new object[] { typeof(int), false },
                new object[] { typeof(int?), true }
        };

    #endregion

    private interface IInterface
    {
    }
    private class TestWithInterface : IInterface
    {
    }
    private class TestWithoutInterface
    {
    }
    private class NotAnInterface
    {
    }
}
