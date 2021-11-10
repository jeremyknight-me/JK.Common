using JK.Common.Contracts;
using System;

namespace JK.Common.Data.InMemory;

[Obsolete("Generic InMemory repos have been left in for reference purposes. Use EF Core In Memory provider instead.")]
public abstract class InMemoryRepositoryIntBase<TEntityType>
    : InMemoryRepositoryNumericBase<TEntityType, int> where TEntityType : class, IIdentifiable<int>
{
    public override int GetNewId() => this.GetNewNumericId();
}
