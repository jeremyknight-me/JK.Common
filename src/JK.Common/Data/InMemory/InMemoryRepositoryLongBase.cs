using JK.Common.Contracts;
using System;

namespace JK.Common.Data.InMemory
{
    [Obsolete("Generic InMemory repos have been left in for reference purposes. Use EF Core In Memory provider instead.")]
    public abstract class InMemoryRepositoryLongBase<TEntityType>
        : InMemoryRepositoryNumericBase<TEntityType, long> where TEntityType : class, IIdentifiable<long>
    {
        public override long GetNewId()
        {
            return Convert.ToInt64(this.GetNewNumericId());
        }
    }
}
