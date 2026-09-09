using System.Globalization;
using ConsoleTables;
using ExpenseTracker.Constants;
using ExpenseTracker.DTOs;
using ExpenseTracker.Models;
using ExpenseTracker.Validators;

namespace ExpenseTracker.View
{
    /// <summary>
    /// Contains the console operations that prints and gets input from user.
    /// </summary>
    public class ConsoleView
    {
        /// <summary>
        /// Prints the input string.
        /// </summary>
        /// <param name="message">The string to be printed.</param>
        public void PrintInfo(string message)
        {
            Console.WriteLine(message);
        }

        /// <summary>
        /// Prints an empty line.
        /// </summary>
        public void PrintEmptyLine()
        {
            Console.WriteLine();
        }

        /// <summary>
        /// Displays the enum value and gets input from the user.
        /// </summary>
        /// <typeparam name="T">Type variable that should be struct.</typeparam>
        /// <param name="message">String to be printed.</param>
        /// <returns>returns a enum value entered by use.</returns>
        public T GetEnumValue<T>(string message)
           where T : struct, Enum
        {
            while (true)
            {
                string input = this.GetString(message);
                if (Enum.TryParse(input, out T result) && Enum.IsDefined(result))
                {
                    return result;
                }

                Console.Clear();
                Console.WriteLine("Enter a valid option");
            }
        }

        /// <summary>
        /// Gets decimal input.
        /// </summary>
        /// <param name="isEditMode">True if we want to perform edit operation.</param>
        /// <returns>decimal input.</returns>
        public string GetDescription(bool isEditMode = false)
        {
            string input = this.GetValidatedInput(
                "Enter the description of the transaction: ",
                isEditMode,
                TransactionValidator.IsValidDescription,
                $"Please enter a valid description with more than {Configurable.MinimumCharacter} characters and less than {Configurable.MaximumCharacter}.");
            return input;
        }

        /// <summary>
        /// Gets decimal input.
        /// </summary>
        /// <param name="isEditMode">True if we want to perform edit operation.</param>
        /// <returns>decimal input.</returns>
        public decimal GetAmount(bool isEditMode = false)
        {
            string input = this.GetValidatedInput(
                "Enter the amount involved in the transaction: ",
                isEditMode,
                TransactionValidator.IsValidAmount,
                $"Invalid amount.Please enter a valid amount greater than {Configurable.MinimumAmount}.");

            // Only returns a empty string in edit mode.
            if (string.IsNullOrEmpty(input))
            {
                return Configurable.ExistingPriceValue;
            }

            return decimal.Parse(input);
        }

        /// <summary>
        /// Gets the Date from the user.
        /// </summary>
        /// <param name="isEditMode">True if we want to perform edit operation.</param>
        /// <returns>DateTime value entered by user.</returns>
        public DateTime GetDate(bool isEditMode = false)
        {
            string input = this.GetValidatedInput(
                $"Enter a date in format ({Configurable.DateFormat}): ",
                isEditMode,
                TransactionValidator.IsValidDate,
                $"Invalid date. Please enter a date in format {Configurable.DateFormat}.\nCan't add transaction for future date.");

            // Only returns a empty string in edit mode.
            if (string.IsNullOrEmpty(input))
            {
                return DateTime.Parse(Configurable.ExistingDate, CultureInfo.InvariantCulture, DateTimeStyles.None);
            }

            return DateTime.Parse(input, CultureInfo.InvariantCulture, DateTimeStyles.None);
        }

        /// <summary>
        /// Gets a valid string category.
        /// </summary>
        /// <param name="isEditMode">True if we want to perform edit operation.</param>
        /// <returns>A string containing the category.</returns>
        public string GetCategory(bool isEditMode = true)
        {
            string input = this.GetValidatedInput(
                $"Enter the category of the transaction: ",
                isEditMode,
                TransactionValidator.IsValidCategory,
                $"Please enter a valid category with more than {Configurable.MinimumCharacter} characters and less than {Configurable.MaximumCategoryCharacter}.");

            return input;
        }

        /// <summary>
        /// Get the id of the transaction.
        /// </summary>
        /// <returns>The transaction Id entered by the user.</returns>
        public string GetId()
        {
            return this.GetValidatedInput("Select the transaction by id: ", false, TransactionValidator.IsValidId, "Enter the ID in the format (I001)");
        }

        /// <summary>
        /// Clears the console messages.
        /// </summary>
        public void ClearConsole()
        {
            // Erases the entire scroll back buffer history
            Console.Write("\x1b[3J");
            Console.Clear();
        }

        /// <summary>
        /// Displays the error message in red color.
        /// </summary>
        /// <param name="message">message to be printed.</param>
        public void PrintError(string message)
        {
            this.PrintColoredText(message, ConsoleColor.Red);
        }

        /// <summary>
        /// Displays the success message in green color.
        /// </summary>
        /// <param name="message">message to be printed.</param>
        public void PrintSuccess(string message)
        {
            this.PrintColoredText(message, ConsoleColor.Green);
        }

        /// <summary>
        /// Displays the error message in red color.
        /// </summary>
        /// <param name="message">message to be printed.</param>
        public void PrintWarning(string message)
        {
            this.PrintColoredText(message, ConsoleColor.Yellow);
        }

        /// <summary>
        /// Displays the transactions.
        /// </summary>
        /// <param name="transactions">List of transactions.</param>
        public void PrintTransactionTable(IReadOnlyList<Transaction> transactions)
        {
            var table = new ConsoleTable(
                "Transaction Id",
                "Type",
                "Category",
                "Date",
                "Amount",
                "Description");

            foreach (Transaction transaction in transactions)
            {
                table.AddRow(
                    transaction.Id,
                    transaction.Type,
                    transaction.Category,
                    transaction.Date.ToShortDateString(),
                    transaction.Amount,
                    transaction.Description);
            }

            table.Write();
        }

        /// <summary>
        /// Prints the summary of all the transactions with visualizations.
        /// </summary>
        /// <param name="summary">Summary instance that contains the summary of all the transactions.</param>
        public void PrintSummary(TransactionSummary summary)
        {
            Console.WriteLine("\nIncome vs expense");
            this.PrintBarChart(new Dictionary<string, decimal>()
            {
                { "Income", summary.Income },
                { "Expense", summary.Expense },
            });

            if (summary.ExpenseCategoryTotals != null && summary.ExpenseCategoryTotals.Count > 0)
            {
                Console.WriteLine("\nCategory wise expense");
                this.PrintBarChart(summary.ExpenseCategoryTotals);
            }
            else
            {
                this.PrintInfo("No expense recorded");
            }

            if (summary.IncomeCategoryTotals != null && summary.IncomeCategoryTotals.Count > 0)
            {
                Console.WriteLine("\nCategory wise income");
                this.PrintBarChart(summary.IncomeCategoryTotals);
            }
            else
            {
                this.PrintInfo("No income recorded");
            }
        }

        /// <summary>
        /// Waits for user to press a key and clears the console.
        /// </summary>
        public void PauseAndReturn()
        {
            Console.WriteLine("Press any key to return to main menu");
            Console.ReadKey();

            // Erases the entire scroll back buffer history
            Console.Write("\x1b[3J");
            Console.Clear();
        }

        private void PrintBarChart(Dictionary<string, decimal> categoryTotals)
        {
            decimal maxValue = categoryTotals.Values.Max();
            int maxPad = categoryTotals.Keys.Max(key => key.Length);
            int maxBarLength = Configurable.MaxBarLength;

            foreach (var item in categoryTotals)
            {
                int barLength = (int)(item.Value * maxBarLength / maxValue) + 1;

                Console.Write($"{item.Key,-10} ");
                Console.BackgroundColor = ConsoleColor.DarkBlue;
                Console.Write($" {new string(' ', barLength)}");
                Console.ResetColor();
                Console.WriteLine($" {item.Value}\n");
            }
        }

        private void PrintColoredText(string message, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        private string GetValidatedInput(
            string prompt,
            bool isEditMode,
            Func<string, bool> isValidField,
            string errorMessage)
        {
            int remainingAttempts = Configurable.MaximumAttempts;
            string input = this.GetString(prompt);
            if (isEditMode && string.IsNullOrWhiteSpace(input))
            {
                return string.Empty;
            }

            while (!isValidField(input))
            {
                if (remainingAttempts == 1)
                {
                    throw new InvalidDataException("No attempt left, Please try again.\n");
                }

                Console.WriteLine(errorMessage);
                Console.WriteLine($"Tries left: {--remainingAttempts}\n");
                input = this.GetString(prompt);
            }

            return input;
        }

        /// <summary>
        /// Gets the string input from the user.
        /// </summary>
        /// <param name="message">Message to be printed.</param>
        /// <returns>int value that we got as input.</returns>
        private string GetString(string message)
        {
            Console.Write(message);
            string input = (Console.ReadLine() ?? string.Empty).Trim();

            return input;
        }
    }
}
