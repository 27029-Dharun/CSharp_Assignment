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
    internal class TransactionController
    {
        private readonly TransactionService _service;
        private readonly ConsoleView _view;

        /// <summary>
        /// Initializes a new instance of the <see cref="TransactionController"/> class.
        /// </summary>
        /// <param name="service">Instance of service</param>
        /// <param name="view">Instance of view</param>
        public TransactionController(TransactionService service, ConsoleView view)
        {
            this._service = service;
            this._view = view;
        }

        /// <summary>
        /// Handles the menu returns from the application runner
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

                case TransactionMenu.Exit:
                    return;
            }
        }

        private void CreateTransaction()
        {
            // gets the type of transaction income/expense
            TransactionType type = this._view.GetEnumValue<TransactionType>("Select the type of the transaction: ");

            // gets the category of the transaction
            this._view.ClearConsole();
            string? category = this.GetCategory(type);
            if (category is null)
            {
                this._view.PrintError("Transaction failed, Please try again");
                return;
            }

            // Gets the amount involved in the transaction
            this._view.ClearConsole();
            bool valid = this._view.GetDecimal($"Enter the {type} amount: ", out decimal amount);
            if (!valid)
            {
                this._view.PrintError("Transaction failed, Please try again");
                return;
            }

            // Gets the date of the transaction
            this._view.ClearConsole();
            valid = this._view.GetDate(out DateTime date);
            if (!valid)
            {
                this._view.PrintError("Transaction failed, Please try again\n");
                return;
            }

            // Gets the description
            this._view.ClearConsole();
            valid = this._view.GetString($"Enter the {type} description: ", out string description);
            if (!valid)
            {
                this._view.PrintError("Transaction failed, Please try again");
                return;
            }

            // Creates the transaction DTO
            TransactionDTO transaction = new TransactionDTO(description, date, type, category, amount);

            if (!this._service.CreateTransaction(transaction, out string validationOutput))
            {
                this._view.PrintWarning(validationOutput);
            }

            this._view.PrintSuccess("Transaction created successfully !!");
            this.ViewAllTransaction();
        }

        /// <summary>
        /// View all the transaction
        /// </summary>
        private void ViewTransaction()
        {
            if (!this._service.CheckTransactionsExist())
            {
                this._view.PrintInfo("No transactions to view");
                return;
            }

            ViewTransactionOption? option = this._view.GetEnumValue<ViewTransactionOption>("\nEnter the option to view: ");
            if (option is null)
            {
                this._view.PrintInfo("Invalid option, Please try again");
                return;
            }

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
            TransactionSummary summary = this._service.GenerateSummary();
            this._view.PrintInfo($"Total income: {summary.Income}");
            this._view.PrintInfo($"Total expense: {summary.Expense}");
            this._view.PrintInfo($"Balance amount: {summary.GetBalance()}");
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

            TransactionDTO? transaction = this._service.GetTransactionById(id);
            if (transaction is null)
            {
                this._view.PrintWarning("Enter a valid transaction id");
                return;
            }

            TransactionType type = transaction.Type;

            int option = this._view.GetOptionalInteger("Enter the field to edit.\n1. Category\n2. Amount\n3. Date\n4. Description\n");

            switch (option)
            {
                case 1:

                    string? category = this.GetCategory(type);
                    if (category is null)
                    {
                        this._view.PrintError("Failed to edit, please try again");
                        return;
                    }

                    transaction.Category = category;
                    break;

                case 2:

                    bool valid = this._view.GetDecimal($"Enter the {type} amount: ", out decimal amount);
                    if (!valid)
                    {
                        this._view.PrintError("Failed to edit, please try again");
                        return;
                    }

                    transaction.Amount = amount;
                    break;

                case 3:

                    if (!this._view.GetDate(out DateTime date))
                    {
                        this._view.PrintError("Failed to edit, please try again");
                        return;
                    }

                    transaction.Date = date;
                    break;

                case 4:
                    if (!this._view.GetString($"Enter the {type} title: ", out string description))
                    {
                        this._view.PrintError("Failed to edit, please try again");
                        return;
                    }

                    transaction.Description = description;
                    break;
            }

            if (!this._service.UpdateTransaction(transaction, id, out string outputValidation))
            {
                this._view.PrintError(outputValidation);
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

            string? id = this.GetTransactionId();
            if (id is null || !this._service.IsValidTransactionId(id))
            {
                this._view.PrintWarning("Enter a valid transaction id");
                return;
            }

            this._service.DeleteTransaction(id);
            this._view.PrintSuccess("Transaction deleted successfully !!");
            this.ViewAllTransaction();
        }

        private string? GetCategory(TransactionType? type)
        {
            if (type == TransactionType.Expense)
            {
                return this._view.GetEnumValue<ExpenseCategory>($"Select the category of the {type}: ").ToString();
            }
            else
            {
                return this._view.GetEnumValue<IncomeCategory>($"Select the category of the {type}: ").ToString();
            }
        }

        private string GetTransactionId()
        {
            IReadOnlyList<Transaction> transactions = this._service.GetAllTransaction();
            this._view.PrintTransactionTable(transactions);
            return this._view.GetOptionalString("Select the transaction by id: ");
        }
    }
}
