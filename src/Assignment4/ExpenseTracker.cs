using Assignment4.Controllers;
using Assignment4.Models.Enums;
using Assignment4.View;

namespace Assignment4
{
    /// <summary>
    /// Entry point of the expense tracker.
    /// </summary>
    public class ExpenseTracker
    {
        private const int Max = 8;
        private readonly ConsoleView _view;
        private readonly TransactionController _controller;

        /// <summary>
        /// Initializes a new instance of the <see cref="ExpenseTracker"/> class.
        /// </summary>
        /// <param name="view">An instance of view</param>
        /// <param name="controller">An instance of controller</param>
        public ExpenseTracker(ConsoleView view, TransactionController controller)
        {
            this._view = view;
            this._controller = controller;
        }

        /// <summary>
        /// Loops and get menu option until the user exits
        /// </summary>
        public void ExecuteExpenseTracker()
        {
            TransactionMenu option = this.GetMenuOption(Max);
            this._view.ClearConsole();
            while (option != TransactionMenu.Exit)
            {
                TransactionMenu menu = option;
                try
                {
                    this._controller.HandleMenu(menu);
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
                option = this.GetMenuOption(Max);
                this._view.ClearConsole();
            }
        }

        /// <summary>
        /// Get the menu option from the user.
        /// </summary>
        /// <param name="max"> Max value range. </param>
        /// <returns> Transaction menu option. </returns>
        private TransactionMenu GetMenuOption(int max)
        {
            this._view.DisplayMainMenu();
            int option = this._view.GetInteger("Select an option to proceed: ");

            while (option > max)
            {
                this._view.ClearConsole();
                this._view.PrintInfo($"Enter an input in range 1 - {max}");
                this._view.PrintInfo("1. Add expense or income\n2. Edit expense or income\n3. Delete income or expense\n4. View summary\n5. View transactions\n6. Exit\n");
                option = this._view.GetInteger("Select an option to proceed: ");
            }

            return (TransactionMenu)option;
        }
    }
}
