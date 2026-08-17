using System.Text.Json;
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
        private readonly List<Transaction> _transactions;
        private readonly string _filePath;

        /// <summary>
        /// Initializes a new instance of the <see cref="TransactionRepository"/> class.
        /// </summary>
        public TransactionRepository()
        {
            this._filePath = "transaction.json";
            if (!File.Exists(this._filePath))
            {
                File.WriteAllText(this._filePath, string.Empty);
                this._transactions = new List<Transaction>();
                return;
            }

            this._transactions = this.ReadAll();
        }

        /// <summary>
        /// Add a transaction to existing list
        /// </summary>
        /// <param name="transaction">A transaction object</param>
        public void Add(Transaction transaction)
        {
            this._transactions.Add(transaction);
            this.WriteAll();
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
            this.WriteAll();
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
            this.WriteAll();
            return true;
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
        /// Checks if any transactions exists
        /// </summary>
        /// <returns>true if any transaction exists, false if it is empty</returns>
        public bool HasAny()
        {
            return this._transactions.Any();
        }

        /// <summary>
        /// Get the transaction copy
        /// </summary>
        /// <param name="id">Unique identifier of the transaction</param>
        /// <returns>A transaction instance</returns>
        public Transaction? GetTransactionCopy(string id)
        {
            Transaction? transaction = this.GetById(id);
            if (transaction is null)
            {
                return null;
            }

            return new Transaction(transaction.Id, transaction.Description, transaction.Date, transaction.Type, transaction.Category, transaction.Amount);
        }

        /// <summary>
        /// Search the transaction by date and category
        /// </summary>
        /// <param name="query">Query text entered by the user</param>
        /// <param name="option">Option to sort by </param>
        /// <returns>A list containing the list that matched the query text</returns>
        public IReadOnlyList<Transaction> Search(string query, int option)
        {
            if (option == 2)
            {
                return this._transactions.Where(x => x.Date == DateTime.Parse(query)).ToList();
            }

            return this._transactions.Where(x => x.Category == query).ToList();
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

        private void WriteAll()
        {
            string json = JsonSerializer.Serialize(this._transactions);
            File.WriteAllText(this._filePath, json);
        }

        private List<Transaction> ReadAll()
        {
            string text = File.ReadAllText(this._filePath);
            List<Transaction>? transactions = JsonSerializer.Deserialize<List<Transaction>>(text);
            if (transactions is null)
            {
                return new List<Transaction>();
            }

            return transactions;
        }
    }
}
