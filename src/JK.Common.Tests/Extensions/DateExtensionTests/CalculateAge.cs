using JK.Common.Extensions;

namespace JK.Common.Tests.Extensions.DateExtensionTests;

public class CalculateAge
{
    [Theory]
    [MemberData(nameof(Data))]
    public void DateTime_Theories(int expected, string birthday, string now)
    {
        var birthdayDate = DateTime.Parse(birthday);
        var nowDate = DateTime.Parse(now);
        var actual = nowDate.CalculateAge(birthdayDate);
        Assert.Equal(expected, actual);
    }

#if NET6_0_OR_GREATER
    [Theory]
    [MemberData(nameof(Data))]
    public void DateOnly_Theories(int expected, string birthday, string now)
    {
        var birthdayDate = DateOnly.Parse(birthday);
        var nowDate = DateOnly.Parse(now);
        var actual = nowDate.CalculateAge(birthdayDate);
        Assert.Equal(expected, actual);
    }
#endif

    public static TheoryData<int, string, string> Data()
        => new()
        {
                { 29, "1983-03-15", "2012-06-12" },
                { 8, "2000-02-29", "2009-02-28" }, // leap year not reached
                { 9, "2000-02-29", "2009-03-01" } // leap year reached
        };
}
