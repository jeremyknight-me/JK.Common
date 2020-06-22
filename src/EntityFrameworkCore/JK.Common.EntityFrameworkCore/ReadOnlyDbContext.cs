using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace JK.Common.EntityFrameworkCore
{
    public abstract class ReadOnlyDbContext<TContext> : DbContext
    {
        protected ReadOnlyDbContext()
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        protected ReadOnlyDbContext(DbContextOptions options)
            : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        #region SaveChanges overrides - ensures read-only

        public override int SaveChanges()
        {
            throw new InvalidOperationException("This context is read-only");
        }

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            throw new InvalidOperationException("This context is read-only");
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            throw new InvalidOperationException("This context is read-only");
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            throw new InvalidOperationException("This context is read-only");
        }

        #endregion
    }
}
