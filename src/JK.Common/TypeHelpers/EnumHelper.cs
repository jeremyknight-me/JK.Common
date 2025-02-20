using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace JK.Common.TypeHelpers;

/// <summary>
/// Class which contains enum utility methods.
/// </summary>
public static class EnumHelper
{
    /// <summary>
    /// Gets a list of the items within an enum. Values will be filled with 
    /// the constant given to each enum value and the Display will be filled with
    /// either the enum value or the ComponentModel DescriptionAttribute.
    /// </summary>
    /// <param name="type">Enum Type to use. Ex: typeof(EnumTypeName</param>
    /// <returns>A list of ListItem for the given enum.</returns>
    public static IEnumerable<ListItem> ConvertToListItems(Type type)
    {
        if (type == null)
        {
            throw new ArgumentNullException(nameof(type));
        }

        if (!type.IsEnum)
        {
            throw new ArgumentException("The 'type' parameter must contain an Enum type.");
        }

        return ConvertToListItemsIterator(type);
    }

    private static IEnumerable<ListItem> ConvertToListItemsIterator(Type type)
    {
        foreach (var name in Enum.GetNames(type))
        {
            var field = type.GetField(name);
            var attribute = field.GetCustomAttributes(typeof(DisplayAttribute), false);
            var item = new ListItem
            {
                Text = attribute.Length > 0 ? ((DisplayAttribute)attribute[0]).Name : name,
                Value = Convert.ToInt32(field.GetRawConstantValue())
            };

            yield return item;
        }
    }

    public static T GetAttribute<T>(in Enum enumVal) where T : Attribute
    {
        var type = enumVal.GetType();
        var memInfo = type.GetMember(enumVal.ToString());
        var attributes = memInfo[0].GetCustomAttributes(typeof(T), false);
        return (attributes.Length > 0) ? (T)attributes[0] : null;
    }

    public static string GetDisplayName<T>(in T value) where T : struct, IConvertible
    {
        EnsureValidEnum<T>();
        var type = typeof(T);
        var name = Enum.GetName(type, value);
        var field = type.GetField(name);
        var attribute = field.GetCustomAttributes(typeof(DisplayAttribute), false);
        return attribute.Length > 0 ? ((DisplayAttribute)attribute[0]).Name : name;
    }

    #region Byte Conversion

    public static T GetByByte<T>(in byte value) where T : struct, IConvertible
    {
        EnsureValidEnum<T>();
        EnsureValidValue<T>(value, nameof(value));
        return (T)Enum.ToObject(typeof(T), value);
    }

    public static T? GetByByte<T>(in byte? value) where T : struct, IConvertible
    {
        EnsureValidEnum<T>();
        if (!value.HasValue)
        {
            return null;
        }

        EnsureValidValue<T>(value.Value, nameof(value));
        return (T)Enum.ToObject(typeof(T), value);
    }

    public static byte GetByte<T>(in T value) where T : struct, IConvertible
    {
        EnsureValidEnum<T>();
        return Convert.ToByte(value);
    }

    public static int? GetByte<T>(in T? value) where T : struct, IConvertible
        => value.HasValue ? (byte?)Convert.ToByte(value) : null;

    #endregion

    #region Integer Conversion

    /// <summary>
    /// Gets an Enumeration value by its associated integer value.
    /// </summary>
    /// <typeparam name="T">Enumeration Type to use. Ex: typeof(EnumerationTypeName)</typeparam>
    /// <param name="value">Integer value.</param>
    /// <returns>Enumeration value of type T.</returns>
    public static T GetByInteger<T>(in int value) where T : struct, IConvertible
    {
        EnsureValidEnum<T>();
        EnsureValidValue<T>(value, nameof(value));
        return (T)Enum.ToObject(typeof(T), value);
    }

    /// <summary>
    /// Gets an Enumeration value by its associated integer value.
    /// </summary>
    /// <typeparam name="T">Enumeration Type to use. Ex: typeof(EnumerationTypeName)</typeparam>
    /// <param name="value">Integer value.</param>
    /// <returns>Enumeration value of type T.</returns>
    public static T? GetByInteger<T>(in int? value) where T : struct, IConvertible
        => value.HasValue
            ? GetByInteger<T>(value.Value)
            : null;

    public static int GetInteger<T>(in T value) where T : struct, IConvertible
    {
        EnsureValidEnum<T>();
        return Convert.ToInt32(value);
    }

    /// <summary>
    /// Gets the integer value associated with the given enumeration type value.
    /// </summary>
    /// <param name="value">Enumeration type value.</param>
    /// <returns>Integer value.</returns>
    public static int? GetInteger<T>(in T? value) where T : struct, IConvertible
        => value.HasValue
            ? Convert.ToInt32(value)
            : null;

    #endregion

    /// <summary>
    /// Determines whether a given byte is a byte value within an enumeration.
    /// </summary>
    /// <typeparam name="T">Type of enumeration.</typeparam>
    /// <param name="value">Byte value to check for.</param>
    /// <returns>True if found, otherwise false.</returns>
    private static bool IsValidValue<T>(byte value) where T : struct, IConvertible
    {
        EnsureValidEnum<T>();
        return Enum.GetValues(typeof(T)).Cast<object>().Any(x => value == Convert.ToByte(x));
    }

    /// <summary>
    /// Determines whether a given integer is an integer value within an enumeration.
    /// </summary>
    /// <typeparam name="T">Type of enumeration.</typeparam>
    /// <param name="value">Integer to check for.</param>
    /// <returns>True if found, otherwise false.</returns>
    private static bool IsValidValue<T>(int value) where T : struct, IConvertible
    {
        EnsureValidEnum<T>();
        return Enum.GetValues(typeof(T)).Cast<int>().Any(x => x == value);
    }

    private static void EnsureValidEnum<T>() where T : struct, IConvertible
    {
        if (!typeof(T).IsEnum)
        {
            throw new ArgumentException("T must be an enumerated type");
        }
    }

    private static void EnsureValidValue<T>(in byte value, in string parameter) where T : struct, IConvertible
    {
        if (!IsValidValue<T>(value))
        {
            throw new ArgumentOutOfRangeException(parameter);
        }
    }

    private static void EnsureValidValue<T>(in int value, in string parameter) where T : struct, IConvertible
    {
        if (!IsValidValue<T>(value))
        {
            throw new ArgumentOutOfRangeException(parameter);
        }
    }
}
