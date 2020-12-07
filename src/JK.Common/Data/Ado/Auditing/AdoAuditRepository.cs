using JK.Common.Data.Contracts;
using System;

namespace JK.Common.Data.Ado.Auditing
{
    /// <summary>
    /// Data access class for an ADO audit table.
    /// </summary>
    [Obsolete("ADO Auditing has been left in for reference purposes. Use EF Core Auditing features instead.")]
    public class AdoAuditRepository : AdoBaseRepository, IAuditRepository
    {
        /// <summary>
        /// Initializes a new instance of the AdoAuditRepository class.
        /// </summary>
        /// <param name="providerName">Name of the provider</param>
        /// <param name="connectionString">Name of the connection string as set up in the *.config file.</param>
        public AdoAuditRepository(string providerName, string connectionString)
            : base(providerName, connectionString)
        {
        }

        /// <summary>
        /// Adds an audit record into the database.
        /// </summary>
        /// <param name="auditRecord">The record to be added.</param>
        public void Add(AuditRecord auditRecord)
        {
            INonQueryOperation operation = new AdoAuditRecordAddOperation(this, auditRecord);
            operation.Execute();
        }
    }
}
