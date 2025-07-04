namespace JK.Common.Patterns.Specification;

public class NotSpecification<TEntity> : Specification<TEntity>
{
    private readonly ISpecification<TEntity> _specification;

    public NotSpecification(ISpecification<TEntity> specificationToUse)
    {
        _specification = specificationToUse;
    }

    public override bool IsSatisfiedBy(in TEntity candidate) => !_specification.IsSatisfiedBy(candidate);
}
