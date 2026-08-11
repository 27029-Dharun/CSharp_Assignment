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
        private readonly ConsoleView _view;

        /// <summary>
        /// Initializes a new instance of the <see cref="EmployeeController"/> class.
        /// </summary>
        /// <param name="view">Instance of the view</param>
        /// <param name="employeeService"> Instance of employee service. </param>
        public EmployeeController(ConsoleView view, EmployeeService employeeService)
        {
            this._view = view;
            this._employeeService = employeeService;
        }

        /// <summary>
        /// Serves as the primary entry point to root employee hierarchy operations.
        /// </summary>
        public void EmployeeOperations()
        {
            EmployeeRole option = (EmployeeRole)this._view.GetInteger("\nSelect Employee Type to Create\r\n1. Developer\n2. Manager\n3. Exit\nEnter the option: ");
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
                    this._view.PrintInfo("Enter a valid Integer in range 1-3");
                    break;
            }

            this._view.PauseAndReturn();
        }

        /// <summary>
        /// Prompts the user to enter the manager profile and displays the calculated bonus.
        /// </summary>
        private void Manager()
        {
            string name = this._view.GetString("Enter the name of the Developer: ");
            decimal salary = this._view.GetAmount("Enter the Salary of the Developer: ");

            Manager? manager = this._employeeService.CreateManager(name, salary);
            if (manager == null)
            {
                this._view.PrintInfo("Salary can't be Negative");
                return;
            }

            this._view.PrintInfo(this._employeeService.GetDetails(manager));
        }

        /// <summary>
        /// Prompts the user to enter the developer profile and displays the calculated bonus.
        /// </summary>
        private void Developer()
        {
            string name = this._view.GetString("Enter the name of the Developer: ");
            decimal salary = this._view.GetAmount("Enter the Salary of the Developer: ");

            Developer? developer = this._employeeService.CreateDeveloper(name, salary);
            if (developer is null)
            {
                this._view.PrintInfo("Salary can't be Negative");
                return;
            }

            this._view.PrintInfo(this._employeeService.GetDetails(developer));
        }
    }
}
