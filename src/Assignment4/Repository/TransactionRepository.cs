using Assignment4.DTOs;
using Assignment4.Models;
using Assignment4.Models.Enums;

namespace Assignment4.Repository
{
    /// <summary>
    /// Transactions are stored as list of Transaction
    /// </summary>
    internal class TransactionRepository : IRepository
    {
        private readonly List<Transaction> _transactions = new List<Transaction>();

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
            return this._transactions.Select(this.Copy).ToList();
        }

        /// <summary>
        /// Get the transaction with a Id
        /// </summary>
        /// <param name="id">Id to find the transaction</param>
        /// <returns>Transaction object</returns>
        public bool IsValidId(string id)
        {
            if (this._transactions.FirstOrDefault(x => id == x.Id) is not null)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// deletes a transaction from the list
        /// </summary>
        /// <param name="id">Id of the transaction to be deleted</param>
        public void DeleteTransactionById(string id)
        {
            Transaction? transaction = this.GetById(id);
            if (transaction is null)
            {
                return;
            }

            this._transactions.Remove(transaction);
        }

        /// <summary>
        /// Checks if any transactions exists
        /// </summary>
        /// <returns>true if any transaction exists, false if it is empty</returns>
        public bool HasAny()
        {
            return this._transactions.Any();
        }

        /// <summary>
        /// Get the expense from the repository
        /// </summary>
        /// <returns>returns a list of expenses</returns>
        public IReadOnlyList<Transaction> GetExpense()
        {
            return this._transactions.Where(x => x.Type == TransactionType.Expense).ToList();
        }

        /// <summary>
        /// Get the expense from the repository
        /// </summary>
        /// <returns>returns a list of expenses</returns>
        public IReadOnlyList<Transaction> GetIncome()
        {
            return this._transactions.Where(x => x.Type == TransactionType.Income).ToList();
        }

        /// <summary>
        /// Edit the transactions in the repository
        /// </summary>
        /// <param name="editedTransaction">Edit the transaction</param>
        /// <param name="id">Unique transaction identifier</param>
        /// <returns>True if edited; otherwise false</returns>
        public bool Edit(TransactionDTO editedTransaction, string id)
        {
            Transaction? transaction = this.GetById(id);
            if (transaction is null)
            {
                return false;
            }

            transaction.Description = editedTransaction.Description;
            transaction.Date = editedTransaction.Date;
            transaction.Amount = editedTransaction.Amount;
            transaction.Category = editedTransaction.Category;
            return true;
        }

        /// <summary>
        /// Get the transaction copy
        /// </summary>
        /// <param name="id">Unique identifier of the transaction</param>
        /// <returns>A transaction instance</returns>
        internal Transaction? GetTransactionCopy(string id)
        {
            Transaction? transaction = this.GetById(id);
            if (transaction is null)
            {
                return null;
            }

            return new Transaction(transaction.Id, transaction.Description, transaction.Date, transaction.Type, transaction.Category, transaction.Amount);
        }

        /// <summary>
        /// Get the transaction with a Id
        /// </summary>
        /// <param name="id">Id to find the transaction</param>
        /// <returns>Transaction object</returns>
        private Transaction? GetById(string id)
        {
            return this._transactions.FirstOrDefault(x => id == x.Id);
        }

        private Transaction Copy(Transaction transaction)
        {
            return new Transaction(transaction.Id, transaction.Description, transaction.Date, transaction.Type, transaction.Category, transaction.Amount);
        }
    }
}
