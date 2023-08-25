using JK.Common.TypeHelpers;

namespace JK.Common.Tests.TypeHelpers.StringHelperTests;

public class RemoveUSCurrencyFormat
{
    [Theory]
    [InlineData("$1,000,000.00", "1000000.00")]
    [InlineData("1000.00", "1000.00")]
    [InlineData("$,", "0")]
    public void RemoveUnitedStatesCurrencyFormat_WithCharacters(string input, string expected)
    {
        var actual = StringHelper.RemoveUnitedStatesCurrencyFormat(input);
        Assert.Equal(expected, actual);
    }
}
