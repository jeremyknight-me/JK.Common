using JK.Common.Contracts;
using System;

namespace JK.Common.Data.InMemory;

[Obsolete("Generic InMemory repos have been left in for reference purposes. Use EF Core In Memory provider instead.")]
public abstract class InMemoryRepositoryGuidBase<TEntityType>
    : InMemoryRepositoryBase<TEntityType, Guid> where TEntityType : class, IIdentifiable<Guid>
{
    public override Guid GetNewId() => Guid.NewGuid();
}
