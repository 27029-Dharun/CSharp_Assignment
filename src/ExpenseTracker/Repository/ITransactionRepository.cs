using ExpenseTracker.Models;

namespace ExpenseTracker.Repository
{
    /// <summary>
    /// Provides a centralized data repository for storing, retrieving transaction entities.
    /// </summary>
    public interface ITransactionRepository
    {
        /// <summary>
        /// Add a transaction to existing list.
        /// </summary>
        /// <param name="transaction">A new transaction created.</param>
        void Add(Transaction transaction);

        /// <summary>
        /// Fetch all the transaction from the list.
        /// </summary>
        /// <returns>List of all the transactions fetched.</returns>
        IReadOnlyList<Transaction> GetAll();

        /// <summary>
        /// Deletes an existing transaction.
        /// </summary>
        /// <param name="id">ID of the transaction to be deleted.</param>
        void DeleteTransactionById(string id);

        /// <summary>
        /// Checks if any transactions exists.
        /// </summary>
        /// <returns>True if any transaction exists; otherwise false.</returns>
        bool HasAny();

        /// <summary>
        /// Edits an existing transaction.
        /// </summary>
        /// <param name="editedTransaction">The edited transaction.</param>
        /// <returns>True if edited; otherwise false.</returns>
        bool Edit(Transaction editedTransaction);

        /// <summary>
        /// Fetches all the expense from the repository.
        /// </summary>
        /// <returns>Returns the transactions that are expenses.</returns>
        IReadOnlyList<Transaction> GetExpense();

        /// <summary>
        /// Fetches all the income from the repository.
        /// </summary>
        /// <returns>Returns the transactions that are income.</returns>
        IReadOnlyList<Transaction> GetIncome();

        /// <summary>
        /// Gets the transaction copy by id.
        /// </summary>
        /// <param name="id">ID of the transaction.</param>
        /// <returns>A new transaction copy with same ID.</returns>
        Transaction? GetTransactionCopy(string id);

        /// <summary>
        /// Returns if the id is valid or not.
        /// </summary>
        /// <param name="id">ID of the transaction.</param>
        /// <returns>True if the ID is valid; otherwise false.</returns>
        bool IsValidId(string id);

        /// <summary>
        /// Search the transaction by date and category.
        /// </summary>
        /// <param name="value">A predicate condition to search.</param>
        /// <returns>A list containing the list that matched the query text.</returns>
        IReadOnlyList<Transaction> Search(Func<Transaction, bool> value);

        /// <summary>
        /// Sorts the transaction by type.
        /// </summary>
        /// <param name="type">The type of the transactions to sort.</param>
        /// <param name="option">Option to sort the transaction.</param>
        /// <returns>A sorted order of the transaction.</returns>
        IReadOnlyList<Transaction> Sort(TransactionType type, SortOption option);
    }
}
