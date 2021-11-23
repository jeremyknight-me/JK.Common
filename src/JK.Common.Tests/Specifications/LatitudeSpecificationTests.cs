﻿using JK.Common.Specifications;

namespace JK.Common.Tests.Specifications;

public class LatitudeSpecificationTests
{
    [Theory]
    [InlineData(-91, false)]
    [InlineData(-90, true)]
    [InlineData(0, true)]
    [InlineData(90, true)]
    [InlineData(91, false)]
    public void IsSatisfiedBy(double input, bool expected)
    {
        var specification = new LatitudeSpecification();
        var actual = specification.IsSatisfiedBy(input);
        Assert.Equal(expected, actual);
    }
}
