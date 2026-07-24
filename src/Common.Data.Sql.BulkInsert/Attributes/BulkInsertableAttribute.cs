namespace JK.Common.Data.Sql.BulkInsert.Attributes;

[AttributeUsage(AttributeTargets.Class)]
public sealed class BulkInsertableAttribute : Attribute
{
    public string TableName { get; }

    public BulkInsertableAttribute(string tableName)
    {
        TableName = tableName;
    }
}
