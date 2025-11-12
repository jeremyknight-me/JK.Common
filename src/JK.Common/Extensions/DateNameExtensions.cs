using System.Globalization;

namespace JK.Common.Extensions;

public static class DateNameExtensions
{
    extension(DateTime date)
    {
        /// <summary>Gets the abbreviated day name.</summary>
        /// <returns>Abbreviated day name.</returns>
        public string AbbreviatedDayName => GetAbbreviatedDayName(date.DayOfWeek, CultureInfo.CurrentCulture);

        /// <summary>Gets the abbreviated month name.</summary>
        /// <returns>Abbreviated month name.</returns>
        public string AbbreviatedMonthName => GetAbbreviatedMonthName(date.Month, CultureInfo.CurrentCulture);

        /// <summary>Gets the full name of a given day.</summary>
        /// <returns>Full day name.</returns>
        public string DayName => GetDayName(date.DayOfWeek, CultureInfo.CurrentCulture);

        /// <summary>Gets the full name of a month.</summary>
        /// <returns>Full month name.</returns>
        public string MonthName => GetMonthName(date.Month, CultureInfo.CurrentCulture);
    }

    extension(DateTimeOffset date)
    {
        /// <summary>Gets the abbreviated day name.</summary>
        /// <returns>Abbreviated day name.</returns>
        public string AbbreviatedDayName => GetAbbreviatedDayName(date.DayOfWeek, CultureInfo.CurrentCulture);

        /// <summary>Gets the abbreviated month name.</summary>
        /// <returns>Abbreviated month name.</returns>
        public string AbbreviatedMonthName => GetAbbreviatedMonthName(date.Month, CultureInfo.CurrentCulture);

        /// <summary>Gets the full name of a given day.</summary>
        /// <returns>Full day name.</returns>
        public string DayName => GetDayName(date.DayOfWeek, CultureInfo.CurrentCulture);

        /// <summary>Gets the full name of a month.</summary>
        /// <returns>Full month name.</returns>
        public string MonthName => GetMonthName(date.Month, CultureInfo.CurrentCulture);
    }

#if NET6_0_OR_GREATER

    extension(DateOnly date)
    {
        /// <summary>Gets the abbreviated day name.</summary>
        /// <returns>Abbreviated day name.</returns>
        public string AbbreviatedDayName => GetAbbreviatedDayName(date.DayOfWeek);

        /// <summary>Gets the abbreviated month name.</summary>
        /// <returns>Abbreviated month name.</returns>
        public string AbbreviatedMonthName => GetAbbreviatedMonthName(date.Month);

        /// <summary>Gets the full name of a given day.</summary>
        /// <returns>Full day name.</returns>
        public string DayName => GetDayName(date.DayOfWeek);

        /// <summary>Gets the full name of a month.</summary>
        /// <returns>Full month name.</returns>
        public string MonthName => GetMonthName(date.Month);
    }

#endif

    private static string GetAbbreviatedDayName(DayOfWeek dayOfWeek, CultureInfo cultureInfo = null)
    {
        cultureInfo ??= CultureInfo.CurrentCulture;
        return cultureInfo.DateTimeFormat.GetAbbreviatedDayName(dayOfWeek);
    }

    private static string GetAbbreviatedMonthName(int month, CultureInfo cultureInfo = null)
    {
        cultureInfo ??= CultureInfo.CurrentCulture;
        return cultureInfo.DateTimeFormat.GetAbbreviatedMonthName(month);
    }

    private static string GetDayName(DayOfWeek dayOfWeek, CultureInfo cultureInfo = null)
    {
        cultureInfo ??= CultureInfo.CurrentCulture;
        return cultureInfo.DateTimeFormat.GetDayName(dayOfWeek);
    }

    private static string GetMonthName(int month, CultureInfo cultureInfo = null)
    {
        cultureInfo ??= CultureInfo.CurrentCulture;
        return cultureInfo.DateTimeFormat.GetMonthName(month);
    }
}
