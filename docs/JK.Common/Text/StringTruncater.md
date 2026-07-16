[Docs](../../README.md) > [JK.Common](../README.md) > StringTruncater

# StringTruncater

**Namespace:** `JK.Common.Text`

Class which truncates strings.

## StringTruncater

**Signature:** `StringTruncater(String originalText)`

**Summary:**
Initializes a new instance of the **StringTruncater** class.

**Parameters:**

- **originalText** — The text to be truncated.

## StringTruncater

**Signature:** `StringTruncater(String originalText, String indicator)`

**Summary:**
Initializes a new instance of the **StringTruncater** class.

**Parameters:**

- **originalText** — Text to be truncated.

- **indicator** — Indicator to be placed within the truncated text to indicate that a truncation has taken place.

## TruncateToLength

**Signature:** `TruncateToLength(Int32 length)`

**Summary:**
Truncates the original text to a given length.

**Parameters:**

- **length** — Length of string to output.

**Returns:** Original text truncated to given length.

## Indicator

**Signature:** `Indicator`

**Summary:**
Gets or sets the indicator to concatenate to the end of truncated text. Ex: '...'