using JK.Common.Extensions;

namespace JK.Common.Tests.Extensions.TypeExtensionsTests;

public class DoesImplement
{
    [Fact]
    public void DoesImplement_NonInterface_Exception()
    {
        ArgumentException ex = Assert.Throws<ArgumentException>(() => typeof(TestWithInterface).DoesImplement<NotAnInterface>());
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
