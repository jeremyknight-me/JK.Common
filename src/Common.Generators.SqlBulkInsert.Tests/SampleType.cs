using JK.Common.Generators.SqlBulkInsert.Attributes;

namespace JK.Common.Generators.SqlBulkInsert.Tests;

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
