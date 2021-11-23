﻿using JK.Common.Specifications.UnitedStates;

namespace JK.Common.Tests.Specifications.UnitedStates;

public class ZipCodeSpecificationTests
{
    [Theory]
    [InlineData("12345", true)]
    [InlineData("12X45", false)]
    [InlineData("12345-6789", true)]
    [InlineData("12X45-6789", false)]
    [InlineData("12345-67X9", false)]
    public void IsSatisfiedBy(string input, bool expected)
    {
        var specification = new ZipCodeSpecification();
        var actual = specification.IsSatisfiedBy(input);
        Assert.Equal(expected, actual);
    }
}
