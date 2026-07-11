using System.Collections.Generic;

namespace JK.Common.Data.Sql;

public class SqlBulkCopySettings
{
    public SqlBulkCopySettings()
    {
        BatchSize = 0;
        Columns = new Dictionary<string, string>();
    }

    public int BatchSize { get; set; }

    /// <summary>
    /// List of columns to be used within the SqlBulkCopy where key is the object's property name and value is the table's column name.
    /// </summary>
    public IDictionary<string, string> Columns { get; set; }

    public string TableName { get; set; }
}
