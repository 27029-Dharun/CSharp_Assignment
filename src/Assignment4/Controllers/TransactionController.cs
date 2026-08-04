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
        private TransactionService _service;
        private ConsoleView _view;

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
        /// Expense Tracker application entry point
        /// </summary>
        public void RunExpenseTracker()
        {
            this._view.PrintInfo("Expense Tracker Application\n");
            while (true)
            {
                int option = this.GetMenuOption(7);
                TransactionMenu menu = (TransactionMenu)option;

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
        }

        /// <summary>
        /// View all the transaction
        /// </summary>
        private void ViewTransaction()
        {
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
            throw new NotImplementedException();
        }

        private void DeleteTransaction()
        {
            string id = this.GetTransactionId();
            if (!this._service.IsValidTransactionId(id))
            {
                this._view.PrintInfo("Enter a valid transaction id");
                return;
            }

            this._service.DeleteTransaction(id);
            this._view.PrintInfo("Transaction deleted successfully !!");
        }

        private void EditTransaction()
        {
            string id = this.GetTransactionId();
            if (!this._service.IsValidTransactionId(id))
            {
                this._view.PrintInfo("Enter a valid transaction id");
                return;
            }
        }

        private void CreateTransaction()
        {
            TransactionType type = this._view.GetEnumValues<TransactionType>("Select the Type of the transaction: ");
            string title = this._view.GetString($"Enter the {type} title: ");
            if (title == string.Empty)
            {
                this._view.PrintInfo("Transaction failed, Please try again");
                return;
            }

            decimal amount = this._view.GetDecimal($"Enter the {type} amount: ");
            if (amount == -1)
            {
                this._view.PrintInfo("Transaction failed, Please try again");
                return;
            }

            DateTime date = this._view.GetDate();
            if (date == DateTime.MinValue)
            {
                this._view.PrintInfo("Transaction failed, Please try again");
                return;
            }

            TransactionCategory category = this._view.GetEnumValues<TransactionCategory>("Select the category of the transaction: ");

            string validatedoutput = this._service.ValidateTransaction(title, date, type, category, amount);

            if (!string.IsNullOrEmpty(validatedoutput))
            {
                this._view.PrintInfo(validatedoutput);
                return;
            }

            Transaction transaction = this._service.CreateTransaction(title, date, type, category, amount);
            this._service.AddTransaction(transaction);

            this._view.PrintInfo($"{type} added successfully");
        }

        private string GetTransactionId()
        {
            IReadOnlyList<Transaction> transactions = this._service.GetAllTransaction();
            this._view.PrintTransactionTable(transactions);
            string id = this._view.GetString("Select the transaction by id to delete: ");
            return id;
        }

        private int GetMenuOption(int max)
        {
            this._view.PrintInfo("1. Add expense or income\n2. Edit expense or income\n3. Delete income or expense\n4. View summary\n5. View transactions\n6. Exit\n");
            int option = this._view.GetInteger("Select an option to proceed: ");
            while (option > max)
            {
                this._view.PrintInfo($"Enter the Interger in range 1 - {max}");
                option = this._view.GetInteger("Select an option to proceed: ");
            }

            return option;
        }
    }
}
