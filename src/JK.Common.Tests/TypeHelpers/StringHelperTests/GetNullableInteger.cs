using JK.Common.TypeHelpers;

namespace JK.Common.Tests.TypeHelpers.StringHelperTests;

public class GetNullableInteger
{
    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("  ")]
    [InlineData("abc")]
    [InlineData("123.456")]
    public void GetNullableInteger_EmptyAlphaOrDecimal_Null(string value)
    {
        var actual = StringHelper.GetNullableInteger(value);
        Assert.Null(actual);
    }

    [Fact]
    public void GetNullableInteger_Numeric_Int()
    {
        var actual = StringHelper.GetNullableInteger("123");
        Assert.Equal(123, actual.Value);
    }
}
