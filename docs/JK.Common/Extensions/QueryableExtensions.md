[Docs](../../README.md) > [JK.Common](../README.md) > QueryableExtensions

# QueryableExtensions

**Namespace:** `JK.Common.Extensions`

<<<<<<< HEAD
<<<<<<< HEAD
Helper and utility extension methods for **IQueryable&lt;T&gt;** .

## SortBy(IQueryable<T>, Func<T, T2> keySelector, Boolean isAscending) *(Inherited)*

**Signature:** `SortBy<T, T2>(IQueryable<T>, Func<T, T2> keySelector, Boolean isAscending)`
=======
=======
>>>>>>> d66d5e94771075443ea96deaa1b24a052ee196d0
Helper and utility extension methods for **IQueryable** .

### SortBy` *(Inherited)*

**Signature:** ``SortBy`(IQueryable{``0}, Func{``0, ``1}@ keySelector, Boolean@ isAscending)``
<<<<<<< HEAD
>>>>>>> initial docs folder changes
=======
>>>>>>> d66d5e94771075443ea96deaa1b24a052ee196d0

**Summary:**
Sorts the elements of a sequence in ascending or descending order according to a key.

**Parameters:**
<<<<<<< HEAD
<<<<<<< HEAD

- **keySelector** — A function to extract a key from an element.

- **isAscending** — True to sort ascending, false for descending.

**Returns:** An **IQueryable&lt;T&gt;** whose elements are sorted according to a key.

## SortBy(IQueryable<T>, String propertyName, Boolean ascending) *(Inherited)*

**Signature:** `SortBy<T>(IQueryable<T>, String propertyName, Boolean ascending)`
=======
=======
>>>>>>> d66d5e94771075443ea96deaa1b24a052ee196d0
- **keySelector** — A function to extract a key from an element.
- **isAscending** — True to sort ascending, false for descending.

**Returns:** An **IQueryable** whose elements are sorted according to a key.

**Remarks:**
### SortBy` *(Inherited)*

**Signature:** ``SortBy`(IQueryable{``0}, String@ propertyName, Boolean@ ascending)``
<<<<<<< HEAD
>>>>>>> initial docs folder changes
=======
>>>>>>> d66d5e94771075443ea96deaa1b24a052ee196d0

**Summary:**
Sorts the elements of a sequence in ascending or descending order according to a property name.

**Parameters:**
<<<<<<< HEAD
<<<<<<< HEAD

- **propertyName** — The name of the property to sort by.

- **ascending** — True to sort ascending, false for descending.

**Returns:** An **IQueryable&lt;T&gt;** whose elements are sorted according to the property name.

## WhereIf *(Inherited)*

**Signature:** `WhereIf<T>(IQueryable<T>, Boolean condition, Expression<Func<T, Boolean>> predicate)`
=======
=======
>>>>>>> d66d5e94771075443ea96deaa1b24a052ee196d0
- **propertyName** — The name of the property to sort by.
- **ascending** — True to sort ascending, false for descending.

**Returns:** An **IQueryable** whose elements are sorted according to the property name.

**Remarks:**
### WhereIf` *(Inherited)*

**Signature:** ``WhereIf`(IQueryable{``0}, Boolean@, Func{``0 condition, Boolean}}@ predicate)``
<<<<<<< HEAD
>>>>>>> initial docs folder changes
=======
>>>>>>> d66d5e94771075443ea96deaa1b24a052ee196d0

**Summary:**
Filters a sequence based on a condition.

**Parameters:**
<<<<<<< HEAD
<<<<<<< HEAD

- **condition** — A boolean value to determine if the predicate should be applied.

- **predicate** — A function to test each element for a condition.

**Returns:** An **IQueryable&lt;T&gt;** that contains elements from the input sequence that satisfy the condition if true, otherwise the original sequence.
=======
=======
>>>>>>> d66d5e94771075443ea96deaa1b24a052ee196d0
- **condition** — A boolean value to determine if the predicate should be applied.
- **predicate** — A function to test each element for a condition.

**Returns:** An **IQueryable** that contains elements from the input sequence that satisfy the condition if true, otherwise the original sequence.

<<<<<<< HEAD
**Remarks:**
>>>>>>> initial docs folder changes
=======
**Remarks:**
>>>>>>> d66d5e94771075443ea96deaa1b24a052ee196d0
