namespace JK.Common.Generators.SqlBulkInsert;

internal sealed record PropertyMetadata
{
    public string PropertyName { get; init; } = null!;
    public string ColumnName { get; init; } = null!;
    public string TypeName { get; init; } = null!;
    public bool IsNullable { get; init; }
}
