[Docs](../../README.md) > [JK.Common](../README.md) > ConcurrentBagExtensions

# ConcurrentBagExtensions

**Namespace:** `JK.Common.Extensions`

Helper and utility extension methods for **ConcurrentBag** .

### AddRange *(Inherited)*

**Signature:** `AddRange(ConcurrentBag<T>, IEnumerable<T> list)`

**Summary:**
Adds a range of items to the **ConcurrentBag`1** .

**Parameters:**

- **list** — The items to add.

### AddRangeIfNotNull *(Inherited)*

**Signature:** `AddRangeIfNotNull(ConcurrentBag<T>, IEnumerable<T> items)`

**Summary:**
Adds the specified items to the collection if they are not **null** .

**Parameters:**

- **items** — The items to add to the collection.

**Remarks:** Each item in **items** will be checked for **null** before being added.