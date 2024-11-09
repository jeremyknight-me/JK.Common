using System;

namespace JK.Common.EntityFrameworkCore;

public interface IAuditableEntity
{
    DateTimeOffset DateCreatedUtc { get; }
    DateTimeOffset DateModifiedUtc { get; }
}
