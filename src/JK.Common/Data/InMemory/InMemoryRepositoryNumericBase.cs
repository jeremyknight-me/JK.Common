using JK.Common.Contracts;
using System;

namespace JK.Common.Data.InMemory
{
    [Obsolete("Generic InMemory repos have been left in for reference purposes. Use EF Core In Memory provider instead.")]
    public abstract class InMemoryRepositoryNumericBase<TEntityType, TKey>
        : InMemoryRepositoryBase<TEntityType, TKey> where TEntityType : class, IIdentifiable<TKey>
    {
        private int identitySeed;

        protected InMemoryRepositoryNumericBase()
        {
            this.identitySeed = 1;
        }

        public int GetNewNumericId()
        {
            return this.identitySeed++;
        }
    }
}
