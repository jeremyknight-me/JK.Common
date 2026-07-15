[Docs](../../../README.md) > [JK.Common](../../README.md) > ISpecification<TEntity>

# ISpecification<TEntity>

**Namespace:** `JK.Common.Patterns.Specification`

Defines the contract for a specification pattern.

**Type Parameter:** `TEntity` — The type of entity to evaluate.

<<<<<<< HEAD
<<<<<<< HEAD
## IsSatisfiedBy

**Signature:** `IsSatisfiedBy(TEntity candidate)`
=======
### IsSatisfiedBy

**Signature:** ``IsSatisfiedBy(TEntity@ candidate)``
>>>>>>> initial docs folder changes
=======
### IsSatisfiedBy

**Signature:** ``IsSatisfiedBy(TEntity@ candidate)``
>>>>>>> d66d5e94771075443ea96deaa1b24a052ee196d0

**Summary:**
Determines whether the specified candidate is satisfied by TEntity.

**Parameters:**
<<<<<<< HEAD
<<<<<<< HEAD

=======
>>>>>>> initial docs folder changes
=======
>>>>>>> d66d5e94771075443ea96deaa1b24a052ee196d0
- **candidate** — The candidate.

**Returns:** True if is satisfied by the specified candidate; otherwise false.

<<<<<<< HEAD
<<<<<<< HEAD
## And

**Signature:** `And(ISpecification<TEntity> specification)`
=======
=======
>>>>>>> d66d5e94771075443ea96deaa1b24a052ee196d0
**Remarks:**
### And

**Signature:** ``And(ISpecification specification)``
<<<<<<< HEAD
>>>>>>> initial docs folder changes
=======
>>>>>>> d66d5e94771075443ea96deaa1b24a052ee196d0

**Summary:**
Ands the specified specification.

**Parameters:**
<<<<<<< HEAD
<<<<<<< HEAD

=======
>>>>>>> initial docs folder changes
=======
>>>>>>> d66d5e94771075443ea96deaa1b24a052ee196d0
- **specification** — The specification

**Returns:** Returns a new specification of type And.

<<<<<<< HEAD
<<<<<<< HEAD
## Not

**Signature:** `Not()`
=======
=======
>>>>>>> d66d5e94771075443ea96deaa1b24a052ee196d0
**Remarks:**
### Not

**Signature:** ``Not()``
<<<<<<< HEAD
>>>>>>> initial docs folder changes
=======
>>>>>>> d66d5e94771075443ea96deaa1b24a052ee196d0

**Summary:**
Performs the 'not' operators on this instance.

**Returns:** Returns a new specification of type Not.

<<<<<<< HEAD
<<<<<<< HEAD
## Or

**Signature:** `Or(ISpecification<TEntity> specification)`
=======
=======
>>>>>>> d66d5e94771075443ea96deaa1b24a052ee196d0
**Remarks:**
### Or

**Signature:** ``Or(ISpecification specification)``
<<<<<<< HEAD
>>>>>>> initial docs folder changes
=======
>>>>>>> d66d5e94771075443ea96deaa1b24a052ee196d0

**Summary:**
Performs the 'or' operator on the specified specification.

**Parameters:**
<<<<<<< HEAD
<<<<<<< HEAD

- **specification** — The specification.

**Returns:** Returns a new specification of type Or.
=======
=======
>>>>>>> d66d5e94771075443ea96deaa1b24a052ee196d0
- **specification** — The specification.

**Returns:** Returns a new specification of type Or.

<<<<<<< HEAD
**Remarks:**
>>>>>>> initial docs folder changes
=======
**Remarks:**
>>>>>>> d66d5e94771075443ea96deaa1b24a052ee196d0
