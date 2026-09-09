using ExpenseTracker.Helper;
using ExpenseTracker.Models;

namespace ExpenseTracker.Repository
{
    /// <summary>
    /// Transactions are stored as list of Transaction.
    /// </summary>
    public class TransactionRepository : ITransactionRepository
    {
        private readonly List<Transaction> _transactions;
        private readonly JsonFileManager _jsonFileManager;
        private string _filePath;
        private TransactionIdGenerator _idGenerator;

        /// <summary>
        /// Initializes a new instance of the <see cref="TransactionRepository"/> class.
        /// </summary>
        /// <param name="path">Path where the file is to be saved.</param>
        /// <param name="fileManager">File manager instance.</param>
        /// <param name="idGenerator">ID generator instance.</param>
        public TransactionRepository(string path, JsonFileManager fileManager, TransactionIdGenerator idGenerator)
        {
            this._filePath = path;
            this._jsonFileManager = fileManager;
            this._idGenerator = idGenerator;
            if (!File.Exists(this._filePath))
            {
                File.WriteAllText(this._filePath, "[]");
                this._transactions = new List<Transaction>();
                return;
            }

            this._transactions = this._jsonFileManager.LoadAll(this._filePath);
        }

        /// <inheritdoc/>
        public void Add(Transaction transaction)
        {
            transaction.Id = this._idGenerator.GetNextId(transaction.Type);
            this._transactions.Add(transaction);
            this._jsonFileManager.WriteAll(this._filePath, this._transactions);
        }

        /// <inheritdoc/>
        public IReadOnlyList<Transaction> GetAll()
        {
            return this._transactions.Select(this.Copy).ToList();
        }

        /// <inheritdoc/>
        public IReadOnlyList<Transaction> GetExpense()
        {
            return this._transactions.Where(x => x.Type == TransactionType.Expense).ToList();
        }

        /// <inheritdoc/>
        public IReadOnlyList<Transaction> GetIncome()
        {
            return this._transactions.Where(x => x.Type == TransactionType.Income).ToList();
        }

        /// <inheritdoc/>
        public void DeleteTransactionById(string id)
        {
            Transaction? transaction = this.GetById(id);
            if (transaction is null)
            {
                return;
            }

            this._transactions.Remove(transaction);
            this._jsonFileManager.WriteAll(this._filePath, this._transactions);
        }

        /// <inheritdoc/>
        public bool Edit(Transaction editedTransaction)
        {
            Transaction? transaction = this.GetById(editedTransaction.Id);
            if (transaction is null)
            {
                return false;
            }

            transaction.Description = editedTransaction.Description;
            transaction.Date = editedTransaction.Date;
            transaction.Amount = editedTransaction.Amount;
            transaction.Category = editedTransaction.Category;
            this._jsonFileManager.WriteAll(this._filePath, this._transactions);
            return true;
        }

        /// <inheritdoc/>
        public bool IsValidId(string id)
        {
            if (this._transactions.FirstOrDefault(x => id == x.Id) is not null)
            {
                return true;
            }

            return false;
        }

        /// <inheritdoc/>
        public bool HasAny()
        {
            return this._transactions.Any();
        }

        /// <inheritdoc/>
        public Transaction? GetTransactionCopy(string id)
        {
            Transaction? transaction = this.GetById(id);
            if (transaction is null)
            {
                return null;
            }

            return this.Copy(transaction);
        }

        /// <inheritdoc/>
        public IReadOnlyList<Transaction> Search(Func<Transaction, bool> predicate)
        {
            return this._transactions.Where(predicate).ToList();
        }

        /// <inheritdoc/>
        public IReadOnlyList<Transaction> Sort(TransactionType type, SortOption option)
        {
            var filteredType = this._transactions.Where(t => t.Type == type);
            if (option == SortOption.Ascending)
            {
                return this._transactions.OrderBy(x => x.Amount).ToList();
            }
            else
            {
                return this._transactions.OrderByDescending(x => x.Amount).ToList();
            }
        }

        /// <summary>
        /// Get the transaction with a Id.
        /// </summary>
        /// <param name="id">Id to find the transaction.</param>
        /// <returns>Transaction object.</returns>
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
