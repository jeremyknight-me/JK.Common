[Docs](../../README.md) > [JK.Common](../README.md) > DateOnlyExtensions

# DateOnlyExtensions

**Namespace:** `JK.Common.Extensions`

Helper and utility extension methods for **DateOnly** .

<<<<<<< HEAD
<<<<<<< HEAD
## op_Subtraction *(Inherited)*

**Signature:** `op_Subtraction(DateOnly left, DateOnly right)`
=======
### op_Subtraction *(Inherited)*

**Signature:** ``op_Subtraction(DateOnly left, DateOnly right)``
>>>>>>> initial docs folder changes
=======
### op_Subtraction *(Inherited)*

**Signature:** ``op_Subtraction(DateOnly left, DateOnly right)``
>>>>>>> d66d5e94771075443ea96deaa1b24a052ee196d0

**Summary:**
Calculates the number of days between two DateOnly instances.

**Parameters:**
<<<<<<< HEAD
<<<<<<< HEAD

- **left** — The first date in the subtraction operation.

=======
- **left** — The first date in the subtraction operation.
>>>>>>> initial docs folder changes
=======
- **left** — The first date in the subtraction operation.
>>>>>>> d66d5e94771075443ea96deaa1b24a052ee196d0
- **right** — The date to subtract from the left operand.

**Returns:** The number of days between the left and right dates. The result is positive if the left
            date is later than the right date, negative if earlier, or zero if they are the same.

**Remarks:** This operator enables direct subtraction of two DateOnly values to determine the
            interval in days.
<<<<<<< HEAD
<<<<<<< HEAD

## AddWorkDays *(Inherited)*

**Signature:** `AddWorkDays(DateOnly, Int32 days)`
=======
### AddWorkDays *(Inherited)*

**Signature:** ``AddWorkDays(DateOnly, Int32@ days)``
>>>>>>> initial docs folder changes
=======
### AddWorkDays *(Inherited)*

**Signature:** ``AddWorkDays(DateOnly, Int32@ days)``
>>>>>>> d66d5e94771075443ea96deaa1b24a052ee196d0

**Summary:**
Adds given number of business days to a date.

**Parameters:**
<<<<<<< HEAD
<<<<<<< HEAD

=======
>>>>>>> initial docs folder changes
=======
>>>>>>> d66d5e94771075443ea96deaa1b24a052ee196d0
- **days** — Number of days to add (can be negative).

**Returns:** The date the given amount of business days from the start date.

<<<<<<< HEAD
<<<<<<< HEAD
## IsBetween *(Inherited)*

**Signature:** `IsBetween(DateOnly, DateOnly start, DateOnly end)`
=======
=======
>>>>>>> d66d5e94771075443ea96deaa1b24a052ee196d0
**Remarks:**
### IsBetween *(Inherited)*

**Signature:** ``IsBetween(DateOnly, DateOnly@ start, DateOnly@ end)``
<<<<<<< HEAD
>>>>>>> initial docs folder changes
=======
>>>>>>> d66d5e94771075443ea96deaa1b24a052ee196d0

**Summary:**
Determines whether or not a given date is between (inclusive) the given start and end dates.

**Parameters:**
<<<<<<< HEAD
<<<<<<< HEAD

- **start** — Start of date range to check

=======
- **start** — Start of date range to check
>>>>>>> initial docs folder changes
=======
- **start** — Start of date range to check
>>>>>>> d66d5e94771075443ea96deaa1b24a052ee196d0
- **end** — End of date range to check

**Returns:** True if date falls within range, otherwise false

<<<<<<< HEAD
<<<<<<< HEAD
## IsSqlDate *(Inherited)*

**Signature:** `IsSqlDate`
=======
=======
>>>>>>> d66d5e94771075443ea96deaa1b24a052ee196d0
**Remarks:**
### get_IsSqlDate *(Inherited)*

**Signature:** ``get_IsSqlDate(DateOnly)``
<<<<<<< HEAD
>>>>>>> initial docs folder changes
=======
>>>>>>> d66d5e94771075443ea96deaa1b24a052ee196d0

**Summary:**
Determines whether or not a given date is valid to place in a SQL datetime column.

**Returns:** True if valid SQL date, otherwise false.

**Remarks:** The minimum date a 'datetime' date type in SQL can hold is January 1, 1753
<<<<<<< HEAD
<<<<<<< HEAD

## IsWeekday *(Inherited)*

**Signature:** `IsWeekday`
=======
### get_IsWeekday *(Inherited)*

**Signature:** ``get_IsWeekday(DateOnly)``
>>>>>>> initial docs folder changes
=======
### get_IsWeekday *(Inherited)*

**Signature:** ``get_IsWeekday(DateOnly)``
>>>>>>> d66d5e94771075443ea96deaa1b24a052ee196d0

**Summary:**
Determines if given date is a weekday.

**Returns:** True if is a weekday, otherwise false.

<<<<<<< HEAD
<<<<<<< HEAD
## IsWeekend *(Inherited)*

**Signature:** `IsWeekend`
=======
=======
>>>>>>> d66d5e94771075443ea96deaa1b24a052ee196d0
**Remarks:**
### get_IsWeekend *(Inherited)*

**Signature:** ``get_IsWeekend(DateOnly)``
<<<<<<< HEAD
>>>>>>> initial docs folder changes
=======
>>>>>>> d66d5e94771075443ea96deaa1b24a052ee196d0

**Summary:**
Determines if given date is a weekday.

<<<<<<< HEAD
<<<<<<< HEAD
**Returns:** True if is a weekend, otherwise false.
=======
**Returns:** True if is a weekend, otherwise false.

**Remarks:**
>>>>>>> initial docs folder changes
=======
**Returns:** True if is a weekend, otherwise false.

**Remarks:**
>>>>>>> d66d5e94771075443ea96deaa1b24a052ee196d0
