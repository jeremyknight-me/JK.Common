using JK.Common.Extensions;

namespace JK.Common.Tests.Extensions.StringExtensionTests;

public class ToNullIfEmpty
{
    [Theory]
    [InlineData(null)]
    [InlineData("")]
    public void EmptyOrNull_ReturnsNull(string value)
    {
        var actual = value.ToNullIfEmpty();
        Assert.Null(actual);
    }

    [Theory]
    [InlineData("hello")]
    [InlineData(" ")]
    public void NonEmpty_ReturnsOriginal(string value)
    {
        var actual = value.ToNullIfEmpty();
        Assert.Equal(value, actual);
    }
}
