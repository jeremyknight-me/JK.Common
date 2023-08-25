using JK.Common.TypeHelpers;

namespace JK.Common.Tests.TypeHelpers.StringHelperTests;

public class Right
{
    [Theory]
    [InlineData("", 2, "")]
    [InlineData("Test", 2, "st")]
    [InlineData("Test", 4, "Test")]
    [InlineData("Test", 6, "Test")]
    public void Right_Theories(string input, int length, string expected)
    {
        var actual = StringHelper.Right(input, length);
        Assert.Equal(expected, actual);
    }
}
