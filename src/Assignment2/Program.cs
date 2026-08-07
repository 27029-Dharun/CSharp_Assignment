using Assignment2.Controllers;
using Assignment2.Repository;
using Assignment2.Services;

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
            EmployeeService employeeService = new EmployeeService();
            ShapeService shapeService = new ShapeService();
            BankRepository repository = new BankRepository();
            BankService bankService = new BankService(repository);
            ShapeController shapeController = new ShapeController(shapeService);
            BankController bankController = new BankController(bankService);
            EmployeeController employeeController = new EmployeeController(employeeService);

            ApplicationController controller = new ApplicationController(shapeController, employeeController, bankController);
            controller.StartApplication();
            Console.WriteLine("Enter a key to exit");
            Console.ReadKey();
        }
    }
}