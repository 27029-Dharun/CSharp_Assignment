using Assignment4.Helper;
using Assignment4.Models;

namespace Assignment4.Repository
{
    /// <summary>
    /// Transactions are stored as list of Transaction.
    /// </summary>
    public class TransactionRepository : IRepository
    {
        private readonly TransactionIdGenerator _idGenerator;
        private readonly List<Transaction> _transactions = new List<Transaction>();

        /// <summary>
        /// Initializes a new instance of the <see cref="TransactionRepository"/> class.
        /// </summary>
        /// <param name="idGenerator">The instance of ID generator.</param>
        public TransactionRepository(TransactionIdGenerator idGenerator)
        {
            this._idGenerator = idGenerator;
        }

        /// <inheritdoc/>
        public void Add(Transaction transaction)
        {
            transaction.Id = this._idGenerator.GetNextId(transaction.Type);
            this._transactions.Add(transaction);
        }

        /// <inheritdoc/>
        public IReadOnlyList<Transaction> GetAll()
        {
            return this._transactions.Select(this.Copy).ToList();
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
        public void DeleteTransactionById(string id)
        {
            Transaction? transaction = this.GetById(id);
            if (transaction is null)
            {
                return;
            }

            this._transactions.Remove(transaction);
        }

        /// <inheritdoc/>
        public bool HasAny()
        {
            return this._transactions.Any();
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
            return true;
        }

        /// <inheritdoc/>
        public Transaction? GetTransactionCopy(string id)
        {
            Transaction? transaction = this.GetById(id);
            if (transaction is null)
            {
                return null;
            }

            return new Transaction(transaction.Id, transaction.Description, transaction.Date, transaction.Type, transaction.Category, transaction.Amount);
        }

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
