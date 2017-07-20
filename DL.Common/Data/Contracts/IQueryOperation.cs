using System.Collections.Generic;

namespace DL.Common.Data.Contracts
{
    /// <summary>
    /// Interface for get data operations.
    /// </summary>
    /// <typeparam name="T">Type of item to get a list of.</typeparam>
    public interface IQueryOperation<out T>
    {
        /// <summary>
        /// Execute method for data operation.
        /// </summary>
        /// <returns>List of items of given type.</returns>
        IEnumerable<T> Execute();
    }
}