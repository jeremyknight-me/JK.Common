using System;

namespace DL.Core
{
    public sealed class EquatableFacade<T> where T : class
    {
        public Func<T, T, bool> AreObjectDetailsEqual { get; set; }

        public bool Equals(object left, object right)
        {
            if (this.AreBothNullReference(left, right) 
                || this.AreSameReference(left, right))
            {
                return true;
            }

            if (this.AreEitherNullReference(left, right))
            {
                return false;
            }

            if (!(left is T))
            {
                throw new ArgumentException(@"The 'left' argument is not the correct type.", "left");
            }

            if (!(right is T))
            {
                throw new ArgumentException(@"The 'right' argument is not the correct type.", "right");
            }

            return this.AreObjectDetailsEqual(left as T, right as T);
        }

        private bool AreBothNullReference(object left, object right)
        {
            return this.IsNullReference(left) && this.IsNullReference(right);
        }

        private bool AreEitherNullReference(object left, object right)
        {
            return this.IsNullReference(left) || this.IsNullReference(right);
        }

        private bool AreSameReference(object left, object right)
        {
            return object.ReferenceEquals(left, right);
        }

        private bool IsNullReference(object entity)
        {
            return object.ReferenceEquals(entity, null);
        }
    }
}
