using Assignment4.DTOs;
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
        /// Deletes a transaction from the list
        /// </summary>
        /// <param name="id"> Id of the transaction to be deleted. </param>
        void DeleteTransactionById(string id);

        /// <summary>
        /// Checks if any transactions exists
        /// </summary>
        /// <returns> True if any transaction exists; otherwise false. </returns>
        bool HasAny();

        /// <summary>
        /// Edit the transaction from the repository
        /// </summary>
        /// <param name="editedTransaction">The edited transaction</param>
        /// <param name="id">Identifier to edit the transaction</param>
        /// <returns>True if edited; otherwise false</returns>
        public bool Edit(TransactionDTO editedTransaction, string id);

        /// <summary>
        /// Fetches all the expense from the repository
        /// </summary>
        /// <returns>Returns the expenses. </returns>
        public IReadOnlyList<Transaction> GetExpense();

        /// <summary>
        /// Fetches all the income from the repository
        /// </summary>
        /// <returns> Returns the income. </returns>
        public IReadOnlyList<Transaction> GetIncome();
    }
}
