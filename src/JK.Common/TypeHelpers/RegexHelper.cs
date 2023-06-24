using System.Text.RegularExpressions;

namespace JK.Common.TypeHelpers;

public static partial class RegexHelper
{
    public static bool IsAlphabetical(string value) => AlphabeticalRegex().IsMatch(value);
    public static bool IsAlphanumeric(string value) => AlphanumericRegex().IsMatch(value);
    public static bool IsDecimal(string value) => DecimalRegex().IsMatch(value);
    public static bool IsDecimalOrCurrency(string value) => DecimalOrCurrencyRegex().IsMatch(value);
    public static bool IsEmailAddress(string value) => EmailAddressRegex().IsMatch(value);
    public static bool IsInteger(string value) => IntegerRegex().IsMatch(value);
    public static bool IsIPv4(string value) => IPv4Regex().IsMatch(value);
    public static bool IsSocialSecurityNumber(string value) => SocialSecurityNumberRegex().IsMatch(value);
    public static bool IsUnitedStatesPhoneNumber(string value) => UnitedStatesPhoneNumberRegex().IsMatch(value);
    public static bool IsUrl(string value) => UrlRegex().IsMatch(value);
    public static bool IsZipCode(string value) => ZipCodeRegex().IsMatch(value);
}

#if NET7_0_OR_GREATER

public static partial class RegexHelper
{
    [GeneratedRegex("^[a-zA-Z]+$", RegexOptions.IgnoreCase)]
    private static partial Regex AlphabeticalRegex();

    [GeneratedRegex("^[a-zA-Z0-9]+$", RegexOptions.IgnoreCase)]
    private static partial Regex AlphanumericRegex();

    [GeneratedRegex(@"^(((\d{1,3},?)(\d{3},?)+|\d{1,3})|\d+)(\.\d{1,2})?$", RegexOptions.IgnoreCase)]
    private static partial Regex DecimalRegex();

    [GeneratedRegex(@"^(-|\$|-\$|\$-)?(((\d{1,3},?)(\d{3},?)+|\d{1,3})|\d+)(\.\d{1,2})?$", RegexOptions.IgnoreCase, "en-US")]
    private static partial Regex DecimalOrCurrencyRegex();

    [GeneratedRegex(@"^[a-zA-Z0-9.!#$%&’'*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$", RegexOptions.IgnoreCase)]
    private static partial Regex EmailAddressRegex();

    [GeneratedRegex(@"^-?\d+$", RegexOptions.IgnoreCase)]
    private static partial Regex IntegerRegex();

    [GeneratedRegex(@"\b(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\b", RegexOptions.IgnoreCase)]
    private static partial Regex IPv4Regex();

    [GeneratedRegex(@"^(?!000)(?!666)(?!9)\d{3}([- ]?)(?!00)\d{2}\1(?!0000)\d{4}$", RegexOptions.IgnoreCase, "en-US")]
    private static partial Regex SocialSecurityNumberRegex();

    [GeneratedRegex(@"^(?:(?:\+?1\s*(?:[.-]\s*)?)?(?:\(\s*([2-9]1[02-9]|[2-9][02-8]1|[2-9][02-8][02-9])\s*\)|([2-9]1[02-9]|[2-9][02-8]1|[2-9][02-8][02-9]))\s*(?:[.-]\s*)?)?([2-9]1[02-9]|[2-9][02-9]1|[2-9][02-9]{2})\s*(?:[.-]\s*)?([0-9]{4})$", RegexOptions.IgnoreCase, "en-US")]
    private static partial Regex UnitedStatesPhoneNumberRegex();

    [GeneratedRegex(@"^(ht|f)tp(s?)\:\/\/[0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*(:(0-9)*)*(\/?)([a-zA-Z0-9\-\.\?\,\'\/\\\+&amp;%\$#_]*)?$", RegexOptions.IgnoreCase)]
    private static partial Regex UrlRegex();

    [GeneratedRegex(@"^(\d{5}-\d{4}|\d{5}|\d{9})$|^([a-zA-Z]\d[a-zA-Z] \d[a-zA-Z]\d)$", RegexOptions.IgnoreCase, "en-US")]
    private static partial Regex ZipCodeRegex();
}

#endif

#if !NET7_0_OR_GREATER

public static partial class RegexHelper
{
    private static Regex AlphabeticalRegex() => new(pattern: "^[a-zA-Z]+$", options: RegexOptions.Compiled | RegexOptions.IgnoreCase);

    private static Regex AlphanumericRegex() => new(pattern: "^[a-zA-Z0-9]+$", options: RegexOptions.Compiled | RegexOptions.IgnoreCase);

    private static Regex DecimalRegex() => new(pattern: @"^(((\d{1,3},?)(\d{3},?)+|\d{1,3})|\d+)(\.\d{1,2})?$", options: RegexOptions.Compiled | RegexOptions.IgnoreCase);

    private static Regex DecimalOrCurrencyRegex() => new(pattern: @"^(-|\$|-\$|\$-)?(((\d{1,3},?)(\d{3},?)+|\d{1,3})|\d+)(\.\d{1,2})?$", options: RegexOptions.Compiled | RegexOptions.IgnoreCase);

    private static Regex EmailAddressRegex() => new(pattern: @"^[a-zA-Z0-9.!#$%&’'*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$", options: RegexOptions.Compiled | RegexOptions.IgnoreCase);
    // email regex = ^(?("")("".+?""@)|(([0-9a-zA-Z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-zA-Z])@))(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,6}))$

    private static Regex IntegerRegex() => new(pattern: @"^-?\d+$", options: RegexOptions.Compiled | RegexOptions.IgnoreCase);

    private static Regex IPv4Regex() => new(pattern: @"\b(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\b", options: RegexOptions.Compiled | RegexOptions.IgnoreCase);

    private static Regex SocialSecurityNumberRegex() => new(pattern: @"^(?!000)(?!666)(?!9)\d{3}([- ]?)(?!00)\d{2}\1(?!0000)\d{4}$", options: RegexOptions.Compiled | RegexOptions.IgnoreCase);

    private static Regex UnitedStatesPhoneNumberRegex() => new(pattern: @"^(?:(?:\+?1\s*(?:[.-]\s*)?)?(?:\(\s*([2-9]1[02-9]|[2-9][02-8]1|[2-9][02-8][02-9])\s*\)|([2-9]1[02-9]|[2-9][02-8]1|[2-9][02-8][02-9]))\s*(?:[.-]\s*)?)?([2-9]1[02-9]|[2-9][02-9]1|[2-9][02-9]{2})\s*(?:[.-]\s*)?([0-9]{4})$", options: RegexOptions.Compiled | RegexOptions.IgnoreCase);
    // phone regex = ^[01]?[- .]?(\([2-9]\d{2}\)|[2-9]\d{2})[- .]?\d{3}[- .]?\d{4}$

    private static Regex UrlRegex() => new(pattern: @"^(ht|f)tp(s?)\:\/\/[0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*(:(0-9)*)*(\/?)([a-zA-Z0-9\-\.\?\,\'\/\\\+&amp;%\$#_]*)?$", options: RegexOptions.Compiled | RegexOptions.IgnoreCase);

    private static Regex ZipCodeRegex() => new(pattern: @"^(\d{5}-\d{4}|\d{5}|\d{9})$|^([a-zA-Z]\d[a-zA-Z] \d[a-zA-Z]\d)$", options: RegexOptions.Compiled | RegexOptions.IgnoreCase);
}

#endif
