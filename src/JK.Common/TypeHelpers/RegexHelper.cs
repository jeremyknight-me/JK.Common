using System.Text.RegularExpressions;

namespace JK.Common.TypeHelpers;

public static class RegexHelper
{
    public static bool IsAlphabetical(string value) => Regex.IsMatch(value, @"^[a-zA-Z]+$");

    public static bool IsAlphanumeric(string value) => Regex.IsMatch(value, @"^[a-zA-Z0-9]+$");

    public static bool IsDecimal(string value) => Regex.IsMatch(value, @"^(((\d{1,3},?)(\d{3},?)+|\d{1,3})|\d+)(\.\d{1,2})?$");

    public static bool IsDecimalOrCurrency(string value) => Regex.IsMatch(value, @"^(-|\$|-\$|\$-)?(((\d{1,3},?)(\d{3},?)+|\d{1,3})|\d+)(\.\d{1,2})?$");

    public static bool IsEmailAddress(string value) => Regex.IsMatch(value, @"^[a-zA-Z0-9.!#$%&’'*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$");
    // email regex = ^(?("")("".+?""@)|(([0-9a-zA-Z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-zA-Z])@))(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,6}))$

    public static bool IsInteger(string value) => Regex.IsMatch(value, @"^-?\d+$");

    public static bool IsIPv4(string value) => Regex.IsMatch(value, @"\b(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\b");

    public static bool IsSocialSecurityNumber(string value) => Regex.IsMatch(value, @"^(?!000)(?!666)(?!9)\d{3}([- ]?)(?!00)\d{2}\1(?!0000)\d{4}$");

    public static bool IsUnitedStatesPhoneNumber(string value) => Regex.IsMatch(value, @"^(?:(?:\+?1\s*(?:[.-]\s*)?)?(?:\(\s*([2-9]1[02-9]|[2-9][02-8]1|[2-9][02-8][02-9])\s*\)|([2-9]1[02-9]|[2-9][02-8]1|[2-9][02-8][02-9]))\s*(?:[.-]\s*)?)?([2-9]1[02-9]|[2-9][02-9]1|[2-9][02-9]{2})\s*(?:[.-]\s*)?([0-9]{4})$");
    // phone regex = ^[01]?[- .]?(\([2-9]\d{2}\)|[2-9]\d{2})[- .]?\d{3}[- .]?\d{4}$

    public static bool IsUrl(string value) => Regex.IsMatch(value, @"^(ht|f)tp(s?)\:\/\/[0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*(:(0-9)*)*(\/?)([a-zA-Z0-9\-\.\?\,\'\/\\\+&amp;%\$#_]*)?$");

    public static bool IsZipCode(string value) => Regex.IsMatch(value, @"^(\d{5}-\d{4}|\d{5}|\d{9})$|^([a-zA-Z]\d[a-zA-Z] \d[a-zA-Z]\d)$");
}
