[Docs](../../README.md) > [JK.Common](../README.md) > WeekdaySpecification

# WeekdaySpecification

**Namespace:** `JK.Common.Specifications`

Specification that determines if a **DateTime** value falls on a weekday (Monday through Friday).

## IsSatisfiedBy

**Signature:** `IsSatisfiedBy(DateTime candidate)`

**Summary:**
Determines whether the specified **DateTime** is a weekday (not Saturday or Sunday).

**Parameters:**

- **candidate** — The date to evaluate.

**Returns:** **true** if the date is a weekday; otherwise, **false**.