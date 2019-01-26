namespace JK.Common.Patterns.Specification
{
    /// <summary>
    /// Generic CompositeSpecification.
    /// </summary>
    /// <typeparam name="TEntity">The type of entity.</typeparam>
    public abstract class CompositeSpecification<TEntity> : Specification<TEntity>
    {
        /// <summary>
        /// The composite specification's left entity.
        /// </summary>
        protected readonly ISpecification<TEntity> Left;

        /// <summary>
        /// The composite specification's right entity.
        /// </summary>
        protected readonly ISpecification<TEntity> Right;

        /// <summary>
        /// Initializes a new instance of the CompositeSpecification class.
        /// </summary>
        /// <param name="leftEntity">The left entity.</param>
        /// <param name="rightEntity">The right entity.</param>
        protected CompositeSpecification(ISpecification<TEntity> leftEntity, ISpecification<TEntity> rightEntity)
        {
            this.Left = leftEntity;
            this.Right = rightEntity;
        }
    }
}
