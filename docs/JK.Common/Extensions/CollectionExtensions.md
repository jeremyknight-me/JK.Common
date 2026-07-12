[Docs](../../README.md) > [JK.Common](../README.md) > CollectionExtensions

# CollectionExtensions

**Namespace:** `JK.Common.Extensions`

<<<<<<< HEAD
Helper and utility extension methods for **ICollection&lt;T&gt;** and **IReadOnlyCollection&lt;T&gt;** .

## AddIfNotNull *(Inherited)*

**Signature:** `AddIfNotNull<T>(ICollection<T>, T item)`
=======
Helper and utility extension methods for **ICollection** and **IReadOnlyCollection** .

### AddIfNotNull` *(Inherited)*

**Signature:** ``AddIfNotNull`(ICollection{``0}, ``0 item)``
>>>>>>> initial docs folder changes

**Summary:**
Adds the specified item to the collection if the item is not **null** .

**Parameters:**
<<<<<<< HEAD

- **item** — The item to add to the collection.

## AddRangeIfNotNull *(Inherited)*

**Signature:** `AddRangeIfNotNull<T>(ICollection<T>, IEnumerable<T> items)`
=======
- **item** — The item to add to the collection.

**Remarks:**
### AddRangeIfNotNull` *(Inherited)*

**Signature:** ``AddRangeIfNotNull`(ICollection{``0}, IEnumerable{``0} items)``
>>>>>>> initial docs folder changes

**Summary:**
Adds the specified items to the collection if they are not **null** .

**Parameters:**
<<<<<<< HEAD

- **items** — The items to add to the collection.

**Remarks:** Each item in **items** will be checked for **null** before being added.

## HasItems *(Inherited)*

**Signature:** `HasItems`
=======
- **items** — The items to add to the collection.

**Remarks:** Each item in **items** will be checked for **null** before being added.
### get_HasItems` *(Inherited)*

**Signature:** ``get_HasItems`(ICollection{``0})``
>>>>>>> initial docs folder changes

**Summary:**
Determines whether the collection has any items.

**Returns:** **true** if the collection has items; otherwise, **false** .

<<<<<<< HEAD
## HasItems *(Inherited)*

**Signature:** `HasItems`
=======
**Remarks:**
### get_HasItems` *(Inherited)*

**Signature:** ``get_HasItems`(IReadOnlyCollection{``0})``
>>>>>>> initial docs folder changes

**Summary:**
Determines whether the read-only collection has any items.

<<<<<<< HEAD
**Returns:** **true** if the collection has items; otherwise, **false** .
=======
**Returns:** **true** if the collection has items; otherwise, **false** .

**Remarks:**
>>>>>>> initial docs folder changes
