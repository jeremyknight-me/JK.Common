[Docs](../../README.md) > [JK.Common](../README.md) > DateTimeSpecification

# DateTimeSpecification

**Namespace:** `JK.Common.Specifications`

Specification to determine if a string is a valid date and time.

### IsSatisfiedBy

**Signature:** `IsSatisfiedBy(String candidate)`

**Summary:**
Determines whether the specified candidate string is a valid date and time.

**Parameters:**

- **candidate** — The string to evaluate as a date and time.

**Returns:** **true** if the candidate is not null or empty and can be parsed as a **DateTime** ; otherwise, **false** .