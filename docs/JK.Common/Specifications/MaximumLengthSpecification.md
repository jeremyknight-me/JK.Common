[Docs](../../README.md) > [JK.Common](../README.md) > MaximumLengthSpecification

# MaximumLengthSpecification

**Namespace:** `JK.Common.Specifications`

Specification to determine if a string's length does not exceed a maximum value.

## MaximumLengthSpecification

**Signature:** `MaximumLengthSpecification(Int32 maximumLengthToUse)`

**Summary:**
Initializes a new instance of the **MaximumLengthSpecification** class.

**Parameters:**

- **maximumLengthToUse** — The maximum allowed length for the string.

## IsSatisfiedBy

**Signature:** `IsSatisfiedBy(String candidate)`

**Summary:**
Determines whether the specified candidate string's length is less than or equal to the maximum length.

**Parameters:**

- **candidate** — The string to evaluate.

**Returns:** **true** if the candidate's length is less than or equal to **MaximumLength**; otherwise, **false**.

## MaximumLength

**Signature:** `MaximumLength`

**Summary:**
Gets the maximum allowed length for the string.