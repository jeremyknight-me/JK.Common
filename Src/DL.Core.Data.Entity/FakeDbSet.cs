using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace DL.Core.Data.Entity
{
    public class FakeDbSet<T> : IDbSet<T> where T : class
    {
        private readonly List<T> data;

        private readonly IQueryable query;

        public FakeDbSet()
        {
            this.data = new List<T>();
            this.query = this.data.AsQueryable();
        }

        public System.Collections.ObjectModel.ObservableCollection<T> Local
        {
            get
            {
                return new System.Collections.ObjectModel.ObservableCollection<T>(this.data);
            }

            set
            {
                this.data.Clear();
                this.data.AddRange(value);
            }
        }

        public Type ElementType
        {
            get { return this.query.ElementType; }
        }

        public Expression Expression
        {
            get { return this.query.Expression; }
        }

        public IQueryProvider Provider
        {
            get { return this.query.Provider; }
        }

        public T Add(T entity)
        {
            this.data.Add(entity);
            return entity;
        }

        public T Attach(T entity)
        {
            this.data.Add(entity);
            return entity;
        }

        public TDerivedEntity Create<TDerivedEntity>() where TDerivedEntity : class, T
        {
            throw new NotImplementedException();
        }

        public T Create()
        {
            return Activator.CreateInstance<T>();
        }

        public virtual T Find(params object[] keyValues)
        {
            throw new NotImplementedException("Derive from FakeDbSet and override Find");
        }       

        public T Remove(T entity)
        {
            this.data.Remove(entity);
            return entity;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return this.data.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.data.GetEnumerator();
        }
    }
}
