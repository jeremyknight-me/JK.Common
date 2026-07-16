[Docs](../../README.md) > [JK.Common](../README.md) > LatitudeSpecification

# LatitudeSpecification

**Namespace:** `JK.Common.Specifications`

Specification to determine if a decimal value is a valid latitude.

## IsSatisfiedBy

**Signature:** `IsSatisfiedBy(Decimal candidate)`

**Summary:**
Determines whether the specified candidate value is a valid latitude.

**Parameters:**

- **candidate** — The latitude value to evaluate.

**Returns:** **true** if the candidate is between -90 and 90 (inclusive); otherwise, **false**.