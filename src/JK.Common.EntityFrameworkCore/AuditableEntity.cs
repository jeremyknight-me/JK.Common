using System;

namespace JK.Common.EntityFrameworkCore;

public abstract class AuditableEntity
{
    public DateTimeOffset DateCreated { get; private set; }
    public DateTimeOffset DateModified { get; internal set; } = DateTimeOffset.UtcNow;
}
