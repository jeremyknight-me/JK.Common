[Docs](../../README.md) > [JK.Common](../README.md) > EnumerableExtensions

# EnumerableExtensions

**Namespace:** `JK.Common.Extensions`

Helper and utility extension methods for **IEnumerable** .

### ForEach`

**Signature:** ``ForEach`(IEnumerable{``0} source, Action{``0}@ action)``

**Summary:**
Performs the specified action on each element of the IEnumerable.

**Parameters:**
- **source** — The sequence to iterate over.
- **action** — The action to perform on each element.

**Remarks:**
### ForEach`

**Signature:** ``ForEach`(IEnumerable{``0}, Action{``0 source, Int32}@ action)``

**Summary:**
Performs the specified action on each element of the IEnumerable.

**Parameters:**
- **source** — The sequence to iterate over.
- **action** — The action to perform on each element. The action's second parameter is the index of the source element.

**Remarks:**
### AsIndexedEnumerable`

**Signature:** ``AsIndexedEnumerable`(IEnumerable{``0} source)``

**Summary:**
Returns a sequence of tuples containing the element and its index.

**Parameters:**
- **source** — The sequence to index.

**Returns:** An IEnumerable of tuples where each tuple contains an element and its index.

**Remarks:**