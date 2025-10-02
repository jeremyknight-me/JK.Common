namespace JK.Common.Patterns.Specification;

/// <summary>
/// Specification that negates the result of another specification.
/// </summary>
/// <typeparam name="TEntity">The type of entity.</typeparam>
/// <inheritdoc cref="Specification{TEntity}"/>
public class NotSpecification<TEntity> : Specification<TEntity>
{
    private readonly ISpecification<TEntity> _specification;

    /// <summary>
    /// Initializes a new instance of the <see cref="NotSpecification{TEntity}"/> class.
    /// </summary>
    /// <param name="specificationToUse">The specification to negate.</param>
    public NotSpecification(ISpecification<TEntity> specificationToUse)
    {
        _specification = specificationToUse;
    }

    /// <inheritdoc/>
    public override bool IsSatisfiedBy(in TEntity candidate) => !_specification.IsSatisfiedBy(candidate);
}
