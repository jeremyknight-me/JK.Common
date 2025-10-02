namespace JK.Common.Patterns.Specification;

/// <summary>
/// Abstraction on ISpecification that supplies And, Or and Not.
/// </summary>
/// <typeparam name="TEntity">The type of entity.</typeparam>
/// <inheritdoc cref="ISpecification{TEntity}"/>
public abstract class Specification<TEntity> : ISpecification<TEntity>
{
    /// <inheritdoc/>
    public abstract bool IsSatisfiedBy(in TEntity candidate);

    /// <inheritdoc/>
    public ISpecification<TEntity> And(ISpecification<TEntity> specification)
        => new AndSpecification<TEntity>(this, specification);

    /// <inheritdoc/>
    public ISpecification<TEntity> Not() => new NotSpecification<TEntity>(this);

    /// <inheritdoc/>
    public ISpecification<TEntity> Or(ISpecification<TEntity> specification)
        => new OrSpecification<TEntity>(this, specification);
}
