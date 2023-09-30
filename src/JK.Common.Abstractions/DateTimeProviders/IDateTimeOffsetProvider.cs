using System;

namespace JK.Common.DateTimeProviders;

public interface IDateTimeOffsetProvider
{
    DateTimeOffset Now { get; }
    DateTimeOffset UtcNow { get; }
}
