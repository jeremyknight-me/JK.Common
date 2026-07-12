[Docs](../../README.md) > [JK.Common](../README.md) > Latitude

# Latitude

**Namespace:** `JK.Common.Geospatial`

Represents a latitude ("y" axis) coordinate.

<<<<<<< HEAD
## Latitude

**Summary:** Initializes a new instance of the **Latitude** class.

**Parameters:**

- **degrees** — The degrees component of the latitude.

## Latitude

**Summary:** Initializes a new instance of the **Latitude** class.

**Parameters:**

- **degrees** — The degrees component of the latitude.

- **minutes** — The minutes component of the latitude.

## Latitude

**Summary:** Initializes a new instance of the **Latitude** class.

**Parameters:**

- **degrees** — The degrees component of the latitude.

- **minutes** — The minutes component of the latitude.

- **seconds** — The seconds component of the latitude.

## Latitude

**Summary:** Initializes a new instance of the **Latitude** class with a direction.

**Parameters:**

- **degrees** — The degrees component of the latitude.

- **direction** — The cardinal direction of the latitude.

## Latitude

**Summary:** Initializes a new instance of the **Latitude** class with minutes and a direction.

**Parameters:**

- **degrees** — The degrees component of the latitude.

- **minutes** — The minutes component of the latitude.

- **direction** — The cardinal direction of the latitude.

## Latitude

**Summary:** Initializes a new instance of the **Latitude** class with minutes, seconds, and a direction.

**Parameters:**

- **degrees** — The degrees component of the latitude.

- **minutes** — The minutes component of the latitude.

- **seconds** — The seconds component of the latitude.

- **direction** — The cardinal direction of the latitude.

## GetValidDirections *(Inherited)*

**Signature:** `GetValidDirections()`

**Summary:**
Gets the valid directions for the coordinate type.

**Returns:** A collection of valid directions.

## SetIsNegative *(Inherited)*

**Signature:** `SetIsNegative(Direction direction)`

**Summary:**
Sets whether the coordinate is negative based on the direction.

**Parameters:**

- **direction** — The direction to evaluate.

## Direction *(Inherited)*

**Signature:** `Direction`

**Summary:**
Gets the cardinal direction of the coordinate.

## CoordinateType *(Inherited)*

**Signature:** `CoordinateType`

**Summary:**
Gets the coordinate type (latitude or longitude).

## ValidationSpecification *(Inherited)*

**Signature:** `ValidationSpecification`

**Summary:**
Gets the validation specification for the coordinate.
=======
### #ctor

**Signature:** ``#ctor(Decimal degrees)``

**Summary:**
Initializes a new instance of the **Latitude** class.

**Parameters:**
- **degrees** — The degrees component of the latitude.

**Remarks:**
### #ctor

**Signature:** ``#ctor(Int32 degrees, Decimal minutes)``

**Summary:**
Initializes a new instance of the **Latitude** class.

**Parameters:**
- **degrees** — The degrees component of the latitude.
- **minutes** — The minutes component of the latitude.

**Remarks:**
### #ctor

**Signature:** ``#ctor(Int32 degrees, Int32 minutes, Decimal seconds)``

**Summary:**
Initializes a new instance of the **Latitude** class.

**Parameters:**
- **degrees** — The degrees component of the latitude.
- **minutes** — The minutes component of the latitude.
- **seconds** — The seconds component of the latitude.

**Remarks:**
### #ctor

**Signature:** ``#ctor(Decimal degrees, Direction direction)``

**Summary:**
Initializes a new instance of the **Latitude** class with a direction.

**Parameters:**
- **degrees** — The degrees component of the latitude.
- **direction** — The cardinal direction of the latitude.

**Remarks:**
### #ctor

**Signature:** ``#ctor(Int32 degrees, Decimal minutes, Direction direction)``

**Summary:**
Initializes a new instance of the **Latitude** class with minutes and a direction.

**Parameters:**
- **degrees** — The degrees component of the latitude.
- **minutes** — The minutes component of the latitude.
- **direction** — The cardinal direction of the latitude.

**Remarks:**
### #ctor

**Signature:** ``#ctor(Int32 degrees, Int32 minutes, Decimal seconds, Direction direction)``

**Summary:**
Initializes a new instance of the **Latitude** class with minutes, seconds, and a direction.

**Parameters:**
- **degrees** — The degrees component of the latitude.
- **minutes** — The minutes component of the latitude.
- **seconds** — The seconds component of the latitude.
- **direction** — The cardinal direction of the latitude.

**Remarks:**
### GetValidDirections *(Inherited)*

**Signature:** ``GetValidDirections()``

**Summary:**

**Remarks:**
### SetIsNegative *(Inherited)*

**Signature:** ``SetIsNegative(Direction@)``

**Summary:**

**Remarks:**

### Direction *(Inherited)*

**Signature:** ``Direction``

**Summary:**

**Remarks:**
### CoordinateType *(Inherited)*

**Signature:** ``CoordinateType``

**Summary:**

**Remarks:**
### ValidationSpecification *(Inherited)*

**Signature:** ``ValidationSpecification``

**Summary:**

**Remarks:**
>>>>>>> initial docs folder changes
