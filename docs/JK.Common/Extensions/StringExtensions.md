[Docs](../../README.md) > [JK.Common](../README.md) > StringExtensions

# StringExtensions

**Namespace:** `JK.Common.Extensions`

Extension methods for the **String** object.

## ConvertFromBase64 *(Inherited)*

**Signature:** `ConvertFromBase64(String, Encoding encoding)`

**Summary:**
Converts a Base64-encoded string to its decoded string representation using the specified encoding.

**Parameters:**

- **encoding** — The encoding to use for decoding. If null, ASCII encoding is used.

**Returns:** The decoded string, or the original string if it is null or empty.

## ConvertToBase64 *(Inherited)*

**Signature:** `ConvertToBase64(String, Encoding encoding)`

**Summary:**
Converts the current string to its Base64-encoded representation using the specified encoding.

**Parameters:**

- **encoding** — The encoding to use for encoding. If null, ASCII encoding is used.

**Returns:** The Base64-encoded string, or the original string if it is null or empty.

## IsNull *(Inherited)*

**Signature:** `IsNull(String)`

**Summary:**
Determines whether the string is **null** .

**Remarks:** Returns **true** if the string is **null** ; otherwise, **false** .

## IsNullOrEmpty *(Inherited)*

**Signature:** `IsNullOrEmpty(String)`

**Summary:**
Determines whether the string is **null** or an empty string.

**Remarks:** Returns **true** if the string is **null** or an empty string; otherwise, **false** .

## IsNullOrWhiteSpace *(Inherited)*

**Signature:** `IsNullOrWhiteSpace(String)`

**Summary:**
Determines whether the string is **null** , empty, or consists only of white-space characters.

**Remarks:** Returns **true** if the string is **null** , empty, or consists only of white-space characters; otherwise, **false** .

## RemoveUnitedStatesCurrencyFormat *(Inherited)*

**Signature:** `RemoveUnitedStatesCurrencyFormat(String)`

**Summary:**
Removes US (dollar) currency format characters from a string.

**Returns:** String that can be parsed into a number.

## RemoveXml *(Inherited)*

**Signature:** `RemoveXml(String)`

**Summary:**
Removes XML/HTML from given text block.

**Returns:** Clean string with no XML/HTML.

## ReplaceWithEmpty *(Inherited)*

**Signature:** `ReplaceWithEmpty(String, String textToReplace)`

**Summary:**
Replaces all occurrences of a specified string in the current string with an empty string.

**Parameters:**

- **textToReplace** — The string to be replaced with an empty string.

**Returns:** A new string with all occurrences of **textToReplace** removed.

## Reverse *(Inherited)*

**Signature:** `Reverse(String)`

**Summary:**
Reverses the characters within a string.

**Returns:** The original string in reverse.

## Right *(Inherited)*

**Signature:** `Right(String, Int32 length)`

**Summary:**
Returns the specified number of characters from the end of string. Same as **!:Last** .

**Parameters:**

- **length** — Number of characters to get from end of string.

**Returns:** Returns the last X characters of the string.

## ToNullableDecimal *(Inherited)*

**Signature:** `ToNullableDecimal(String)`

**Summary:**
Attempts to parse the string as a decimal value. Returns null if the string is null, whitespace, or not a valid decimal.

**Returns:** The parsed decimal value, or null if parsing fails.

## ToNullableInteger *(Inherited)*

**Signature:** `ToNullableInteger(String)`

**Summary:**
Attempts to parse the string as an integer value. Returns null if the string is null, whitespace, or not a valid integer.

**Returns:** The parsed integer value, or null if parsing fails.

## ToNullIfEmpty *(Inherited)*

**Signature:** `ToNullIfEmpty(String)`

**Summary:**
Converts an empty string to null.

**Returns:** Null if the string is empty or null; otherwise, the original string.

## ToEmptyIfNull *(Inherited)*

**Signature:** `ToEmptyIfNull(String)`

**Summary:**
Converts a null string to an empty string.

**Returns:** An empty string if null; otherwise, the original string.

## Truncate(String, Int32 length) *(Inherited)*

**Signature:** `Truncate(String, Int32 length)`

**Summary:**
Trims a block of text to a specified length. The string will be trimmed to the previous space coming before the length position passed. Relies on **StringTruncater**

**Parameters:**

- **length** — Number of characters to keep from the original string.

**Returns:** Truncated, or shortened, text.

## Truncate(String, Int32 length, String indicator) *(Inherited)*

**Signature:** `Truncate(String, Int32 length, String indicator)`

**Summary:**
Trims a block of text to a specified length. The string will be trimmed to the previous space coming before the length position passed. Relies on **StringTruncater**

**Parameters:**

- **length** — Number of characters to keep from the original string.

- **indicator** — String of characters to indicate that a truncation has occurred.

**Returns:** Truncated, or shortened, text with an indicator marking where the truncation occurred.

## Parse *(Inherited)*

**Signature:** `Parse<T>(String, IFormatProvider formatProvider)`

**Summary:**
Parses a string into a specified type.

**Parameters:**

- **formatProvider** — Format provider to pass down to the **Parse** method.

**Returns:** Parsed value of type T.

## IsDateTime *(Inherited)*

**Signature:** `IsDateTime`

**Summary:**
Determines if the given string is a date/time. Relies on **DateTimeSpecification**

**Returns:** True if a date, otherwise false.

## IsNumeric *(Inherited)*

**Signature:** `IsNumeric`

**Summary:**
Determines if the given string is a number. Relies on **NumericSpecification**

**Returns:** True if a number, otherwise false.

## IsValidEmailAddress *(Inherited)*

**Signature:** `IsValidEmailAddress`

**Summary:**
Validates that a string is a valid email address. Relies on **EmailSpecification**

**Returns:** True if valid email otherwise false.

## IsValidIpAddress *(Inherited)*

**Signature:** `IsValidIpAddress`

**Summary:**
Validates that a string is a valid IP v4 address. Relies on **InternetProtocolAddressSpecification**

**Returns:** True if valid IP v4 address otherwise false.

## IsValidUnitedStatesPhoneNumber *(Inherited)*

**Signature:** `IsValidUnitedStatesPhoneNumber`

**Summary:**
Validates that a string is a valid United States phone number. Relies on **PhoneNumberSpecification**

**Returns:** True if valid US phone number otherwise false.

## IsValidZip *(Inherited)*

**Signature:** `IsValidZip`

**Summary:**
Validates that a string is a valid zip code. Relies on **ZipCodeSpecification**

**Returns:** True if valid zip code otherwise false.