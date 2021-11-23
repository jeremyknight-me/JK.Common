using System;

namespace JK.Common.EntityFrameworkCore.Auditing.Sets;

public class AuditLog
{
    public Guid Id { get; set; }
    public string TableName { get; set; }
    public string EventType { get; set; }
    public DateTimeOffset EventDate { get; set; }
    public string KeyValues { get; set; }
    public string OldValues { get; set; }
    public string NewValues { get; set; }
}
