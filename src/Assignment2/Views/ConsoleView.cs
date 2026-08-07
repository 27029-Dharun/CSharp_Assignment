using Assignment2.Models.BankingSystem;

namespace Assignment2.Views
{
    /// <summary>
    /// Contains all the console operations
    /// </summary>
    internal class ConsoleView
    {
        /// <summary>
        /// Prints the info on the console.
        /// </summary>
        /// <param name="message">String to be printed</param>
        internal static void PrintInfo(string message)
        {
            Console.WriteLine(message);
        }

        /// <summary>
        /// Gets a valid decimal input from the user until the input is a valid decimal number.
        /// </summary>
        /// <param name="prompt"> Prompt to be displayed to the user. </param>
        /// <returns> The decimal value entered by user. </returns>
        internal static decimal GetDecimal(string prompt)
        {
            decimal amount;
            Console.Write(prompt);
            while (!decimal.TryParse(Console.ReadLine(), out amount))
            {
                Console.WriteLine("Please enter a positive decimal value");
                Console.Write(prompt);
            }

            return amount;
        }

        /// <summary>
        /// Gets a valid double input from the user until the input is a valid double number.
        /// </summary>
        /// <param name="prompt"> Prompt to be displayed to the user. </param>
        /// <returns> The double value entered by user. </returns>
        internal static double GetDouble(string prompt)
        {
            double amount;
            Console.Write(prompt);
            while (!double.TryParse(Console.ReadLine(), out amount))
            {
                Console.WriteLine("Please enter a positive Double value");
                Console.Write(prompt);
            }

            return amount;
        }

        /// <summary>
        /// Gets a string input from the user until the input is a valid string.
        /// </summary>
        /// <param name="prompt"> Prompt to be displayed to the user. </param>
        /// <returns> The string entered by user. </returns>
        internal static string GetString(string prompt)
        {
            Console.Write(prompt);
            string input = (Console.ReadLine() ?? string.Empty).Trim();
            while (input == string.Empty)
            {
                Console.WriteLine("String can't be Empty");
                Console.Write(prompt);
                input = (Console.ReadLine() ?? string.Empty).Trim();
            }

            return input;
        }

        /// <summary>
        /// Gets a integer input from the user until the input is a valid integer number.
        /// </summary>
        /// <param name="prompt"> Prompt to be displayed to the user. </param>
        /// <returns> The integer value entered by user. </returns>
        internal static int GetInteger(string prompt)
        {
            Console.Write(prompt);
            int input;
            while (!int.TryParse(Console.ReadLine(), out input))
            {
                Console.WriteLine("Enter a Valid Integer");
            }

            return input;
        }

        /// <summary>
        /// This prints the balance and account of the Account.
        /// </summary>
        /// <param name="account"> Instance of the account. </param>
        internal static void PrintBalance(BankAccount account)
        {
            Console.WriteLine($"Account Number: {account.AccountNumber}");
            Console.WriteLine($"Balance: {account.Balance}");
        }

        /// <summary>
        /// Pause the flow until a key is entered.
        /// </summary>
        internal static void PauseAndReturn()
        {
            Console.WriteLine("Press any key to return to main menu");
            Console.ReadKey();

            // Erases the entire scroll back buffer history
            Console.Write("\x1b[3J");
            Console.Clear();
        }
    }
}
