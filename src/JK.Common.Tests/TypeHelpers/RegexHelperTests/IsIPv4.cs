using JK.Common.TypeHelpers;

namespace JK.Common.Tests.TypeHelpers.RegexHelperTests;

public class IsIPv4
{
    [Theory]
    [InlineData("255.255.255.255", true)]
    [InlineData("300.300.300.300", false)]
    [InlineData("255.255.255", false)]
    public void IsIPv4_Theories(string input, bool expected)
    {
        var actual = RegexHelper.IsIPv4(input);
        Assert.Equal(expected, actual);
    }
}
