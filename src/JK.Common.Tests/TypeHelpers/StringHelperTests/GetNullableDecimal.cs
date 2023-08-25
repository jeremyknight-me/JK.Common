using JK.Common.TypeHelpers;

namespace JK.Common.Tests.TypeHelpers.StringHelperTests;

public class GetNullableDecimal
{
    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("  ")]
    [InlineData("abc")]
    public void GetNullableDecimal_EmptyOrAlpha_Null(string value)
    {
        var actual = StringHelper.GetNullableDecimal(value);
        Assert.Null(actual);
    }

    [Theory]
    [InlineData("123", 123)]
    [InlineData("123.456", 123.456)]
    public void GetNullableDecimal_Numeric_Decimal(string input, decimal expected)
    {
        var actual = StringHelper.GetNullableDecimal(input);
        Assert.Equal(expected, actual);
    }
}
