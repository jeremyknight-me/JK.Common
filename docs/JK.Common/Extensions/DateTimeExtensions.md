[Docs](../../README.md) > [JK.Common](../README.md) > DateTimeExtensions

# DateTimeExtensions

**Namespace:** `JK.Common.Extensions`

Extension methods for the DateTime object.

### AddWorkDays *(Inherited)*

**Signature:** ``AddWorkDays(DateTime, Int32@ days)``

**Summary:**
Adds given number of business days to a date.

**Parameters:**
- **days** — Number of days to add (can be negative).

**Returns:** The date the given amount of business days from the start date.

**Remarks:**
### IsBetween *(Inherited)*

**Signature:** ``IsBetween(DateTime, DateTime@ start, DateTime@ end)``

**Summary:**
Determines whether or not a given date is between (inclusive) the given start and end dates.

**Parameters:**
- **start** — Start of date range to check
- **end** — End of date range to check

**Returns:** True if date falls within range, otherwise false

**Remarks:**
### get_IsSqlDate *(Inherited)*

**Signature:** ``get_IsSqlDate(DateTime)``

**Summary:**
Determines whether or not a given date is valid to place in a SQL datetime column.

**Returns:** True if valid SQL date, otherwise false.

**Remarks:** The minimum date a 'datetime' date type in SQL can hold is January 1, 1753
### get_IsWeekday *(Inherited)*

**Signature:** ``get_IsWeekday(DateTime)``

**Summary:**
Determines if given date is a weekday.

**Returns:** True if is a weekday, otherwise false.

**Remarks:**
### get_IsWeekend *(Inherited)*

**Signature:** ``get_IsWeekend(DateTime)``

**Summary:**
Determines if given date is a weekday.

**Returns:** True if is a weekend, otherwise false.

**Remarks:**