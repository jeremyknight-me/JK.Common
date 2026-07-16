[Docs](../../README.md) > [JK.Common](../README.md) > Latitude

# Latitude

**Namespace:** `JK.Common.Geospatial`

Represents a latitude ("y" axis) coordinate.

## Latitude

**Signature:** `Latitude(Decimal degrees)`

**Summary:**
Initializes a new instance of the **Latitude** class.

**Parameters:**

- **degrees** — The degrees component of the latitude.

## Latitude

**Signature:** `Latitude(Int32 degrees, Decimal minutes)`

**Summary:**
Initializes a new instance of the **Latitude** class.

**Parameters:**

- **degrees** — The degrees component of the latitude.

- **minutes** — The minutes component of the latitude.

## Latitude

**Signature:** `Latitude(Int32 degrees, Int32 minutes, Decimal seconds)`

**Summary:**
Initializes a new instance of the **Latitude** class.

**Parameters:**

- **degrees** — The degrees component of the latitude.

- **minutes** — The minutes component of the latitude.

- **seconds** — The seconds component of the latitude.

## Latitude

**Signature:** `Latitude(Decimal degrees, Direction direction)`

**Summary:**
Initializes a new instance of the **Latitude** class with a direction.

**Parameters:**

- **degrees** — The degrees component of the latitude.

- **direction** — The cardinal direction of the latitude.

## Latitude

**Signature:** `Latitude(Int32 degrees, Decimal minutes, Direction direction)`

**Summary:**
Initializes a new instance of the **Latitude** class with minutes and a direction.

**Parameters:**

- **degrees** — The degrees component of the latitude.

- **minutes** — The minutes component of the latitude.

- **direction** — The cardinal direction of the latitude.

## Latitude

**Signature:** `Latitude(Int32 degrees, Int32 minutes, Decimal seconds, Direction direction)`

**Summary:**
Initializes a new instance of the **Latitude** class with minutes, seconds, and a direction.

**Parameters:**

- **degrees** — The degrees component of the latitude.

- **minutes** — The minutes component of the latitude.

- **seconds** — The seconds component of the latitude.

- **direction** — The cardinal direction of the latitude.

## GetValidDirections

**Signature:** `GetValidDirections()`

## SetIsNegative

**Signature:** `SetIsNegative(Direction)`

## Direction

**Signature:** `Direction`

## CoordinateType

**Signature:** `CoordinateType`

## ValidationSpecification

**Signature:** `ValidationSpecification`