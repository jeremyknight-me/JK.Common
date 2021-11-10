namespace JK.Common.Patterns.Specification;

/// <summary>
/// Generic Or specification.
/// </summary>
/// <typeparam name="TEntity">The type of the entity.</typeparam>
public class OrSpecification<TEntity> : CompositeSpecification<TEntity>
{
    /// <summary>
    /// Initializes a new instance of the OrSpecification class.
    /// </summary>
    /// <param name="left">The left entity.</param>
    /// <param name="right">The right entity.</param>
    public OrSpecification(ISpecification<TEntity> left, ISpecification<TEntity> right)
        : base(left, right)
    {
    }

    /// <summary>
    /// Determines whether the specified candidate is satisfied by TEntity.
    /// </summary>
    /// <param name="candidate">The candidate.</param>
    /// <returns>True if is satisfied by the specified candidate; otherwise false.</returns>
    public override bool IsSatisfiedBy(TEntity candidate)
        => this.Left.IsSatisfiedBy(candidate) || this.Right.IsSatisfiedBy(candidate);
}
