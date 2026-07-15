[Docs](../../README.md) > [JK.Common](../README.md) > NumericSpecification

# NumericSpecification

**Namespace:** `JK.Common.Specifications`

Specification to determine if a string represents a numeric value.

## IsSatisfiedBy

**Signature:** `IsSatisfiedBy(String candidate)`

**Summary:**
Determines whether the specified candidate string is a valid numeric value.

**Parameters:**

- **candidate** — The string to evaluate.

**Returns:** **true** if the candidate is not null, not whitespace, and can be parsed as a double; otherwise, **false** .