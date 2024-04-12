using System;

namespace JK.Common.DateTimeProviders;

/// <summary>
/// Abstraction to disconnect <see cref="DateTimeOffset"/> from the system clock.
/// </summary>
public interface IDateTimeOffsetProvider
{
    /// <summary>
    /// Returns a <see cref="DateTimeOffset"/> representing the current date and time.
    /// </summary>
    DateTimeOffset Now { get; }

    /// <summary>
    /// Returns a <see cref="DateTimeOffset"/> representing the current UTC date and time.
    /// </summary>
    DateTimeOffset UtcNow { get; }
}
