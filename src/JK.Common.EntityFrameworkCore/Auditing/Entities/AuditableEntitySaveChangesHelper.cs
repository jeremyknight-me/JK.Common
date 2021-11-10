using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Linq;

namespace JK.Common.EntityFrameworkCore.Auditing.Entities;

public class AuditableEntitySaveChangesHelper
{
    private readonly string contextName;

    public AuditableEntitySaveChangesHelper()
        : this("ApplicationContext")
    {
    }

    public AuditableEntitySaveChangesHelper(string applicationContextName)
    {
        this.contextName = applicationContextName;
    }

    public void AuditChanges(ChangeTracker changeTracker, Func<AuditableEntity, EntityEntry<AuditableEntity>> entryMethod, string user)
    {
        var entries = changeTracker.Entries()
            .Where(e => e.Entity is AuditableEntity && (e.State == EntityState.Added || e.State == EntityState.Modified));
        foreach (var entityEntry in entries)
        {
            var now = DateTimeOffset.UtcNow;
            // If state is Added, set DateCreated and CreatedBy properties
            if (entityEntry.State == EntityState.Added)
            {
                ((AuditableEntity)entityEntry.Entity).DateCreated = now;
                ((AuditableEntity)entityEntry.Entity).CreatedBy = user ?? this.contextName;
            }
            else
            {
                // If state is Modified, don't all modification to DateCreated and CreatedBy properties
                entryMethod((AuditableEntity)entityEntry.Entity).Property(p => p.DateCreated).IsModified = false;
                entryMethod((AuditableEntity)entityEntry.Entity).Property(p => p.CreatedBy).IsModified = false;
            }

            // In any case we always want to set the properties
            // ModifiedAt and ModifiedBy
            ((AuditableEntity)entityEntry.Entity).DateModified = now;
            ((AuditableEntity)entityEntry.Entity).ModifiedBy = user ?? this.contextName;
        }
    }
}
