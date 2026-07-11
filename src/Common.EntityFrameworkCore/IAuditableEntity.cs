namespace JK.Common.EntityFrameworkCore;

/// <summary>
/// Defines an entity that tracks creation and modification timestamps.
/// </summary>
public interface IAuditableEntity
{
    /// <summary>
    /// Gets the UTC date and time when the entity was created.
    /// </summary>
    DateTimeOffset DateCreatedUtc { get; }

    /// <summary>
    /// Gets the UTC date and time when the entity was last modified.
    /// </summary>
    DateTimeOffset DateModifiedUtc { get; }
}
