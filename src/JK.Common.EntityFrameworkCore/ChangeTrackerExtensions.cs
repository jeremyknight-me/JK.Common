using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace JK.Common.EntityFrameworkCore;

public static class ChangeTrackerExtensions
{
    public static int EnsureAuditableEntitiesUpdated(this ChangeTracker changeTracker)
    {
        var count = 0;
        foreach (var change in changeTracker.Entries())
        {
            if (change.State == EntityState.Modified
                && change.Entity is AuditableEntity auditableEntity)
            {
                auditableEntity.DateModified = DateTimeOffset.UtcNow;
                count++;
            }
        }

        return count;
    }
}
