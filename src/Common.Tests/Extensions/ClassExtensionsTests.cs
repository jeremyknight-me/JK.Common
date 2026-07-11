using JK.Common.Extensions;

namespace JK.Common.Tests.Extensions;

public class ClassExtensionsTests
{
    [Fact]
    public void IsNull_Null_True()
    {
        SimpleObject simple = null;
        var actual = simple.IsNull();
        Assert.True(actual);
    }

    [Fact]
    public void IsNull_Object_False()
    {
        SimpleObject simple = new();
        var actual = simple.IsNull();
        Assert.False(actual);
    }

    [Fact]
    public void IsNotNull_Null_False()
    {
        SimpleObject simple = new();
        var actual = simple.IsNull();
        Assert.False(actual);
    }

    [Fact]
    public void IsNotNull_Object_True()
    {

    }
}
