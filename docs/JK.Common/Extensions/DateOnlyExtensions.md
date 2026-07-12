[Docs](../../README.md) > [JK.Common](../README.md) > DateOnlyExtensions

# DateOnlyExtensions

**Namespace:** `JK.Common.Extensions`

Helper and utility extension methods for **DateOnly** .

### op_Subtraction *(Inherited)*

**Signature:** ``op_Subtraction(DateOnly left, DateOnly right)``

**Summary:**
Calculates the number of days between two DateOnly instances.

**Parameters:**
- **left** — The first date in the subtraction operation.
- **right** — The date to subtract from the left operand.

**Returns:** The number of days between the left and right dates. The result is positive if the left
            date is later than the right date, negative if earlier, or zero if they are the same.

**Remarks:** This operator enables direct subtraction of two DateOnly values to determine the
            interval in days.
### AddWorkDays *(Inherited)*

**Signature:** ``AddWorkDays(DateOnly, Int32@ days)``

**Summary:**
Adds given number of business days to a date.

**Parameters:**
- **days** — Number of days to add (can be negative).

**Returns:** The date the given amount of business days from the start date.

**Remarks:**
### IsBetween *(Inherited)*

**Signature:** ``IsBetween(DateOnly, DateOnly@ start, DateOnly@ end)``

**Summary:**
Determines whether or not a given date is between (inclusive) the given start and end dates.

**Parameters:**
- **start** — Start of date range to check
- **end** — End of date range to check

**Returns:** True if date falls within range, otherwise false

**Remarks:**
### get_IsSqlDate *(Inherited)*

**Signature:** ``get_IsSqlDate(DateOnly)``

**Summary:**
Determines whether or not a given date is valid to place in a SQL datetime column.

**Returns:** True if valid SQL date, otherwise false.

**Remarks:** The minimum date a 'datetime' date type in SQL can hold is January 1, 1753
### get_IsWeekday *(Inherited)*

**Signature:** ``get_IsWeekday(DateOnly)``

**Summary:**
Determines if given date is a weekday.

**Returns:** True if is a weekday, otherwise false.

**Remarks:**
### get_IsWeekend *(Inherited)*

**Signature:** ``get_IsWeekend(DateOnly)``

**Summary:**
Determines if given date is a weekday.

**Returns:** True if is a weekend, otherwise false.

**Remarks:**