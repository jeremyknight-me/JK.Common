[Docs](../../README.md) > [JK.Common](../README.md) > CoordinateBase

# CoordinateBase

**Namespace:** `JK.Common.Geospatial`

Base object for latitudes and longitudes coordinates.

### #ctor

**Signature:** ``#ctor(Decimal degrees, Decimal minutes, Decimal seconds)``

**Summary:**
Initializes a new instance of the **CoordinateBase** class.

**Parameters:**
- **degrees** — The degrees component of the coordinate.
- **minutes** — The minutes component of the coordinate. Defaults to 0.
- **seconds** — The seconds component of the coordinate. Defaults to 0.

**Remarks:**
### #ctor

**Signature:** ``#ctor(Decimal degrees, Direction direction)``

**Summary:**
Initializes a new instance of the **CoordinateBase** class with a direction.

**Parameters:**
- **degrees** — The degrees component of the coordinate.
- **direction** — The cardinal direction of the coordinate.

**Remarks:**
### #ctor

**Signature:** ``#ctor(Decimal degrees, Decimal minutes, Direction direction)``

**Summary:**
Initializes a new instance of the **CoordinateBase** class with minutes and a direction.

**Parameters:**
- **degrees** — The degrees component of the coordinate.
- **minutes** — The minutes component of the coordinate.
- **direction** — The cardinal direction of the coordinate.

**Remarks:**
### #ctor

**Signature:** ``#ctor(Decimal degrees, Decimal minutes, Decimal seconds, Direction direction)``

**Summary:**
Initializes a new instance of the **CoordinateBase** class with minutes, seconds, and a direction.

**Parameters:**
- **degrees** — The degrees component of the coordinate.
- **minutes** — The minutes component of the coordinate.
- **seconds** — The seconds component of the coordinate.
- **direction** — The cardinal direction of the coordinate.

**Remarks:**
### ToString

**Signature:** ``ToString()``

**Summary:**
Returns a string that represents the current coordinate in decimal degrees.

**Returns:** A string that represents the current coordinate.

**Remarks:**
### ToString

**Signature:** ``ToString(DisplayFormat@ format)``

**Summary:**
Formats the value of the current coordinate using the specified format.

**Parameters:**
- **format** — The format to use.

**Returns:** The value of the current coordinate in the specified format.

**Remarks:**
### ToHtmlString

**Signature:** ``ToHtmlString(DisplayFormat@ format)``

**Summary:**
Formats the value of the current coordinate as HTML using the specified format.

**Parameters:**
- **format** — The format to use.

**Returns:** The value of the current coordinate in the specified HTML format.

**Remarks:**
### GetValidDirections

**Signature:** ``GetValidDirections()``

**Summary:**
Gets the valid directions for the coordinate type.

**Returns:** A collection of valid directions.

**Remarks:**
### SetIsNegative

**Signature:** ``SetIsNegative(Decimal@ degrees)``

**Summary:**
Sets whether the coordinate is negative based on the degrees value.

**Parameters:**
- **degrees** — The degrees value to evaluate.

**Remarks:**
### SetIsNegative

**Signature:** ``SetIsNegative(Direction@ direction)``

**Summary:**
Sets whether the coordinate is negative based on the direction.

**Parameters:**
- **direction** — The direction to evaluate.

**Remarks:**
### Validate

**Signature:** ``Validate(Decimal@ value)``

**Summary:**
Validates the coordinate value using the validation specification.

**Parameters:**
- **value** — The value to validate.

**Exceptions:**
- **System.ArgumentOutOfRangeException**: Thrown if the value is not valid for this type of coordinate.

**Remarks:**
### Validate

**Signature:** ``Validate(Decimal@ value, Direction@ direction)``

**Summary:**
Validates the coordinate value and direction using the validation specification.

**Parameters:**
- **value** — The value to validate.
- **direction** — The direction to validate.

**Exceptions:**
- **System.ArgumentOutOfRangeException**: Thrown if the value or direction is not valid for this type of coordinate.

**Remarks:**

### IsNegative

**Signature:** ``IsNegative``

**Summary:**
Gets or sets whether the coordinate represents positive or negative point.

**Remarks:**
### Coordinate

**Signature:** ``Coordinate``

**Summary:**
Gets or sets the absolute value of the coordinate.

**Remarks:**
### CoordinateSigned

**Signature:** ``CoordinateSigned``

**Summary:**
Gets the signed value of the coordinate.

**Remarks:**
### DecimalDegrees

**Signature:** ``DecimalDegrees``

**Summary:**
Gets the unsigned degrees rounded to 10 decimal places.

**Remarks:**
### DecimalDegreesSigned

**Signature:** ``DecimalDegreesSigned``

**Summary:**
Gets the signed degrees rounded to 10 decimal places.

**Remarks:**
### DegreesSigned

**Signature:** ``DegreesSigned``

**Summary:**
Gets the signed degrees as an integer.

**Remarks:**
### Degrees

**Signature:** ``Degrees``

**Summary:**
Gets the unsigned degrees as an integer.

**Remarks:**
### DecimalMinutes

**Signature:** ``DecimalMinutes``

**Summary:**
Gets the minutes to 3 decimal places.

**Remarks:**
### Minutes

**Signature:** ``Minutes``

**Summary:**
Gets the minutes as an integer.

**Remarks:**
### Seconds

**Signature:** ``Seconds``

**Summary:**
Gets the seconds as an integer.

**Remarks:**
### Direction

**Signature:** ``Direction``

**Summary:**
Gets the cardinal direction of the coordinate.

**Remarks:**
### CoordinateType

**Signature:** ``CoordinateType``

**Summary:**
Gets the coordinate type (latitude or longitude).

**Remarks:**
### ValidationSpecification

**Signature:** ``ValidationSpecification``

**Summary:**
Gets the validation specification for the coordinate.

**Remarks:**