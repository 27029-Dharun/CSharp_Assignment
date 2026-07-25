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
                Console.Write(operation);
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
                Console.Write(operation);
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
                Console.Write(operation);
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
        /// This class prints the shape
        /// </summary>
        /// <param name="shape">Shape object</param>
        internal static void PrintShape(Shape shape)
        {
            Console.WriteLine(shape.PrintDetails());
        }

        /// <summary>
        /// This prints the balance and other info of the Account
        /// </summary>
        /// <param name="account">The account object that is to be Printed</param>
        internal static void PrintBalance(BankAccount account)
        {
            Console.WriteLine($"Account Number: {account.AccountNumber}");
            Console.WriteLine($"Balance: {account.Balance}");
        }
    }
}
