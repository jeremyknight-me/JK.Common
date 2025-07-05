using JK.Common.Converters;

namespace JK.Common.Tests.Converters;

public class TimeConverterTests
{
    [Fact]
    public void ConvertSecondsToMillisecondsTest()
    {
        var seconds = 1;
        var expected = 1000;
        var actual = TimeConverter.ConvertSecondsToMilliseconds(seconds);
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void ConvertMinutesToSecondsTest()
    {
        var minutes = 1;
        var expected = 60;
        var actual = TimeConverter.ConvertMinutesToSeconds(minutes);
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void ConvertMinutesToMillisecondsTest()
    {
        var minutes = 1;
        var expected = 60000;
        var actual = TimeConverter.ConvertMinutesToMilliseconds(minutes);
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void ConvertHoursToMillisecondsTest()
    {
        var hours = 1;
        var expected = 3600000;
        var actual = TimeConverter.ConvertHoursToMilliseconds(hours);
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void ConvertHoursToMinutesTest()
    {
        var hours = 1;
        var expected = 60;
        var actual = TimeConverter.ConvertHoursToMinutes(hours);
        Assert.Equal(expected, actual);
    }
}
