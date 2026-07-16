[Docs](../../../README.md) > [JK.Common](../../README.md) > NotSpecification<TEntity>

# NotSpecification<TEntity>

**Namespace:** `JK.Common.Patterns.Specification`

Specification that negates the result of another specification.

**Type Parameter:** `TEntity` — The type of entity.

## NotSpecification<TEntity>

**Signature:** `NotSpecification<TEntity>(ISpecification<TEntity> specificationToUse)`

**Summary:**
Initializes a new instance of the **NotSpecification&lt;T&gt;** class.

**Parameters:**

- **specificationToUse** — The specification to negate.

## IsSatisfiedBy *(Inherited)*

**Signature:** `IsSatisfiedBy(TEntity)`

**Summary:**