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

        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationController"/> class.
        /// </summary>
        /// <param name="shapeController">Instance of shape controller</param>
        /// <param name="employeeController">Instance of employee controller object</param>
        /// <param name="bankController">Instance of bank controller</param>
        public ApplicationController(ShapeController shapeController, EmployeeController employeeController, BankController bankController)
        {
            this._shapeController = shapeController;
            this._employeeController = employeeController;
            this._bankController = bankController;
        }

        /// <summary>
        /// Starts the application and show the main menu
        /// Calls the specific application controller
        /// </summary>
        public void StartApplication()
        {
            ChooseTask input;
            do
            {
                input = (ChooseTask)ConsoleView.GetInteger("Application main menu\n1. Shape\n2. Employee\n3. Banking system\n4. Exit\nEnter an operation to continue: ");
                switch (input)
                {
                    case ChooseTask.Shape:
                        this._shapeController.ShapeOperations();
                        break;

                    case ChooseTask.Employee:
                        this._employeeController.EmployeeOperations();
                        break;

                    case ChooseTask.Bank:
                        this._bankController.BankOperations();
                        break;

                    case ChooseTask.Exit:
                        return;

                    default:
                        ConsoleView.PrintInfo("Enter a number in range 1-4");
                        break;
                }
            }
            while (input != ChooseTask.Exit);
        }
    }
}
