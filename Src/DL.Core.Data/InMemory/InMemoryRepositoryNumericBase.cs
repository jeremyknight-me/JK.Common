using DL.Core.Contracts;

namespace DL.Core.Data.InMemory
{
    public abstract class InMemoryRepositoryNumericBase<TEntityType, TKey>
        : InMemoryRepositoryBase<TEntityType, TKey> 
            where TEntityType : class, IIdentifiable<TKey>
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
