[Docs](../../README.md) > [JK.Common](../README.md) > DateTimeOffsetFactory

# DateTimeOffsetFactory

**Namespace:** `JK.Common.TypeHelpers`

Provides factory methods for creating **DateTimeOffset** instances with specific time zones.

### Make

**Signature:** `Make(DateTime date, String timeZoneId)`

**Summary:**
Creates a **DateTimeOffset** from a **DateTime** and a time zone ID.

**Parameters:**

- **date** — The date and time to use.

- **timeZoneId** — The time zone identifier (e.g., "Central Standard Time").

**Returns:** A **DateTimeOffset** representing the specified date and time in the given time zone.

### Make

**Signature:** `Make(Int32 year, Int32 month, Int32 day, String timeZoneId)`

**Summary:**
Creates a **DateTimeOffset** from year, month, day, and a time zone ID.

**Parameters:**

- **year** — The year component.

- **month** — The month component.

- **day** — The day component.

- **timeZoneId** — The time zone identifier (e.g., "Central Standard Time").

**Returns:** A **DateTimeOffset** representing the specified date in the given time zone.

### Make

**Signature:** `Make(Int32 year, Int32 month, Int32 day, Int32 hour, Int32 minute, Int32 second, String timeZoneId)`

**Summary:**
Creates a **DateTimeOffset** from year, month, day, hour, minute, second, and a time zone ID.

**Parameters:**

- **year** — The year component.

- **month** — The month component.

- **day** — The day component.

- **hour** — The hour component.

- **minute** — The minute component.

- **second** — The second component.

- **timeZoneId** — The time zone identifier (e.g., "Central Standard Time").

**Returns:** A **DateTimeOffset** representing the specified date and time in the given time zone.