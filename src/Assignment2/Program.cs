using Assignment2.Controllers;
using Assignment2.Repository;
using Assignment2.Services;
using Assignment2.Views;

namespace Assignment2
{
    /// <summary>
    /// Application entry point and composition root. Wires up the dependencies once.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Main entry point of the program and starts the application.
        /// </summary>
        public static void Main()
        {
            ConsoleView view = new ConsoleView();
            EmployeeService employeeService = new EmployeeService();
            ShapeService shapeService = new ShapeService();
            BankRepository repository = new BankRepository();
            BankService bankService = new BankService(repository);
            ShapeController shapeController = new ShapeController(view, shapeService);
            BankController bankController = new BankController(view, bankService);
            EmployeeController employeeController = new EmployeeController(view, employeeService);

            ApplicationController controller = new ApplicationController(view, shapeController, employeeController, bankController);
            controller.StartApplication();
        }
    }
}