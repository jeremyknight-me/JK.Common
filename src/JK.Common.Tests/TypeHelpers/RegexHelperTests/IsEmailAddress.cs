using JK.Common.TypeHelpers;

namespace JK.Common.Tests.TypeHelpers.RegexHelperTests;

public class IsEmailAddress
{
    [Theory]
    [InlineData("someemail@domain.com", true)]
    [InlineData("some@email@domain.com", false)]
    public void IsEmailAddress_Theories(string input, bool expected)
    {
        var actual = RegexHelper.IsEmailAddress(input);
        Assert.Equal(expected, actual);
    }
}
