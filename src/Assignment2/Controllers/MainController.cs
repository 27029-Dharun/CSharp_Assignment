using Assignment2.Models.Enums;
using Assignment2.Views;

namespace Assignment2.Controllers
{
    /// <summary>
    /// This is the assignment Controller
    /// </summary>
    internal class MainController
    {
        private ShapeController _shapeController;
        private EmployeeController _employeeController;
        private BankController _bankController;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainController"/> class.
        /// </summary>
        /// <param name="shapeController">Shape controller object</param>
        /// <param name="employeeController">Employee controller object</param>
        /// <param name="bankController">Bank controller object</param>
        public MainController(ShapeController shapeController, EmployeeController employeeController, BankController bankController)
        {
            this._shapeController = shapeController;
            this._employeeController = employeeController;
            this._bankController = bankController;
        }

        /// <summary>
        /// This method is the entery point
        /// </summary>
        public void Run()
        {
            ChooseTask input;
            do
            {
                input = (ChooseTask)ConsoleView.GetInteger("Application Main Menu\n1. Shape\n2. Employee\n3. Banking System\n4. Exit\nEnter an operation to continue: ");
                switch (input)
                {
                    case ChooseTask.Shape:
                        this._shapeController.RunShapeOperations();
                        break;

                    case ChooseTask.Employee:
                        this._employeeController.RunEmployeeOperations();
                        break;

                    case ChooseTask.Bank:
                        this._bankController.RunBankOperations();
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
