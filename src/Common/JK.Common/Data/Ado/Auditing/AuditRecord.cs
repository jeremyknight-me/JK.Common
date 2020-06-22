using System;

namespace JK.Common.Data.Ado.Auditing
{
    [Obsolete("ADO Auditing has been left in for reference purposes. Use EF Core Auditing features instead.")]
    public class AuditRecord
    {
        public DateTimeOffset DateStamp { get; set; }
        public string ObjectId { get; set; }
        public string ObjectName { get; set; }
        public string OriginalObject { get; set; }
        public string ChangedObject { get; set; }
    }
}
