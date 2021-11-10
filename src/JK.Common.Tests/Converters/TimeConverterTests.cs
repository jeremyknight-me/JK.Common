using JK.Common.Converters;

namespace JK.Common.Tests.Converters;

public class TimeConverterTests
{
    [Fact]
    public void ConvertSecondsToMillesecondsTest()
    {
        int seconds = 1;
        int expected = 1000;
        int actual = TimeConverter.ConvertSecondsToMilliseconds(seconds);
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void ConvertMinutesToSecondsTest()
    {
        int minutes = 1;
        int expected = 60;
        int actual = TimeConverter.ConvertMinutesToSeconds(minutes);
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void ConvertMinutesToMillesecondsTest()
    {
        int minutes = 1;
        int expected = 60000;
        int actual = TimeConverter.ConvertMinutesToMilliseconds(minutes);
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void ConvertHoursToMillesecondsTest()
    {
        int hours = 1;
        int expected = 3600000;
        int actual = TimeConverter.ConvertHoursToMilliseconds(hours);
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void ConvertHoursToMinutesTest()
    {
        int hours = 1;
        int expected = 60;
        int actual = TimeConverter.ConvertHoursToMinutes(hours);
        Assert.Equal(expected, actual);
    }
}
