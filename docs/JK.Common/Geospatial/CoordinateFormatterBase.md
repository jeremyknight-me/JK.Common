[Docs](../../README.md) > [JK.Common](../README.md) > CoordinateFormatterBase

# CoordinateFormatterBase

**Namespace:** `JK.Common.Geospatial`

Base class for formatting coordinates in various display formats.

## CoordinateFormatterBase

**Summary:** Initializes a new instance of the **CoordinateFormatterBase** class.

**Parameters:**

- **coordinateToUse** — The coordinate to format.

## Format

**Signature:** `Format(DisplayFormat format)`

**Summary:**
Formats the coordinate using the specified display format.

**Parameters:**

- **format** — The display format to use.

**Returns:** The formatted coordinate string.

## ToStringDegrees

**Signature:** `ToStringDegrees()`

**Summary:**
Returns the coordinate as a string in degrees format.

**Returns:** The coordinate in degrees format.

## ToStringDegreesMinutes

**Signature:** `ToStringDegreesMinutes()`

**Summary:**
Returns the coordinate as a string in degrees and minutes format.

**Returns:** The coordinate in degrees and minutes format.

## ToStringDegreesMinutesSeconds

**Signature:** `ToStringDegreesMinutesSeconds()`

**Summary:**
Returns the coordinate as a string in degrees, minutes, and seconds format.

**Returns:** The coordinate in degrees, minutes, and seconds format.

## ToStringDegreesDirection

**Signature:** `ToStringDegreesDirection()`

**Summary:**
Returns the coordinate as a string in degrees and direction format.

**Returns:** The coordinate in degrees and direction format.

## ToStringDegreesMinutesDirection

**Signature:** `ToStringDegreesMinutesDirection()`

**Summary:**
Returns the coordinate as a string in degrees, minutes, and direction format.

**Returns:** The coordinate in degrees, minutes, and direction format.

## ToStringDegreesMinutesSecondsDirection

**Signature:** `ToStringDegreesMinutesSecondsDirection()`

**Summary:**
Returns the coordinate as a string in degrees, minutes, seconds, and direction format.

**Returns:** The coordinate in degrees, minutes, seconds, and direction format.

## Coordinate

**Signature:** `Coordinate`

**Summary:**
Gets or sets the coordinate to format.