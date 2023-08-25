using JK.Common.TypeHelpers;

namespace JK.Common.Tests.TypeHelpers.DateHelperTests;

public partial class CalculateAge
{
    [Theory]
    [InlineData(29, "1983-03-15", "2012-06-12")]
    [InlineData(8, "2000-02-29", "2009-02-28")] // leap year not reached
    [InlineData(9, "2000-02-29", "2009-03-01")] // leap year reached
    public void DateTime_Theories(int expected, string birthday, string now)
    {
        var birthdayDate = DateTime.Parse(birthday);
        var nowDate = DateTime.Parse(now);
        var actual = DateHelper.CalculateAge(nowDate, birthdayDate);
        Assert.Equal(expected, actual);
    }
}

#if (NET6_0_OR_GREATER)

public partial class CalculateAge
{
    [Theory]
    [InlineData(29, "1983-03-15", "2012-06-12")]
    [InlineData(8, "2000-02-29", "2009-02-28")] // leap year not reached
    [InlineData(9, "2000-02-29", "2009-03-01")] // leap year reached
    public void DateOnly_Theories(int expected, string birthday, string now)
    {
        var birthdayDate = DateOnly.Parse(birthday);
        var nowDate = DateOnly.Parse(now);
        var actual = DateHelper.CalculateAge(nowDate, birthdayDate);
        Assert.Equal(expected, actual);
    }
}

#endif
