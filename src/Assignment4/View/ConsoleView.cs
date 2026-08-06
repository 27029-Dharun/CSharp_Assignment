using System.Globalization;
using Assignment4.Models;
using ConsoleTables;

namespace Assignment4.View
{
    /// <summary>
    /// Contains the console operations that prints and gets input from user
    /// </summary>
    public class ConsoleView
    {
        private const string BORDER = "=========================================";
        private const int TRIES = 3;

        /// <summary>
        /// Print the message in console
        /// </summary>
        /// <param name="message">Message to be printed</param>
        internal void PrintInfo(string message)
        {
            Console.WriteLine(message);
        }

        /// <summary>
        /// Displays the enum value and gets input from the user
        /// </summary>
        /// <typeparam name="T">Type variable that should be struct</typeparam>
        /// <param name="message">String to be printed</param>
        /// <returns>returns a enum value entered by use</returns>
        internal T GetEnumValue<T>(string message)
            where T : struct, Enum
        {
            Console.WriteLine($"\n{message}");

            foreach (var value in Enum.GetValues<T>())
            {
                Console.WriteLine($"{Convert.ToInt32(value)}. {value}");
            }

            string input = Console.ReadLine() ?? string.Empty;
            int integer;
            while (!int.TryParse(input, out integer) || !Enum.IsDefined(typeof(T), integer))
            {
                Console.WriteLine("Enter the valid integer");
                Console.WriteLine($"{message}");
                input = Console.ReadLine() ?? string.Empty;
            }

            return (T)Enum.ToObject(typeof(T), integer);
        }

        /// <summary>
        /// Get the integer
        /// </summary>
        /// <param name="message">Message to be printed</param>
        /// <param name="input">Input entered by the user</param>
        /// <param name="tries">Tries left to enter a valid Integer</param>
        /// <returns>status of the operation</returns>
        internal bool GetInteger(string message, out int input, int tries = TRIES)
        {
            Console.Write(message);
            while (!int.TryParse(Console.ReadLine(), out input))
            {
                if (tries <= 0)
                {
                    return true;
                }

                Console.WriteLine($"Tries left: {tries--}");
                Console.WriteLine($"Enter a valid integer\n");
                Console.Write(message);
            }

            return false;
        }

        /// <summary>
        /// Get the integer
        /// </summary>
        /// <param name="message">Message to be printed</param>
        /// <param name="tries">Tries left to enter a valid Integer</param>
        /// <returns>status of the operation</returns>
        internal int GetOptionalInteger(string message, int tries = TRIES)
        {
            int input;
            Console.Write(message);
            while (!int.TryParse(Console.ReadLine(), out input))
            {
                Console.Write(message);
            }

            return input;
        }

        /// <summary>
        /// Gets the string
        /// </summary>
        /// <param name="message">Message to be displayed</param>
        /// <param name="input">out param that returns the string input</param>
        /// <param name="tries">Tries left to enter a valid string</param>
        /// <returns>Returns false if the user enters repeated invalid input</returns>
        internal bool GetString(string message, out string input, int tries = TRIES)
        {
            Console.Write(message);
            input = Console.ReadLine() ?? string.Empty;

            while (input == string.Empty)
            {
                if (tries <= 0)
                {
                    return false;
                }

                Console.WriteLine($"Tries Left: {tries--}");
                Console.WriteLine("Entered string can't be empty\n");
                Console.Write(message);
                input = Console.ReadLine() ?? string.Empty;
            }

            return true;
        }

        /// <summary>
        /// Gets decimal input
        /// </summary>
        /// <param name="message">Message to be printed</param>
        /// <param name="input">out param that returns the decimal input</param>
        /// <param name="tries">Tries left to enter a valid decimal</param>
        /// <returns>decimal input</returns>
        internal bool GetDecimal(string message, out decimal input, int tries = TRIES)
        {
            Console.Write(message);
            while (!decimal.TryParse(Console.ReadLine(), out input))
            {
                if (tries <= 0)
                {
                    return false;
                }

                Console.WriteLine($"Tries Left: {tries--}");
                Console.WriteLine("Enter a valid decimal\n");
                Console.Write(message);
            }

            return true;
        }

        /// <summary>
        /// Gets the Date from the user
        /// </summary>
        /// <param name="validDate">Out param that returns the valid date</param>
        /// <param name="tries">Tries for user to retry</param>
        /// <returns>DateTime value entered by user</returns>
        internal bool GetDate(out DateTime validDate, int tries = TRIES)
        {
            string input;
            string format = "dd/MM/yyyy";
            Console.Write($"Enter a date in format ({format}): ");

            input = Console.ReadLine() ?? string.Empty;
            while (!DateTime.TryParseExact(input, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out validDate))
            {
                if (tries <= 0)
                {
                    return false;
                }

                Console.WriteLine($"Tries Left: {tries--}");
                Console.Write($"Invalid date. Please enter in format {format}: ");
                input = Console.ReadLine() ?? string.Empty;
            }

            return true;
        }

        /// <summary>
        /// Clears the console messages
        /// </summary>
        internal void ClearConsole()
        {
            // Erases the entire scrollback buffer history
            Console.Write("\x1b[3J");
            Console.Clear();
        }

        /// <summary>
        /// prints the error message in red color
        /// </summary>
        /// <param name="message">message to be printed</param>
        internal void PrintError(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        /// <summary>
        /// prints the success message in green color
        /// </summary>
        /// <param name="message">message to be printed</param>
        internal void PrintSuccess(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        /// <summary>
        /// prints the error message in red color
        /// </summary>
        /// <param name="message">message to be printed</param>
        internal void PrintWarning(string message)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        /// <summary>
        /// Prints the Transactions
        /// </summary>
        /// <param name="transactions">Transactions to be printed</param>
        internal void PrintTransactionTable(IReadOnlyList<Transaction> transactions)
        {
            var table = new ConsoleTable("Transaction Id", "Transaction Type", "Transaction Title", "Transaction Date", "Transaction Amount", "Transaction Category");

            foreach (Transaction transaction in transactions)
            {
                table.AddRow(transaction.Id, transaction.Type, transaction.Title, transaction.Date.ToShortDateString(), transaction.Amount, transaction.Category);
            }

            table.Write();
        }

        /// <summary>
        /// Pause the flow until a key is entered
        /// </summary>
        internal void PauseAndReturn()
        {
            Console.WriteLine("Press any key to return to main menu");
            Console.ReadKey();

            // Erases the entire scrollback buffer history
            Console.Write("\x1b[3J");
            Console.Clear();
        }

        /// <summary>
        /// Displays the menu
        /// </summary>
        internal void DisplayMainMenu()
        {
            Console.WriteLine(BORDER);
            Console.WriteLine("       FINANCE TRACKER - MAIN MENU       ");
            Console.WriteLine(BORDER);

            Console.WriteLine("[1] Add Transaction (Income/Expense)");
            Console.WriteLine("[2] Edit Transaction");
            Console.WriteLine("[3] Delete Transaction");
            Console.WriteLine("[4] View Financial Summary");
            Console.WriteLine("[5] View History / Transactions");
            Console.WriteLine("[6] Exit Application");

            Console.WriteLine(BORDER);
            Console.WriteLine("Please enter your choice (1-6): ");
        }
    }
}
