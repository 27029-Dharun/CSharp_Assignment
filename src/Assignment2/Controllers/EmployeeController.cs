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
        /// This class contains Manager operations
        /// </summary>
        private void Manager()
        {
            string name = this.GetValidString("Enter the name of the Manager: ");

            decimal salary = this.GetValidSalary("Enter the Salary of the Manager: ");

            Manager manager = this._employeeService.CreateManager(name, salary);
            ConsoleView.PrintEmployee(manager);
        }

        /// <summary>
        /// This methods contains Developer operations
        /// </summary>
        private void Developer()
        {
            string name = this.GetValidString("Enter the name of the Developer: ");

            decimal salary = this.GetValidSalary("Enter the Salary of the Developer");

            Developer developer = this._employeeService.CreateDeveloper(name, salary);
            ConsoleView.PrintEmployee(developer);
        }

        /// <summary>
        /// This Validates the decimal salary value
        /// </summary>
        /// <param name="message">Message to be printed</param>
        /// <returns>returns decimal</returns>
        private decimal GetValidSalary(string message)
        {
            decimal input = ConsoleView.GetDecimal(message);
            int tries = 3;
            while (input <= 0 && tries > 0)
            {
                ConsoleView.PrintInfo("Dimensions should be positive");
                ConsoleView.PrintInfo($"Tries Left: {tries}");
                tries--;
                input = ConsoleView.GetDecimal(message);
            }

            if (input <= 0)
            {
                return -1;
            }

            return input;
        }

        /// <summary>
        /// This is a Valid Dimension
        /// </summary>
        /// <param name="message">The message to be printed</param>
        /// <returns>Double dimension field</returns>
        private string GetValidString(string message)
        {
            int tries = 3;
            string color = ConsoleView.GetString(message);
            while (Validator.IsAllAlphabet(color) != string.Empty)
            {
                ConsoleView.PrintInfo("Invalid Color");
                ConsoleView.PrintInfo($"Tries Left: {tries}");
                tries--;
                color = ConsoleView.GetString(message);
            }

            if (Validator.IsAllAlphabet(color) != string.Empty)
            {
                ConsoleView.PrintInfo("Invalid Color");
                return string.Empty;
            }

            return color;
        }
    }
}
