using System;

namespace JK.Common
{
    public sealed class EquatableFacade<T>
    {
        public Func<T, T, bool> AreObjectsEqual { get; set; } = (left, right) => ((T)left).Equals((T)right);

        public bool AreEqual(object left, object right)
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
                throw new ArgumentException(@"The 'left' argument is not the correct type.", nameof(left));
            }

            if (!(right is T))
            {
                throw new ArgumentException(@"The 'right' argument is not the correct type.", nameof(right));
            }

            return this.AreObjectsEqual((T)left, (T)right);
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
