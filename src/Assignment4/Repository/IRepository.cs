using Assignment4.Models;

namespace Assignment4.Repository
{
    /// <summary>
    /// Repository methods used to make the expense tracker functional
    /// </summary>
    internal interface IRepository
    {
        /// <summary>
        /// Add a transaction to existing list
        /// </summary>
        /// <param name="transaction">A transaction object</param>
        void Add(Transaction transaction);

        /// <summary>
        /// Fetch all the transaction from the repository
        /// </summary>
        /// <returns>transaction stored</returns>
        IReadOnlyList<Transaction> GetAll();

        /// <summary>
        /// Get the transaction with a Id
        /// </summary>
        /// <param name="id">Id to find the transaction</param>
        /// <returns>Transaction object</returns>
        Transaction? GetById(string id);

        /// <summary>
        /// deletes a transaction from the list
        /// </summary>
        /// <param name="id">Id of the transaction to be deleted</param>
        void DeleteTransactionById(string id);

        /// <summary>
        /// Checks if any transactions exists
        /// </summary>
        /// <returns>true if any transaction exists, false if it is empty</returns>
        bool IsAny();
    }
}
