using JK.Common.TypeHelpers;

namespace JK.Common.Tests.TypeHelpers.RegexHelperTests;

public class IsDecimal
{
    [Theory]
    [InlineData("12", true)]
    [InlineData("12.00", true)]
    [InlineData("0.34", true)]
    [InlineData("00.34", true)]
    [InlineData("12.34", true)]
    [InlineData("$12.34", false)]
    [InlineData("-$12.34", false)]
    [InlineData("$-12.34", false)]
    [InlineData("$1,234", false)]
    [InlineData("$1,234.56", false)]
    [InlineData("1a", false)]
    [InlineData("1a.00", false)]
    [InlineData("0a.34", false)]
    [InlineData("1a.34", false)]
    [InlineData("$1a.34", false)]
    public void IsDecimal_Theories(string input, bool expected)
    {
        var actual = RegexHelper.IsDecimal(input);
        Assert.Equal(expected, actual);
    }
}
