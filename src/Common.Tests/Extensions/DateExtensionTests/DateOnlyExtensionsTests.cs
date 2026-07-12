#if NET6_0_OR_GREATER

using JK.Common.Extensions;

namespace JK.Common.Tests.Extensions.DateExtensionTests;

public class DateOnlyExtensionsTests
{
    [Theory]
    [MemberData(nameof(SubtractOperator_Data))]
    public void SubtractOperator_Theories(DateOnly left, DateOnly right, int expected)
    {
        var result = left - right;
        Assert.Equal(expected, result);
    }

    public static TheoryData<DateOnly, DateOnly, int> SubtractOperator_Data { get; }
        = new TheoryData<DateOnly, DateOnly, int>
        {
            // Left is after Right -> positive difference (4 days)
            { new DateOnly(2023, 10, 5), new DateOnly(2023, 10, 1), 4 },
            // Left is before Right -> negative difference (-4 days)
            { new DateOnly(2023, 10, 1), new DateOnly(2023, 10, 5), -4 },
            // Cross-year difference: early 2024 minus end of 2023
            { new DateOnly(2024, 1, 15), new DateOnly(2023, 12, 31), 15 },
            // Same year span from Jan 1 to Dec 31 (non-leap year)
            { new DateOnly(2023, 12, 31), new DateOnly(2023, 1, 1), 364 },
            // Full year in a leap year from Jan 1 to Dec 31 (365 days)
            { new DateOnly(2024, 12, 31), new DateOnly(2024, 1, 1), 365 },
            // Same date -> zero difference
            { new DateOnly(2023, 5, 10), new DateOnly(2023, 5, 10), 0 },
            // Leap-year February: 2024-02-29 minus 2024-02-01 = 28 days
            { new DateOnly(2024, 2, 29), new DateOnly(2024, 2, 1), 28 },
        };
}

#endif
