namespace DL.Common.Data.Contracts
{
    /// <summary>
    /// Interface for void, non-typed data operations such as delete and update.
    /// </summary>
    public interface INonQueryOperation
    {
        /// <summary>
        /// Execute method for data operation.
        /// </summary>
        void Execute();
    }
}