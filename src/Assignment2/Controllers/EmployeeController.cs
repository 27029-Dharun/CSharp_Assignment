using Assignment2.Models.EmployeeHierarchy;
using Assignment2.Services;
using Assignment2.Validators;
using Assignment2.Views;

namespace Assignment2.Controllers
{
    /// <summary>
    /// This is the Employee Role enum
    /// </summary>
    internal enum EmployeeRole
    {
        /// <summary>
        /// Developer
        /// </summary>
        Developer = 1,

        /// <summary>
        /// Manager
        /// </summary>
        Manager = 2,

        /// <summary>
        /// Exit form operation
        /// </summary>
        Exit = 3,
    }

    /// <summary>
    /// THis is the Employee Controller
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
        /// This is the Entry point of the Employee Task
        /// </summary>
        public void Run()
        {
            int option;
            do
            {
                option = ConsoleView.GetEmployeeType();
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
        /// This class contains Manager operations
        /// </summary>
        private void Manager()
        {
            string name = ConsoleView.GetString("Enter the Name of the Manager: ");
            decimal salary = ConsoleView.GetDecimal("Enter the Salary of the Manager: ");

            if (Validator.IsAllAlphabet(name) != string.Empty)
            {
                ConsoleView.PrintInfo(Validator.IsAllAlphabet(name));
                return;
            }

            if (Validator.IsValidAmount(salary) != string.Empty)
            {
                ConsoleView.PrintInfo(Validator.IsValidAmount(salary));
                return;
            }

            Manager manager = this._employeeService.CreateManager(name, salary);
            ConsoleView.PrintEmployee(manager);
        }

        /// <summary>
        /// This methods contains Developer operatoins
        /// </summary>
        private void Developer()
        {
            string name = ConsoleView.GetString("Enter the Name of the Developer: ");
            decimal salary = ConsoleView.GetDecimal("Enter the Salary of the Developer: ");
            if (Validator.IsAllAlphabet(name) != string.Empty)
            {
                ConsoleView.PrintInfo(Validator.IsAllAlphabet(name));
                return;
            }

            if (Validator.IsValidAmount(salary) != string.Empty)
            {
                ConsoleView.PrintInfo(Validator.IsValidAmount(salary));
                return;
            }

            Developer developer = this._employeeService.CreateDeveloper(name, salary);
            ConsoleView.PrintEmployee(developer);
        }
    }
}
