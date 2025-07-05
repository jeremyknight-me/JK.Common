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
    private readonly IAdoConnectionFactory _connectionFactory;

    public SqlBulkInsertOperation(IAdoConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }

    public void Execute(SqlBulkCopySettings settings, IEnumerable<T> items)
    {
        Guard(settings, items);
        using (var connection = _connectionFactory.Make() as SqlConnection)
        using (var bulk = new SqlBulkCopy(connection, SqlBulkCopyOptions.KeepNulls | SqlBulkCopyOptions.UseInternalTransaction, null))
        {
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }

            bulk.BatchSize = settings.BatchSize == 0 ? items.Count() : settings.BatchSize;
            bulk.DestinationTableName = settings.TableName;

            var table = new DataTable();
            PropertyDescriptor[] props = TypeDescriptor.GetProperties(typeof(T))
                .Cast<PropertyDescriptor>()
                .Where(pd => pd.PropertyType.Namespace.Equals("System")
                    && settings.Columns.ContainsKey(pd.Name))
                .ToArray();
            foreach (PropertyDescriptor prop in props)
            {
                var columnName = settings.Columns[prop.Name];
                bulk.ColumnMappings.Add(prop.Name, columnName);
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            }

            var values = new object[props.Length];
            foreach (T item in items)
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

#if NET8_0_OR_GREATER
    private static void Guard(SqlBulkCopySettings settings, IEnumerable<T> items)
    {
        ArgumentNullException.ThrowIfNull(settings, nameof(settings));
        ArgumentNullException.ThrowIfNull(items, nameof(items));
        ArgumentException.ThrowIfNullOrWhiteSpace(settings.TableName, nameof(settings.TableName));

        if (settings.Columns is null || settings.Columns.Count == 0)
        {
            throw new ArgumentNullException(nameof(settings), "Columns property cannot be null or empty.");
        }
    }
#else
    private static void Guard(SqlBulkCopySettings settings, IEnumerable<T> items)
    {
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
    }
#endif
}
