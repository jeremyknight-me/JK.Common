[Docs](../../README.md) > [JK.Common](../README.md) > CoordinateFormatterBase

# CoordinateFormatterBase

**Namespace:** `JK.Common.Geospatial`

Base class for formatting coordinates in various display formats.

### #ctor

**Signature:** ``#ctor(CoordinateBase coordinateToUse)``

**Summary:**
Initializes a new instance of the **CoordinateFormatterBase** class.

**Parameters:**
- **coordinateToUse** — The coordinate to format.

**Remarks:**
### Format

**Signature:** ``Format(DisplayFormat@ format)``

**Summary:**
Formats the coordinate using the specified display format.

**Parameters:**
- **format** — The display format to use.

**Returns:** The formatted coordinate string.

**Remarks:**
### ToStringDegrees

**Signature:** ``ToStringDegrees()``

**Summary:**
Returns the coordinate as a string in degrees format.

**Returns:** The coordinate in degrees format.

**Remarks:**
### ToStringDegreesMinutes

**Signature:** ``ToStringDegreesMinutes()``

**Summary:**
Returns the coordinate as a string in degrees and minutes format.

**Returns:** The coordinate in degrees and minutes format.

**Remarks:**
### ToStringDegreesMinutesSeconds

**Signature:** ``ToStringDegreesMinutesSeconds()``

**Summary:**
Returns the coordinate as a string in degrees, minutes, and seconds format.

**Returns:** The coordinate in degrees, minutes, and seconds format.

**Remarks:**
### ToStringDegreesDirection

**Signature:** ``ToStringDegreesDirection()``

**Summary:**
Returns the coordinate as a string in degrees and direction format.

**Returns:** The coordinate in degrees and direction format.

**Remarks:**
### ToStringDegreesMinutesDirection

**Signature:** ``ToStringDegreesMinutesDirection()``

**Summary:**
Returns the coordinate as a string in degrees, minutes, and direction format.

**Returns:** The coordinate in degrees, minutes, and direction format.

**Remarks:**
### ToStringDegreesMinutesSecondsDirection

**Signature:** ``ToStringDegreesMinutesSecondsDirection()``

**Summary:**
Returns the coordinate as a string in degrees, minutes, seconds, and direction format.

**Returns:** The coordinate in degrees, minutes, seconds, and direction format.

**Remarks:**

### Coordinate

**Signature:** ``Coordinate``

**Summary:**
Gets or sets the coordinate to format.

**Remarks:**