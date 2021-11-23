﻿namespace JK.Common.Patterns.Specification;

public interface ISpecification<TEntity>
{
    ISpecification<TEntity> And(ISpecification<TEntity> specification);

    bool IsSatisfiedBy(in TEntity candidate);

    ISpecification<TEntity> Not();

    ISpecification<TEntity> Or(ISpecification<TEntity> specification);
}
