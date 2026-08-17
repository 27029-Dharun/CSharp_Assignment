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
    public class TransactionService
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
        public void DeleteTransaction(string id)
        {
            this._repository.DeleteTransactionById(id);
        }

        /// <summary>
        /// Update the existing transaction.
        /// </summary>
        /// <param name="editedTransaction"> Transaction to be updated in the place of existing transaction. </param>
        /// <param name="id"> Unique identifier of the transaction. </param>
        /// <returns> True if the update process is done; otherwise false. </returns>
        public bool UpdateTransaction(TransactionDTO editedTransaction, string id)
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
        public IReadOnlyList<Transaction> GetExpense()
        {
            return this._repository.GetExpense();
        }

        /// <summary>
        /// Get the income from the repository
        /// </summary>
        /// <returns>  list of incomes</returns>
        public IReadOnlyList<Transaction> GetIncome()
        {
            return this._repository.GetIncome();
        }

        /// <summary>
        /// Gets all the transactions from the repository
        /// </summary>
        /// <returns>List of transaction</returns>
        public IReadOnlyList<Transaction> GetAllTransaction()
        {
            return this._repository.GetAll();
        }

        /// <summary>
        /// Checks if the id is valid.
        /// </summary>
        /// <param name="id">Id of the transaction to be validated</param>
        /// <returns>boolean true if valid</returns>
        public bool IsValidTransactionId(string id)
        {
            return this._repository.IsValidId(id);
        }

        /// <summary>
        /// Gets the transaction by id.
        /// </summary>
        /// <param name="id">Id of the transaction. </param>
        /// <returns> Transaction Instance if it is present; otherwise null. </returns>
        public TransactionDTO? GetTransactionById(string id)
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
        public bool CheckTransactionsExist()
        {
            return this._repository.HasAny();
        }

        /// <summary>
        /// Generates the summary of the transaction
        /// </summary>
        /// <returns>Transaction summary instance that contains the summary data</returns>
        public TransactionSummary GenerateSummary()
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
    }
}
