[Docs](../../README.md) > [JK.Common](../README.md) > Longitude

# Longitude

**Namespace:** `JK.Common.Geospatial`

Represents a longitude ("x" axis) coordinate.

### #ctor

**Signature:** ``#ctor(Decimal degrees)``

**Summary:**
Initializes a new instance of the **Longitude** class.

**Parameters:**
- **degrees** — The degrees component of the longitude.

**Remarks:**
### #ctor

**Signature:** ``#ctor(Int32 degrees, Decimal minutes)``

**Summary:**
Initializes a new instance of the **Longitude** class.

**Parameters:**
- **degrees** — The degrees component of the longitude.
- **minutes** — The minutes component of the longitude.

**Remarks:**
### #ctor

**Signature:** ``#ctor(Int32 degrees, Int32 minutes, Decimal seconds)``

**Summary:**
Initializes a new instance of the **Longitude** class.

**Parameters:**
- **degrees** — The degrees component of the longitude.
- **minutes** — The minutes component of the longitude.
- **seconds** — The seconds component of the longitude.

**Remarks:**
### #ctor

**Signature:** ``#ctor(Decimal degrees, Direction direction)``

**Summary:**
Initializes a new instance of the **Longitude** class with a direction.

**Parameters:**
- **degrees** — The degrees component of the longitude.
- **direction** — The cardinal direction of the longitude.

**Remarks:**
### #ctor

**Signature:** ``#ctor(Int32 degrees, Decimal minutes, Direction direction)``

**Summary:**
Initializes a new instance of the **Longitude** class with minutes and a direction.

**Parameters:**
- **degrees** — The degrees component of the longitude.
- **minutes** — The minutes component of the longitude.
- **direction** — The cardinal direction of the longitude.

**Remarks:**
### #ctor

**Signature:** ``#ctor(Int32 degrees, Int32 minutes, Decimal seconds, Direction direction)``

**Summary:**
Initializes a new instance of the **Longitude** class with minutes, seconds, and a direction.

**Parameters:**
- **degrees** — The degrees component of the longitude.
- **minutes** — The minutes component of the longitude.
- **seconds** — The seconds component of the longitude.
- **direction** — The cardinal direction of the longitude.

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