[Docs](../../README.md) > [JK.Common](../README.md) > DateTimeExtensions

# DateTimeExtensions

**Namespace:** `JK.Common.Extensions`

Extension methods for the DateTime object.

<<<<<<< HEAD
## AddWorkDays *(Inherited)*

**Signature:** `AddWorkDays(DateTime, Int32 days)`
=======
### AddWorkDays *(Inherited)*

**Signature:** ``AddWorkDays(DateTime, Int32@ days)``
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

**Signature:** `IsBetween(DateTime, DateTime start, DateTime end)`
=======
**Remarks:**
### IsBetween *(Inherited)*

**Signature:** ``IsBetween(DateTime, DateTime@ start, DateTime@ end)``
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

**Signature:** ``get_IsSqlDate(DateTime)``
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

**Signature:** ``get_IsWeekday(DateTime)``
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

**Signature:** ``get_IsWeekend(DateTime)``
>>>>>>> initial docs folder changes

**Summary:**
Determines if given date is a weekday.

<<<<<<< HEAD
**Returns:** True if is a weekend, otherwise false.
=======
**Returns:** True if is a weekend, otherwise false.

**Remarks:**
>>>>>>> initial docs folder changes
