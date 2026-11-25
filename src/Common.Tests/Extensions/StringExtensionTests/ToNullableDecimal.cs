using JK.Common.Extensions;

namespace JK.Common.Tests.Extensions.StringExtensionTests;

public class ToNullableDecimal
{
    public static TheoryData<string, decimal> NumericData => new()
    {
        { "123", 123m },
        { "123.456", 123.456m }
    };

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("  ")]
    [InlineData("abc")]
    public void EmptyOrAlpha_Null(string value)
    {
        var actual = value.ToNullableDecimal();
        Assert.Null(actual);
    }

    [Theory]
    [MemberData(nameof(NumericData))]
    public void Numeric_Decimal(string input, decimal expected)
    {
        var actual = input.ToNullableDecimal();
        Assert.Equal(expected, actual);
    }
}
