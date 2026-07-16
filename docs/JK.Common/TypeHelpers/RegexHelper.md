[Docs](../../README.md) > [JK.Common](../README.md) > RegexHelper

# RegexHelper

**Namespace:** `JK.Common.TypeHelpers`

Helper methods for common regular expression validations.

## IsAlphabetical

**Signature:** `IsAlphabetical(String value)`

**Summary:**
Determines whether the input string contains only alphabetical characters.

**Parameters:**

- **value** — The string to validate.

**Returns:** **true** if the string is alphabetical; otherwise, **false**.

## IsAlphanumeric

**Signature:** `IsAlphanumeric(String value)`

**Summary:**
Determines whether the input string contains only alphanumeric characters.

**Parameters:**

- **value** — The string to validate.

**Returns:** **true** if the string is alphanumeric; otherwise, **false**.

## IsDecimal

**Signature:** `IsDecimal(String value)`

**Summary:**
Determines whether the input string is a valid decimal number.

**Parameters:**

- **value** — The string to validate.

**Returns:** **true** if the string is a decimal; otherwise, **false**.

## IsDecimalOrCurrency

**Signature:** `IsDecimalOrCurrency(String value)`

**Summary:**
Determines whether the input string is a valid decimal or currency value.

**Parameters:**

- **value** — The string to validate.

**Returns:** **true** if the string is a decimal or currency; otherwise, **false**.

## IsEmailAddress

**Signature:** `IsEmailAddress(String value)`

**Summary:**
Determines whether the input string is a valid email address.

**Parameters:**

- **value** — The string to validate.

**Returns:** **true** if the string is an email address; otherwise, **false**.

## IsInteger

**Signature:** `IsInteger(String value)`

**Summary:**
Determines whether the input string is a valid integer.

**Parameters:**

- **value** — The string to validate.

**Returns:** **true** if the string is an integer; otherwise, **false**.

## IsIPv4

**Signature:** `IsIPv4(String value)`

**Summary:**
Determines whether the input string is a valid IPv4 address.

**Parameters:**

- **value** — The string to validate.

**Returns:** **true** if the string is an IPv4 address; otherwise, **false**.

## IsSocialSecurityNumber

**Signature:** `IsSocialSecurityNumber(String value)`

**Summary:**
Determines whether the input string is a valid US Social Security Number.

**Parameters:**

- **value** — The string to validate.

**Returns:** **true** if the string is a valid SSN; otherwise, **false**.

## IsUnitedStatesPhoneNumber

**Signature:** `IsUnitedStatesPhoneNumber(String value)`

**Summary:**
Determines whether the input string is a valid United States phone number.

**Parameters:**

- **value** — The string to validate.

**Returns:** **true** if the string is a valid US phone number; otherwise, **false**.

## IsUrl

**Signature:** `IsUrl(String value)`

**Summary:**
Determines whether the input string is a valid URL.

**Parameters:**

- **value** — The string to validate.

**Returns:** **true** if the string is a valid URL; otherwise, **false**.

## IsZipCode

**Signature:** `IsZipCode(String value)`

**Summary:**
Determines whether the input string is a valid US or Canadian zip code.

**Parameters:**

- **value** — The string to validate.

**Returns:** **true** if the string is a valid zip code; otherwise, **false**.

## AlphabeticalRegex

**Signature:** `AlphabeticalRegex()`

**Summary:**

**Remarks:** Pattern: 
 ```
^[a-zA-Z]+$
``` 
 Options: 
 ```
RegexOptions.IgnoreCase
``` 
 Explanation: 
 ```

            ○ Match if at the beginning of the string.
            ○ Match a character in the set [A-Za-z\u212A] atomically at least once.
            ○ Match if at the end of the string or if before an ending newline.
```

## AlphanumericRegex

**Signature:** `AlphanumericRegex()`

**Summary:**

**Remarks:** Pattern: 
 ```
^[a-zA-Z0-9]+$
``` 
 Options: 
 ```
RegexOptions.IgnoreCase
``` 
 Explanation: 
 ```

            ○ Match if at the beginning of the string.
            ○ Match a character in the set [0-9A-Za-z\u212A] atomically at least once.
            ○ Match if at the end of the string or if before an ending newline.
```

## DecimalRegex

**Signature:** `DecimalRegex()`

**Summary:**

**Remarks:** Pattern: 
 ```
^(((\\d{1,3},?)(\\d{3},?)+|\\d{1,3})|\\d+)(\\.\\d{1,2})?$
``` 
 Options: 
 ```
RegexOptions.IgnoreCase
``` 
 Explanation: 
 ```

            ○ Match if at the beginning of the string.
            ○ 1st capture group.
                ○ Match with 2 alternative expressions.
                    ○ 2nd capture group.
                        ○ Match with 2 alternative expressions.
                            ○ Match a sequence of expressions.
                                ○ 3rd capture group.
                                    ○ Match a Unicode digit greedily at least 1 and at most 3 times.
                                    ○ Match ',' atomically, optionally.
                                ○ Loop greedily at least once.
                                    ○ 4th capture group.
                                        ○ Match a Unicode digit exactly 3 times.
                                        ○ Match ',' greedily, optionally.
                            ○ Match a Unicode digit greedily at least 1 and at most 3 times.
                    ○ Match a Unicode digit greedily at least once.
            ○ Optional (greedy).
                ○ 5th capture group.
                    ○ Match '.'.
                    ○ Match a Unicode digit atomically at least 1 and at most 2 times.
            ○ Match if at the end of the string or if before an ending newline.
```

## DecimalOrCurrencyRegex

**Signature:** `DecimalOrCurrencyRegex()`

**Summary:**

**Remarks:** Pattern: 
 ```
^(-|\\$|-\\$|\\$-)?(((\\d{1,3},?)(\\d{3},?)+|\\d{1,3})|\\d+)(\\.\\d{1,2})?$
``` 
 Options: 
 ```
RegexOptions.IgnoreCase
``` 
 Explanation: 
 ```

            ○ Match if at the beginning of the string.
            ○ Optional (greedy).
                ○ 1st capture group.
                    ○ Match with 3 alternative expressions.
                        ○ Match a character in the set [$\-].
                        ○ Match the string "-$".
                        ○ Match the string "$-".
            ○ 2nd capture group.
                ○ Match with 2 alternative expressions.
                    ○ 3rd capture group.
                        ○ Match with 2 alternative expressions.
                            ○ Match a sequence of expressions.
                                ○ 4th capture group.
                                    ○ Match a Unicode digit greedily at least 1 and at most 3 times.
                                    ○ Match ',' atomically, optionally.
                                ○ Loop greedily at least once.
                                    ○ 5th capture group.
                                        ○ Match a Unicode digit exactly 3 times.
                                        ○ Match ',' greedily, optionally.
                            ○ Match a Unicode digit greedily at least 1 and at most 3 times.
                    ○ Match a Unicode digit greedily at least once.
            ○ Optional (greedy).
                ○ 6th capture group.
                    ○ Match '.'.
                    ○ Match a Unicode digit atomically at least 1 and at most 2 times.
            ○ Match if at the end of the string or if before an ending newline.
```

## EmailAddressRegex

**Signature:** `EmailAddressRegex()`

**Summary:**

**Remarks:** Pattern: 
 ```
^[a-zA-Z0-9.!#$%&’'*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\\.[a-zA-Z0-9-]+)*$
``` 
 Options: 
 ```
RegexOptions.IgnoreCase
``` 
 Explanation: 
 ```

            ○ Match if at the beginning of the string.
            ○ Match a character in the set [!#-'*+\--9=?A-Z^-~\u2019\u212A] atomically at least once.
            ○ Match '@'.
            ○ Match a character in the set [\-0-9A-Za-z\u212A] greedily at least once.
            ○ Loop greedily any number of times.
                ○ Match '.'.
                ○ Match a character in the set [\-0-9A-Za-z\u212A] atomically at least once.
            ○ Match if at the end of the string or if before an ending newline.
```

## IntegerRegex

**Signature:** `IntegerRegex()`

**Summary:**

**Remarks:** Pattern: 
 ```
^-?\\d+$
``` 
 Options: 
 ```
RegexOptions.IgnoreCase
``` 
 Explanation: 
 ```

            ○ Match if at the beginning of the string.
            ○ Match '-' atomically, optionally.
            ○ Match a Unicode digit atomically at least once.
            ○ Match if at the end of the string or if before an ending newline.
```

## IPv4Regex

**Signature:** `IPv4Regex()`

**Summary:**

**Remarks:** Pattern: 
 ```
\\b(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\\b
``` 
 Options: 
 ```
RegexOptions.IgnoreCase
``` 
 Explanation: 
 ```

            ○ Match if at a word boundary.
            ○ 1st capture group.
                ○ Match with 2 alternative expressions.
                    ○ Match a sequence of expressions.
                        ○ Match '2'.
                        ○ Match with 2 alternative expressions.
                            ○ Match a sequence of expressions.
                                ○ Match '5'.
                                ○ Match a character in the set [0-5].
                            ○ Match a sequence of expressions.
                                ○ Match a character in the set [0-4].
                                ○ Match a character in the set [0-9].
                    ○ Match a sequence of expressions.
                        ○ Match a character in the set [01] greedily, optionally.
                        ○ Match a character in the set [0-9] atomically at least 1 and at most 2 times.
            ○ Match '.'.
            ○ 2nd capture group.
                ○ Match with 2 alternative expressions.
                    ○ Match a sequence of expressions.
                        ○ Match '2'.
                        ○ Match with 2 alternative expressions.
                            ○ Match a sequence of expressions.
                                ○ Match '5'.
                                ○ Match a character in the set [0-5].
                            ○ Match a sequence of expressions.
                                ○ Match a character in the set [0-4].
                                ○ Match a character in the set [0-9].
                    ○ Match a sequence of expressions.
                        ○ Match a character in the set [01] greedily, optionally.
                        ○ Match a character in the set [0-9] atomically at least 1 and at most 2 times.
            ○ Match '.'.
            ○ 3rd capture group.
                ○ Match with 2 alternative expressions.
                    ○ Match a sequence of expressions.
                        ○ Match '2'.
                        ○ Match with 2 alternative expressions.
                            ○ Match a sequence of expressions.
                                ○ Match '5'.
                                ○ Match a character in the set [0-5].
                            ○ Match a sequence of expressions.
                                ○ Match a character in the set [0-4].
                                ○ Match a character in the set [0-9].
                    ○ Match a sequence of expressions.
                        ○ Match a character in the set [01] greedily, optionally.
                        ○ Match a character in the set [0-9] atomically at least 1 and at most 2 times.
            ○ Match '.'.
            ○ 4th capture group.
                ○ Match with 2 alternative expressions.
                    ○ Match a sequence of expressions.
                        ○ Match '2'.
                        ○ Match with 2 alternative expressions.
                            ○ Match a sequence of expressions.
                                ○ Match '5'.
                                ○ Match a character in the set [0-5].
                            ○ Match a sequence of expressions.
                                ○ Match a character in the set [0-4].
                                ○ Match a character in the set [0-9].
                    ○ Match a sequence of expressions.
                        ○ Match a character in the set [01] greedily, optionally.
                        ○ Match a character in the set [0-9] atomically at least 1 and at most 2 times.
            ○ Match if at a word boundary.
```

## SocialSecurityNumberRegex

**Signature:** `SocialSecurityNumberRegex()`

**Summary:**

**Remarks:** Pattern: 
 ```
^(?!000)(?!666)(?!9)\\d{3}([- ]?)(?!00)\\d{2}\\1(?!0000)\\d{4}$
``` 
 Options: 
 ```
RegexOptions.IgnoreCase
``` 
 Explanation: 
 ```

            ○ Match if at the beginning of the string.
            ○ Zero-width negative lookahead.
                ○ Match the string "000".
            ○ Zero-width negative lookahead.
                ○ Match the string "666".
            ○ Zero-width negative lookahead.
                ○ Match '9'.
            ○ Match a Unicode digit exactly 3 times.
            ○ 1st capture group.
                ○ Match a character in the set [ \-] greedily, optionally.
            ○ Zero-width negative lookahead.
                ○ Match the string "00".
            ○ Match a Unicode digit exactly 2 times.
            ○ Match the same text as matched by the 1st capture group.
            ○ Zero-width negative lookahead.
                ○ Match the string "0000".
            ○ Match a Unicode digit exactly 4 times.
            ○ Match if at the end of the string or if before an ending newline.
```

## UnitedStatesPhoneNumberRegex

**Signature:** `UnitedStatesPhoneNumberRegex()`

**Summary:**

**Remarks:** Pattern: 
 ```
^(?:(?:\\+?1\\s*(?:[.-]\\s*)?)?(?:\\(\\s*([2-9]1[02-9]|[2-9][02-8]1|[2-9][02-8][02-9])\\s*\\)|([2-9]1[02-9]|[2-9][02-8]1|[2-9][02-8][02-9]))\\s*(?:[.-]\\s*)?)?([2-9]1[02-9]|[2-9][02-9]1|[2-9][02-9]{2})\\s*(?:[.-]\\s*)?([0-9]{4})$
``` 
 Options: 
 ```
RegexOptions.IgnoreCase
``` 
 Explanation: 
 ```

            ○ Match if at the beginning of the string.
            ○ Optional (greedy).
                ○ Optional (greedy).
                    ○ Match '+' atomically, optionally.
                    ○ Match '1'.
                    ○ Match a whitespace character greedily any number of times.
                    ○ Optional (greedy).
                        ○ Match a character in the set [\-.].
                        ○ Match a whitespace character atomically any number of times.
                ○ Match with 2 alternative expressions.
                    ○ Match a sequence of expressions.
                        ○ Match '('.
                        ○ Match a whitespace character atomically any number of times.
                        ○ 1st capture group.
                            ○ Match a character in the set [2-9].
                            ○ Match with 2 alternative expressions.
                                ○ Match a sequence of expressions.
                                    ○ Match '1'.
                                    ○ Match a character in the set [02-9].
                                ○ Match a sequence of expressions.
                                    ○ Match a character in the set [02-8].
                                    ○ Match a character in the set [0-9].
                        ○ Match a whitespace character atomically any number of times.
                        ○ Match ')'.
                    ○ 2nd capture group.
                        ○ Match a character in the set [2-9].
                        ○ Match with 2 alternative expressions.
                            ○ Match a sequence of expressions.
                                ○ Match '1'.
                                ○ Match a character in the set [02-9].
                            ○ Match a sequence of expressions.
                                ○ Match a character in the set [02-8].
                                ○ Match a character in the set [0-9].
                ○ Match a whitespace character greedily any number of times.
                ○ Optional (greedy).
                    ○ Match a character in the set [\-.].
                    ○ Match a whitespace character atomically any number of times.
            ○ 3rd capture group.
                ○ Match a character in the set [2-9].
                ○ Match with 3 alternative expressions.
                    ○ Match a sequence of expressions.
                        ○ Match '1'.
                        ○ Match a character in the set [02-9].
                    ○ Match a sequence of expressions.
                        ○ Match a character in the set [02-9].
                        ○ Match '1'.
                    ○ Match a character in the set [02-9] exactly 2 times.
            ○ Match a whitespace character greedily any number of times.
            ○ Optional (greedy).
                ○ Match a character in the set [\-.].
                ○ Match a whitespace character atomically any number of times.
            ○ 4th capture group.
                ○ Match a character in the set [0-9] exactly 4 times.
            ○ Match if at the end of the string or if before an ending newline.
```

## UrlRegex

**Signature:** `UrlRegex()`

**Summary:**

**Remarks:** Pattern: 
 ```
^(ht|f)tp(s?)\\:\\/\\/[0-9a-zA-Z]([-.\\w]*[0-9a-zA-Z])*(:(0-9)*)*(\\/?)([a-zA-Z0-9\\-\\.\\?\\,\\'\\/\\\\\\+&amp;%\\$#_]*)?$
``` 
 Options: 
 ```
RegexOptions.IgnoreCase
``` 
 Explanation: 
 ```

            ○ Match if at the beginning of the string.
            ○ 1st capture group.
                ○ Match with 2 alternative expressions.
                    ○ Match a sequence of expressions.
                        ○ Match a character in the set [Hh].
                        ○ Match a character in the set [Tt].
                    ○ Match a character in the set [Ff].
            ○ Match a character in the set [Tt].
            ○ Match a character in the set [Pp].
            ○ 2nd capture group.
                ○ Match a character in the set [Ss] atomically, optionally.
            ○ Match the string "://".
            ○ Match a character in the set [0-9A-Za-z\u212A].
            ○ Loop greedily any number of times.
                ○ 3rd capture group.
                    ○ Match a character in the set [\-.\w] greedily any number of times.
                    ○ Match a character in the set [0-9A-Za-z\u212A].
            ○ Loop greedily any number of times.
                ○ 4th capture group.
                    ○ Match ':'.
                    ○ Loop greedily any number of times.
                        ○ 5th capture group.
                            ○ Match the string "0-9".
            ○ 6th capture group.
                ○ Match '/' greedily, optionally.
            ○ Optional (greedy).
                ○ 7th capture group.
                    ○ Match a character in the set [#-'+-9;?A-Z\\_a-z\u212A] atomically any number of times.
            ○ Match if at the end of the string or if before an ending newline.
```

## ZipCodeRegex

**Signature:** `ZipCodeRegex()`

**Summary:**

**Remarks:** Pattern: 
 ```
^(\\d{5}-\\d{4}|\\d{5}|\\d{9})$|^([a-zA-Z]\\d[a-zA-Z] \\d[a-zA-Z]\\d)$
``` 
 Options: 
 ```
RegexOptions.IgnoreCase
``` 
 Explanation: 
 ```

            ○ Match if at the beginning of the string.
            ○ Match with 2 alternative expressions, atomically.
                ○ Match a sequence of expressions.
                    ○ 1st capture group.
                        ○ Match with 3 alternative expressions.
                            ○ Match a sequence of expressions.
                                ○ Match a Unicode digit exactly 5 times.
                                ○ Match '-'.
                                ○ Match a Unicode digit exactly 4 times.
                            ○ Match a Unicode digit exactly 5 times.
                            ○ Match a Unicode digit exactly 9 times.
                    ○ Match if at the end of the string or if before an ending newline.
                ○ Match a sequence of expressions.
                    ○ 2nd capture group.
                        ○ Match a character in the set [A-Za-z\u0130\u212A].
                        ○ Match a Unicode digit.
                        ○ Match a character in the set [A-Za-z\u0130\u212A].
                        ○ Match ' '.
                        ○ Match a Unicode digit.
                        ○ Match a character in the set [A-Za-z\u0130\u212A].
                        ○ Match a Unicode digit.
                    ○ Match if at the end of the string or if before an ending newline.
```