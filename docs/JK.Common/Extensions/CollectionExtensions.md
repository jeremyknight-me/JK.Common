[Docs](../../README.md) > [JK.Common](../README.md) > CollectionExtensions

# CollectionExtensions

**Namespace:** `JK.Common.Extensions`

Helper and utility extension methods for **ICollection&lt;T&gt;** and **IReadOnlyCollection&lt;T&gt;**.

## AddIfNotNull *(Inherited)*

**Signature:** `AddIfNotNull<T>(ICollection<T>, T)`

**Summary:**
Adds the specified item to the collection if the item is not **null**.

**Parameters:**

- **item** — The item to add to the collection.

## AddRangeIfNotNull *(Inherited)*

**Signature:** `AddRangeIfNotNull<T>(ICollection<T>, IEnumerable<T>)`

**Summary:**
Adds the specified items to the collection if they are not **null**.

**Parameters:**

- **items** — The items to add to the collection.

**Remarks:** Each item in **items** will be checked for **null** before being added.

## HasItems *(Inherited)*

**Signature:** `HasItems`

**Summary:**
Determines whether the collection has any items.

**Returns:** **true** if the collection has items; otherwise, **false**.

## HasItems *(Inherited)*

**Signature:** `HasItems`

**Summary:**
Determines whether the read-only collection has any items.

**Returns:** **true** if the collection has items; otherwise, **false**.