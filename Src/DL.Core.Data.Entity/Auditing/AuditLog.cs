using System;
using System.Data.Entity.Infrastructure;

namespace DL.Core.Data.Entity.Auditing
{
    public class AuditLog
    {
        public AuditLog()
        {
            this.Id = Guid.NewGuid();
            this.Datestamp = DateTime.UtcNow;
        }

        public Guid Id { get; set; }

        public string UserToken { get; set; }

        public DateTimeOffset Datestamp { get; set; }

        public string Operation { get; set; }

        public string TableName { get; set; }

        public string RecordId { get; set; }

        public string OriginalValue { get; set; }

        public string NewValue { get; set; }

        public Func<DbEntityEntry, string> GetRecordIdAction { get; set; } 
    }
}
