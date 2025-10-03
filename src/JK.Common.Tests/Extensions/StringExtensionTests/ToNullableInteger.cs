using JK.Common.Extensions;

namespace JK.Common.Tests.Extensions.StringExtensionTests;

public class ToNullableInteger
{
    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("  ")]
    [InlineData("abc")]
    [InlineData("123.456")]
    public void ToNullableInteger_EmptyAlphaOrDecimal_Null(string value)
    {
        var actual = value.ToNullableInteger();
        Assert.Null(actual);
    }

    [Fact]
    public void ToNullableInteger_Numeric_Int()
    {
        var actual = "123".ToNullableInteger();
        Assert.Equal(123, actual.Value);
    }
}
