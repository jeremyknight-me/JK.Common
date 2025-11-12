namespace JK.Common.TypeHelpers;

/// <summary>
/// Helper methods for working with date ranges.
/// </summary>
public static class DateRangeHelper
{
    /// <summary>Determines whether or not two date ranges overlap.</summary>
    /// <param name="startOne">Start date of range one</param>
    /// <param name="endOne">End date of range one</param>
    /// <param name="startTwo">Start date of range two</param>
    /// <param name="endTwo">End date of range two</param>
    /// <returns>True if overlap, otherwise false</returns>
    public static bool DoesOverlap(in DateTime startOne, in DateTime endOne, in DateTime startTwo, in DateTime endTwo) => startOne < endTwo && startTwo < endOne;

    /// <summary>Determines whether or not two date ranges overlap.</summary>
    /// <param name="startOne">Start date of range one</param>
    /// <param name="endOne">End date of range one</param>
    /// <param name="startTwo">Start date of range two</param>
    /// <param name="endTwo">End date of range two</param>
    /// <returns>True if overlap, otherwise false</returns>
    public static bool DoesOverlap(in DateTimeOffset startOne, in DateTimeOffset endOne, in DateTimeOffset startTwo, in DateTimeOffset endTwo) => startOne < endTwo && startTwo < endOne;


#if NET6_0_OR_GREATER

    /// <summary>Determines whether or not two date ranges overlap.</summary>
    /// <param name="startOne">Start date of range one</param>
    /// <param name="endOne">End date of range one</param>
    /// <param name="startTwo">Start date of range two</param>
    /// <param name="endTwo">End date of range two</param>
    /// <returns>True if overlap, otherwise false</returns>
    public static bool DoesOverlap(in DateOnly startOne, in DateOnly endOne, in DateOnly startTwo, in DateOnly endTwo)
        => startOne < endTwo && startTwo < endOne;

#endif

}
