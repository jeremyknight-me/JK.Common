namespace JK.Common.DateTimeProviders;

/// <summary>
/// Default implementation of <see cref="IDateTimeOffsetProvider"/> that returns the current system time offset.
/// </summary>
public sealed class DefaultDateTimeOffsetProvider : IDateTimeOffsetProvider
{
    /// <inheritdoc/>
    public DateTimeOffset Now => DateTimeOffset.Now;

    /// <inheritdoc/>
    public DateTimeOffset UtcNow => DateTimeOffset.UtcNow;
}
