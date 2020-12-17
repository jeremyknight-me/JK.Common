using System;

namespace JK.Common.TypeHelpers
{
    public class DateTimeOffsetFactory
    {
        public DateTimeOffset Make(DateTime date, string timeZoneId)
        {
            var offset = this.GetOffsetForDate(date, timeZoneId);
            return DateTimeOffset.Parse($"{date:yyyy-MM-ddTHH:mm:ss}{offset.Hours:+00;-00}:00");
        }

        public DateTimeOffset Make(int year, int month, int day, string timeZoneId)
        {
            var date = new DateTime(year, month, day);
            return this.Make(date, timeZoneId);
        }

        public DateTimeOffset Make(int year, int month, int day, int hour, int minute, int second, string timeZoneId)
        {
            var date = new DateTime(year, month, day, hour, minute, second);
            return this.Make(date, timeZoneId);
        }

        private TimeSpan GetOffsetForDate(DateTime date, string timeZoneId)
        {
            var dateOffset = DateTimeOffset.Parse($"{date:yyyy-MM-dd} 12:00:00");
            var centralDate = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(dateOffset, timeZoneId);
            return centralDate.Offset;
        }
    }
}
