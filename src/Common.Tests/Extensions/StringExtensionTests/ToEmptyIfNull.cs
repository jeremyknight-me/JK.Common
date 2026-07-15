using JK.Common.Extensions;

namespace JK.Common.Tests.Extensions.StringExtensionTests;

public class ToEmptyIfNull
{
    [Fact]
    public void Null_ReturnsEmpty()
    {
        string value = null;
        var actual = value.ToEmptyIfNull();
        Assert.Equal(string.Empty, actual);
    }

    [Theory]
    [InlineData("hello")]
    [InlineData("")]
    [InlineData(" ")]
    public void NonNull_ReturnsOriginal(string value)
    {
        var actual = value.ToEmptyIfNull();
        Assert.Equal(value, actual);
    }
}
