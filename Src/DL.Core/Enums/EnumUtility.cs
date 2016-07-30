using System;
using System.Collections.Generic;
using System.Linq;
using DL.Core.Contracts;

namespace DL.Core.Enums
{
    /// <summary>
    /// Class which contains enum utility methods.
    /// </summary>
    public class EnumUtility
    {
        /// <summary>
        /// Gets a list of the items within an enumeration type. Values will be filled with 
        /// the constant given to each enumeration type value and the Display will be filled with
        /// either the enumeration type value or the ComponentModel DescriptionAttribute.
        /// </summary>
        /// <param name="type">Enumeration type to use. Ex: typeof(EnumerationTypeName)</param>
        /// <returns>A list of ListItemData for the given enumeration type.</returns>
        public IEnumerable<ILabeledIdentifiable<int>> ConvertValuesToListItemData<T>() where T : struct, IConvertible
        {
            this.EnsureValidEnum<T>();
            var enumValues = this.GetValues<T>();
            var values = new List<ILabeledIdentifiable<int>>();

            foreach (var value in enumValues)
            {
                var item = new ListItemData<int>
                {
                    Id = this.GetInteger(value), 
                    Label = this.GetTitle(value)
                };
                values.Add(item);
            }

            return values;
        }

        public T GetByByte<T>(byte byteValue) where T : struct, IConvertible
        {
            this.EnsureValidEnum<T>();
            this.EnsureValidValue<T>(byteValue, "byteValue");
            return (T)Enum.ToObject(typeof(T), byteValue);
        }

        public byte GetByte(object value)
        {
            return Convert.ToByte(value);
        }

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

        /// <summary>
        /// Gets the integer value associated with the given enumeration type value.
        /// </summary>
        /// <param name="value">Enumeration type value.</param>
        /// <returns>Integer value.</returns>
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
                ? (int?) Convert.ToInt32(value) 
                : null;
        }

        /// <summary>
        /// Gets the title of the given enumeration type value's integer constant.
        /// </summary>
        /// <typeparam name="T">Enumeration type to use. Ex: typeof(EnumerationName)</typeparam>
        /// <param name="integer">Integer value associated with the enumeration type value.</param>
        /// <returns>String filled with either the enumeration type name or the ComponentModel DescriptionAttribute.</returns>
        public string GetTitle<T>(int integer) where T : struct, IConvertible
        {
            this.EnsureValidEnum<T>();
            this.EnsureValidValue<T>(integer, "integer");
            T value = this.GetByInteger<T>(integer);
            return this.GetTitle(value);
        }

        /// <summary>
        /// Gets the title of the given enumeration type value.
        /// </summary>
        /// <typeparam name="T">Enumeration Type to use. Ex: typeof(EnumerationName)</typeparam>
        /// <param name="value">Enumeration type value.</param>
        /// <returns>String filled with either the enumeration name or the ComponentModel DescriptionAttribute.</returns>
        public string GetTitle<T>(T value) where T : struct, IConvertible
        {
            this.EnsureValidEnum<T>();
            Type enumType = typeof(T);
            string name = Enum.GetName(enumType, value);
            var field = enumType.GetField(name);
            var attribute = field.GetCustomAttributes(typeof(EnumLabelAttribute), false);
            return attribute.Length > 0 ? ((EnumLabelAttribute)attribute[0]).Name : name;
        }

        /// <summary>
        /// Gets a list of values associated with the given enumeration type.
        /// </summary>
        /// <typeparam name="T">Type of the enumeration</typeparam>
        /// <returns>List of enumeration values.</returns>
        public IEnumerable<T> GetValues<T>() where T : struct, IConvertible
        {
            this.EnsureValidEnum<T>();
            return Enum.GetValues(typeof(T)).Cast<T>();
        }

        /// <summary>
        /// Determines whether a given byte is a byte value within an enumeration.
        /// </summary>
        /// <typeparam name="T">Type of enumeration.</typeparam>
        /// <param name="byteValue">Byte value to check for.</param>
        /// <returns>True if found, otherwise false.</returns>
        public bool IsValidEnumByte<T>(byte byteValue) where T : struct, IConvertible
        {
            this.EnsureValidEnum<T>();
            return Enum.GetValues(typeof(T)).Cast<object>().Any(enumValue => byteValue == Convert.ToByte(enumValue));
        }

        /// <summary>
        /// Determines whether a given integer is an integer value within an enumeration.
        /// </summary>
        /// <typeparam name="T">Type of enumeration.</typeparam>
        /// <param name="integer">Integer to check for.</param>
        /// <returns>True if found, otherwise false.</returns>
        public bool IsValidEnumInteger<T>(int integer) where T : struct, IConvertible
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

        private void EnsureValidValue<T>(byte byteValue, string parameter) where T : struct, IConvertible
        {
            if (!this.IsValidEnumInteger<T>(byteValue))
            {
                throw new ArgumentOutOfRangeException(parameter);
            }
        }
    }
}
