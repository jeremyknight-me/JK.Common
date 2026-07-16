[Docs](../../README.md) > [JK.Common](../README.md) > CoordinateBase

# CoordinateBase

**Namespace:** `JK.Common.Geospatial`

Base object for latitudes and longitudes coordinates.

## CoordinateBase

**Signature:** `CoordinateBase(Decimal degrees, Decimal minutes, Decimal seconds)`

**Summary:**
Initializes a new instance of the **CoordinateBase** class.

**Parameters:**

- **degrees** — The degrees component of the coordinate.

- **minutes** — The minutes component of the coordinate. Defaults to 0.

- **seconds** — The seconds component of the coordinate. Defaults to 0.

## CoordinateBase

**Signature:** `CoordinateBase(Decimal degrees, Direction direction)`

**Summary:**
Initializes a new instance of the **CoordinateBase** class with a direction.

**Parameters:**

- **degrees** — The degrees component of the coordinate.

- **direction** — The cardinal direction of the coordinate.

## CoordinateBase

**Signature:** `CoordinateBase(Decimal degrees, Decimal minutes, Direction direction)`

**Summary:**
Initializes a new instance of the **CoordinateBase** class with minutes and a direction.

**Parameters:**

- **degrees** — The degrees component of the coordinate.

- **minutes** — The minutes component of the coordinate.

- **direction** — The cardinal direction of the coordinate.

## CoordinateBase

**Signature:** `CoordinateBase(Decimal degrees, Decimal minutes, Decimal seconds, Direction direction)`

**Summary:**
Initializes a new instance of the **CoordinateBase** class with minutes, seconds, and a direction.

**Parameters:**

- **degrees** — The degrees component of the coordinate.

- **minutes** — The minutes component of the coordinate.

- **seconds** — The seconds component of the coordinate.

- **direction** — The cardinal direction of the coordinate.

## ToString()

**Signature:** `ToString()`

**Summary:**
Returns a string that represents the current coordinate in decimal degrees.

**Returns:** A string that represents the current coordinate.

## ToString(DisplayFormat format)

**Signature:** `ToString(DisplayFormat format)`

**Summary:**
Formats the value of the current coordinate using the specified format.

**Parameters:**

- **format** — The format to use.

**Returns:** The value of the current coordinate in the specified format.

## ToHtmlString

**Signature:** `ToHtmlString(DisplayFormat format)`

**Summary:**
Formats the value of the current coordinate as HTML using the specified format.

**Parameters:**

- **format** — The format to use.

**Returns:** The value of the current coordinate in the specified HTML format.

## GetValidDirections

**Signature:** `GetValidDirections()`

**Summary:**
Gets the valid directions for the coordinate type.

**Returns:** A collection of valid directions.

## SetIsNegative(Decimal degrees)

**Signature:** `SetIsNegative(Decimal degrees)`

**Summary:**
Sets whether the coordinate is negative based on the degrees value.

**Parameters:**

- **degrees** — The degrees value to evaluate.

## SetIsNegative(Direction direction)

**Signature:** `SetIsNegative(Direction direction)`

**Summary:**
Sets whether the coordinate is negative based on the direction.

**Parameters:**

- **direction** — The direction to evaluate.

## Validate(Decimal value)

**Signature:** `Validate(Decimal value)`

**Summary:**
Validates the coordinate value using the validation specification.

**Parameters:**

- **value** — The value to validate.

**Exceptions:**

- **System.ArgumentOutOfRangeException**: Thrown if the value is not valid for this type of coordinate.

## Validate(Decimal value, Direction direction)

**Signature:** `Validate(Decimal value, Direction direction)`

**Summary:**
Validates the coordinate value and direction using the validation specification.

**Parameters:**

- **value** — The value to validate.

- **direction** — The direction to validate.

**Exceptions:**

- **System.ArgumentOutOfRangeException**: Thrown if the value or direction is not valid for this type of coordinate.

## IsNegative

**Signature:** `IsNegative`

**Summary:**
Gets or sets whether the coordinate represents positive or negative point.

## Coordinate

**Signature:** `Coordinate`

**Summary:**
Gets or sets the absolute value of the coordinate.

## CoordinateSigned

**Signature:** `CoordinateSigned`

**Summary:**
Gets the signed value of the coordinate.

## DecimalDegrees

**Signature:** `DecimalDegrees`

**Summary:**
Gets the unsigned degrees rounded to 10 decimal places.

## DecimalDegreesSigned

**Signature:** `DecimalDegreesSigned`

**Summary:**
Gets the signed degrees rounded to 10 decimal places.

## DegreesSigned

**Signature:** `DegreesSigned`

**Summary:**
Gets the signed degrees as an integer.

## Degrees

**Signature:** `Degrees`

**Summary:**
Gets the unsigned degrees as an integer.

## DecimalMinutes

**Signature:** `DecimalMinutes`

**Summary:**
Gets the minutes to 3 decimal places.

## Minutes

**Signature:** `Minutes`

**Summary:**
Gets the minutes as an integer.

## Seconds

**Signature:** `Seconds`

**Summary:**
Gets the seconds as an integer.

## Direction

**Signature:** `Direction`

**Summary:**
Gets the cardinal direction of the coordinate.

## CoordinateType

**Signature:** `CoordinateType`

**Summary:**
Gets the coordinate type (latitude or longitude).

## ValidationSpecification

**Signature:** `ValidationSpecification`

**Summary:**
Gets the validation specification for the coordinate.