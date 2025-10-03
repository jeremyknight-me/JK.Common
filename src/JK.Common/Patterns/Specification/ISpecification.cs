namespace JK.Common.Patterns.Specification;

/// <summary>
/// Defines the contract for a specification pattern.
/// </summary>
/// <typeparam name="TEntity">The type of entity to evaluate.</typeparam>
public interface ISpecification<TEntity>
{
    /// <summary>
    /// Determines whether the specified candidate is satisfied by TEntity.
    /// </summary>
    /// <param name="candidate">The candidate.</param>
    /// <returns>True if is satisfied by the specified candidate; otherwise false.</returns>
    bool IsSatisfiedBy(in TEntity candidate);

    /// <summary>
    /// Ands the specified specification.
    /// </summary>
    /// <param name="specification">The specification</param>
    /// <returns>Returns a new specification of type And.</returns>
    ISpecification<TEntity> And(ISpecification<TEntity> specification);

    /// <summary>
    /// Performs the 'not' operators on this instance.
    /// </summary>
    /// <returns>Returns a new specification of type Not.</returns>
    ISpecification<TEntity> Not();

    /// <summary>
    /// Performs the 'or' operator on the specified specification.
    /// </summary>
    /// <param name="specification">The specification.</param>
    /// <returns>Returns a new specification of type Or.</returns>
    ISpecification<TEntity> Or(ISpecification<TEntity> specification);
}
