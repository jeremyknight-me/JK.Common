[Docs](../../README.md) > [JK.Common](../README.md) > DateTimeExtensions

# DateTimeExtensions

**Namespace:** `JK.Common.Extensions`

Extension methods for the DateTime object.

## AddWorkDays *(Inherited)*

**Signature:** `AddWorkDays(DateTime, Int32)`

**Summary:**
Adds given number of business days to a date.

**Parameters:**

- **days** — Number of days to add (can be negative).

**Returns:** The date the given amount of business days from the start date.

## IsBetween *(Inherited)*

**Signature:** `IsBetween(DateTime, DateTime, DateTime)`

**Summary:**
Determines whether or not a given date is between (inclusive) the given start and end dates.

**Parameters:**

- **start** — Start of date range to check

- **end** — End of date range to check

**Returns:** True if date falls within range, otherwise false

## IsSqlDate *(Inherited)*

**Signature:** `IsSqlDate`

**Summary:**
Determines whether or not a given date is valid to place in a SQL datetime column.

**Returns:** True if valid SQL date, otherwise false.

**Remarks:** The minimum date a 'datetime' date type in SQL can hold is January 1, 1753

## IsWeekday *(Inherited)*

**Signature:** `IsWeekday`

**Summary:**
Determines if given date is a weekday.

**Returns:** True if is a weekday, otherwise false.

## IsWeekend *(Inherited)*

**Signature:** `IsWeekend`

**Summary:**
Determines if given date is a weekday.

**Returns:** True if is a weekend, otherwise false.