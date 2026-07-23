using Assignment2.Models.BankingSystem;
using Assignment2.Models.EmployeeHierarchy;
using Assignment2.Models.ShapeHierarchy;

namespace Assignment2.Views
{
    /// <summary>
    /// THis class contains all the console operations
    /// </summary>
    internal class ConsoleView
    {
        /// <summary>
        /// This method prints info
        /// </summary>
        /// <param name="message">String to be printed</param>
        internal static void PrintInfo(string message)
        {
            Console.WriteLine(message);
        }

        /// <summary>
        /// This Method gets the decimal
        /// </summary>
        /// <param name="operation">Message displayed to user</param>
        /// <returns>decimal value entered by the user</returns>
        internal static decimal GetDecimal(string operation)
        {
            decimal amount;
            Console.Write(operation);
            while (!decimal.TryParse(Console.ReadLine(), out amount))
            {
                Console.WriteLine("Please enter a positive decimal value");
            }

            return amount;
        }

        /// <summary>
        /// This Method gets the double
        /// </summary>
        /// <param name="operation">Message displayed to user</param>
        /// <returns>double value entered by the user</returns>
        internal static double GetDouble(string operation)
        {
            double amount;
            Console.Write(operation);
            while (!double.TryParse(Console.ReadLine(), out amount))
            {
                Console.WriteLine("Please enter a positive Double value");
            }

            return amount;
        }

        /// <summary>
        /// This Method gets the string input
        /// </summary>
        /// <param name="operation">Message displayed to user</param>
        /// <returns>string value entered by the user</returns>
        internal static string GetString(string operation)
        {
            Console.Write(operation);
            string input = (Console.ReadLine() ?? string.Empty).Trim();
            while (input == string.Empty)
            {
                Console.WriteLine("String can't be Empty");
                input = (Console.ReadLine() ?? string.Empty).Trim();
            }

            return input;
        }

        /// <summary>
        /// This prints the Details of the Employee
        /// </summary>
        /// <param name="employee">The employee object</param>
        internal static void PrintEmployee(Employee employee)
        {
            Console.WriteLine(employee.PrintDetails());
        }

        /// <summary>
        /// This methods get the integer input
        /// </summary>
        /// <param name="operation">The string to be printed</param>
        /// <returns>Returns the integer that we got as a input</returns>
        internal static int GetInteger(string operation)
        {
            Console.Write(operation);
            int input;
            while (!int.TryParse(Console.ReadLine(), out input))
            {
                Console.WriteLine("Enter a Valid Integer");
            }

            return input;
        }

        /// <summary>
        /// This returns the Employee Type that is to be created
        /// </summary>
        /// <returns>Int value 1 - Developer 2 - Manager </returns>
        internal static int GetEmployeeType()
        {
            int input;
            Console.WriteLine();
            Console.WriteLine("Select the Employee Type");
            Console.WriteLine("1. Developer");
            Console.WriteLine("2. Manager");
            Console.WriteLine("3. Exit");

            while (!int.TryParse(Console.ReadLine(), out input))
            {
                Console.WriteLine("Enter a Valid Input");
            }

            return input;
        }

        /// <summary>
        /// This class displays the Operation to do
        /// </summary>
        /// <returns>Int value of the Shape operation</returns>
        internal static int GetShapeOptions()
        {
            int input;
            Console.WriteLine();
            Console.WriteLine("Select the Create a Shape");
            Console.WriteLine("1. Circle");
            Console.WriteLine("2. Rectangle");
            Console.WriteLine("3. Exit");

            while (!int.TryParse(Console.ReadLine(), out input))
            {
                Console.WriteLine("Enter a Valid Input");
            }

            return input;
        }

        /// <summary>
        /// This class prints the shape
        /// </summary>
        /// <param name="shape">Shape object</param>
        internal static void PrintShape(Shape shape)
        {
            Console.WriteLine(shape.PrintDetails());
        }

        /// <summary>
        /// Get Task to Perform
        /// </summary>
        /// <returns>A task presented by int</returns>
        internal static int GetTask()
        {
            int input;
            Console.WriteLine();
            Console.WriteLine("Enter the number to Continue with a Task");
            Console.WriteLine("1. Shape Hierarchy");
            Console.WriteLine("2. Employee Hierarchy");
            Console.WriteLine("3. Banking System");
            Console.WriteLine("4. Exit");

            while (!int.TryParse(Console.ReadLine(), out input))
            {
                Console.WriteLine("Please enter a Valid Input");
            }

            return input;
        }

        /// <summary>
        /// Gets the option of operation to be performed
        /// </summary>
        /// <returns>Integer value telling the operation</returns>
        internal static int GetOption()
        {
            int option;
            Console.WriteLine("Enter the Operation to Continue");
            Console.WriteLine("1. Create Bank Account");
            Console.WriteLine("2. Log In to An Existing Account");
            Console.WriteLine("3. Exit");

            while (!int.TryParse(Console.ReadLine(), out option))
            {
                Console.WriteLine("Invalid Option");
            }

            return option;
        }

        /// <summary>
        /// This gets the operation that is to be done after login
        /// </summary>
        /// <returns>Int value to represent operation</returns>
        internal static int GetLogInOperation()
        {
            int input;
            Console.WriteLine("Enter an Operation to Continue: ");
            Console.WriteLine("1. Check Balance");
            Console.WriteLine("2. Withdraw Amount");
            Console.WriteLine("3. Deposit Amount");
            Console.WriteLine("4. Exit");

            while (!int.TryParse(Console.ReadLine(), out input))
            {
                Console.WriteLine("Please enter a Valid Input");
            }

            return input;
        }

        /// <summary>
        /// This prints the balance and other info of the Account
        /// </summary>
        /// <param name="account">The account object that is to be Printed</param>
        internal static void DisplayBalance(BankAccount account)
        {
            Console.WriteLine($"Account Number: {account.AccountNumber}");
            Console.WriteLine($"Balance: {account.Balance}");
        }
    }
}
