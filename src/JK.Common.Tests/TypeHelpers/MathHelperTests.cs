﻿using System.Collections.Generic;
using System.Linq;
using JK.Common.TypeHelpers;

namespace JK.Common.Tests.TypeHelpers;

public class MathHelperTests
{
    [Fact]
    public void Fibonacci()
    {
        IEnumerable<long> actual = MathHelper.Fibonacci(0, 1, 8);
        var actualDelimited = string.Join(",", actual.Select(x => $"{x}"));
        Assert.Equal("0,1,1,2,3,5,8,13,21", actualDelimited);
    }

    [Theory]
    [InlineData(1, false)]
    [InlineData(2, true)]
    [InlineData(15, false)]
    [InlineData(18, true)]
    public void IsEven(long input, bool expected)
    {
        var actual = MathHelper.IsEven(input);
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(1, true)]
    [InlineData(2, false)]
    [InlineData(15, true)]
    [InlineData(18, false)]
    public void IsOdd(long input, bool expected)
    {
        var actual = MathHelper.IsOdd(input);
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(1, false)]
    [InlineData(2, true)]
    [InlineData(8, false)]
    [InlineData(17, true)]
    [InlineData(6857, true)]
    public void IsPrime(int input, bool expected)
    {
        var actual = MathHelper.IsPrime(input);
        Assert.Equal(expected, actual);
    }
}
