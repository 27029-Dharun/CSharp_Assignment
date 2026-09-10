using ExpenseTracker.DTOs;
using ExpenseTracker.Models;
using ExpenseTracker.Repository;

namespace ExpenseTracker.Services
{
    /// <summary>
    /// Contains the business logic for transactions, perform validation and create transaction instances.
    /// </summary>
    public class TransactionService
    {
        private readonly ITransactionRepository _repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="TransactionService"/> class.
        /// </summary>
        /// <param name="repository">The repository instance injected through dependency injection.</param>
        public TransactionService(ITransactionRepository repository)
        {
            this._repository = repository;
        }

        /// <summary>
        /// Creates a Transaction and returns it.
        /// </summary>
        /// <param name="transaction">A <see cref="TransactionDTO"/> containing transaction details.</param>
        public void CreateTransaction(TransactionDTO transaction)
        {
            Transaction createdTransaction = new Transaction(
                transaction.Description,
                transaction.Date,
                transaction.Type,
                transaction.Category,
                transaction.Amount);
            this._repository.Add(createdTransaction);
        }

        /// <summary>
        /// Deletes the transaction by id.
        /// </summary>
        /// <param name="id">Unique id of the transaction to be deleted.</param>
        public void DeleteTransaction(string id)
        {
            this._repository.DeleteTransactionById(id);
        }

        /// <summary>
        /// Update the existing transaction.
        /// </summary>
        /// <param name="editedTransaction"> Transaction to be updated in the place of existing transaction. </param>
        /// <returns> True if the update process is done; otherwise false. </returns>
        public bool EditTransaction(Transaction editedTransaction)
        {
            if (this._repository.Edit(editedTransaction))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Get the expense from the repository.
        /// </summary>
        /// <returns>returns a list of expenses.</returns>
        public IReadOnlyList<Transaction> GetExpense()
        {
            return this._repository.GetExpense();
        }

        /// <summary>
        /// Get the income from the repository.
        /// </summary>
        /// <returns>  list of incomes.</returns>
        public IReadOnlyList<Transaction> GetIncome()
        {
            return this._repository.GetIncome();
        }

        /// <summary>
        /// Gets all the transactions from the repository.
        /// </summary>
        /// <returns>List of transaction.</returns>
        public IReadOnlyList<Transaction> GetAllTransaction()
        {
            return this._repository.GetAll();
        }

        /// <summary>
        /// Checks if the id is valid.
        /// </summary>
        /// <param name="id">Id of the transaction to be validated.</param>
        /// <returns>boolean true if valid.</returns>
        public bool IsValidTransactionId(string id)
        {
            return this._repository.IsValidId(id);
        }

        /// <summary>
        /// Gets the transaction by id.
        /// </summary>
        /// <param name="id">Id of the transaction. </param>
        /// <returns> Transaction Instance if it is present; otherwise null. </returns>
        public Transaction? GetTransactionById(string id)
        {
            return this._repository.GetTransactionCopy(id);
        }

        /// <summary>
        /// Check if any transactions exists.
        /// </summary>
        /// <returns>true if any transaction exists; otherwise false. </returns>
        public bool HasTransactions()
        {
            return this._repository.HasAny();
        }

        /// <summary>
        /// Generates the summary of the transaction.
        /// </summary>
        /// <returns>Transaction summary instance that contains the summary data.</returns>
        public TransactionSummary GenerateSummary()
        {
            IReadOnlyList<Transaction> transactions = this._repository.GetAll();

            decimal income = transactions
                .Where(transaction => transaction.Type == TransactionType.Income)
                .Sum(transaction => transaction.Amount);

            decimal expense = transactions
                .Where(transaction => transaction.Type == TransactionType.Expense)
                .Sum(transaction => transaction.Amount);

            int currentYear = DateTime.Now.Year;
            int currentMonth = DateTime.Now.Month;

            IReadOnlyList<Transaction> currentMonthTransaction = transactions
                .Where(transaction => transaction.Date.Month == currentMonth && transaction.Date.Year == currentYear)
                .ToList();

            decimal currentIncome = currentMonthTransaction
                .Where(transaction => transaction.Type == TransactionType.Income)
                .Sum(transaction => transaction.Amount);

            decimal currentExpense = currentMonthTransaction
                .Where(transaction => transaction.Type == TransactionType.Expense)
                .Sum(transaction => transaction.Amount);

            Dictionary<string, decimal> categoryWiseExpense = transactions
                .Where(transaction => transaction.Type == TransactionType.Expense)
                .GroupBy(transaction => transaction.Category)
                .ToDictionary(
                    group => group.Key,
                    group => group.Sum(transaction => transaction.Amount));

            Dictionary<string, decimal> categoryWiseIncome = transactions
                .Where(transaction => transaction.Type == TransactionType.Income)
                .GroupBy(transaction => transaction.Category)
                .ToDictionary(
                    group => group.Key,
                    group => group.Sum(transaction => transaction.Amount));

            return new TransactionSummary(income, expense, currentIncome, currentExpense, categoryWiseIncome, categoryWiseExpense);
        }

        /// <summary>
        /// Gets the income in the sorted order based on the user input.
        /// </summary>
        /// <param name="option">The option to sort the income.</param>
        /// <returns>The list of income in sorted order.</returns>
        public IReadOnlyList<Transaction> GetSortedIncome(SortOption option)
        {
            return this._repository.Sort(TransactionType.Income, option);
        }

        /// <summary>
        /// Gets the expense in the sorted order based on the user input.
        /// </summary>
        /// <param name="option">The option to sort the expense.</param>
        /// <returns>The list of income in sorted order.</returns>
        public IReadOnlyList<Transaction> GetSortedExpense(SortOption option)
        {
            return this._repository.Sort(TransactionType.Expense, option);
        }

        /// <summary>
        /// Gets the transactions with matching date.
        /// </summary>
        /// <param name="date">Date of the transaction to search.</param>
        /// <returns>A list of transactions with matching date.</returns>
        public IReadOnlyList<Transaction> SearchByDate(DateTime date)
        {
            return this._repository.Search(t => t.Date.Date == date.Date);
        }

        /// <summary>
        /// Gets the transactions with matching category.
        /// </summary>
        /// <param name="category">Category of the transaction to search.</param>
        /// <returns>A list of transactions with matching category.</returns>
        public IReadOnlyList<Transaction> SearchByCategory(string category)
        {
            return this._repository.Search(t => t.Category == category);
        }
    }
}
