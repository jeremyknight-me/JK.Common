[Docs](../../README.md) > [JK.Common](../README.md) > IDateTimeProvider

# IDateTimeProvider

**Namespace:** `JK.Common.DateTimeProviders`

Abstraction to disconnect **DateTime** from the system clock.

## Now

**Signature:** `Now`

**Summary:**
Returns a **DateTime** representing the current date and time.

## Today

**Signature:** `Today`

**Summary:**
Returns a Dat **DateTime** eTime representing the current date. The date part
            of the returned value is the current date, and the time-of-day part of
            the returned value is zero (midnight).

## UtcNow

**Signature:** `UtcNow`

**Summary:**
Returns a **DateTime** representing the current UTC date and time.