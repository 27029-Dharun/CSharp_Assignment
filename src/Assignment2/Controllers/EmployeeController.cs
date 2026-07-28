using Assignment2.Models.EmployeeHierarchy;
using Assignment2.Models.Enums;
using Assignment2.Services;
using Assignment2.Validators;
using Assignment2.Views;

namespace Assignment2.Controllers
{
    /// <summary>
    /// This is the Employee Controller.
    /// </summary>
    internal class EmployeeController
    {
        private EmployeeService _employeeService = new EmployeeService();

        /// <summary>
        /// Initializes a new instance of the <see cref="EmployeeController"/> class.
        /// </summary>
        /// <param name="employeeService">Employee service object</param>
        public EmployeeController(EmployeeService employeeService)
        {
            this._employeeService = employeeService;
        }

        /// <summary>
        /// This is the Entry point of the Employee Task.
        /// </summary>
        public void RunEmployeeOperations()
        {
            int option;
            do
            {
                option = ConsoleView.GetInteger("Select Employee Type to Create\r\n1. Developer\n2. Manager\n3. Exit\n");
                switch (option)
                {
                    case (int)EmployeeRole.Developer:
                        this.Developer();
                        break;

                    case (int)EmployeeRole.Manager:
                        this.Manager();
                        break;

                    case (int)EmployeeRole.Exit:
                        return;

                    default:
                        ConsoleView.PrintInfo("Enter a valid Integer in range 1-3");
                        break;
                }
            }
            while (option != 3);
        }

        /// <summary>
        /// This class contains Manager operations.
        /// </summary>
        private void Manager()
        {
            string name = ConsoleView.GetString("Enter the name of the Developer: ");
            decimal salary = ConsoleView.GetDecimal("Enter the Salary of the Developer: ");

            Manager? manager = this._employeeService.CreateManager(name, salary);
            if (manager == null)
            {
                ConsoleView.PrintInfo("Salary can't be Negative");
                return;
            }

            ConsoleView.PrintEmployee(manager);
        }

        /// <summary>
        /// This methods contains Developer operations.
        /// </summary>
        private void Developer()
        {
            string name = ConsoleView.GetString("Enter the name of the Developer: ");
            decimal salary = ConsoleView.GetDecimal("Enter the Salary of the Developer: ");

            Developer? developer = this._employeeService.CreateDeveloper(name, salary);
            if (developer == null)
            {
                ConsoleView.PrintInfo("Salary can't be Negative");
                return;
            }

            ConsoleView.PrintEmployee(developer);
        }
    }
}
