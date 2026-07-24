using Assignment2.Services;
using Assignment2.Views;

namespace Assignment2.Controllers
{
    /// <summary>
    /// This enum represents all the Task as enum
    /// </summary>
    internal enum ChooseTask
    {
        /// <summary>
        /// Shape
        /// </summary>
        Shape = 1,

        /// <summary>
        /// Employee
        /// </summary>
        Employee = 2,

        /// <summary>
        /// Bank
        /// </summary>
        Bank = 3,

        /// <summary>
        /// Exit
        /// </summary>
        Exit = 4,
    }

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
            int input;
            do
            {
                input = ConsoleView.GetInteger("Enter the number to Continue with a Task\n1. Shape\n2. Employee\n3. Banking System\n");
                switch (input)
                {
                    case (int)ChooseTask.Shape:
                        this._shapeController.Run();
                        break;

                    case (int)ChooseTask.Employee:
                        this._employeeController.Run();
                        break;

                    case (int)ChooseTask.Bank:
                        this._bankController.Run();
                        break;

                    case (int)ChooseTask.Exit:
                        break;

                    default:
                        ConsoleView.PrintInfo("Enter a number in range 1-4");
                        break;
                }
            }
            while (input != 4);
        }
    }
}
