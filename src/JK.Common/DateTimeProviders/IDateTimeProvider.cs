using System;

namespace JK.Common.DateTimeProviders;

/// <summary>
/// Abstraction to disconnect <see cref="DateTime"/> from the system clock.
/// </summary>
public interface IDateTimeProvider
{
    /// <summary>
    /// Returns a <see cref="DateTime"/> representing the current date and time.
    /// </summary>
    DateTime Now { get; }

    /// <summary>
    /// Returns a Dat<see cref="DateTime"/>eTime representing the current date. The date part
    /// of the returned value is the current date, and the time-of-day part of
    /// the returned value is zero (midnight).
    /// </summary>
    DateTime Today { get; }

    /// <summary>
    /// Returns a <see cref="DateTime"/> representing the current UTC date and time.
    /// </summary>
    DateTime UtcNow { get; }
}
