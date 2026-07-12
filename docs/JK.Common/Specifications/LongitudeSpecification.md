[Docs](../../README.md) > [JK.Common](../README.md) > LongitudeSpecification

# LongitudeSpecification

**Namespace:** `JK.Common.Specifications`

Specification to determine if a decimal value is a valid longitude.

### IsSatisfiedBy

**Signature:** ``IsSatisfiedBy(Decimal@ candidate)``

**Summary:**
Determines whether the specified candidate value is a valid longitude.

**Parameters:**
- **candidate** — The longitude value to evaluate.

**Returns:** **true** if the candidate is between -180 and 180 (inclusive); otherwise, **false** .

**Remarks:**