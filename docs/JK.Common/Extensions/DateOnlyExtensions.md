[Docs](../../README.md) > [JK.Common](../README.md) > DateOnlyExtensions

# DateOnlyExtensions

**Namespace:** `JK.Common.Extensions`

Helper and utility extension methods for **DateOnly** .

<<<<<<< HEAD
## op_Subtraction *(Inherited)*

**Signature:** `op_Subtraction(DateOnly left, DateOnly right)`
=======
### op_Subtraction *(Inherited)*

**Signature:** ``op_Subtraction(DateOnly left, DateOnly right)``
>>>>>>> initial docs folder changes

**Summary:**
Calculates the number of days between two DateOnly instances.

**Parameters:**
<<<<<<< HEAD

- **left** — The first date in the subtraction operation.

=======
- **left** — The first date in the subtraction operation.
>>>>>>> initial docs folder changes
- **right** — The date to subtract from the left operand.

**Returns:** The number of days between the left and right dates. The result is positive if the left
            date is later than the right date, negative if earlier, or zero if they are the same.

**Remarks:** This operator enables direct subtraction of two DateOnly values to determine the
            interval in days.
<<<<<<< HEAD

## AddWorkDays *(Inherited)*

**Signature:** `AddWorkDays(DateOnly, Int32 days)`
=======
### AddWorkDays *(Inherited)*

**Signature:** ``AddWorkDays(DateOnly, Int32@ days)``
>>>>>>> initial docs folder changes

**Summary:**
Adds given number of business days to a date.

**Parameters:**
<<<<<<< HEAD

=======
>>>>>>> initial docs folder changes
- **days** — Number of days to add (can be negative).

**Returns:** The date the given amount of business days from the start date.

<<<<<<< HEAD
## IsBetween *(Inherited)*

**Signature:** `IsBetween(DateOnly, DateOnly start, DateOnly end)`
=======
**Remarks:**
### IsBetween *(Inherited)*

**Signature:** ``IsBetween(DateOnly, DateOnly@ start, DateOnly@ end)``
>>>>>>> initial docs folder changes

**Summary:**
Determines whether or not a given date is between (inclusive) the given start and end dates.

**Parameters:**
<<<<<<< HEAD

- **start** — Start of date range to check

=======
- **start** — Start of date range to check
>>>>>>> initial docs folder changes
- **end** — End of date range to check

**Returns:** True if date falls within range, otherwise false

<<<<<<< HEAD
## IsSqlDate *(Inherited)*

**Signature:** `IsSqlDate`
=======
**Remarks:**
### get_IsSqlDate *(Inherited)*

**Signature:** ``get_IsSqlDate(DateOnly)``
>>>>>>> initial docs folder changes

**Summary:**
Determines whether or not a given date is valid to place in a SQL datetime column.

**Returns:** True if valid SQL date, otherwise false.

**Remarks:** The minimum date a 'datetime' date type in SQL can hold is January 1, 1753
<<<<<<< HEAD

## IsWeekday *(Inherited)*

**Signature:** `IsWeekday`
=======
### get_IsWeekday *(Inherited)*

**Signature:** ``get_IsWeekday(DateOnly)``
>>>>>>> initial docs folder changes

**Summary:**
Determines if given date is a weekday.

**Returns:** True if is a weekday, otherwise false.

<<<<<<< HEAD
## IsWeekend *(Inherited)*

**Signature:** `IsWeekend`
=======
**Remarks:**
### get_IsWeekend *(Inherited)*

**Signature:** ``get_IsWeekend(DateOnly)``
>>>>>>> initial docs folder changes

**Summary:**
Determines if given date is a weekday.

<<<<<<< HEAD
**Returns:** True if is a weekend, otherwise false.
=======
**Returns:** True if is a weekend, otherwise false.

**Remarks:**
>>>>>>> initial docs folder changes
