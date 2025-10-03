using JK.Common.Extensions;

namespace JK.Common.Tests.Extensions.StringExtensionTests;

public class ToNullableDecimal
{
    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("  ")]
    [InlineData("abc")]
    public void ToNullableDecimal_EmptyOrAlpha_Null(string value)
    {
        var actual = value.ToNullableDecimal();
        Assert.Null(actual);
    }

    [Theory]
    [InlineData("123", 123)]
    [InlineData("123.456", 123.456)]
    public void ToNullableDecimal_Numeric_Decimal(string input, decimal expected)
    {
        var actual = input.ToNullableDecimal();
        Assert.Equal(expected, actual);
    }
}
