[Docs](../../../README.md) > [JK.Common](../../README.md) > ISpecification<TEntity>

# ISpecification<TEntity>

**Namespace:** `JK.Common.Patterns.Specification`

Defines the contract for a specification pattern.

**Type Parameter:** `TEntity` — The type of entity to evaluate.

<<<<<<< HEAD
## IsSatisfiedBy

**Signature:** `IsSatisfiedBy(TEntity candidate)`
=======
### IsSatisfiedBy

**Signature:** ``IsSatisfiedBy(TEntity@ candidate)``
>>>>>>> initial docs folder changes

**Summary:**
Determines whether the specified candidate is satisfied by TEntity.

**Parameters:**
<<<<<<< HEAD

=======
>>>>>>> initial docs folder changes
- **candidate** — The candidate.

**Returns:** True if is satisfied by the specified candidate; otherwise false.

<<<<<<< HEAD
## And

**Signature:** `And(ISpecification<TEntity> specification)`
=======
**Remarks:**
### And

**Signature:** ``And(ISpecification specification)``
>>>>>>> initial docs folder changes

**Summary:**
Ands the specified specification.

**Parameters:**
<<<<<<< HEAD

=======
>>>>>>> initial docs folder changes
- **specification** — The specification

**Returns:** Returns a new specification of type And.

<<<<<<< HEAD
## Not

**Signature:** `Not()`
=======
**Remarks:**
### Not

**Signature:** ``Not()``
>>>>>>> initial docs folder changes

**Summary:**
Performs the 'not' operators on this instance.

**Returns:** Returns a new specification of type Not.

<<<<<<< HEAD
## Or

**Signature:** `Or(ISpecification<TEntity> specification)`
=======
**Remarks:**
### Or

**Signature:** ``Or(ISpecification specification)``
>>>>>>> initial docs folder changes

**Summary:**
Performs the 'or' operator on the specified specification.

**Parameters:**
<<<<<<< HEAD

- **specification** — The specification.

**Returns:** Returns a new specification of type Or.
=======
- **specification** — The specification.

**Returns:** Returns a new specification of type Or.

**Remarks:**
>>>>>>> initial docs folder changes
