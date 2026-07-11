using System.Data;

namespace JK.Common.Data.Extensions;

/// <summary>
/// Extension methods for IDataRecord
/// </summary>  
public static class DataRecordExtensions
{
    extension(IDataRecord dataRecord)
    {
        /// <summary>
        /// Gets the value of the given field from the data reader or the 
        /// default for the object type.
        /// </summary>
        /// <typeparam name="T">Type of object.</typeparam>
        /// <param name="name">Name of field within IDataRecord.</param>
        /// <returns>The given field's value or the default for the object type.</returns>
        public T GetValueOrDefault<T>(string name)
        {
            if (dataRecord is null)
            {
                throw new ArgumentNullException(nameof(dataRecord));
            }

            var value = dataRecord[name];
            return DatabaseValueParser.GetValueOrDefault<T>(value);
        }

        /// <summary>
        /// Gets the value of the given field from the data reader or the 
        /// default for the object type.
        /// </summary>
        /// <typeparam name="T">Type of object.</typeparam>
        /// <param name="name">Name of field within IDataRecord.</param>
        /// <param name="defaultValue">Value to use if null field value.</param>
        /// <returns>The given field's value or the given default.</returns>
        public T GetValueOrDefault<T>(string name, T defaultValue)
        {
            if (dataRecord is null)
            {
                throw new ArgumentNullException(nameof(dataRecord));
            }

            var value = dataRecord[name];
            return DatabaseValueParser.GetValueOrDefault(value, defaultValue);
        }

        /// <summary>
        /// Gets the value of the given field from the data reader or the 
        /// default for the object type.
        /// </summary>
        /// <typeparam name="T">Type of object.</typeparam>
        /// <param name="index">Index of field within IDataRecord.</param>
        /// <returns>The given field's value or the default for the object type.</returns>
        public T GetValueOrDefault<T>(int index)
        {
            if (dataRecord is null)
            {
                throw new ArgumentNullException(nameof(dataRecord));
            }

            var value = dataRecord[index];
            return DatabaseValueParser.GetValueOrDefault<T>(value);
        }

        /// <summary>
        /// Gets the value of the given field from the data reader or the 
        /// default for the object type.
        /// </summary>
        /// <typeparam name="T">Type of object.</typeparam>
        /// <param name="index">Index of field within IDataRecord.</param>
        /// <param name="defaultValue">Value to use if null field value.</param>
        /// <returns>The given field's value or the given default.</returns>
        public T GetValueOrDefault<T>(int index, T defaultValue)
        {
            if (dataRecord is null)
            {
                throw new ArgumentNullException(nameof(dataRecord));
            }

            var value = dataRecord[index];
            return DatabaseValueParser.GetValueOrDefault(value, defaultValue);
        }

        /// <summary>
        /// Gets the value of the given field from the data reader or null.
        /// </summary>
        /// <typeparam name="T">Type of object.</typeparam>
        /// <param name="name">Name of field within IDataRecord.</param>
        /// <returns>The given field's value or null.</returns>
        public T GetValueOrNull<T>(string name)
        {
            if (dataRecord is null)
            {
                throw new ArgumentNullException(nameof(dataRecord));
            }

            var value = dataRecord[name];
            return DatabaseValueParser.GetValueOrNull<T>(value);
        }

        /// <summary>
        /// Gets the value of the given field from the data reader or null.
        /// </summary>
        /// <typeparam name="T">Type of object.</typeparam>
        /// <param name="index">Index of field within IDataRecord.</param>
        /// <returns>The given field's value or null.</returns>
        public T GetValueOrNull<T>(int index)
        {
            if (dataRecord is null)
            {
                throw new ArgumentNullException(nameof(dataRecord));
            }

            var value = dataRecord[index];
            return DatabaseValueParser.GetValueOrNull<T>(value);
        }

        /// <summary>
        /// Determine whether or not the given column exists in the record.
        /// </summary>
        /// <param name="columnName">The column name to search for.</param>
        /// <returns>True if column found, otherwise false.</returns>
        public bool HasColumn(string columnName)
        {
            if (dataRecord is null)
            {
                throw new ArgumentNullException(nameof(dataRecord));
            }

            for (var i = 0; i < dataRecord.FieldCount; i++)
            {
                if (dataRecord.GetName(i).Equals(columnName, StringComparison.InvariantCultureIgnoreCase))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Determines whether the given field is null.
        /// </summary>
        /// <param name="name">Name of field within IDataRecord.</param>
        /// <returns>True if DBNull, otherwise false.</returns>
        public bool IsDbNull(string name)
            => dataRecord is null
                ? throw new ArgumentNullException(nameof(dataRecord))
                : dataRecord.IsDBNull(dataRecord.GetOrdinal(name));
    }
}
