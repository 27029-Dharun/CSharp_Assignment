using Assignment4.DTOs;
using Assignment4.Helper;
using Assignment4.Models;
using Assignment4.Models.Enums;
using Assignment4.Repository;
using Assignment4.Validation;

namespace Assignment4.Services
{
    /// <summary>
    /// Contains the business logic for transactions, perform validation and create transaction instances
    /// </summary>
    internal class TransactionService
    {
        private readonly TransactionValidator _validator;
        private readonly TransactionRepository _repository;
        private readonly TransactionIdGenerator _idGenerator;

        /// <summary>
        /// Initializes a new instance of the <see cref="TransactionService"/> class.
        /// </summary>
        /// <param name="validator">Validator object</param>
        /// <param name="idGenerator">IdGenerator object</param>
        /// <param name="repository">repository object</param>
        public TransactionService(TransactionValidator validator, TransactionIdGenerator idGenerator, TransactionRepository repository)
        {
            this._validator = validator;
            this._idGenerator = idGenerator;
            this._repository = repository;
        }

        /// <summary>
        /// Creates a Transaction object and returns it.
        /// </summary>
        /// <param name="transaction">An instance of transaction DTO</param>
        /// <param name="validationOutput">A string telling representing the validation output. </param>
        /// <returns>A string output showing the status of the operation</returns>
        public bool CreateTransaction(TransactionDTO transaction, out string validationOutput)
        {
            validationOutput = this.ValidateTransaction(transaction);
            if (validationOutput == string.Empty)
            {
                return false;
            }

            string id = this._idGenerator.GetNextId(transaction.Type);
            Transaction createdTransaction = new Transaction(id, transaction.Description, transaction.Date, transaction.Type, transaction.Category, transaction.Amount);
            this._repository.Add(createdTransaction);
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
        /// Checks if the id is valid.
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
        /// Gets the transaction by id.
        /// </summary>
        /// <param name="id">Id of the transaction. </param>
        /// <returns> Transaction Instance if it is present; otherwise null. </returns>
        internal TransactionDTO? GetTransactionById(string id)
        {
            Transaction? transaction = this._repository.GetById(id);
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
            return this._repository.IsAny();
        }

        /// <summary>
        /// Update the existing transaction.
        /// </summary>
        /// <param name="editedTransaction"> Transaction to be updated in the place of existing transaction. </param>
        /// <param name="id"> Unique identifier of the transaction. </param>
        /// <param name="validationOutput"> Validation output. </param>
        /// <returns> True if the update process is done; otherwise false. </returns>
        internal bool UpdateTransaction(TransactionDTO editedTransaction, string id, out string validationOutput)
        {
            validationOutput = this.ValidateTransaction(editedTransaction);
            if (!string.IsNullOrEmpty(validationOutput))
            {
                return false;
            }

            Transaction? transaction = this._repository.GetById(id);
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
        /// Generates the summary of the transaction
        /// </summary>
        /// <returns>Transaction summary object that contains the summary data</returns>
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

            return new TransactionSummary(income, expense);
        }

        private string ValidateTransaction(TransactionDTO transaction)
        {
            string nameValidator = this._validator.ValidateTitle(transaction.Description);
            string dateValidator = this._validator.ValidateDate(transaction.Date);
            string amountValidator = this._validator.ValidateAmount(transaction.Amount);

            if (nameValidator != string.Empty || dateValidator != string.Empty || amountValidator != string.Empty)
            {
                return nameValidator + dateValidator + amountValidator;
            }

            return string.Empty;
        }
    }
}
