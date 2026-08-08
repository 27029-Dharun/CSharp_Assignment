using Assignment4.Models;

namespace Assignment4.Repository
{
    /// <summary>
    /// Provides a centralized data repository for storing, retrieving transaction entities
    /// </summary>
    internal interface IRepository
    {
        /// <summary>
        /// Add a transaction to existing list
        /// </summary>
        /// <param name="transaction"> A transaction object. </param>
        void Add(Transaction transaction);

        /// <summary>
        /// Fetch all the transaction from the repository
        /// </summary>
        /// <returns> List of all the transactions fetched. </returns>
        IReadOnlyList<Transaction> GetAll();

        /// <summary>
        /// Get the transaction with a unique identifier.
        /// </summary>
        /// <param name="id"> Unique identifier of the transaction. </param>
        /// <returns> Transaction instance if present; otherwise null. </returns>
        Transaction? GetById(string id);

        /// <summary>
        /// Deletes a transaction from the list
        /// </summary>
        /// <param name="id"> Id of the transaction to be deleted. </param>
        void DeleteTransactionById(string id);

        /// <summary>
        /// Checks if any transactions exists
        /// </summary>
        /// <returns> True if any transaction exists; otherwise false. </returns>
        bool IsAny();
    }
}
