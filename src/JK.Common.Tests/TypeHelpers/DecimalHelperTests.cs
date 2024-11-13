using JK.Common.TypeHelpers;

namespace JK.Common.Tests.TypeHelpers;

public class DecimalHelperTests
{
    [Theory]
    [InlineData(0, 1.0)]
    [InlineData(0.1, 1.1)]
    [InlineData(0.25, 1.25)]
    public void GetDecimalPart_Theories(decimal expected, decimal value)
    {
        var actual = DecimalHelper.GetDecimalPart(value);
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(0, 0.12)]
    [InlineData(1, 1.54)]
    [InlineData(25, 25.75)]
    public void GetWholePart_Theories(decimal expected, decimal value)
    {
        var actual = DecimalHelper.GetWholePart(value);
        Assert.Equal(expected, actual);
    }
}
