[Docs](../../README.md) > [JK.Common](../README.md) > QueryableExtensions

# QueryableExtensions

**Namespace:** `JK.Common.Extensions`

<<<<<<< HEAD
Helper and utility extension methods for **IQueryable&lt;T&gt;** .

## SortBy(IQueryable<T>, Func<T, T2> keySelector, Boolean isAscending) *(Inherited)*

**Signature:** `SortBy<T, T2>(IQueryable<T>, Func<T, T2> keySelector, Boolean isAscending)`
=======
Helper and utility extension methods for **IQueryable** .

### SortBy` *(Inherited)*

**Signature:** ``SortBy`(IQueryable{``0}, Func{``0, ``1}@ keySelector, Boolean@ isAscending)``
>>>>>>> initial docs folder changes

**Summary:**
Sorts the elements of a sequence in ascending or descending order according to a key.

**Parameters:**
<<<<<<< HEAD

- **keySelector** — A function to extract a key from an element.

- **isAscending** — True to sort ascending, false for descending.

**Returns:** An **IQueryable&lt;T&gt;** whose elements are sorted according to a key.

## SortBy(IQueryable<T>, String propertyName, Boolean ascending) *(Inherited)*

**Signature:** `SortBy<T>(IQueryable<T>, String propertyName, Boolean ascending)`
=======
- **keySelector** — A function to extract a key from an element.
- **isAscending** — True to sort ascending, false for descending.

**Returns:** An **IQueryable** whose elements are sorted according to a key.

**Remarks:**
### SortBy` *(Inherited)*

**Signature:** ``SortBy`(IQueryable{``0}, String@ propertyName, Boolean@ ascending)``
>>>>>>> initial docs folder changes

**Summary:**
Sorts the elements of a sequence in ascending or descending order according to a property name.

**Parameters:**
<<<<<<< HEAD

- **propertyName** — The name of the property to sort by.

- **ascending** — True to sort ascending, false for descending.

**Returns:** An **IQueryable&lt;T&gt;** whose elements are sorted according to the property name.

## WhereIf *(Inherited)*

**Signature:** `WhereIf<T>(IQueryable<T>, Boolean condition, Expression<Func<T, Boolean>> predicate)`
=======
- **propertyName** — The name of the property to sort by.
- **ascending** — True to sort ascending, false for descending.

**Returns:** An **IQueryable** whose elements are sorted according to the property name.

**Remarks:**
### WhereIf` *(Inherited)*

**Signature:** ``WhereIf`(IQueryable{``0}, Boolean@, Func{``0 condition, Boolean}}@ predicate)``
>>>>>>> initial docs folder changes

**Summary:**
Filters a sequence based on a condition.

**Parameters:**
<<<<<<< HEAD

- **condition** — A boolean value to determine if the predicate should be applied.

- **predicate** — A function to test each element for a condition.

**Returns:** An **IQueryable&lt;T&gt;** that contains elements from the input sequence that satisfy the condition if true, otherwise the original sequence.
=======
- **condition** — A boolean value to determine if the predicate should be applied.
- **predicate** — A function to test each element for a condition.

**Returns:** An **IQueryable** that contains elements from the input sequence that satisfy the condition if true, otherwise the original sequence.

**Remarks:**
>>>>>>> initial docs folder changes
