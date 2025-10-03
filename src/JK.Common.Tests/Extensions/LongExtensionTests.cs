using JK.Common.Extensions;

namespace JK.Common.Tests.Extensions;

public  class LongExtensionTests
{
    [Theory]
    [InlineData(1, false)]
    [InlineData(2, true)]
    [InlineData(15, false)]
    [InlineData(18, true)]
    public void IsEven(long input, bool expected)
    {
        var actual = input.IsEven();
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(1, true)]
    [InlineData(2, false)]
    [InlineData(15, true)]
    [InlineData(18, false)]
    public void IsOdd(long input, bool expected)
    {
        var actual = input.IsOdd();
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(1, false)]
    [InlineData(2, true)]
    [InlineData(8, false)]
    [InlineData(17, true)]
    [InlineData(71, true)]
    [InlineData(6857, true)]
    public void IsPrime(long input, bool expected)
    {
        var actual = input.IsPrime();
        Assert.Equal(expected, actual);
    }
}
