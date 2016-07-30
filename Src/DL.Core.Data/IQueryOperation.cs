using System.Collections.Generic;

namespace DL.Core.Data
{
    /// <summary>
    /// Interface for get data operations.
    /// </summary>
    /// <typeparam name="T">Type of item to get a list of.</typeparam>
    public interface IQueryOperation<T>
    {
        /// <summary>
        /// Execute method for data operation.
        /// </summary>
        /// <returns>List of items of given type.</returns>
        IEnumerable<T> Execute();
    }
}