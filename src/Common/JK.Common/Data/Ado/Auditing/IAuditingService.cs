using JK.Common.Contracts;
using System;

namespace JK.Common.Data.Ado.Auditing
{
    [Obsolete("ADO Auditing has been left in for reference purposes. Use EF Core Auditing features instead.")]
    public interface IAuditingService
    {
        AuditRecord Record { get; }

        bool AreEqual<TKey, TEntity>(TEntity originalEntity, TEntity changedEntity) where TEntity : IIdentifiable<TKey>;

        void LogChange();
    }
}
