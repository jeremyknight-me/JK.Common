using JK.Common.Data.Sql.BulkInsert.Attributes;

namespace JK.Common.Data.Sql.BulkInsert.Tests;

[BulkInsertable("Employees")]
public class SampleType
{
    [BulkInsertColumn("FirstName")]
    public string FirstName { get; set; }

    [BulkInsertColumn("LastName")]
    public string LastName { get; set; }

    [BulkInsertColumn("Age")]
    public int Age { get; set; }
}
