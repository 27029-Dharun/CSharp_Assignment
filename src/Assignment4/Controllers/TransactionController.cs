using Assignment4.DTOs;
using Assignment4.Models;
using Assignment4.Models.Enums;
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
        /// <param name="service">Instance of service</param>
        /// <param name="view">Instance of view</param>
        /// <param name="inputHandler">Instance of input handler</param>
        public TransactionController(TransactionService service, ConsoleView view)
        {
            this._service = service;
            this._view = view;
        }

        /// <summary>
        /// Handles the menu returns from the application runner.
        /// </summary>
        /// <param name="menu">Menu option selected from the user</param>
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

                case TransactionMenu.Exit:
                    return;
            }
        }

        private void CreateTransaction()
        {
            // Creates the transaction DTO
            TransactionDTO? transaction = this.GetCreateTransactionInput();
            if (transaction is null)
            {
                this._view.PrintError("Transaction failed, Please try again");
                return;
            }

            this._service.CreateTransaction(transaction);

            this._view.PrintSuccess("Transaction created successfully !!");
            this.ViewAllTransaction();
        }

        /// <summary>
        /// Handles view all the transaction
        /// </summary>
        private void ViewTransaction()
        {
            if (!this._service.CheckTransactionsExist())
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
            }

            this._view.PrintTransactionTable(income);
        }

        private void ViewExpense()
        {
            IReadOnlyList<Transaction> expense = this._service.GetExpense();
            if (!expense.Any())
            {
                this._view.PrintInfo("No expense recorded");
            }

            this._view.PrintTransactionTable(expense);
        }

        private void ViewSummary()
        {
            if (!this._service.CheckTransactionsExist())
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
            if (!this._service.CheckTransactionsExist())
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

            if (!this._service.UpdateTransaction(transaction))
            {
                this._view.PrintError("Failed to update the transaction.");
                return;
            }

            this._view.ClearConsole();
            this._view.PrintSuccess($"{type} edited successfully !!\n");
            this.ViewAllTransaction();
        }

        private void DeleteTransaction()
        {
            if (!this._service.CheckTransactionsExist())
            {
                this._view.PrintInfo("No transactions to delete");
                return;
            }

            string id = this.GetTransactionId();
            if (!this._service.IsValidTransactionId(id))
            {
                this._view.PrintInfo("Invalid transaction id to delete");
                return;
            }

            this._service.DeleteTransaction(id);
            this._view.PrintSuccess("Transaction deleted successfully !!");
            this.ViewAllTransaction();
        }

        private string GetTransactionId()
        {
            IReadOnlyList<Transaction> transactions = this._service.GetAllTransaction();
            this._view.PrintTransactionTable(transactions);
            return this._view.GetString("Select the transaction by id: ");
        }

        /// <summary>
        /// Gets the data for editing a transaction
        /// </summary>
        /// <param name="transaction">A transaction instance</param>
        private void EditTransactionInputHandler(Transaction transaction)
        {
            string category = this._view.GetValidCategory($"Enter the category of the {transaction.Type}: ");
            if (!string.IsNullOrWhiteSpace(category))
            {
                transaction.Category = category;
            }

            string amount = this._view.GetValidAmount("Enter the amount involved in the transaction: ", true);
            if (!string.IsNullOrWhiteSpace(amount))
            {
                transaction.Amount = decimal.Parse(amount);
            }

            string date = this._view.GetValidDate(true);
            if (!string.IsNullOrWhiteSpace(date))
            {
                transaction.Date = DateTime.Parse(date);
            }

            string description = this._view.GetValidDescription("Enter the description of the transaction: ", true);
            if (!string.IsNullOrWhiteSpace(description))
            {
                transaction.Description = description;
            }
        }

        private void SortTransactionByAmount()
        {
            if (!this._service.CheckTransactionsExist())
            {
                this._view.PrintInfo("No transactions to sort.");
                return;
            }

            int option = this._view.GetInteger("Sort amount by\n1. Ascending\n2. Descending\nSelect one of the above option: ");

            IReadOnlyList<Transaction> filteredIncome = this._service.GetSortedIncome(option);
            IReadOnlyList<Transaction> filteredExpense = this._service.GetSortedExpense(option);
            this._view.PrintTransactionTable(filteredIncome);
            this._view.PrintTransactionTable(filteredExpense);
        }

        private void SearchTransaction()
        {
            if (!this._service.CheckTransactionsExist())
            {
                this._view.PrintInfo("No transactions to search.");
                return;
            }

            int option = this._view.GetInteger("1. Category\n2. Date\nSelect the field to search with: ");
            string query;
            if (option == 1)
            {
                query = this._view.GetValidCategory($"Enter the category to search: ");
            }
            else if (option == 2)
            {
                query = this._view.GetValidDate();
            }
            else
            {
                this._view.PrintInfo("Please enter a valid field to search.");
                return;
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
        /// <returns>Transaction data instance</returns>
        private TransactionDTO? GetCreateTransactionInput()
        {
            TransactionType type = this._view.GetEnumValue<TransactionType>("Select the type of the transaction: ");
            string category = this._view.GetValidCategory($"Enter the category of {type}: ");
            decimal amount = decimal.Parse(this._view.GetValidAmount("Enter the amount involved in the transaction: "));
            DateTime date = DateTime.Parse(this._view.GetValidDate());
            string description = this._view.GetValidDescription("Enter the description: ");

            // Creates the transaction DTO
            return new TransactionDTO(description, date, type, category, amount);
        }
    }
}
