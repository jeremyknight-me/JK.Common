namespace JK.Common.Patterns.Specification;

/// <summary>
/// Abstraction on ISpecification that supplies And, Or and Not.
/// </summary>
/// <typeparam name="TEntity">The type of entity.</typeparam>
public abstract class Specification<TEntity> : ISpecification<TEntity>
{
    /// <summary>
    /// Determines whether the specified candidate is satisfied by TEntity.
    /// </summary>
    /// <param name="candidate">The candidate.</param>
    /// <returns>True if is satisfied by the specified candidate; otherwise false.</returns>
    public abstract bool IsSatisfiedBy(in TEntity candidate);

    /// <summary>
    /// Ands the specified specification.
    /// </summary>
    /// <param name="specification">The specification</param>
    /// <returns>Returns a new specification of type And.</returns>
    public ISpecification<TEntity> And(ISpecification<TEntity> specification)
        => new AndSpecification<TEntity>(this, specification);

    /// <summary>
    /// Performs the 'not' operators on this instance.
    /// </summary>
    /// <returns>Returns a new specification of type Not.</returns>
    public ISpecification<TEntity> Not() => new NotSpecification<TEntity>(this);

    /// <summary>
    /// Performs the 'or' operator on the specified specification.
    /// </summary>
    /// <param name="specification">The specification.</param>
    /// <returns>Returns a new specification of type Or.</returns>
    public ISpecification<TEntity> Or(ISpecification<TEntity> specification)
        => new OrSpecification<TEntity>(this, specification);
}
