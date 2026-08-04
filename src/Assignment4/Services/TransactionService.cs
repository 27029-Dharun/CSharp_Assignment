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

        /// <summary>
        /// Initializes a new instance of the <see cref="TransactionService"/> class.
        /// </summary>
        /// <param name="validator">Validator object</param>
        public TransactionService(TransactionValidator validator)
        {
            this._validator = validator;
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
        public Transaction CreateTransaction(string name, DateTime date, TransactionType type, TransactionCategory category, decimal amount)
        {
            string id = this.GenerateTransactionId(type);
            return new Transaction(id, name, date, type, category, amount);
        }

        /// <summary>
        /// Validates the transaction fiels
        /// </summary>
        /// <param name="name">Title of the transaction</param>
        /// <param name="date">Date of the transaction</param>
        /// <param name="type">Type of the transaction</param>
        /// <param name="category">Category of the transaction</param>
        /// <param name="amount">Amount of the transaction</param>
        /// <returns>returns the validation output and empty string if are fiels are valid</returns>
        public string ValidateTransaction(string name, DateTime date, TransactionType type, TransactionCategory category, decimal amount)
        {
            string nameValidator = this._validator.ValidateTitle(name);
            string dateValidator = this._validator.ValidateDate(date);
            string amountValidator = this._validator.ValidateAmount(amount);

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
        internal List<Transaction> GetExpense()
        {
            List<Transaction> transactions = this._repository.GetAll().ToList();

            var filtered = transactions.Where(x => x.Type == TransactionType.Expense).ToList();
            return filtered;
        }

        /// <summary>
        /// Get the income from the repository
        /// </summary>
        /// <returns>returns a list of incomes</returns>
        internal List<Transaction> GetIncome()
        {
            List<Transaction> transactions = this._repository.GetAll().ToList();

            var filtered = transactions.Where(x => x.Type == TransactionType.Income).ToList();
            return filtered;
        }

        /// <summary>
        /// Generates transaction id for the transaction
        /// </summary>
        /// <param name="type">Transaction type</param>
        /// <returns>unique transaction id</returns>
        private string GenerateTransactionId(TransactionType type)
        {
            int eId = 100;
            int iId = 100;

            if (type == TransactionType.Expense)
            {
                return "E" + (eId++);
            }

            return "I" + (iId++);
        }
    }
}
