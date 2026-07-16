[Docs](../../README.md) > [JK.Common](../README.md) > QueryableExtensions

# QueryableExtensions

**Namespace:** `JK.Common.Extensions`

Helper and utility extension methods for **IQueryable&lt;T&gt;**.

## SortBy<T, T2>(IQueryable<T>, Func<T, T2>, Boolean) *(Inherited)*

**Signature:** `SortBy<T, T2>(IQueryable<T>, Func<T, T2>, Boolean)`

**Summary:**
Sorts the elements of a sequence in ascending or descending order according to a key.

**Parameters:**

- **keySelector** — A function to extract a key from an element.

- **isAscending** — True to sort ascending, false for descending.

**Returns:** An **IQueryable&lt;T&gt;** whose elements are sorted according to a key.

## SortBy<T>(IQueryable<T>, String, Boolean) *(Inherited)*

**Signature:** `SortBy<T>(IQueryable<T>, String, Boolean)`

**Summary:**
Sorts the elements of a sequence in ascending or descending order according to a property name.

**Parameters:**

- **propertyName** — The name of the property to sort by.

- **ascending** — True to sort ascending, false for descending.

**Returns:** An **IQueryable&lt;T&gt;** whose elements are sorted according to the property name.

## WhereIf *(Inherited)*

**Signature:** `WhereIf<T>(IQueryable<T>, Boolean, Expression<Func<T, Boolean>>)`

**Summary:**
Filters a sequence based on a condition.

**Parameters:**

- **condition** — A boolean value to determine if the predicate should be applied.

- **predicate** — A function to test each element for a condition.

**Returns:** An **IQueryable&lt;T&gt;** that contains elements from the input sequence that satisfy the condition if true, otherwise the original sequence.