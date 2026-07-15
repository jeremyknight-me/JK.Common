[Docs](../../README.md) > [JK.Common](../README.md) > CoordinateBase

# CoordinateBase

**Namespace:** `JK.Common.Geospatial`

Base object for latitudes and longitudes coordinates.

<<<<<<< HEAD
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
=======
>>>>>>> d66d5e94771075443ea96deaa1b24a052ee196d0
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
<<<<<<< HEAD
>>>>>>> initial docs folder changes
=======
>>>>>>> d66d5e94771075443ea96deaa1b24a052ee196d0

**Summary:**
Returns a string that represents the current coordinate in decimal degrees.

**Returns:** A string that represents the current coordinate.

<<<<<<< HEAD
<<<<<<< HEAD
## ToString(DisplayFormat format)

**Signature:** `ToString(DisplayFormat format)`
=======
=======
>>>>>>> d66d5e94771075443ea96deaa1b24a052ee196d0
**Remarks:**
### ToString

**Signature:** ``ToString(DisplayFormat@ format)``
<<<<<<< HEAD
>>>>>>> initial docs folder changes
=======
>>>>>>> d66d5e94771075443ea96deaa1b24a052ee196d0

**Summary:**
Formats the value of the current coordinate using the specified format.

**Parameters:**
<<<<<<< HEAD
<<<<<<< HEAD

=======
>>>>>>> initial docs folder changes
=======
>>>>>>> d66d5e94771075443ea96deaa1b24a052ee196d0
- **format** — The format to use.

**Returns:** The value of the current coordinate in the specified format.

<<<<<<< HEAD
<<<<<<< HEAD
## ToHtmlString

**Signature:** `ToHtmlString(DisplayFormat format)`
=======
=======
>>>>>>> d66d5e94771075443ea96deaa1b24a052ee196d0
**Remarks:**
### ToHtmlString

**Signature:** ``ToHtmlString(DisplayFormat@ format)``
<<<<<<< HEAD
>>>>>>> initial docs folder changes
=======
>>>>>>> d66d5e94771075443ea96deaa1b24a052ee196d0

**Summary:**
Formats the value of the current coordinate as HTML using the specified format.

**Parameters:**
<<<<<<< HEAD
<<<<<<< HEAD

=======
>>>>>>> initial docs folder changes
=======
>>>>>>> d66d5e94771075443ea96deaa1b24a052ee196d0
- **format** — The format to use.

**Returns:** The value of the current coordinate in the specified HTML format.

<<<<<<< HEAD
<<<<<<< HEAD
## GetValidDirections

**Signature:** `GetValidDirections()`
=======
=======
>>>>>>> d66d5e94771075443ea96deaa1b24a052ee196d0
**Remarks:**
### GetValidDirections

**Signature:** ``GetValidDirections()``
<<<<<<< HEAD
>>>>>>> initial docs folder changes
=======
>>>>>>> d66d5e94771075443ea96deaa1b24a052ee196d0

**Summary:**
Gets the valid directions for the coordinate type.

**Returns:** A collection of valid directions.

<<<<<<< HEAD
<<<<<<< HEAD
## SetIsNegative(Decimal degrees)

**Signature:** `SetIsNegative(Decimal degrees)`
=======
=======
>>>>>>> d66d5e94771075443ea96deaa1b24a052ee196d0
**Remarks:**
### SetIsNegative

**Signature:** ``SetIsNegative(Decimal@ degrees)``
<<<<<<< HEAD
>>>>>>> initial docs folder changes
=======
>>>>>>> d66d5e94771075443ea96deaa1b24a052ee196d0

**Summary:**
Sets whether the coordinate is negative based on the degrees value.

**Parameters:**
<<<<<<< HEAD
<<<<<<< HEAD

- **degrees** — The degrees value to evaluate.

## SetIsNegative(Direction direction)

**Signature:** `SetIsNegative(Direction direction)`
=======
=======
>>>>>>> d66d5e94771075443ea96deaa1b24a052ee196d0
- **degrees** — The degrees value to evaluate.

**Remarks:**
### SetIsNegative

**Signature:** ``SetIsNegative(Direction@ direction)``
<<<<<<< HEAD
>>>>>>> initial docs folder changes
=======
>>>>>>> d66d5e94771075443ea96deaa1b24a052ee196d0

**Summary:**
Sets whether the coordinate is negative based on the direction.

**Parameters:**
<<<<<<< HEAD
<<<<<<< HEAD

- **direction** — The direction to evaluate.

## Validate(Decimal value)

**Signature:** `Validate(Decimal value)`
=======
=======
>>>>>>> d66d5e94771075443ea96deaa1b24a052ee196d0
- **direction** — The direction to evaluate.

**Remarks:**
### Validate

**Signature:** ``Validate(Decimal@ value)``
<<<<<<< HEAD
>>>>>>> initial docs folder changes
=======
>>>>>>> d66d5e94771075443ea96deaa1b24a052ee196d0

**Summary:**
Validates the coordinate value using the validation specification.

**Parameters:**
<<<<<<< HEAD
<<<<<<< HEAD

- **value** — The value to validate.

**Exceptions:**

- **System.ArgumentOutOfRangeException**: Thrown if the value is not valid for this type of coordinate.

## Validate(Decimal value, Direction direction)

**Signature:** `Validate(Decimal value, Direction direction)`
=======
=======
>>>>>>> d66d5e94771075443ea96deaa1b24a052ee196d0
- **value** — The value to validate.

**Exceptions:**
- **System.ArgumentOutOfRangeException**: Thrown if the value is not valid for this type of coordinate.

**Remarks:**
### Validate

**Signature:** ``Validate(Decimal@ value, Direction@ direction)``
<<<<<<< HEAD
>>>>>>> initial docs folder changes
=======
>>>>>>> d66d5e94771075443ea96deaa1b24a052ee196d0

**Summary:**
Validates the coordinate value and direction using the validation specification.

**Parameters:**
<<<<<<< HEAD
<<<<<<< HEAD

- **value** — The value to validate.

- **direction** — The direction to validate.

**Exceptions:**

- **System.ArgumentOutOfRangeException**: Thrown if the value or direction is not valid for this type of coordinate.

## IsNegative

**Signature:** `IsNegative`
=======
=======
>>>>>>> d66d5e94771075443ea96deaa1b24a052ee196d0
- **value** — The value to validate.
- **direction** — The direction to validate.

**Exceptions:**
- **System.ArgumentOutOfRangeException**: Thrown if the value or direction is not valid for this type of coordinate.

**Remarks:**

### IsNegative

**Signature:** ``IsNegative``
<<<<<<< HEAD
>>>>>>> initial docs folder changes
=======
>>>>>>> d66d5e94771075443ea96deaa1b24a052ee196d0

**Summary:**
Gets or sets whether the coordinate represents positive or negative point.

<<<<<<< HEAD
<<<<<<< HEAD
## Coordinate

**Signature:** `Coordinate`
=======
=======
>>>>>>> d66d5e94771075443ea96deaa1b24a052ee196d0
**Remarks:**
### Coordinate

**Signature:** ``Coordinate``
<<<<<<< HEAD
>>>>>>> initial docs folder changes
=======
>>>>>>> d66d5e94771075443ea96deaa1b24a052ee196d0

**Summary:**
Gets or sets the absolute value of the coordinate.

<<<<<<< HEAD
<<<<<<< HEAD
## CoordinateSigned

**Signature:** `CoordinateSigned`
=======
=======
>>>>>>> d66d5e94771075443ea96deaa1b24a052ee196d0
**Remarks:**
### CoordinateSigned

**Signature:** ``CoordinateSigned``
<<<<<<< HEAD
>>>>>>> initial docs folder changes
=======
>>>>>>> d66d5e94771075443ea96deaa1b24a052ee196d0

**Summary:**
Gets the signed value of the coordinate.

<<<<<<< HEAD
<<<<<<< HEAD
## DecimalDegrees

**Signature:** `DecimalDegrees`
=======
=======
>>>>>>> d66d5e94771075443ea96deaa1b24a052ee196d0
**Remarks:**
### DecimalDegrees

**Signature:** ``DecimalDegrees``
<<<<<<< HEAD
>>>>>>> initial docs folder changes
=======
>>>>>>> d66d5e94771075443ea96deaa1b24a052ee196d0

**Summary:**
Gets the unsigned degrees rounded to 10 decimal places.

<<<<<<< HEAD
<<<<<<< HEAD
## DecimalDegreesSigned

**Signature:** `DecimalDegreesSigned`
=======
=======
>>>>>>> d66d5e94771075443ea96deaa1b24a052ee196d0
**Remarks:**
### DecimalDegreesSigned

**Signature:** ``DecimalDegreesSigned``
<<<<<<< HEAD
>>>>>>> initial docs folder changes
=======
>>>>>>> d66d5e94771075443ea96deaa1b24a052ee196d0

**Summary:**
Gets the signed degrees rounded to 10 decimal places.

<<<<<<< HEAD
<<<<<<< HEAD
## DegreesSigned

**Signature:** `DegreesSigned`
=======
=======
>>>>>>> d66d5e94771075443ea96deaa1b24a052ee196d0
**Remarks:**
### DegreesSigned

**Signature:** ``DegreesSigned``
<<<<<<< HEAD
>>>>>>> initial docs folder changes
=======
>>>>>>> d66d5e94771075443ea96deaa1b24a052ee196d0

**Summary:**
Gets the signed degrees as an integer.

<<<<<<< HEAD
<<<<<<< HEAD
## Degrees

**Signature:** `Degrees`
=======
=======
>>>>>>> d66d5e94771075443ea96deaa1b24a052ee196d0
**Remarks:**
### Degrees

**Signature:** ``Degrees``
<<<<<<< HEAD
>>>>>>> initial docs folder changes
=======
>>>>>>> d66d5e94771075443ea96deaa1b24a052ee196d0

**Summary:**
Gets the unsigned degrees as an integer.

<<<<<<< HEAD
<<<<<<< HEAD
## DecimalMinutes

**Signature:** `DecimalMinutes`
=======
=======
>>>>>>> d66d5e94771075443ea96deaa1b24a052ee196d0
**Remarks:**
### DecimalMinutes

**Signature:** ``DecimalMinutes``
<<<<<<< HEAD
>>>>>>> initial docs folder changes
=======
>>>>>>> d66d5e94771075443ea96deaa1b24a052ee196d0

**Summary:**
Gets the minutes to 3 decimal places.

<<<<<<< HEAD
<<<<<<< HEAD
## Minutes

**Signature:** `Minutes`
=======
=======
>>>>>>> d66d5e94771075443ea96deaa1b24a052ee196d0
**Remarks:**
### Minutes

**Signature:** ``Minutes``
<<<<<<< HEAD
>>>>>>> initial docs folder changes
=======
>>>>>>> d66d5e94771075443ea96deaa1b24a052ee196d0

**Summary:**
Gets the minutes as an integer.

<<<<<<< HEAD
<<<<<<< HEAD
## Seconds

**Signature:** `Seconds`
=======
=======
>>>>>>> d66d5e94771075443ea96deaa1b24a052ee196d0
**Remarks:**
### Seconds

**Signature:** ``Seconds``
<<<<<<< HEAD
>>>>>>> initial docs folder changes
=======
>>>>>>> d66d5e94771075443ea96deaa1b24a052ee196d0

**Summary:**
Gets the seconds as an integer.

<<<<<<< HEAD
<<<<<<< HEAD
## Direction

**Signature:** `Direction`
=======
=======
>>>>>>> d66d5e94771075443ea96deaa1b24a052ee196d0
**Remarks:**
### Direction

**Signature:** ``Direction``
<<<<<<< HEAD
>>>>>>> initial docs folder changes
=======
>>>>>>> d66d5e94771075443ea96deaa1b24a052ee196d0

**Summary:**
Gets the cardinal direction of the coordinate.

<<<<<<< HEAD
<<<<<<< HEAD
## CoordinateType

**Signature:** `CoordinateType`
=======
=======
>>>>>>> d66d5e94771075443ea96deaa1b24a052ee196d0
**Remarks:**
### CoordinateType

**Signature:** ``CoordinateType``
<<<<<<< HEAD
>>>>>>> initial docs folder changes
=======
>>>>>>> d66d5e94771075443ea96deaa1b24a052ee196d0

**Summary:**
Gets the coordinate type (latitude or longitude).

<<<<<<< HEAD
<<<<<<< HEAD
## ValidationSpecification

**Signature:** `ValidationSpecification`

**Summary:**
Gets the validation specification for the coordinate.
=======
=======
>>>>>>> d66d5e94771075443ea96deaa1b24a052ee196d0
**Remarks:**
### ValidationSpecification

**Signature:** ``ValidationSpecification``

**Summary:**
Gets the validation specification for the coordinate.

<<<<<<< HEAD
**Remarks:**
>>>>>>> initial docs folder changes
=======
**Remarks:**
>>>>>>> d66d5e94771075443ea96deaa1b24a052ee196d0
