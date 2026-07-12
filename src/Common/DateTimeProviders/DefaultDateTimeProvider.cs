namespace JK.Common.DateTimeProviders;

/// <inheritdoc/>
public sealed class DefaultDateTimeProvider : IDateTimeProvider
{
    /// <inheritdoc/>
    public DateTime Now => DateTime.Now;

    /// <inheritdoc/>
    public DateTime Today => DateTime.Today;

    /// <inheritdoc/>
    public DateTime UtcNow => DateTime.UtcNow;
}
