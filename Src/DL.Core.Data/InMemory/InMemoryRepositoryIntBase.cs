using DL.Core.Contracts;

namespace DL.Core.Data.InMemory
{
    public abstract class InMemoryRepositoryIntBase<TEntityType>
        : InMemoryRepositoryNumericBase<TEntityType, int> where TEntityType : class, IIdentifiable<int>
    {
        public override int GetNewId()
        {
            return this.GetNewNumericId();
        }
    }
}
