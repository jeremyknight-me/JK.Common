using System;

namespace JK.Common.TypeHelpers;

public class DateTimeOffsetFactory
{
    public DateTimeOffset Make(in DateTime date, in string timeZoneId)
    {
        var offset = this.GetOffsetForDate(date, timeZoneId);
        return DateTimeOffset.Parse($"{date:yyyy-MM-ddTHH:mm:ss}{offset.Hours:+00;-00}:00");
    }

    public DateTimeOffset Make(in int year, in int month, in int day, in string timeZoneId)
    {
        var date = new DateTime(year, month, day);
        return this.Make(date, timeZoneId);
    }

    public DateTimeOffset Make(in int year, in int month, in int day,
        in int hour, in int minute, in int second, in string timeZoneId)
    {
        var date = new DateTime(year, month, day, hour, minute, second);
        return this.Make(date, timeZoneId);
    }

    private TimeSpan GetOffsetForDate(in DateTime date, in string timeZoneId)
    {
        var dateOffset = DateTimeOffset.Parse($"{date:yyyy-MM-dd} 12:00:00");
        var centralDate = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(dateOffset, timeZoneId);
        return centralDate.Offset;
    }
}
