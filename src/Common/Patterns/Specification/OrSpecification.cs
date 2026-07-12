namespace JK.Common.Patterns.Specification;

/// <summary>
/// Generic Or specification.
/// </summary>
/// <typeparam name="TEntity">The type of the entity.</typeparam>
/// <inheritdoc cref="CompositeSpecification{TEntity}"/>
public class OrSpecification<TEntity> : CompositeSpecification<TEntity>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="OrSpecification{TEntity}"/> class.
    /// </summary>
    /// <param name="left">The left entity.</param>
    /// <param name="right">The right entity.</param>
    public OrSpecification(ISpecification<TEntity> left, ISpecification<TEntity> right)
        : base(left, right)
    {
    }

    /// <inheritdoc/>
    public override bool IsSatisfiedBy(in TEntity candidate)
        => Left.IsSatisfiedBy(candidate) || Right.IsSatisfiedBy(candidate);
}
