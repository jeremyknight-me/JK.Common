[Docs](../../README.md) > [JK.Common](../README.md) > QueryableExtensions

# QueryableExtensions

**Namespace:** `JK.Common.Extensions`

Helper and utility extension methods for **IQueryable** .

### SortBy` *(Inherited)*

**Signature:** ``SortBy`(IQueryable{``0}, Func{``0, ``1}@ keySelector, Boolean@ isAscending)``

**Summary:**
Sorts the elements of a sequence in ascending or descending order according to a key.

**Parameters:**
- **keySelector** — A function to extract a key from an element.
- **isAscending** — True to sort ascending, false for descending.

**Returns:** An **IQueryable** whose elements are sorted according to a key.

**Remarks:**
### SortBy` *(Inherited)*

**Signature:** ``SortBy`(IQueryable{``0}, String@ propertyName, Boolean@ ascending)``

**Summary:**
Sorts the elements of a sequence in ascending or descending order according to a property name.

**Parameters:**
- **propertyName** — The name of the property to sort by.
- **ascending** — True to sort ascending, false for descending.

**Returns:** An **IQueryable** whose elements are sorted according to the property name.

**Remarks:**
### WhereIf` *(Inherited)*

**Signature:** ``WhereIf`(IQueryable{``0}, Boolean@, Func{``0 condition, Boolean}}@ predicate)``

**Summary:**
Filters a sequence based on a condition.

**Parameters:**
- **condition** — A boolean value to determine if the predicate should be applied.
- **predicate** — A function to test each element for a condition.

**Returns:** An **IQueryable** that contains elements from the input sequence that satisfy the condition if true, otherwise the original sequence.

**Remarks:**