[Docs](../../README.md) > [JK.Common](../README.md) > CoordinateBase

# CoordinateBase

**Namespace:** `JK.Common.Geospatial`

Base object for latitudes and longitudes coordinates.

<<<<<<< HEAD
## CoordinateBase

**Summary:** Initializes a new instance of the **CoordinateBase** class.

**Parameters:**

- **degrees** — The degrees component of the coordinate.

- **minutes** — The minutes component of the coordinate. Defaults to 0.

- **seconds** — The seconds component of the coordinate. Defaults to 0.

## CoordinateBase

**Summary:** Initializes a new instance of the **CoordinateBase** class with a direction.

**Parameters:**

- **degrees** — The degrees component of the coordinate.

- **direction** — The cardinal direction of the coordinate.

## CoordinateBase

**Summary:** Initializes a new instance of the **CoordinateBase** class with minutes and a direction.

**Parameters:**

- **degrees** — The degrees component of the coordinate.

- **minutes** — The minutes component of the coordinate.

- **direction** — The cardinal direction of the coordinate.

## CoordinateBase

**Summary:** Initializes a new instance of the **CoordinateBase** class with minutes, seconds, and a direction.

**Parameters:**

- **degrees** — The degrees component of the coordinate.

- **minutes** — The minutes component of the coordinate.

- **seconds** — The seconds component of the coordinate.

- **direction** — The cardinal direction of the coordinate.

## ToString()

**Signature:** `ToString()`
=======
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
>>>>>>> initial docs folder changes

**Summary:**
Returns a string that represents the current coordinate in decimal degrees.

**Returns:** A string that represents the current coordinate.

<<<<<<< HEAD
## ToString(DisplayFormat format)

**Signature:** `ToString(DisplayFormat format)`
=======
**Remarks:**
### ToString

**Signature:** ``ToString(DisplayFormat@ format)``
>>>>>>> initial docs folder changes

**Summary:**
Formats the value of the current coordinate using the specified format.

**Parameters:**
<<<<<<< HEAD

=======
>>>>>>> initial docs folder changes
- **format** — The format to use.

**Returns:** The value of the current coordinate in the specified format.

<<<<<<< HEAD
## ToHtmlString

**Signature:** `ToHtmlString(DisplayFormat format)`
=======
**Remarks:**
### ToHtmlString

**Signature:** ``ToHtmlString(DisplayFormat@ format)``
>>>>>>> initial docs folder changes

**Summary:**
Formats the value of the current coordinate as HTML using the specified format.

**Parameters:**
<<<<<<< HEAD

=======
>>>>>>> initial docs folder changes
- **format** — The format to use.

**Returns:** The value of the current coordinate in the specified HTML format.

<<<<<<< HEAD
## GetValidDirections

**Signature:** `GetValidDirections()`
=======
**Remarks:**
### GetValidDirections

**Signature:** ``GetValidDirections()``
>>>>>>> initial docs folder changes

**Summary:**
Gets the valid directions for the coordinate type.

**Returns:** A collection of valid directions.

<<<<<<< HEAD
## SetIsNegative(Decimal degrees)

**Signature:** `SetIsNegative(Decimal degrees)`
=======
**Remarks:**
### SetIsNegative

**Signature:** ``SetIsNegative(Decimal@ degrees)``
>>>>>>> initial docs folder changes

**Summary:**
Sets whether the coordinate is negative based on the degrees value.

**Parameters:**
<<<<<<< HEAD

- **degrees** — The degrees value to evaluate.

## SetIsNegative(Direction direction)

**Signature:** `SetIsNegative(Direction direction)`
=======
- **degrees** — The degrees value to evaluate.

**Remarks:**
### SetIsNegative

**Signature:** ``SetIsNegative(Direction@ direction)``
>>>>>>> initial docs folder changes

**Summary:**
Sets whether the coordinate is negative based on the direction.

**Parameters:**
<<<<<<< HEAD

- **direction** — The direction to evaluate.

## Validate(Decimal value)

**Signature:** `Validate(Decimal value)`
=======
- **direction** — The direction to evaluate.

**Remarks:**
### Validate

**Signature:** ``Validate(Decimal@ value)``
>>>>>>> initial docs folder changes

**Summary:**
Validates the coordinate value using the validation specification.

**Parameters:**
<<<<<<< HEAD

- **value** — The value to validate.

**Exceptions:**

- **System.ArgumentOutOfRangeException**: Thrown if the value is not valid for this type of coordinate.

## Validate(Decimal value, Direction direction)

**Signature:** `Validate(Decimal value, Direction direction)`
=======
- **value** — The value to validate.

**Exceptions:**
- **System.ArgumentOutOfRangeException**: Thrown if the value is not valid for this type of coordinate.

**Remarks:**
### Validate

**Signature:** ``Validate(Decimal@ value, Direction@ direction)``
>>>>>>> initial docs folder changes

**Summary:**
Validates the coordinate value and direction using the validation specification.

**Parameters:**
<<<<<<< HEAD

- **value** — The value to validate.

- **direction** — The direction to validate.

**Exceptions:**

- **System.ArgumentOutOfRangeException**: Thrown if the value or direction is not valid for this type of coordinate.

## IsNegative

**Signature:** `IsNegative`
=======
- **value** — The value to validate.
- **direction** — The direction to validate.

**Exceptions:**
- **System.ArgumentOutOfRangeException**: Thrown if the value or direction is not valid for this type of coordinate.

**Remarks:**

### IsNegative

**Signature:** ``IsNegative``
>>>>>>> initial docs folder changes

**Summary:**
Gets or sets whether the coordinate represents positive or negative point.

<<<<<<< HEAD
## Coordinate

**Signature:** `Coordinate`
=======
**Remarks:**
### Coordinate

**Signature:** ``Coordinate``
>>>>>>> initial docs folder changes

**Summary:**
Gets or sets the absolute value of the coordinate.

<<<<<<< HEAD
## CoordinateSigned

**Signature:** `CoordinateSigned`
=======
**Remarks:**
### CoordinateSigned

**Signature:** ``CoordinateSigned``
>>>>>>> initial docs folder changes

**Summary:**
Gets the signed value of the coordinate.

<<<<<<< HEAD
## DecimalDegrees

**Signature:** `DecimalDegrees`
=======
**Remarks:**
### DecimalDegrees

**Signature:** ``DecimalDegrees``
>>>>>>> initial docs folder changes

**Summary:**
Gets the unsigned degrees rounded to 10 decimal places.

<<<<<<< HEAD
## DecimalDegreesSigned

**Signature:** `DecimalDegreesSigned`
=======
**Remarks:**
### DecimalDegreesSigned

**Signature:** ``DecimalDegreesSigned``
>>>>>>> initial docs folder changes

**Summary:**
Gets the signed degrees rounded to 10 decimal places.

<<<<<<< HEAD
## DegreesSigned

**Signature:** `DegreesSigned`
=======
**Remarks:**
### DegreesSigned

**Signature:** ``DegreesSigned``
>>>>>>> initial docs folder changes

**Summary:**
Gets the signed degrees as an integer.

<<<<<<< HEAD
## Degrees

**Signature:** `Degrees`
=======
**Remarks:**
### Degrees

**Signature:** ``Degrees``
>>>>>>> initial docs folder changes

**Summary:**
Gets the unsigned degrees as an integer.

<<<<<<< HEAD
## DecimalMinutes

**Signature:** `DecimalMinutes`
=======
**Remarks:**
### DecimalMinutes

**Signature:** ``DecimalMinutes``
>>>>>>> initial docs folder changes

**Summary:**
Gets the minutes to 3 decimal places.

<<<<<<< HEAD
## Minutes

**Signature:** `Minutes`
=======
**Remarks:**
### Minutes

**Signature:** ``Minutes``
>>>>>>> initial docs folder changes

**Summary:**
Gets the minutes as an integer.

<<<<<<< HEAD
## Seconds

**Signature:** `Seconds`
=======
**Remarks:**
### Seconds

**Signature:** ``Seconds``
>>>>>>> initial docs folder changes

**Summary:**
Gets the seconds as an integer.

<<<<<<< HEAD
## Direction

**Signature:** `Direction`
=======
**Remarks:**
### Direction

**Signature:** ``Direction``
>>>>>>> initial docs folder changes

**Summary:**
Gets the cardinal direction of the coordinate.

<<<<<<< HEAD
## CoordinateType

**Signature:** `CoordinateType`
=======
**Remarks:**
### CoordinateType

**Signature:** ``CoordinateType``
>>>>>>> initial docs folder changes

**Summary:**
Gets the coordinate type (latitude or longitude).

<<<<<<< HEAD
## ValidationSpecification

**Signature:** `ValidationSpecification`

**Summary:**
Gets the validation specification for the coordinate.
=======
**Remarks:**
### ValidationSpecification

**Signature:** ``ValidationSpecification``

**Summary:**
Gets the validation specification for the coordinate.

**Remarks:**
>>>>>>> initial docs folder changes
