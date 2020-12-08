using JK.Common.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace JK.Common.Data.InMemory
{
    [Obsolete("Generic InMemory repos have been left in for reference purposes. Use EF Core In Memory provider instead.")]
    public abstract class InMemoryRepositoryBase<TEntityType, TKey> where TEntityType : class, IIdentifiable<TKey>
    {
        protected InMemoryRepositoryBase()
        {
            this.Dictionary = new Dictionary<TKey, TEntityType>();
        }

        public Dictionary<TKey, TEntityType> Dictionary { get; }

        public void Delete(TEntityType entity) => _ = this.Dictionary.Remove(entity.Id);

        public abstract TKey GetNewId();

        public void Save(TEntityType entity)
        {
            if (this.ContainsItem(entity))
            {
                this.Update(entity);
            }
            else
            {
                this.Add(entity);
            }
        }

        public IEnumerable<TEntityType> SelectAll() => this.Dictionary.Values.Where(x => x != null).ToArray();

        public TEntityType SelectById(TKey id) => this.Dictionary.ContainsKey(id) ? this.Dictionary[id] : null;

        private bool ContainsItem(TEntityType entity) => this.Dictionary.ContainsKey(entity.Id) && this.Dictionary[entity.Id] != null;

        private void Add(TEntityType entity)
        {
            var newId = this.GetNewId();
            this.Dictionary.Add(newId, entity);
        }

        private void Update(TEntityType entity) => this.Dictionary[entity.Id] = entity;
    }
}
