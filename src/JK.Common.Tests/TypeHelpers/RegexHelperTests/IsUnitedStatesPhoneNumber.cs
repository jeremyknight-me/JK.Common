using JK.Common.TypeHelpers;

namespace JK.Common.Tests.TypeHelpers.RegexHelperTests;

public class IsUnitedStatesPhoneNumber
{
    [Theory]
    [InlineData("5555551234", true)]
    [InlineData("(555) 555-1234", true)]
    [InlineData("555-555-1234", true)]
    [InlineData("5551234", true)]
    [InlineData("555-1234", true)]
    public void IsUnitedStatesPhoneNumber_Theories(string input, bool expected)
    {
        var actual = RegexHelper.IsUnitedStatesPhoneNumber(input);
        Assert.Equal(expected, actual);
    }
}
