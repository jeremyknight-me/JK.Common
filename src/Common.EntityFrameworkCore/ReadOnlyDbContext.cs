namespace JK.Common.EntityFrameworkCore;

/// <summary>
/// A read-only <see cref="DbContext"/> that disables change tracking and throws on save attempts.
/// </summary>
public abstract class ReadOnlyDbContext : DbContext
{
    private const string readOnlyErrorMessage = "This context is read-only.";

    /// <summary>
    /// Initializes a new instance of the <see cref="ReadOnlyDbContext"/> class.
    /// </summary>
    protected ReadOnlyDbContext()
    {
        ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="ReadOnlyDbContext"/> class.
    /// </summary>
    /// <param name="options">The options for this context.</param>
    protected ReadOnlyDbContext(DbContextOptions options)
        : base(options)
    {
        ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
    }

    /// <inheritdoc />
    public override int SaveChanges()
        => throw new InvalidOperationException(readOnlyErrorMessage);

    /// <inheritdoc />
    public override int SaveChanges(bool acceptAllChangesOnSuccess)
        => throw new InvalidOperationException(readOnlyErrorMessage);

    /// <inheritdoc />
    public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        => throw new InvalidOperationException(readOnlyErrorMessage);

    /// <inheritdoc />
    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        => throw new InvalidOperationException(readOnlyErrorMessage);
}
