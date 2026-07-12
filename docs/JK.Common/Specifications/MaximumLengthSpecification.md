[Docs](../../README.md) > [JK.Common](../README.md) > MaximumLengthSpecification

# MaximumLengthSpecification

**Namespace:** `JK.Common.Specifications`

Specification to determine if a string's length does not exceed a maximum value.

<<<<<<< HEAD
## MaximumLengthSpecification

**Summary:** Initializes a new instance of the **MaximumLengthSpecification** class.

**Parameters:**

- **maximumLengthToUse** — The maximum allowed length for the string.

## IsSatisfiedBy

**Signature:** `IsSatisfiedBy(String candidate)`
=======
### #ctor

**Signature:** ``#ctor(Int32 maximumLengthToUse)``

**Summary:**
Initializes a new instance of the **MaximumLengthSpecification** class.

**Parameters:**
- **maximumLengthToUse** — The maximum allowed length for the string.

**Remarks:**
### IsSatisfiedBy

**Signature:** ``IsSatisfiedBy(String@ candidate)``
>>>>>>> initial docs folder changes

**Summary:**
Determines whether the specified candidate string's length is less than or equal to the maximum length.

**Parameters:**
<<<<<<< HEAD

=======
>>>>>>> initial docs folder changes
- **candidate** — The string to evaluate.

**Returns:** **true** if the candidate's length is less than or equal to **MaximumLength** ; otherwise, **false** .

<<<<<<< HEAD
## MaximumLength

**Signature:** `MaximumLength`

**Summary:**
Gets the maximum allowed length for the string.
=======
**Remarks:**

### MaximumLength

**Signature:** ``MaximumLength``

**Summary:**
Gets the maximum allowed length for the string.

**Remarks:**
>>>>>>> initial docs folder changes
