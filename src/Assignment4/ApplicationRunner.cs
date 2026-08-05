using Assignment4.Controllers;
using Assignment4.Models.Enums;
using Assignment4.View;

namespace Assignment4
{
    /// <summary>
    /// The execution of the program begins here
    /// </summary>
    internal class ApplicationRunner
    {
        private readonly ConsoleView _view;
        private readonly TransactionController _controller;

        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationRunner"/> class.
        /// </summary>
        /// <param name="view">View object</param>
        /// <param name="controller">controller object</param>
        public ApplicationRunner(ConsoleView view, TransactionController controller)
        {
            this._view = view;
            this._controller = controller;
        }

        /// <summary>
        /// Expense Tracker application entry point
        /// </summary>
        public void RunExpenseTracker()
        {
            this._view.PrintInfo("Expense Tracker Application\n");
            int option = this.GetMenuOption(6);
            while (option != 6)
            {
                TransactionMenu menu = (TransactionMenu)option;
                this._controller.HandleMenu(menu);

                this._view.PauseAndReturn();
                option = this.GetMenuOption(6);
                this._view.ClearConsole();
            }
        }

        /// <summary>
        /// Get the menu option from the user
        /// </summary>
        /// <param name="max">max value range</param>
        /// <returns>integer value representing the task</returns>
        private int GetMenuOption(int max)
        {
            this._view.PrintInfo("1. Add expense or income\n2. Edit expense or income\n3. Delete income or expense\n4. View summary\n5. View transactions\n6. Exit\n");
            int option = this._view.GetOptinalInteger("Select an option to proceed: ");
            while (option > max)
            {
                this._view.ClearConsole();
                this._view.PrintInfo($"Enter an input in range 1 - {max}");
                this._view.PrintInfo("1. Add expense or income\n2. Edit expense or income\n3. Delete income or expense\n4. View summary\n5. View transactions\n6. Exit\n");
                option = this._view.GetOptinalInteger("Select an option to proceed: ");
            }

            return option;
        }
    }
}
