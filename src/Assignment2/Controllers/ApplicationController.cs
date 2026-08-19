using Assignment2.Models.Enums;
using Assignment2.Views;

namespace Assignment2.Controllers
{
    /// <summary>
    /// Manages the application and connects the view and service
    /// </summary>
    internal class ApplicationController
    {
        private readonly ShapeController _shapeController;
        private readonly EmployeeController _employeeController;
        private readonly BankController _bankController;
        private readonly ConsoleView _view;

        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationController"/> class.
        /// </summary>
        /// <param name="view">Instance of the view</param>
        /// <param name="shapeController">Instance of shape controller</param>
        /// <param name="employeeController">Instance of employee controller object</param>
        /// <param name="bankController">Instance of bank controller</param>
        internal ApplicationController(ConsoleView view, ShapeController shapeController, EmployeeController employeeController, BankController bankController)
        {
            this._view = view;
            this._shapeController = shapeController;
            this._employeeController = employeeController;
            this._bankController = bankController;
        }

        /// <summary>
        /// Starts the application and show the main menu
        /// Calls the specific application controller
        /// </summary>
        internal void StartApplication()
        {
            MainMenuOption input;
            while (true)
            {
                input = this._view.GetEnumOption<MainMenuOption>("Application main menu\n1. Shape\n2. Employee\n3. Banking system\n4. Exit\nEnter an operation to continue: ");
                switch (input)
                {
                    case MainMenuOption.Shape:
                        this._shapeController.ShapeOperations();
                        break;

                    case MainMenuOption.Employee:
                        this._employeeController.EmployeeOperations();
                        break;

                    case MainMenuOption.Bank:
                        this._bankController.BankOperations();
                        break;

                    case MainMenuOption.Exit:
                        return;

                    default:
                        this._view.PrintInfo("Enter a number in range 1-4");
                        break;
                }
            }
        }
    }
}
