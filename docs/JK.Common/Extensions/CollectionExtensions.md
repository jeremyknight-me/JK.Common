[Docs](../../README.md) > [JK.Common](../README.md) > CollectionExtensions

# CollectionExtensions

**Namespace:** `JK.Common.Extensions`

Helper and utility extension methods for **ICollection** and **IReadOnlyCollection** .

### AddIfNotNull` *(Inherited)*

**Signature:** ``AddIfNotNull`(ICollection{``0}, ``0 item)``

**Summary:**
Adds the specified item to the collection if the item is not **null** .

**Parameters:**
- **item** — The item to add to the collection.

**Remarks:**
### AddRangeIfNotNull` *(Inherited)*

**Signature:** ``AddRangeIfNotNull`(ICollection{``0}, IEnumerable{``0} items)``

**Summary:**
Adds the specified items to the collection if they are not **null** .

**Parameters:**
- **items** — The items to add to the collection.

**Remarks:** Each item in **items** will be checked for **null** before being added.
### get_HasItems` *(Inherited)*

**Signature:** ``get_HasItems`(ICollection{``0})``

**Summary:**
Determines whether the collection has any items.

**Returns:** **true** if the collection has items; otherwise, **false** .

**Remarks:**
### get_HasItems` *(Inherited)*

**Signature:** ``get_HasItems`(IReadOnlyCollection{``0})``

**Summary:**
Determines whether the read-only collection has any items.

**Returns:** **true** if the collection has items; otherwise, **false** .

**Remarks:**