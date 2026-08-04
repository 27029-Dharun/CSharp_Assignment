using Assignment4.Helper;
using Assignment4.Models;
using Assignment4.Models.Enums;
using Assignment4.Repository;
using Assignment4.Validation;

namespace Assignment4.Services
{
    /// <summary>
    /// Transaction Services
    /// </summary>
    internal class TransactionService
    {
        private TransactionValidator _validator;
        private TransactionRepository _repository = new TransactionRepository();
        private TransactionIdGenerator _idGenerator = new TransactionIdGenerator();

        /// <summary>
        /// Initializes a new instance of the <see cref="TransactionService"/> class.
        /// </summary>
        /// <param name="validator">Validator object</param>
        /// <param name="idGenerator">IdGenerator object</param>
        public TransactionService(TransactionValidator validator, TransactionIdGenerator idGenerator)
        {
            this._validator = validator;
            this._idGenerator = idGenerator;
        }

        /// <summary>
        /// Creates a Transaction object and returns it.
        /// </summary>
        /// <param name="name">Title of the transaction</param>
        /// <param name="date">Date of the transaction</param>
        /// <param name="type">Type of the transaction</param>
        /// <param name="category">Category of the transaction</param>
        /// <param name="amount">Amount of the transaction</param>
        /// <returns>returns a Transaction object</returns>
        public Transaction CreateTransaction(string name, DateTime date, TransactionType type, string category, decimal amount)
        {
            string id = this._idGenerator.GetNextId(type);
            return new Transaction(id, name, date, type, category, amount);
        }

        /// <summary>
        /// Validates the transaction fiels
        /// </summary>
        /// <param name="transaction">transaction object to be</param>
        /// <returns>returns the validation output and empty string if are fiels are valid</returns>
        public string ValidateTransaction(Transaction transaction)
        {
            string nameValidator = this._validator.ValidateTitle(transaction.Title);
            string dateValidator = this._validator.ValidateDate(transaction.Date);
            string amountValidator = this._validator.ValidateAmount(transaction.Amount);

            if (nameValidator != string.Empty || dateValidator != string.Empty || amountValidator != string.Empty)
            {
                return nameValidator + dateValidator + amountValidator;
            }

            return string.Empty;
        }

        /// <summary>
        /// Add a transaction to the Transaction list
        /// </summary>
        /// <param name="transaction">Transaction to be added</param>
        /// <returns>boolean value true if added</returns>
        public bool AddTransaction(Transaction transaction)
        {
            this._repository.Add(transaction);
            return true;
        }

        /// <summary>
        /// Get the expense from the repository
        /// </summary>
        /// <returns>returns a list of expenses</returns>
        internal IReadOnlyList<Transaction> GetExpense()
        {
            IReadOnlyList<Transaction> transactions = this._repository.GetAll();

            var filtered = transactions.Where(x => x.Type == TransactionType.Expense);
            return filtered.ToList();
        }

        /// <summary>
        /// Get the income from the repository
        /// </summary>
        /// <returns>returns a list of incomes</returns>
        internal IReadOnlyList<Transaction> GetIncome()
        {
            IReadOnlyList<Transaction> transactions = this._repository.GetAll();

            var filtered = transactions.Where(x => x.Type == TransactionType.Income);
            return filtered.ToList();
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
        /// Gets all the transactions from the repository
        /// </summary>
        /// <returns>list of transaction</returns>
        internal IReadOnlyList<Transaction> GetAllTransaction()
        {
            return this._repository.GetAll();
        }

        /// <summary>
        /// checks if the id is valid
        /// </summary>
        /// <param name="id">Id of the transaction to be validated</param>
        /// <returns>boolean true if valid</returns>
        internal bool IsValidTransactionId(string id)
        {
            if (this._repository.GetById(id) == null)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// get the transaction by id
        /// </summary>
        /// <param name="id">id of the transaction</param>
        /// <returns>Transaction with matching id</returns>
        internal Transaction? GetTransactionById(string id)
        {
            return this._repository.GetById(id);
        }

        /// <summary>
        /// Check if any transactions exists
        /// </summary>
        /// <returns>true if any transaction exists, false if it is empty</returns>
        internal bool CheckTransactionsExist()
        {
            return this._repository.IsAny();
        }

        /// <summary>
        /// Update the exisiting transaction
        /// </summary>
        /// <param name="editedTransaction">Transaction to be updated in the place of exisiting transaction</param>
        internal void UpdateTransaction(Transaction editedTransaction)
        {
            string id = editedTransaction.Id;
            Transaction? transaction = this._repository.GetById(id);
            if (transaction is null)
            {
                return;
            }

            transaction.Title = editedTransaction.Title;
            transaction.Date = editedTransaction.Date;
            transaction.Amount = editedTransaction.Amount;
            transaction.Category = editedTransaction.Category;
        }

        /// <summary>
        /// Generates the summary of the transaction
        /// </summary>
        /// <returns>TransactionsSummary object that contains the summary data</returns>
        internal TransactionSummary GenerateSummary()
        {
            IReadOnlyList<Transaction> transactions = this._repository.GetAll();
            decimal income = 0;
            decimal expense = 0;

            foreach (Transaction transaction in transactions)
            {
                if (transaction.Type == TransactionType.Expense)
                {
                    income += transaction.Amount;
                }
                else
                {
                    expense += transaction.Amount;
                }
            }

            return new TransactionSummary(income, expense);
        }
    }
}
