[Docs](../../../README.md) > [JK.Common](../../README.md) > ISpecification<TEntity>

# ISpecification<TEntity>

**Namespace:** `JK.Common.Patterns.Specification`

Defines the contract for a specification pattern.

**Type Parameter:** `TEntity` — The type of entity to evaluate.

### IsSatisfiedBy

**Signature:** ``IsSatisfiedBy(TEntity@ candidate)``

**Summary:**
Determines whether the specified candidate is satisfied by TEntity.

**Parameters:**
- **candidate** — The candidate.

**Returns:** True if is satisfied by the specified candidate; otherwise false.

**Remarks:**
### And

**Signature:** ``And(ISpecification specification)``

**Summary:**
Ands the specified specification.

**Parameters:**
- **specification** — The specification

**Returns:** Returns a new specification of type And.

**Remarks:**
### Not

**Signature:** ``Not()``

**Summary:**
Performs the 'not' operators on this instance.

**Returns:** Returns a new specification of type Not.

**Remarks:**
### Or

**Signature:** ``Or(ISpecification specification)``

**Summary:**
Performs the 'or' operator on the specified specification.

**Parameters:**
- **specification** — The specification.

**Returns:** Returns a new specification of type Or.

**Remarks:**