[Docs](../../README.md) > [JK.Common](../README.md) > ConcurrentBagExtensions

# ConcurrentBagExtensions

**Namespace:** `JK.Common.Extensions`

<<<<<<< HEAD
Helper and utility extension methods for **ConcurrentBag&lt;T&gt;** .

## AddRange *(Inherited)*

**Signature:** `AddRange<T>(ConcurrentBag<T>, IEnumerable<T> list)`

**Summary:**
Adds a range of items to the **ConcurrentBag&lt;T&gt;** .

**Parameters:**

- **list** — The items to add.

## AddRangeIfNotNull *(Inherited)*

**Signature:** `AddRangeIfNotNull<T>(ConcurrentBag<T>, IEnumerable<T> items)`
=======
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
>>>>>>> initial docs folder changes

**Summary:**
Adds the specified items to the collection if they are not **null** .

**Parameters:**
<<<<<<< HEAD

=======
>>>>>>> initial docs folder changes
- **items** — The items to add to the collection.

**Remarks:** Each item in **items** will be checked for **null** before being added.