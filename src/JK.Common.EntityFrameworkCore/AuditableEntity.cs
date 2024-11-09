using System;

namespace JK.Common.EntityFrameworkCore;

public abstract class AuditableEntity : IAuditableEntity
{
    public DateTimeOffset DateCreatedUtc { get; private set; }
    public DateTimeOffset DateModifiedUtc { get; private set; }
}
