namespace JK.Common.Geospatial;

/// <summary>
/// Represents the display format for geographic coordinates.
/// </summary>
public enum DisplayFormat
{
    /// <summary>
    /// Degrees only (DDD.dddddddd).
    /// </summary>
    Degrees = 0,
    /// <summary>
    /// Degrees and minutes (DDD° MM.mmm').
    /// </summary>
    DegreesMinutes = 1,
    /// <summary>
    /// Degrees, minutes, and seconds (DDD° MM' SS").
    /// </summary>
    DegreesMinutesSeconds = 2,
    /// <summary>
    /// Degrees and direction (DDD° [N|S|E|W]).
    /// </summary>
    DegreesDirection = 3,
    /// <summary>
    /// Degrees, minutes, and direction (DDD° MM.mmm' [N|S|E|W]).
    /// </summary>
    DegreesMinutesDirection = 4,
    /// <summary>
    /// Degrees, minutes, seconds, and direction (DDD° MM' SS" [N|S|E|W]).
    /// </summary>
    DegreesMinutesSecondsDirection = 5
}
