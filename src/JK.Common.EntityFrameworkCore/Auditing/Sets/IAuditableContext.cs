using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Threading;
using System.Threading.Tasks;

namespace JK.Common.EntityFrameworkCore.Auditing.Sets
{
    public interface IAuditableContext
    {
        DbSet<AuditLog> AuditLogs { get; set; }

        ChangeTracker ChangeTracker { get; }

        int SaveChanges();

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
