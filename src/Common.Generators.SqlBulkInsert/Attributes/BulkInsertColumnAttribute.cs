namespace JK.Common.Generators.SqlBulkInsert.Attributes;

[AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
public sealed class BulkInsertColumnAttribute : Attribute
{
    public string ColumnName { get; }

    public BulkInsertColumnAttribute(string columnName)
    {
        ColumnName = columnName;
    }
}
