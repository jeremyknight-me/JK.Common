using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace JK.Common.EntityFrameworkCore;

public abstract class ReadOnlyDbContext : DbContext
{
    private const string readOnlyErrorMessage = "This context is read-only.";

    protected ReadOnlyDbContext()
    {
        this.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
    }

    protected ReadOnlyDbContext(DbContextOptions options)
        : base(options)
    {
        this.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
    }

    #region SaveChanges overrides - ensures read-only

    public override int SaveChanges()
        => throw new InvalidOperationException(readOnlyErrorMessage);

    public override int SaveChanges(bool acceptAllChangesOnSuccess)
        => throw new InvalidOperationException(readOnlyErrorMessage);

    public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        => throw new InvalidOperationException(readOnlyErrorMessage);

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        => throw new InvalidOperationException(readOnlyErrorMessage);

    #endregion
}
