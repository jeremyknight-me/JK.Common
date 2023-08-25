using JK.Common.TypeHelpers;

namespace JK.Common.Tests.TypeHelpers.RegexHelperTests;

public class IsAlphanumeric
{
    [Theory]
    [InlineData("abc123", true)]
    [InlineData("asdf234*@#asdf", false)]
    public void IsAlphanumeric_Theories(string input, bool expected)
    {
        var actual = RegexHelper.IsAlphanumeric(input);
        Assert.Equal(expected, actual);
    }
}
