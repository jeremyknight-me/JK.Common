using System;

namespace JK.Common.Data
{
    /// <summary>
    /// Static class which adds database value parsing.
    /// </summary>
    public static class DatabaseValueParser
    {
        /// <summary>
        /// Gets the value of an object or returns the objects default type.
        /// </summary>
        /// <typeparam name="T">Type of object.</typeparam>
        /// <param name="value">Object to test.</param>
        /// <returns>Object's type default if DBNull, otherwise the object's value.</returns>
        public static T GetValueOrDefault<T>(object value)
        {
            return Convert.IsDBNull(value) ? default(T) : (T)value;
        }

        /// <summary>
        /// Gets the value of an object or returns the given default value.
        /// </summary>
        /// <typeparam name="T">Type of object.</typeparam>
        /// <param name="value">Object to test.</param>
        /// <param name="defaultValue">Value to use is DBNull.</param>
        /// <returns>Given default value if DBNull, otherwise the object's value.</returns>
        public static T GetValueOrDefault<T>(object value, T defaultValue)
        {
            return Convert.IsDBNull(value) ? defaultValue : (T)value;
        }

        /// <summary>
        /// Gets the value of an object or null.
        /// </summary>
        /// <typeparam name="T">Type of object.</typeparam>
        /// <param name="value">Object to test.</param>
        /// <returns>Null if DBNull, otherwise the object's value.</returns>
        public static T GetValueOrNull<T>(object value)
        {
            object nullValue = null;

            return Convert.IsDBNull(value) ? (T)nullValue : (T)value;
        }

        /// <summary>
        /// Get value or DbNull from a Nullable type.
        /// </summary>
        /// <typeparam name="T">Type of object.</typeparam>
        /// <param name="nullable">Object to get value or DbNull.</param>
        /// <returns>If not null value of object, otherwise DbNull.</returns>
        public static object GetValueOrDbNull<T>(T? nullable) where T : struct
        {
            return nullable.HasValue ? (object)nullable.Value : DBNull.Value;
        }
    }
}
