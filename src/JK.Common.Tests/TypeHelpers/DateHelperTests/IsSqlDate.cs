using JK.Common.TypeHelpers;

namespace JK.Common.Tests.TypeHelpers.DateHelperTests;

public partial class IsSqlDate
{
    [Theory]
    [InlineData(false, "1700-01-18")]
    [InlineData(true, "2011-01-15")]
    public void DateTime_Theories(bool expected, string dateInput)
    {
        var date = DateTime.Parse(dateInput);
        var actual = DateHelper.IsSqlDate(date);
        Assert.Equal(expected, actual);
    }
}

#if (NET6_0_OR_GREATER)

public partial class IsSqlDate
{
    [Theory]
    [InlineData(false, "1700-01-18")]
    [InlineData(true, "2011-01-15")]
    public void DateOnly_Theories(bool expected, string dateInput)
    {
        var date = DateOnly.Parse(dateInput);
        var actual = DateHelper.IsSqlDate(date);
        Assert.Equal(expected, actual);
    }
}

#endif
