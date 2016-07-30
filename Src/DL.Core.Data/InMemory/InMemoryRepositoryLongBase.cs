using System;
using DL.Core.Contracts;

namespace DL.Core.Data.InMemory
{
    public abstract class InMemoryRepositoryLongBase<TEntityType>
        : InMemoryRepositoryNumericBase<TEntityType, long> where TEntityType : class, IIdentifiable<long>
    {
        public override long GetNewId()
        {
            return Convert.ToInt64(this.GetNewNumericId());
        }
    }
}
