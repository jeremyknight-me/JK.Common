[Docs](../../README.md) > [JK.Common](../README.md) > EnumerableExtensions

# EnumerableExtensions

**Namespace:** `JK.Common.Extensions`

<<<<<<< HEAD
Helper and utility extension methods for **IEnumerable&lt;T&gt;** .

## ForEach(IEnumerable<T> source, Action<T> action)

**Signature:** `ForEach<T>(IEnumerable<T> source, Action<T> action)`
=======
Helper and utility extension methods for **IEnumerable** .

### ForEach`

**Signature:** ``ForEach`(IEnumerable{``0} source, Action{``0}@ action)``
>>>>>>> initial docs folder changes

**Summary:**
Performs the specified action on each element of the IEnumerable.

**Parameters:**
<<<<<<< HEAD

- **source** — The sequence to iterate over.

- **action** — The action to perform on each element.

## ForEach(IEnumerable<T> source, Action<T, Int32> action)

**Signature:** `ForEach<T>(IEnumerable<T> source, Action<T, Int32> action)`
=======
- **source** — The sequence to iterate over.
- **action** — The action to perform on each element.

**Remarks:**
### ForEach`

**Signature:** ``ForEach`(IEnumerable{``0}, Action{``0 source, Int32}@ action)``
>>>>>>> initial docs folder changes

**Summary:**
Performs the specified action on each element of the IEnumerable.

**Parameters:**
<<<<<<< HEAD

- **source** — The sequence to iterate over.

- **action** — The action to perform on each element. The action's second parameter is the index of the source element.

## AsIndexedEnumerable

**Signature:** `AsIndexedEnumerable<T>(IEnumerable<T> source)`
=======
- **source** — The sequence to iterate over.
- **action** — The action to perform on each element. The action's second parameter is the index of the source element.

**Remarks:**
### AsIndexedEnumerable`

**Signature:** ``AsIndexedEnumerable`(IEnumerable{``0} source)``
>>>>>>> initial docs folder changes

**Summary:**
Returns a sequence of tuples containing the element and its index.

**Parameters:**
<<<<<<< HEAD

- **source** — The sequence to index.

**Returns:** An IEnumerable of tuples where each tuple contains an element and its index.
=======
- **source** — The sequence to index.

**Returns:** An IEnumerable of tuples where each tuple contains an element and its index.

**Remarks:**
>>>>>>> initial docs folder changes
