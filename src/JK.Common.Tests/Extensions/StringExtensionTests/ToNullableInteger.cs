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
    public void EmptyAlphaOrDecimal_Null(string value)
    {
        var actual = value.ToNullableInteger();
        Assert.Null(actual);
    }

    [Fact]
    public void Numeric_Int()
    {
        var actual = "123".ToNullableInteger();
        Assert.Equal(123, actual.Value);
    }
}
