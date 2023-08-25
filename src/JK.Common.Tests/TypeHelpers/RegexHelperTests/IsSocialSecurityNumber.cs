﻿using JK.Common.TypeHelpers;

namespace JK.Common.Tests.TypeHelpers.RegexHelperTests;

public class IsSocialSecurityNumber
{
    [Theory]
    [InlineData("078051120", true)]
    [InlineData("078 05 1120", true)]
    [InlineData("078-05-1120", true)]
    [InlineData("899-05-1120", true)] // left less than 900
    [InlineData("000000000", false)]
    [InlineData("000 00 0000", false)]
    [InlineData("000-00-0000", false)]
    [InlineData("111-00-1111", false)] // middle all 0
    [InlineData("111-11-0000", false)] // right all 0
    [InlineData("666-12-4321", false)] // left 666
    [InlineData("900-12-4321", false)] // left greater than equal 900
    public void IsSocialSecurityNumber_Theories(string input, bool expected)
    {
        var actual = RegexHelper.IsSocialSecurityNumber(input);
        Assert.Equal(expected, actual);
    }
}
