using JK.Common.DateTimeProviders;

namespace JK.Common.TypeHelpers;

public sealed class AgeCalculator
{
    private readonly IDateTimeProvider _dateTimeProvider;

    public AgeCalculator()
    {
        _dateTimeProvider = new DefaultDateTimeProvider();
    }

    public AgeCalculator(IDateTimeProvider dateTimeProvider)
    {
        _dateTimeProvider = dateTimeProvider;
    }

#if NET6_0_OR_GREATER

    /// <summary>
    /// Calculates the age in years from the specified <paramref name="startDate"/> to today.
    /// </summary>
    /// <param name="startDate">The start date (typically the date of birth).</param>
    /// <returns>The calculated age in years.</returns>
    public int Calculate(in DateOnly startDate)
    {
        var now = DateOnly.FromDateTime(_dateTimeProvider.Today);
        return Calculate(startDate, now);
    }

    /// <summary>
    /// Calculates the age in years from the specified <paramref name="startDate"/> to the specified <paramref name="endDate"/>.
    /// </summary>
    /// <param name="startDate">The start date (typically the date of birth).</param>
    /// <param name="endDate">The end date to calculate the age as of.</param>
    /// <returns>The calculated age in years.</returns>
    public int Calculate(in DateOnly startDate, in DateOnly endDate)
    {
        var age = endDate.Year - startDate.Year;
        if (startDate > endDate.AddYears(-age))
        {
            age--;
        }

        return age;
    }

#endif

    /// <summary>
    /// Calculates the age in years from the specified <paramref name="startDate"/> to today.
    /// </summary>
    /// <param name="startDate">The start date (typically the date of birth).</param>
    /// <returns>The calculated age in years.</returns>
    public int Calculate(in DateTime startDate)
    {
        DateTime now = _dateTimeProvider.Today;
        return Calculate(startDate, now);
    }

    /// <summary>
    /// Calculates the age in years from the specified <paramref name="startDate"/> to the specified <paramref name="endDate"/>.
    /// </summary>
    /// <param name="startDate">The start date (typically the date of birth).</param>
    /// <param name="endDate">The end date to calculate the age as of.</param>
    /// <returns>The calculated age in years.</returns>
    public int Calculate(in DateTime startDate, in DateTime endDate)
    {
        DateTime now = endDate.Date;
        var age = now.Year - startDate.Year;
        if (startDate > now.AddYears(-age))
        {
            age--;
        }

        return age;
    }
}
