using System;
using System.Linq;

namespace DL.Common.TypeHelpers
{
    /// <summary>
    /// Class which contains enum utility methods.
    /// </summary>
    public class EnumHelper
    {
        /// <summary>
        /// Gets an Enumeration value by its associated integer value.
        /// </summary>
        /// <typeparam name="T">Enumeration Type to use. Ex: typeof(EnumerationTypeName)</typeparam>
        /// <param name="integer">Integer value.</param>
        /// <returns>Enumeration value of type T.</returns>
        public T GetByInteger<T>(int integer) where T : struct, IConvertible
        {
            this.EnsureValidEnum<T>();
            this.EnsureValidValue<T>(integer, "integer");
            return (T)Enum.ToObject(typeof(T), integer);
        }

        /// <summary>
        /// Gets an Enumeration value by its associated integer value.
        /// </summary>
        /// <typeparam name="T">Enumeration Type to use. Ex: typeof(EnumerationTypeName)</typeparam>
        /// <param name="integer">Integer value.</param>
        /// <returns>Enumeration value of type T.</returns>
        public T? GetByInteger<T>(int? integer) where T : struct, IConvertible
        {
            this.EnsureValidEnum<T>();

            if (!integer.HasValue)
            {
                return null;
            }

            this.EnsureValidValue<T>(integer.Value, "integer");
            return (T)Enum.ToObject(typeof(T), integer);
        }

        public int GetInteger<T>(T value) where T : struct, IConvertible
        {
            return Convert.ToInt32(value);
        }

        /// <summary>
        /// Gets the integer value associated with the given enumeration type value.
        /// </summary>
        /// <param name="value">Enumeration type value.</param>
        /// <returns>Integer value.</returns>
        public int? GetInteger<T>(T? value) where T : struct, IConvertible
        {
            return value.HasValue
                ? (int?)Convert.ToInt32(value)
                : null;
        }

        /// <summary>
        /// Determines whether a given integer is an integer value within an enumeration.
        /// </summary>
        /// <typeparam name="T">Type of enumeration.</typeparam>
        /// <param name="integer">Integer to check for.</param>
        /// <returns>True if found, otherwise false.</returns>
        private bool IsValidEnumInteger<T>(int integer) where T : struct, IConvertible
        {
            this.EnsureValidEnum<T>();
            return Enum.GetValues(typeof(T)).Cast<int>().Any(value => value == integer);
        }

        private void EnsureValidEnum<T>() where T : struct, IConvertible
        {
            if (!typeof(T).IsEnum)
            {
                throw new ArgumentException("T must be an enumerated type");
            }
        }

        private void EnsureValidValue<T>(int integer, string parameter) where T : struct, IConvertible
        {
            if (!this.IsValidEnumInteger<T>(integer))
            {
                throw new ArgumentOutOfRangeException(parameter);
            }
        }
    }
}
