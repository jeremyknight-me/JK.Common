[Docs](../../README.md) > [JK.Common](../README.md) > Longitude

# Longitude

**Namespace:** `JK.Common.Geospatial`

Represents a longitude ("x" axis) coordinate.

## Longitude

**Summary:** Initializes a new instance of the **Longitude** class.

**Parameters:**

- **degrees** — The degrees component of the longitude.

## Longitude

**Summary:** Initializes a new instance of the **Longitude** class.

**Parameters:**

- **degrees** — The degrees component of the longitude.

- **minutes** — The minutes component of the longitude.

## Longitude

**Summary:** Initializes a new instance of the **Longitude** class.

**Parameters:**

- **degrees** — The degrees component of the longitude.

- **minutes** — The minutes component of the longitude.

- **seconds** — The seconds component of the longitude.

## Longitude

**Summary:** Initializes a new instance of the **Longitude** class with a direction.

**Parameters:**

- **degrees** — The degrees component of the longitude.

- **direction** — The cardinal direction of the longitude.

## Longitude

**Summary:** Initializes a new instance of the **Longitude** class with minutes and a direction.

**Parameters:**

- **degrees** — The degrees component of the longitude.

- **minutes** — The minutes component of the longitude.

- **direction** — The cardinal direction of the longitude.

## Longitude

**Summary:** Initializes a new instance of the **Longitude** class with minutes, seconds, and a direction.

**Parameters:**

- **degrees** — The degrees component of the longitude.

- **minutes** — The minutes component of the longitude.

- **seconds** — The seconds component of the longitude.

- **direction** — The cardinal direction of the longitude.

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