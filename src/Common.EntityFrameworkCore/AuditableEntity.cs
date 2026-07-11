namespace JK.Common.EntityFrameworkCore;

/// <summary>
/// Base class for entities that track creation and modification timestamps.
/// </summary>
public abstract class AuditableEntity : IAuditableEntity
{
    /// <inheritdoc />
    public DateTimeOffset DateCreatedUtc { get; private set; }

    /// <inheritdoc />
    public DateTimeOffset DateModifiedUtc { get; private set; }
}
