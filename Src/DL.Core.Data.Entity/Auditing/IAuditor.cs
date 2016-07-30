using System.Data.Entity.Infrastructure;

namespace DL.Core.Data.Entity.Auditing
{
    public interface IAuditor
    {
        AuditLog AuditChange(DbEntityEntry entry, string userToken);
    }
}