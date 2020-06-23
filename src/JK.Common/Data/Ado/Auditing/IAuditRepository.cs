using System;

namespace JK.Common.Data.Ado.Auditing
{
    [Obsolete("ADO Auditing has been left in for reference purposes. Use EF Core Auditing features instead.")]
    public interface IAuditRepository
    {
        void Add(AuditRecord auditRecord);
    }
}
