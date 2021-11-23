﻿using JK.Common.Specifications;

namespace JK.Common.Tests.Specifications;

public class NotEmptySpecificationTests
{
    [Theory]
    [InlineData(null, false)]
    [InlineData("", false)]
    [InlineData("  ", false)]
    [InlineData("x", true)]
    public void IsSatisfiedBy(string input, bool expected)
    {
        var specification = new NotEmptySpecification();
        var actual = specification.IsSatisfiedBy(input);
        Assert.Equal(expected, actual);
    }
}
