﻿using JK.Common.TypeHelpers;

namespace JK.Common.Tests.TypeHelpers;

public class ExcelHelperTests
{
    #region GetColumnName() Tests

    [Theory]
    [InlineData(1, "A")]
    [InlineData(10, "J")]
    [InlineData(27, "AA")]
    [InlineData(36, "AJ")]
    public void GetColumnName_Tests(int columnNumber, string expected)
    {
        var actual = ExcelHelper.GetColumnName(columnNumber);
        Assert.Equal(expected, actual);
    }

    #endregion
}
