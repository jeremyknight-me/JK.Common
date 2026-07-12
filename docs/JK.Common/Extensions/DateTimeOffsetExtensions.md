[Docs](../../README.md) > [JK.Common](../README.md) > DateTimeOffsetExtensions

# DateTimeOffsetExtensions

**Namespace:** `JK.Common.Extensions`

Extension methods for the DateTimeOffset object.

### AddWorkDays *(Inherited)*

**Signature:** ``AddWorkDays(DateTimeOffset, Int32@ days)``

**Summary:**
Adds given number of business days to a date.

**Parameters:**
- **days** — Number of days to add (can be negative).

**Returns:** The date the given amount of business days from the start date.

**Remarks:**
### IsBetween *(Inherited)*

**Signature:** ``IsBetween(DateTimeOffset, DateTimeOffset@ start, DateTimeOffset@ end)``

**Summary:**
Determines whether or not a given date is between (inclusive) the given start and end dates.

**Parameters:**
- **start** — Start of date range to check
- **end** — End of date range to check

**Returns:** True if date falls within range, otherwise false

**Remarks:**
### get_IsWeekday *(Inherited)*

**Signature:** ``get_IsWeekday(DateTimeOffset)``

**Summary:**
Determines if given date is a weekday.

**Returns:** True if is a weekday, otherwise false.

**Remarks:**
### get_IsWeekend *(Inherited)*

**Signature:** ``get_IsWeekend(DateTimeOffset)``

**Summary:**
Determines if given date is a weekday.

**Returns:** True if is a weekend, otherwise false.

**Remarks:**