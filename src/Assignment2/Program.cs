using Assignment2.Controllers;
using Assignment2.Services;

namespace Assignment2
{
    /// <summary>
    /// This class is Main Entry point of our program
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// This method is the main method of Assignment 2
        /// </summary>
        public static void Main()
        {
            EmployeeService employeeService = new EmployeeService();
            BankService bankService = new ();
            ShapeService shapeservice = new ();
            ShapeController shapeController = new ShapeController(shapeservice);
            BankController bankController = new BankController(bankService);
            EmployeeController employeeController = new EmployeeController(employeeService);

            MainController controller = new MainController(shapeController, employeeController, bankController);
            controller.Run();
            Console.WriteLine("Enter a Key to Exit");
            Console.ReadKey();
        }
    }
}