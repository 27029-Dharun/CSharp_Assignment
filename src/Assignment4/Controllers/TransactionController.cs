using Assignment4.DTOs;
using Assignment4.Models;
using Assignment4.Services;
using Assignment4.View;

namespace Assignment4.Controllers
{
    /// <summary>
    /// Coordinates operations between the view and services.
    /// </summary>
    public class TransactionController
    {
        private readonly TransactionService _service;
        private readonly ConsoleView _view;

        /// <summary>
        /// Initializes a new instance of the <see cref="TransactionController"/> class.
        /// </summary>
        /// <param name="service">The service instance injected through dependency injection.</param>
        /// <param name="view">The view instance injected through dependency injection.</param>
        public TransactionController(TransactionService service, ConsoleView view)
        {
            this._service = service;
            this._view = view;
        }

        /// <summary>
        /// Handles the menu returns from the application runner.
        /// </summary>
        /// <param name="menu">Menu option selected from the user.</param>
        public void HandleMenu(TransactionMenu menu)
        {
            switch (menu)
            {
                case TransactionMenu.AddTransaction:
                    this.CreateTransaction();
                    break;

                case TransactionMenu.EditTransaction:
                    this.EditTransaction();
                    break;

                case TransactionMenu.DeleteTransaction:
                    this.DeleteTransaction();
                    break;

                case TransactionMenu.ViewSummary:
                    this.ViewSummary();
                    break;

                case TransactionMenu.ViewTransaction:
                    this.ViewTransaction();
                    break;

                case TransactionMenu.Exit:
                    return;
            }
        }

        private void CreateTransaction()
        {
            // Creates the transaction DTO
            TransactionDTO transaction = this.GetTransactionInput();

            this._service.CreateTransaction(transaction);

            this._view.PrintSuccess("Transaction created successfully.");
            this.ViewAllTransaction();
        }

        private void ViewTransaction()
        {
            if (!this._service.HasTransactions())
            {
                this._view.PrintInfo("No transactions to view");
                return;
            }

            ViewTransactionOption option = this._view.GetEnumValue<ViewTransactionOption>("\nEnter the option to view: ");

            switch (option)
            {
                case ViewTransactionOption.Expense:
                    this.ViewExpense();
                    break;

                case ViewTransactionOption.Income:
                    this.ViewIncome();
                    break;

                case ViewTransactionOption.All:
                    this.ViewAllTransaction();
                    break;
            }
        }

        private void ViewAllTransaction()
        {
            IReadOnlyList<Transaction> transactions = this._service.GetAllTransaction();
            this._view.PrintTransactionTable(transactions);
        }

        private void ViewIncome()
        {
            IReadOnlyList<Transaction> income = this._service.GetIncome();
            if (!income.Any())
            {
                this._view.PrintInfo("No income recorded");
                return;
            }

            this._view.PrintTransactionTable(income);
        }

        private void ViewExpense()
        {
            IReadOnlyList<Transaction> expense = this._service.GetExpense();
            if (!expense.Any())
            {
                this._view.PrintInfo("No expense recorded");
                return;
            }

            this._view.PrintTransactionTable(expense);
        }

        private void ViewSummary()
        {
            if (!this._service.HasTransactions())
            {
                this._view.PrintInfo("No transactions available");
                return;
            }

            TransactionSummary summary = this._service.GenerateSummary();
            this._view.PrintInfo($"Total income: {summary.Income}");
            this._view.PrintInfo($"Total expense: {summary.Expense}");
            this._view.PrintInfo($"Balance amount: {summary.GetBalance()}");
        }

        private void EditTransaction()
        {
            if (!this._service.HasTransactions())
            {
                this._view.PrintInfo("No transactions to edit");
                return;
            }

            // Gets id of the transaction to edit
            string id = this.GetTransactionId();

            Transaction? transaction = this._service.GetTransactionById(id);
            if (transaction is null)
            {
                this._view.PrintWarning("Enter a valid transaction id.");
                return;
            }

            TransactionType type = transaction.Type;
            this.EditTransactionInputHandler(transaction);

            if (!this._service.EditTransaction(transaction))
            {
                this._view.PrintError("Failed to update the transaction.");
                return;
            }

            this._view.ClearConsole();
            this._view.PrintSuccess($"{type} edited successfully.\n");
            this.ViewAllTransaction();
        }

        private void DeleteTransaction()
        {
            if (!this._service.HasTransactions())
            {
                this._view.PrintInfo("No transactions to delete");
                return;
            }

            string id = this.GetTransactionId();
            if (!this._service.IsValidTransactionId(id))
            {
                this._view.PrintWarning("Invalid transaction ID to delete");
                return;
            }

            this._service.DeleteTransaction(id);
            this._view.PrintSuccess("Transaction deleted successfully.");
            this.ViewAllTransaction();
        }

        private string GetTransactionId()
        {
            IReadOnlyList<Transaction> transactions = this._service.GetAllTransaction();
            this._view.PrintTransactionTable(transactions);

            return this._view.GetId();
        }

        /// <summary>
        /// Gets the data for editing a transaction.
        /// </summary>
        /// <param name="transaction">A transaction instance.</param>
        private void EditTransactionInputHandler(Transaction transaction)
        {
            string category = this._view.GetCategory();
            if (!string.IsNullOrWhiteSpace(category))
            {
                transaction.Category = category;
            }

            string amount = this._view.GetAmount(true);
            if (!string.IsNullOrWhiteSpace(amount))
            {
                transaction.Amount = decimal.Parse(amount);
            }

            string date = this._view.GetDate(true);
            if (!string.IsNullOrWhiteSpace(date))
            {
                transaction.Date = DateTime.Parse(date);
            }

            string description = this._view.GetDescription(true);
            if (!string.IsNullOrWhiteSpace(description))
            {
                transaction.Description = description;
            }
        }

        /// <summary>
        /// Gets the input from the user for creating a transaction.
        /// </summary>
        /// <returns>Transaction data instance.</returns>
        private TransactionDTO GetTransactionInput()
        {
            TransactionType type = this._view.GetEnumValue<TransactionType>("Select the type of the transaction: ");
            string category = this._view.GetCategory();
            decimal amount = decimal.Parse(this._view.GetAmount());
            DateTime date = DateTime.Parse(this._view.GetDate());
            string description = this._view.GetDescription();

            // Creates the transaction DTO
            return new TransactionDTO(description, date, type, category, amount);
        }
    }
}
