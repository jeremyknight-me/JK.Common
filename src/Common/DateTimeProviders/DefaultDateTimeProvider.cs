namespace JK.Common.DateTimeProviders;

/// <summary>
/// Default implementation of <see cref="IDateTimeProvider"/> that returns the current system time.
/// </summary>
public sealed class DefaultDateTimeProvider : IDateTimeProvider
{
    /// <inheritdoc/>
    public DateTime Now => DateTime.Now;

    /// <inheritdoc/>
    public DateTime Today => DateTime.Today;

    /// <inheritdoc/>
    public DateTime UtcNow => DateTime.UtcNow;
}
