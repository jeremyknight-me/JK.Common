using System;

namespace JK.Common.EntityFrameworkCore.Auditing.Entities;

public class AuditableEntity
{
    public string CreatedBy { get; set; }
    public string ModifiedBy { get; set; }
    public DateTimeOffset DateCreated { get; set; }
    public DateTimeOffset DateModified { get; set; }
}
