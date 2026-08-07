using Assignment2.Models.EmployeeHierarchy;
using Assignment2.Models.Enums;
using Assignment2.Services;
using Assignment2.Views;

namespace Assignment2.Controllers
{
    /// <summary>
    /// Manages employee hierarchy, connect view and shape service.
    /// </summary>
    internal class EmployeeController
    {
        private readonly EmployeeService _employeeService;

        /// <summary>
        /// Initializes a new instance of the <see cref="EmployeeController"/> class.
        /// </summary>
        /// <param name="employeeService"> Employee service object. </param>
        public EmployeeController(EmployeeService employeeService)
        {
            this._employeeService = employeeService;
        }

        /// <summary>
        /// Serves as the primary entry point to root employee hierarchy operations.
        /// </summary>
        public void EmployeeOperations()
        {
            EmployeeRole option = (EmployeeRole)ConsoleView.GetInteger("\nSelect Employee Type to Create\r\n1. Developer\n2. Manager\n3. Exit\nEnter the option: ");
            switch (option)
            {
                case EmployeeRole.Developer:
                    this.Developer();
                    break;

                case EmployeeRole.Manager:
                    this.Manager();
                    break;

                case EmployeeRole.Exit:
                    return;

                default:
                    ConsoleView.PrintInfo("Enter a valid Integer in range 1-3");
                    break;
            }

            ConsoleView.PauseAndReturn();
        }

        /// <summary>
        /// Prompts the user to enter the manager profile and displays the calculated bonus.
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

            ConsoleView.PrintInfo(this._employeeService.GetDetails(manager));
        }

        /// <summary>
        /// Prompts the user to enter the developer profile and displays the calculated bonus.
        /// </summary>
        private void Developer()
        {
            string name = ConsoleView.GetString("Enter the name of the Developer: ");
            decimal salary = ConsoleView.GetDecimal("Enter the Salary of the Developer: ");

            Developer? developer = this._employeeService.CreateDeveloper(name, salary);
            if (developer is null)
            {
                ConsoleView.PrintInfo("Salary can't be Negative");
                return;
            }

            ConsoleView.PrintInfo(this._employeeService.GetDetails(developer));
        }
    }
}
