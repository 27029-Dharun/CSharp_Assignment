using Assignment4.Models;
using Assignment4.Models.Enums;
using Assignment4.Services;
using Assignment4.View;

namespace Assignment4.Controllers
{
    /// <summary>
    /// Transaction controller class
    /// </summary>
    internal class TransactionController
    {
        private readonly TransactionService _service;
        private readonly ConsoleView _view;

        /// <summary>
        /// Initializes a new instance of the <see cref="TransactionController"/> class.
        /// </summary>
        /// <param name="service">Service object</param>
        /// <param name="view">View Object</param>
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

            ViewTransactionOption option = this._view.GetEnumValues<ViewTransactionOption>("\nEnter the option to view: ");
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
            this._view.PrintTransactionTable(income);
        }

        private void ViewExpense()
        {
            IReadOnlyList<Transaction> expense = this._service.GetExpense();
            this._view.PrintTransactionTable(expense);
        }

        private void ViewSummary()
        {
            TransactionSummary summary = this._service.GenerateSummary();
            this._view.PrintInfo($"Total income: {summary.Income}");
            this._view.PrintInfo($"Total expense: {summary.Expense}");
            this._view.PrintInfo($"Balance amount: {summary.GetBalance()}");
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
                this._view.PrintWarning("Enter a valid transaction id");
                return;
            }

            this._service.DeleteTransaction(id);
            this._view.PrintSuccess("Transaction deleted successfully !!");
            this.ViewAllTransaction();
        }

        private void EditTransaction()
        {
            if (!this._service.CheckTransactionsExist())
            {
                this._view.PrintInfo("No transactions to edit");
                return;
            }

            string id = this.GetTransactionId();
            Transaction? transaction = this._service.GetTransactionById(id);
            if (transaction is null)
            {
                this._view.PrintError("Invalid Transaction id");
                return;
            }

            TransactionType type = transaction.Type;
            string category = this.GetCategory(type);

            this._view.PrintSeperator();
            decimal amount = this._view.GetOptinalDecimal($"Enter the {type} amount: ");
            if (amount == -1)
            {
                amount = transaction.Amount;
            }

            this._view.PrintSeperator();
            DateTime date = this._view.GetOptionalDate();
            if (date == DateTime.MinValue)
            {
                date = transaction.Date;
            }

            this._view.PrintSeperator();
            string title = this._view.GetOptionalString($"Enter the {type} title: ");
            if (title == string.Empty)
            {
                title = transaction.Title;
            }

            Transaction editedTransaction = this._service.CreateTransaction(title, date, type, category, amount, id);

            string validatedoutput = this._service.ValidateTransaction(editedTransaction);
            if (!string.IsNullOrEmpty(validatedoutput))
            {
                this._view.PrintWarning(validatedoutput);
                return;
            }

            this._service.UpdateTransaction(editedTransaction);
            this._view.PrintSeperator();
            this._view.PrintSuccess($"{type} edited successfully !!\n");
            this.ViewAllTransaction();
        }

        private void CreateTransaction()
        {
            TransactionType type = this._view.GetEnumValues<TransactionType>("Select the type of the transaction: ");

            this._view.PrintSeperator();
            string category = this.GetCategory(type);

            this._view.PrintSeperator();
            decimal amount = this._view.GetDecimal($"Enter the {type} amount: ");
            if (amount == -1)
            {
                this._view.PrintError("Transaction failed, Please try again");
                return;
            }

            this._view.PrintSeperator();
            DateTime date = this._view.GetDate();
            if (date == DateTime.MinValue)
            {
                this._view.PrintError("Transaction failed, Please try again\n");
                return;
            }

            this._view.PrintSeperator();
            string description = this._view.GetString($"Enter the {type} description: ");
            if (description == string.Empty)
            {
                this._view.PrintError("Transaction failed, Please try again");
                return;
            }

            Transaction transaction = this._service.CreateTransaction(description, date, type, category, amount);
            string validatedoutput = this._service.ValidateTransaction(transaction);
            if (!string.IsNullOrEmpty(validatedoutput))
            {
                this._view.PrintWarning(validatedoutput);
                return;
            }

            this._service.AddTransaction(transaction);
            this._view.PrintSeperator();
            this._view.PrintSuccess($"{type} added successfully !!");
            this.ViewAllTransaction();
        }

        private string GetCategory(TransactionType type)
        {
            if (type == TransactionType.Expense)
            {
                return this._view.GetEnumValues<ExpenseCategory>($"Select the category of the {type}: ").ToString();
            }
            else
            {
                return this._view.GetEnumValues<IncomeCategory>($"Select the category of the {type}: ").ToString();
            }
        }

        private string GetTransactionId()
        {
            IReadOnlyList<Transaction> transactions = this._service.GetAllTransaction();
            this._view.PrintTransactionTable(transactions);
            string id = this._view.GetString("Select the transaction by id to delete: ");
            return id;
        }
    }
}
