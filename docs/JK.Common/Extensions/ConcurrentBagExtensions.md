[Docs](../../README.md) > [JK.Common](../README.md) > ConcurrentBagExtensions

# ConcurrentBagExtensions

**Namespace:** `JK.Common.Extensions`

Helper and utility extension methods for **ConcurrentBag** .

### AddRange` *(Inherited)*

**Signature:** ``AddRange`(ConcurrentBag{``0}, IEnumerable{``0}@ list)``

**Summary:**
Adds a range of items to the **ConcurrentBag** .

**Parameters:**
- **list** — The items to add.

**Remarks:**
### AddRangeIfNotNull` *(Inherited)*

**Signature:** ``AddRangeIfNotNull`(ConcurrentBag{``0}, IEnumerable{``0} items)``

**Summary:**
Adds the specified items to the collection if they are not **null** .

**Parameters:**
- **items** — The items to add to the collection.

**Remarks:** Each item in **items** will be checked for **null** before being added.