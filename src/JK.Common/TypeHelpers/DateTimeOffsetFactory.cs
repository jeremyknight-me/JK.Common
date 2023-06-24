using System;

namespace JK.Common.TypeHelpers;

public static class DateTimeOffsetFactory
{
    public static DateTimeOffset Make(in DateTime date, in string timeZoneId)
    {
        var offset = GetOffsetForDate(date, timeZoneId);
        return DateTimeOffset.Parse($"{date:yyyy-MM-ddTHH:mm:ss}{offset.Hours:+00;-00}:00");
    }

    public static DateTimeOffset Make(in int year, in int month, in int day, in string timeZoneId)
    {
        var date = new DateTime(year, month, day);
        return Make(date, timeZoneId);
    }

    public static DateTimeOffset Make(in int year, in int month, in int day,
        in int hour, in int minute, in int second, in string timeZoneId)
    {
        var date = new DateTime(year, month, day, hour, minute, second);
        return Make(date, timeZoneId);
    }

    private static TimeSpan GetOffsetForDate(in DateTime date, in string timeZoneId)
    {
        var dateOffset = DateTimeOffset.Parse($"{date:yyyy-MM-dd} 12:00:00");
        var centralDate = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(dateOffset, timeZoneId);
        return centralDate.Offset;
    }
}
