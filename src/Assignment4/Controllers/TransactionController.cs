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

                    case TransactionMenu.ViewExpense:
                        this.ViewExpense();
                        break;

                    case TransactionMenu.ViewIncome:
                        this.ViewIncome();
                        break;

                    case TransactionMenu.Exit:
                        return;
                }
            }
        }

        private void ViewIncome()
        {
            List<Transaction> income = this._service.GetIncome();
            this._view.PrintTransactionTable(income);
        }

        private void ViewExpense()
        {
            List<Transaction> expense = this._service.GetExpense();
            this._view.PrintTransactionTable(expense);
        }

        private void ViewSummary()
        {
            throw new NotImplementedException();
        }

        private void DeleteTransaction()
        {
            throw new NotImplementedException();
        }

        private void EditTransaction()
        {
            throw new NotImplementedException();
        }

        private void CreateTransaction()
        {
            TransactionType type = this._view.GetEnumValues<TransactionType>("Select the Type of the transaction");
            string title = this._view.GetString($"Enter the {type} title: ");
            decimal amount = this._view.GetDecimal($"Enter the {type} amount: ");
            DateTime date = this._view.GetDate("Enter the date: ");
            TransactionCategory category = this._view.GetEnumValues<TransactionCategory>("Select the type of the transaction");

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

        private int GetMenuOption(int max)
        {
            this._view.PrintInfo("1. Add expense or income\n2. Edit expense or income\n3. Delete income or expense\n4. View summary\n5. View Expense\n6. View Income\n7. Exit\n");
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
