namespace DL.Core.SpecificationPattern
{
    /// <summary>
    /// Generic And specification
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    public class AndSpecification<TEntity> : CompositeSpecification<TEntity>
    {
        /// <summary>
        /// Initializes a new instance of the AndSpecification class.
        /// </summary>
        /// <param name="left">The left entity.</param>
        /// <param name="right">The right entity.</param>
        public AndSpecification(ISpecification<TEntity> left, ISpecification<TEntity> right)
            : base(left, right)        
        {
        }

        /// <summary>
        /// Determines whether the specified candidate is satisfied by TEntity.
        /// </summary>
        /// <param name="candidate">The candidate.</param>
        /// <returns>True if is satisfied by the specified candidate; otherwise false.</returns>
        public override bool IsSatisfiedBy(TEntity candidate)
        {
            return this.Left.IsSatisfiedBy(candidate) && this.Right.IsSatisfiedBy(candidate);
        }
    }
}
