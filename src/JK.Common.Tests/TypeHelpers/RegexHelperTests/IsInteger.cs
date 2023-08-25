using JK.Common.TypeHelpers;

namespace JK.Common.Tests.TypeHelpers.RegexHelperTests;

public class IsInteger
{
    [Theory]
    [InlineData("12", true)]
    [InlineData("-12", true)]
    [InlineData("12.00", false)]
    [InlineData("1a", false)]
    public void IsInteger_Theories(string input, bool expected)
    {
        var actual = RegexHelper.IsInteger(input);
        Assert.Equal(expected, actual);
    }
}
