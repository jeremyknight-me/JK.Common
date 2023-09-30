using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using JK.Common.Data.Sql.Extensions;
using Microsoft.Data.SqlClient;

namespace JK.Common.Data.Sql;

public class SqlBulkInsertOperation<T> 
{
    private readonly string connString;

    public SqlBulkInsertOperation(string connectionString)
    {
        this.connString = connectionString;
    }

    public void Execute(SqlBulkCopySettings settings, IEnumerable<T> items)
    {
        #region ArgumentNull Checks

        if (settings is null)
        {
            throw new ArgumentNullException(nameof(settings));
        }

        if (items is null)
        {
            throw new ArgumentNullException(nameof(items));
        }

        if (string.IsNullOrWhiteSpace(settings.TableName))
        {
            throw new ArgumentNullException(nameof(settings.TableName));
        }

        if (settings.Columns is null || settings.Columns.Count == 0)
        {
            throw new ArgumentNullException(nameof(settings.Columns));
        }

        #endregion

        using (var connection = new SqlConnection(this.connString))
        using (var bulk = new SqlBulkCopy(connection, SqlBulkCopyOptions.KeepNulls | SqlBulkCopyOptions.UseInternalTransaction, null))
        {
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }

            bulk.BatchSize = settings.BatchSize == 0 ? items.Count() : settings.BatchSize;
            bulk.DestinationTableName = settings.TableName;

            var table = new DataTable();
            var props = TypeDescriptor.GetProperties(typeof(T))
                .Cast<PropertyDescriptor>()
                .Where(pd => pd.PropertyType.Namespace.Equals("System")
                    && settings.Columns.ContainsKey(pd.Name))
                .ToArray();
            foreach (var prop in props)
            {
                var columnName = settings.Columns[prop.Name];
                bulk.ColumnMappings.Add(prop.Name, columnName);
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            }

            var values = new object[props.Length];
            foreach (var item in items)
            {
                for (var i = 0; i < values.Length; i++)
                {
                    values[i] = props[i].GetValue(item);
                }

                table.Rows.Add(values);
            }

            try
            {
                bulk.WriteToServer(table);
            }
            catch (SqlException ex)
            {
                bulk.ThrowIfColumnLengthException(ex);
                throw;
            }
        }
    }
}
