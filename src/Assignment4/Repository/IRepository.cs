using Assignment4.Models;

namespace Assignment4.Repository
{
    /// <summary>
    /// Provides a centralized data repository for storing, retrieving transaction entities
    /// </summary>
    public interface IRepository
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
        /// <returns>True if edited; otherwise false</returns>
        public bool Edit(Transaction editedTransaction);

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

        /// <summary>
        /// Gets the transaction copy by id
        /// </summary>
        /// <param name="id">Unique identifier of the transaction</param>
        /// <returns>The transaction copy</returns>
        public Transaction? GetTransactionCopy(string id);

        /// <summary>
        /// Returns if the id is valid or not.
        /// </summary>
        /// <param name="id"> Unique identifier of the transaction. </param>
        /// <returns> True if the id is valid; otherwise false. </returns>
        public bool IsValidId(string id);

        /// <summary>
        /// Search the transaction by date and category
        /// </summary>
        /// <param name="query">Query text entered by the user</param>
        /// <param name="option">Option to sort by </param>
        /// <returns>A list containing the list that matched the query text</returns>
        public IReadOnlyList<Transaction> Search(string query, int option);
    }
}
