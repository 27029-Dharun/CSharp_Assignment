namespace Assignment4.View
{
    /// <summary>
    /// Contains the console operations that prints and gets input from user
    /// </summary>
    internal class ConsoleView
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
                Console.WriteLine("Enter a valid integer\n");
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

            decimal value;
            if (!decimal.TryParse(input, out value))
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
        /// <param name="message">Message to be printed</param>
        /// <param name="tries">Tries for user to retry</param>
        /// <returns>DateOnly value entered by user</returns>
        internal DateOnly GetDate(string message, int tries = 3)
        {
            DateOnly validDate;
            string input;
            string format = "dd/MM/yyyy";
            Console.Write(message);
            Console.WriteLine($"Enter a date in format ({format}):");

            input = Console.ReadLine() ?? string.Empty;
            while (DateOnly.TryParseExact(input, format, out validDate))
            {
                if (tries <= 0)
                {
                    return DateOnly.MinValue;
                }

                Console.WriteLine($"Invalid date. Please enter in format {format}:");
                tries--;

                Console.WriteLine($"Tries Left: {tries--}");
                Console.WriteLine(message);
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
        /// Prints empty line
        /// </summary>
        internal void PrintEmptyLine()
        {
            Console.WriteLine();
        }
    }
}
