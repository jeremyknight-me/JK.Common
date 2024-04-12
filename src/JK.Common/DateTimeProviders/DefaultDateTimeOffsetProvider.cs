using System;

namespace JK.Common.DateTimeProviders;

/// <inheritdoc/>
public sealed class DefaultDateTimeOffsetProvider : IDateTimeOffsetProvider
{
    /// <inheritdoc/>
    public DateTimeOffset Now => DateTimeOffset.Now;

    /// <inheritdoc/>
    public DateTimeOffset UtcNow => DateTimeOffset.UtcNow;
}
