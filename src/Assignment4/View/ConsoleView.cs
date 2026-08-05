using System.Globalization;
using Assignment4.Helper;
using Assignment4.Models;
using ConsoleTables;

namespace Assignment4.View
{
    /// <summary>
    /// Contains the console operations that prints and gets input from user
    /// </summary>
    public class ConsoleView
    {
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
        internal T GetEnumValues<T>(string message)
            where T : Enum
        {
            int length = 0;
            Console.WriteLine();
            foreach (T value in EnumHelper.GetAllEnumValues<T>())
            {
                Console.WriteLine($"{Convert.ToInt32(value)}. {value}");
                length++;
            }

            int input = this.GetInteger(message);
            while (!Enum.IsDefined(typeof(T), input))
            {
                this.PrintInfo("Enter a valid integer in range");
                input = this.GetInteger(message);
            }

            return (T)Enum.ToObject(typeof(T), input);
        }

        /// <summary>
        /// Get the integer
        /// </summary>
        /// <param name="message">Message to be printed</param>
        /// <param name="tries">Tries left to enter a valid Integer</param>
        /// <returns>Integer input</returns>
        internal int GetInteger(string message, int tries = 3)
        {
            Console.Write(message);
            int input;
            while (!int.TryParse(Console.ReadLine(), out input))
            {
                if (tries <= 0)
                {
                    return -1;
                }

                Console.WriteLine($"Tries left: {tries--}");
                Console.WriteLine($"Enter a valid integer\n");
                Console.Write(message);
            }

            return input;
        }

        /// <summary>
        /// Gets the string
        /// </summary>
        /// <param name="message">Message to be displayed</param>
        /// <param name="tries">Tries left to enter a valid string</param>
        /// <returns>String given as input</returns>
        internal string GetString(string message, int tries = 3)
        {
            Console.Write(message);
            string input = Console.ReadLine() ?? string.Empty;

            while (input == string.Empty)
            {
                if (tries <= 0)
                {
                    return string.Empty;
                }

                Console.WriteLine($"Tries Left: {tries--}");
                Console.WriteLine("Entered string can't be empty\n");
                Console.Write(message);
                input = Console.ReadLine() ?? string.Empty;
            }

            return input;
        }

        /// <summary>
        /// Gets decimal input
        /// </summary>
        /// <param name="message">Message to be printed</param>
        /// <param name="tries">Tries left to enter a valid decimal</param>
        /// <returns>decimal input</returns>
        internal decimal GetDecimal(string message, int tries = 3)
        {
            Console.Write(message);
            decimal input;
            while (!decimal.TryParse(Console.ReadLine(), out input))
            {
                if (tries <= 0)
                {
                    return -1;
                }

                Console.WriteLine($"Tries Left: {tries--}");
                Console.WriteLine("Enter a valid decimal\n");
                Console.Write(message);
            }

            return input;
        }

        /// <summary>
        /// Gets the string input as optional field
        /// </summary>
        /// <param name="message">Message to print</param>
        /// <returns>returns string.Empty if null</returns>
        internal string GetOptionalString(string message)
        {
            Console.Write(message);
            string input = Console.ReadLine() ?? string.Empty;
            return input;
        }

        /// <summary>
        /// Get the optional decimal value
        /// </summary>
        /// <param name="message">Message to print</param>
        /// <returns>Returns the decimal input</returns>
        internal decimal GetOptinalDecimal(string message)
        {
            Console.Write(message);
            string input = Console.ReadLine() ?? string.Empty;
            if (input == string.Empty)
            {
                return -1;
            }

            if (!decimal.TryParse(input, out decimal value))
            {
                throw new FormatException("The input is not in the correct format.");
            }

            return value;
        }

        /// <summary>
        /// Gets the optional integer value
        /// </summary>
        /// <param name="message">Message to be printed</param>
        /// <returns>Returns the integer value</returns>
        internal int GetOptinalInteger(string message)
        {
            Console.Write(message);
            string input = Console.ReadLine() ?? string.Empty;
            if (input == string.Empty)
            {
                return -1;
            }

            if (!int.TryParse(input, out int value))
            {
                throw new FormatException("The input is not in the correct format.");
            }

            return value;
        }

        /// <summary>
        /// Gets the Date from the user
        /// </summary>
        /// <param name="tries">Tries for user to retry</param>
        /// <returns>DateTime value entered by user</returns>
        internal DateTime GetDate(int tries = 3)
        {
            DateTime validDate;
            string input;
            string format = "dd/MM/yyyy";
            Console.Write($"Enter a date in format ({format}): ");

            input = Console.ReadLine() ?? string.Empty;
            while (!DateTime.TryParseExact(input, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out validDate))
            {
                if (tries <= 0)
                {
                    return DateTime.MinValue;
                }

                Console.WriteLine($"Tries Left: {tries--}");
                Console.Write($"Invalid date. Please enter in format {format}: ");
                input = Console.ReadLine() ?? string.Empty;
            }

            return validDate;
        }

        /// <summary>
        /// Gets the Date from the user as optional field
        /// </summary>
        /// <returns>DateTime value entered by user</returns>
        internal DateTime GetOptionalDate()
        {
            DateTime validDate;
            string input;
            string format = "dd/MM/yyyy";
            Console.Write($"Enter a date in format ({format}): ");

            input = Console.ReadLine() ?? string.Empty;
            if (string.IsNullOrEmpty(input))
            {
                return DateTime.MinValue;
            }

            while (!DateTime.TryParseExact(input, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out validDate))
            {
                Console.WriteLine($"Invalid date. Please enter in format {format}:");
                input = Console.ReadLine() ?? string.Empty;
                if (string.IsNullOrEmpty(input))
                {
                    return DateTime.MinValue;
                }
            }

            return validDate;
        }

        /// <summary>
        /// Reads a key
        /// </summary>
        internal void ReadKey()
        {
            Console.ReadKey();
        }

        /// <summary>
        /// Prints a empty line
        /// </summary>
        internal void PrintEmptyLine()
        {
            Console.WriteLine();
        }

        /// <summary>
        /// Clears the console messages
        /// </summary>
        internal void ClearConsole()
        {
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
                table.AddRow(transaction.Id, transaction.Type, transaction.Title, transaction.Date.Date, transaction.Amount, transaction.Category);
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
            Console.Clear();
        }

        /// <summary>
        /// Prints the seperator line
        /// </summary>
        internal void PrintSeperator()
        {
            Console.WriteLine("--------------------");
        }
    }
}
