using Assignment4.Models;

namespace Assignment4.Repository
{
    /// <summary>
    /// Transactions are stored as list of Transaction
    /// </summary>
    internal class TransactionRepository
    {
        private List<Transaction> _transactions = new List<Transaction>();

        /// <summary>
        /// Add a transaction to existing list
        /// </summary>
        /// <param name="transaction">A transaction object</param>
        public void Add(Transaction transaction)
        {
            this._transactions.Add(transaction);
        }

        /// <summary>
        /// Fetch all the transaction from the repository
        /// </summary>
        /// <returns>transaction stored</returns>
        public IReadOnlyList<Transaction> GetAll()
        {
            return this._transactions.ToList();
        }

        /// <summary>
        /// Get the transaction with a Id
        /// </summary>
        /// <param name="id">Id to find the transaction</param>
        /// <returns>Transaction object</returns>
        public Transaction? GetTransactionById(string id)
        {
            return this._transactions.FirstOrDefault(x => id == x.Id);
        }

        /// <summary>
        /// deletes a transaction from the list
        /// </summary>
        /// <param name="id">Id of the transaction to be deleted</param>
        internal void DeleteTransactionById(string id)
        {
            Transaction? transaction = this.GetTransactionById(id);
            if (transaction == null)
            {
                return;
            }

            this._transactions.Remove(transaction);
        }
    }
}
