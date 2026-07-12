using System.Collections.Generic;

namespace JK.Common.Data.Sql;

/// <summary>
/// Settings for configuring <see cref="SqlBulkCopy"/> operations.
/// </summary>
[Obsolete("SqlBulkCopy has moved to new source generated library: JK.Common.Generators.SqlBulkInsert")]
public class SqlBulkCopySettings
{
    /// <summary>
    /// Initializes a new instance of the <see cref="SqlBulkCopySettings"/> class.
    /// </summary>
    public SqlBulkCopySettings()
    {
        BatchSize = 0;
        Columns = new Dictionary<string, string>();
    }

    /// <summary>
    /// Gets or sets the batch size for the bulk copy operation. A value of 0 sends all rows in a single batch.
    /// </summary>
    public int BatchSize { get; set; }

    /// <summary>
    /// Gets or sets the column mappings where key is the object's property name and value is the table's column name.
    /// </summary>
    public IDictionary<string, string> Columns { get; set; }

    /// <summary>
    /// Gets or sets the name of the destination table.
    /// </summary>
    public string TableName { get; set; }
}
