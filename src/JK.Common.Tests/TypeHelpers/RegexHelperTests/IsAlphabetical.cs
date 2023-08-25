using JK.Common.TypeHelpers;

namespace JK.Common.Tests.TypeHelpers.RegexHelperTests;

public class IsAlphabetical
{
    [Theory]
    [InlineData("abc", true)]
    [InlineData("asdf234", false)]
    public void IsAlphabetical_Theories(string input, bool expected)
    {
        var actual = RegexHelper.IsAlphabetical(input);
        Assert.Equal(expected, actual);
    }
}
