using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace JK.Common.EntityFrameworkCore.Auditing.Sets;

public class AuditEntry
{
    public AuditEntry(EntityEntry entry)
    {
        this.Entry = entry;
    }

    public EntityEntry Entry { get; }
    public string TableName { get; set; }
    public string EventType { get; set; }
    public IDictionary<string, object> KeyValues { get; } = new Dictionary<string, object>();
    public IDictionary<string, object> OldValues { get; } = new Dictionary<string, object>();
    public IDictionary<string, object> NewValues { get; } = new Dictionary<string, object>();
    public ICollection<PropertyEntry> TemporaryProperties { get; } = new List<PropertyEntry>();

    public bool HasTemporaryProperties => this.TemporaryProperties.Any();

    public AuditLog ToAuditLog()
    {
        var log = new AuditLog
        {
            TableName = this.TableName,
            EventType = this.EventType,
            EventDate = DateTime.UtcNow,
            KeyValues = JsonSerializer.Serialize(this.KeyValues),
            OldValues = this.OldValues.Count == 0 ? null : JsonSerializer.Serialize(this.OldValues),
            NewValues = this.NewValues.Count == 0 ? null : JsonSerializer.Serialize(this.NewValues)
        };
        return log;
    }
}
