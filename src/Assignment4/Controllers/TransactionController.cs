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

        private readonly string _menuMessage = "       FINANCE TRACKER - MAIN MENU       \n" +
                "[1] Add Transaction (Income/Expense)\n" +
                "[2] Edit Transaction\n" +
                "[3] Delete Transaction\n" +
                "[4] View Financial Summary\n" +
                "[5] View History / Transactions\n" +
                "[6] Search Transaction\n" +
                "[7] Sort Transaction\n" +
                "[8] Exit Application\n\n" +
                "Please enter your choice (1-8): ";

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
        /// Loops and get menu option until the user exits.
        /// </summary>
        public void Run()
        {
            TransactionMenu option = default;
            while (option != TransactionMenu.Exit)
            {
                option = this._view.GetEnumValue<TransactionMenu>(this._menuMessage);
                this._view.ClearConsole();
                if (option == TransactionMenu.Exit)
                {
                    return;
                }

                try
                {
                    this.HandleMenu(option);
                }
                catch (InvalidDataException ex)
                {
                    this._view.PrintInfo(ex.Message);
                }
                catch (Exception ex)
                {
                    this._view.PrintInfo(ex.Message);
                }

                this._view.PauseAndReturn();
            }
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

                case TransactionMenu.SearchTransaction:
                    this.SearchTransaction();
                    break;

                case TransactionMenu.SortTransaction:
                    this.SortTransactionByAmount();
                    break;
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

            ViewTransactionOption option = this._view.GetEnumValue<ViewTransactionOption>("1. View all expense\n2. View all income\n3. View all transactions\nEnter the option to view: ");

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
            this._view.PrintEmptyLine();
            this._view.PrintInfo($"Monthly income: {summary.MonthlyIncome}");
            this._view.PrintInfo($"Monthly expense: {summary.MonthlyExpense}");

            this._view.PrintSummary(summary);
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

        private void SortTransactionByAmount()
        {
            if (!this._service.HasTransactions())
            {
                this._view.PrintInfo("No transactions to sort.");
                return;
            }

            SortOption option = this._view.GetEnumValue<SortOption>("Sort amount by\n1. Ascending\n2. Descending\nSelect one of the above option: ");

            IReadOnlyList<Transaction> filteredIncome = this._service.GetSortedIncome(option);
            IReadOnlyList<Transaction> filteredExpense = this._service.GetSortedExpense(option);
            this._view.PrintTransactionTable(filteredIncome);
            this._view.PrintTransactionTable(filteredExpense);
        }

        private void SearchTransaction()
        {
            if (!this._service.HasTransactions())
            {
                this._view.PrintInfo("No transactions to search.");
                return;
            }

            SearchTransactionOption option = this._view.GetEnumValue<SearchTransactionOption>("1. Category\n2. Date\nSelect the field to search with: ");
            string query;
            if (option == SearchTransactionOption.Category)
            {
                query = this._view.GetValidCategory($"Enter the category to search: ");
            }
            else
            {
                query = this._view.GetDate();
            }

            IReadOnlyList<Transaction> filteredTransaction = this._service.GetSearchResult(query, option);
            if (!filteredTransaction.Any())
            {
                this._view.PrintInfo("No matched transactions found");
                return;
            }

            this._view.PrintTransactionTable(filteredTransaction);
        }

        /// <summary>
        /// Gets the input from the user for creating a transaction.
        /// </summary>
        /// <returns>Transaction data instance.</returns>
        private TransactionDTO GetTransactionInput()
        {
            TransactionType type = this._view.GetEnumValue<TransactionType>("1. Expense\n2. Income\nSelect the type of the transaction: ");
            string category = this._view.GetCategory();
            decimal amount = decimal.Parse(this._view.GetAmount());
            DateTime date = DateTime.Parse(this._view.GetDate());
            string description = this._view.GetDescription();

            // Creates the transaction DTO
            return new TransactionDTO(description, date, type, category, amount);
        }
    }
}
