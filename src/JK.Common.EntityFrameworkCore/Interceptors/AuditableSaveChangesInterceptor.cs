using System.Linq;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace JK.Common.EntityFrameworkCore.Interceptors;

public sealed class AuditableSaveChangesInterceptor : SaveChangesInterceptor
{
    public override InterceptionResult<int> SavingChanges(
        DbContextEventData eventData,
        InterceptionResult<int> result)
    {
        if (eventData.Context is not null)
        {
            UpdateAuditableEntities(eventData.Context);
        }

        return base.SavingChanges(eventData, result);
    }

    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(
        DbContextEventData eventData,
        InterceptionResult<int> result,
        CancellationToken cancellationToken = default)
    {
        if (eventData.Context is not null)
        {
            UpdateAuditableEntities(eventData.Context);
        }

        return base.SavingChangesAsync(eventData, result, cancellationToken);
    }

    private static void UpdateAuditableEntities(DbContext context)
    {
        DateTimeOffset now = DateTimeOffset.UtcNow;
        EntityEntry<IAuditableEntity>[] entries = context.ChangeTracker
            .Entries<IAuditableEntity>()
            .Where(e =>
                e.State == EntityState.Added
                || e.State == EntityState.Modified)
            .ToArray();
        foreach (EntityEntry<IAuditableEntity> entry in entries)
        {
            entry.Property(nameof(IAuditableEntity.DateModifiedUtc)).CurrentValue = now;
            if (entry.State == EntityState.Added)
            {
                entry.Property(nameof(IAuditableEntity.DateCreatedUtc)).CurrentValue = now;
            }
        }
    }
}
