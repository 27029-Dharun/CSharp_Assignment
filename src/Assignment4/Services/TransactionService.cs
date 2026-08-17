using Assignment4.DTOs;
using Assignment4.Helper;
using Assignment4.Models;
using Assignment4.Models.Enums;
using Assignment4.Repository;

namespace Assignment4.Services
{
    /// <summary>
    /// Contains the business logic for transactions, perform validation and create transaction instances
    /// </summary>
    internal class TransactionService
    {
        private readonly IRepository _repository;
        private readonly TransactionIdGenerator _idGenerator;

        /// <summary>
        /// Initializes a new instance of the <see cref="TransactionService"/> class.
        /// </summary>
        /// <param name="idGenerator">Id Generator instance</param>
        /// <param name="repository">repository instance</param>
        public TransactionService(TransactionIdGenerator idGenerator, IRepository repository)
        {
            this._idGenerator = idGenerator;
            this._repository = repository;
        }

        /// <summary>
        /// Creates a Transaction instance and returns it.
        /// </summary>
        /// <param name="transaction">An instance of transaction DTO</param>
        public void CreateTransaction(TransactionDTO transaction)
        {
            string id = this._idGenerator.GetNextId(transaction.Type);
            Transaction createdTransaction = new Transaction(id, transaction.Description, transaction.Date, transaction.Type, transaction.Category, transaction.Amount);
            this._repository.Add(createdTransaction);
        }

        /// <summary>
        /// Deletes the transaction by id
        /// </summary>
        /// <param name="id">Unique id of the transaction to be deleted</param>
        internal void DeleteTransaction(string id)
        {
            this._repository.DeleteTransactionById(id);
        }

        /// <summary>
        /// Update the existing transaction.
        /// </summary>
        /// <param name="editedTransaction"> Transaction to be updated in the place of existing transaction. </param>
        /// <param name="id"> Unique identifier of the transaction. </param>
        /// <returns> True if the update process is done; otherwise false. </returns>
        internal bool UpdateTransaction(TransactionDTO editedTransaction, string id)
        {
            if (this._repository.Edit(editedTransaction, id))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Get the expense from the repository
        /// </summary>
        /// <returns>returns a list of expenses</returns>
        internal IReadOnlyList<Transaction> GetExpense()
        {
            return this._repository.GetExpense();
        }

        /// <summary>
        /// Get the income from the repository
        /// </summary>
        /// <returns>  list of incomes</returns>
        internal IReadOnlyList<Transaction> GetIncome()
        {
            return this._repository.GetIncome();
        }

        /// <summary>
        /// Gets all the transactions from the repository
        /// </summary>
        /// <returns>List of transaction</returns>
        internal IReadOnlyList<Transaction> GetAllTransaction()
        {
            return this._repository.GetAll();
        }

        /// <summary>
        /// Checks if the id is valid.
        /// </summary>
        /// <param name="id">Id of the transaction to be validated</param>
        /// <returns>boolean true if valid</returns>
        internal bool IsValidTransactionId(string id)
        {
            return this._repository.IsValidId(id);
        }

        /// <summary>
        /// Gets the transaction by id.
        /// </summary>
        /// <param name="id">Id of the transaction. </param>
        /// <returns> Transaction Instance if it is present; otherwise null. </returns>
        internal TransactionDTO? GetTransactionById(string id)
        {
            Transaction? transaction = this._repository.GetTransactionCopy(id);
            if (transaction is null)
            {
                return null;
            }

            return new TransactionDTO(transaction.Description, transaction.Date, transaction.Type, transaction.Category, transaction.Amount);
        }

        /// <summary>
        /// Check if any transactions exists
        /// </summary>
        /// <returns>true if any transaction exists; otherwise false. </returns>
        internal bool CheckTransactionsExist()
        {
            return this._repository.HasAny();
        }

        /// <summary>
        /// Generates the summary of the transaction
        /// </summary>
        /// <returns>Transaction summary instance that contains the summary data</returns>
        internal TransactionSummary GenerateSummary()
        {
            IReadOnlyList<Transaction> transactions = this._repository.GetAll();
            decimal income = 0;
            decimal expense = 0;

            foreach (Transaction transaction in transactions)
            {
                if (transaction.Type == TransactionType.Expense)
                {
                    expense += transaction.Amount;
                }
                else
                {
                    income += transaction.Amount;
                }
            }

            decimal monthlyExpense = transactions.Where(transaction => transaction.Date.Month == DateTime.Now.Month && transaction.Type == TransactionType.Expense).Sum(transaction => transaction.Amount);
            decimal monthlyIncome = transactions.Where(transaction => transaction.Date.Month == DateTime.Now.Month && transaction.Type == TransactionType.Income).Sum(transaction => transaction.Amount);

            return new TransactionSummary(income, expense, monthlyExpense, monthlyIncome);
        }

        /// <summary>
        /// Gets the matching
        /// </summary>
        /// <param name="query">Query entered by the user</param>
        /// <param name="option">Option to search</param>
        /// <returns>A list containing the transactions that matches the query text</returns>
        internal IReadOnlyList<Transaction> GetSearchResult(string query, int option)
        {
            return this._repository.Search(query, option);
        }

        /// <summary>
        /// Gets the income in the sorted order based on the user input.
        /// </summary>
        /// <param name="option"> Option to sort ascending or descending. </param>
        /// <returns> A list of income sorted based on user preference. </returns>
        internal IReadOnlyList<Transaction> GetSortedIncome(int option)
        {
            if (option == 1)
            {
                return this._repository.GetAll().Where(x => x.Type == TransactionType.Income).OrderBy(x => x.Amount).ToList();
            }

            return this._repository.GetAll().Where(x => x.Type == TransactionType.Income).OrderByDescending(x => x.Amount).ToList();
        }

        /// <summary>
        /// Gets the expense in the sorted order based on the user input.
        /// </summary>
        /// <param name="option"> Option to sort ascending or descending. </param>
        /// <returns> A list of expense sorted based on user preference. </returns>
        internal IReadOnlyList<Transaction> GetSortedExpense(int option)
        {
            if (option == 1)
            {
                return this._repository.GetAll().Where(x => x.Type == TransactionType.Expense).OrderBy(x => x.Amount).ToList();
            }

            return this._repository.GetAll().Where(x => x.Type == TransactionType.Expense).OrderByDescending(x => x.Amount).ToList();
        }
    }
}
