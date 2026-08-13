using Assignment4.Constants;
using Assignment4.Models;
using Assignment4.Validation;
using ConsoleTables;

namespace Assignment4.View
{
    /// <summary>
    /// Contains the console operations that prints and gets input from user
    /// </summary>
    public class ConsoleView
    {/// <summary>
     /// Prints the empty line
     /// </summary>
        internal void PrintEmptyLine() => Console.WriteLine();

        /// <summary>
        /// Prints the input string
        /// </summary>
        /// <param name="message">The string to be printed</param>
        internal void PrintInfo(string message)
        {
            Console.WriteLine(message);
        }

        /// <summary>
        /// Gets the string input from the user.
        /// </summary>
        /// <param name="message">Message to be printed</param>
        /// <returns>int value that we got as input</returns>
        internal string GetString(string message)
        {
            Console.Write(message);
            string input = (Console.ReadLine() ?? string.Empty).Trim();

            return input;
        }

        /// <summary>
        /// Gets the Integer input
        /// </summary>
        /// <param name="message">Message to be printed</param>
        /// <returns>int value that we got as input</returns>
        internal int GetInteger(string message)
        {
            int input;
            Console.Write(message);
            while (!int.TryParse(Console.ReadLine(), out input))
            {
                Console.WriteLine("Please enter a integer");
            }

            return input;
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
        /// Gets decimal input
        /// </summary>
        /// <param name="prompt">Message to be displayed</param>
        /// <param name="optional">True if we want to perform edit operation</param>
        /// <returns>decimal input</returns>
        internal string GetValidDescription(string prompt, bool optional = false)
        {
            string input = this.GetValidatedInput(
                prompt,
                optional,
                TransactionValidator.IsValidDescription,
                $"Please enter a valid description with more than {Configurable.MinimumCharacter}.");
            return input;
        }

        /// <summary>
        /// Gets decimal input
        /// </summary>
        /// <param name="prompt">Message to be displayed</param>
        /// <param name="optional">True if we want to perform edit operation</param>
        /// <returns>decimal input</returns>
        internal string GetValidAmount(string prompt, bool optional = false)
        {
            string input = this.GetValidatedInput(
                prompt,
                optional,
                TransactionValidator.IsValidAmount,
                $"Invalid amount.Please enter a valid amount greater than {Configurable.MinimumAmount}");

            return input;
        }

        /// <summary>
        /// Gets the Date from the user
        /// </summary>
        /// <param name="optional">True if we want to perform edit operation</param>
        /// <returns>DateTime value entered by user</returns>
        internal string GetValidDate(bool optional = false)
        {
            string input = this.GetValidatedInput(
                $"Enter a date in format ({Configurable.DateFormat}): ",
                optional,
                TransactionValidator.IsValidDate,
                $"Invalid date.Please enter a date in format {Configurable.DateFormat}:");

            return input;
        }

        /// <summary>
        /// Clears the console messages
        /// </summary>
        internal void ClearConsole()
        {
            // Erases the entire scroll back buffer history
            Console.Write("\x1b[3J");
            Console.Clear();
        }

        /// <summary>
        /// Displays the error message in red color
        /// </summary>
        /// <param name="message">message to be printed</param>
        internal void PrintError(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        /// <summary>
        /// Displays the success message in green color
        /// </summary>
        /// <param name="message">message to be printed</param>
        internal void PrintSuccess(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        /// <summary>
        /// Displays the error message in red color
        /// </summary>
        /// <param name="message">message to be printed</param>
        internal void PrintWarning(string message)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        /// <summary>
        /// Displays the transactions
        /// </summary>
        /// <param name="transactions">List of transactions</param>
        internal void PrintTransactionTable(IReadOnlyList<Transaction> transactions)
        {
            var table = new ConsoleTable("Transaction Id", "Type", "Category", "Date", "Amount", "Description");

            foreach (Transaction transaction in transactions)
            {
                table.AddRow(transaction.Id, transaction.Type, transaction.Category, transaction.Date.ToShortDateString(), transaction.Amount, transaction.Description);
            }

            table.Write();
        }

        /// <summary>
        /// Waits for user to press a key and clears the console.
        /// </summary>
        internal void PauseAndReturn()
        {
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();

            // Erases the entire scroll back buffer history
            Console.Write("\x1b[3J");
            Console.Clear();
        }

        /// <summary>
        /// Displays the menu
        /// </summary>
        internal void DisplayMainMenu()
        {
            Console.WriteLine("       FINANCE TRACKER - MAIN MENU       \n");

            Console.WriteLine("[1] Add Transaction (Income/Expense)");
            Console.WriteLine("[2] Edit Transaction");
            Console.WriteLine("[3] Delete Transaction");
            Console.WriteLine("[4] View Financial Summary");
            Console.WriteLine("[5] View History / Transactions");
            Console.WriteLine("[6] Exit Application\n");

            Console.WriteLine("Please enter your choice (1-6): ");
        }

        private string GetValidatedInput(string prompt, bool optional, Func<string, bool> isValidField, string errorMessage)
        {
            int tries = Configurable.Tries;
            string input = this.GetString(prompt);
            if (optional && string.IsNullOrWhiteSpace(input))
            {
                return string.Empty;
            }

            while (!isValidField(input))
            {
                if (tries <= 0)
                {
                    throw new InvalidDataException("No attempt left, Please try again." + Environment.NewLine);
                }

                Console.WriteLine(errorMessage);
                Console.WriteLine($"Tries left: {--tries}\n");
                input = this.GetString(prompt);
            }

            return input;
        }
    }
}
