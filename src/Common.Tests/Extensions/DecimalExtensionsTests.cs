using JK.Common.Extensions;

namespace JK.Common.Tests.Extensions;

public class DecimalExtensionsTests
{
    public static TheoryData<decimal, decimal> DecimalPartData => new()
    {
        { 0m, 1.0m },
        { 0.1m, 1.1m },
        { 0.25m, 1.25m }
    };

    [Theory]
    [MemberData(nameof(DecimalPartData))]
    public void GetDecimalPart_Theories(decimal expected, decimal value)
    {
        var actual = value.DecimalPart;
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(0, 0.12)]
    [InlineData(1, 1.54)]
    [InlineData(25, 25.75)]
    public void GetWholePart_Theories(decimal expected, decimal value)
    {
        var actual = value.WholePart;
        Assert.Equal(expected, actual);
    }
}
