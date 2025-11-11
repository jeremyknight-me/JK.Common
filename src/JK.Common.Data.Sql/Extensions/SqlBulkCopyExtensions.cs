using System;
using System.Data;
using System.Reflection;
using System.Text.RegularExpressions;
using Microsoft.Data.SqlClient;

namespace JK.Common.Data.Sql.Extensions;

public static class SqlBulkCopyExtensions
{
    extension(SqlBulkCopy bulk)
    {
        public void ThrowIfColumnLengthException(SqlException ex)
        {
            if (ex.Message.Contains("Received an invalid column length from the bcp client for colid"))
            {
                var pattern = @"\d+";
                Match match = Regex.Match(ex.Message.ToString(), pattern);
                var index = Convert.ToInt32(match.Value) - 1;
                FieldInfo sortedColumnsField = typeof(SqlBulkCopy).GetField("_sortedColumnMappings", BindingFlags.NonPublic | BindingFlags.Instance);
                var sortedColumns = sortedColumnsField.GetValue(bulk);
                FieldInfo itemsField = sortedColumns.GetType().GetField("_items", BindingFlags.NonPublic | BindingFlags.Instance);
                var items = (object[])itemsField.GetValue(sortedColumns);
                FieldInfo itemdata = items[index].GetType().GetField("_metadata", BindingFlags.NonPublic | BindingFlags.Instance);
                var metadata = itemdata.GetValue(items[index]);
                var column = metadata.GetType()
                    .GetField("column", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance)
                    .GetValue(metadata);
                var length = metadata.GetType()
                    .GetField("length", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance)
                    .GetValue(metadata);
                throw new DataException($"Column '{column}' contains data with a length greater than {length}", ex);
            }
        }
    }
}
