using System;
using DL.Core.Contracts;

namespace DL.Core.Data.InMemory
{
    public abstract class InMemoryRepositoryGuidBase<TEntityType>
        : InMemoryRepositoryBase<TEntityType, Guid> where TEntityType : class, IIdentifiable<Guid>
    {
        public override Guid GetNewId()
        {
            return Guid.NewGuid();
        }
    }
}
