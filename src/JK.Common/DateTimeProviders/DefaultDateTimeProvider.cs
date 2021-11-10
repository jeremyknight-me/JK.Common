using System;

namespace JK.Common.DateTimeProviders;

public sealed class DefaultDateTimeProvider : IDateTimeProvider
{
    public DateTime Now => DateTime.Now;
    public DateTime Today => DateTime.Today;
    public DateTime UtcNow => DateTime.UtcNow;
}
