[Docs](../../README.md) > [JK.Common](../README.md) > ConcurrentBagExtensions

# ConcurrentBagExtensions

**Namespace:** `JK.Common.Extensions`

Helper and utility extension methods for **`ConcurrentBag<T>`**.

## AddRange

**Signature:** `AddRange<T>(ConcurrentBag<T>, IEnumerable<T>)`

**Summary:**
Adds a range of items to the **`ConcurrentBag<T>`**.

**Parameters:**

- **list** — The items to add.

## AddRangeIfNotNull

**Signature:** `AddRangeIfNotNull<T>(ConcurrentBag<T>, IEnumerable<T>)`

**Summary:**
Adds the specified items to the collection if they are not **null**.

**Parameters:**

- **items** — The items to add to the collection.

**Remarks:** Each item in **items** will be checked for **null** before being added.