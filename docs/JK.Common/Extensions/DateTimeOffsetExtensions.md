[Docs](../../README.md) > [JK.Common](../README.md) > DateTimeOffsetExtensions

# DateTimeOffsetExtensions

**Namespace:** `JK.Common.Extensions`

Extension methods for the DateTimeOffset object.

## AddWorkDays

**Signature:** `AddWorkDays(DateTimeOffset, Int32)`

**Summary:**
Adds given number of business days to a date.

**Parameters:**

- **days** — Number of days to add (can be negative).

**Returns:** The date the given amount of business days from the start date.

## IsBetween

**Signature:** `IsBetween(DateTimeOffset, DateTimeOffset, DateTimeOffset)`

**Summary:**
Determines whether or not a given date is between (inclusive) the given start and end dates.

**Parameters:**

- **start** — Start of date range to check

- **end** — End of date range to check

**Returns:** True if date falls within range, otherwise false

## IsWeekday

**Signature:** `IsWeekday`

**Summary:**
Determines if given date is a weekday.

**Returns:** True if is a weekday, otherwise false.

## IsWeekend

**Signature:** `IsWeekend`

**Summary:**
Determines if given date is a weekend.

**Returns:** True if is a weekend, otherwise false.