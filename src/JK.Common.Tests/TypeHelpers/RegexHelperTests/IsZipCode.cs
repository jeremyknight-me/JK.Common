using JK.Common.TypeHelpers;

namespace JK.Common.Tests.TypeHelpers.RegexHelperTests;

public class IsZipCode
{
    [Theory]
    [InlineData("12345", true)]
    [InlineData("12X45", false)]
    [InlineData("12345-6789", true)]
    [InlineData("12X45-6789", false)]
    [InlineData("12345-67X9", false)]
    public void IsZipCode_Theories(string input, bool expected)
    {
        var actual = RegexHelper.IsZipCode(input);
        Assert.Equal(expected, actual);
    }
}
