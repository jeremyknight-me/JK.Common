[Docs](../../README.md) > [JK.Common](../README.md) > SqlDateSpecification

# SqlDateSpecification

**Namespace:** `JK.Common.Specifications`

Specification that determines if a **DateTime** value is valid for a SQL 'datetime' column (year >= 1753).

### IsSatisfiedBy

**Signature:** `IsSatisfiedBy(DateTime candidate)`

**Summary:**
Determines whether the specified **DateTime** is valid for a SQL 'datetime' column (year >= 1753).

**Parameters:**

- **candidate** — The date to evaluate.

**Returns:** **true** if the date is valid for SQL; otherwise, **false** .