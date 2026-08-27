namespace Assignment9AdvancedLINQ.Views
{
    /// <summary>
    /// Contains the view level operations
    /// </summary>
    public class ConsoleView
    {
        /// <summary>
        /// Displays the message and gets the input from the user.
        /// </summary>
        /// <param name="message">Message to be printed.</param>
        /// <returns>A string value entered by the user.</returns>
        public string GetString(string message)
        {
            Console.Write(message);
            string input = (Console.ReadLine() ?? string.Empty).Trim();
            return input;
        }

        /// <summary>
        /// Displays the enum value and gets input from the user
        /// </summary>
        /// <typeparam name="T">Type variable that should be struct</typeparam>
        /// <param name="message">String to be printed</param>
        /// <returns>returns a enum value entered by use</returns>
        public T GetEnumValue<T>(string message)
           where T : struct, Enum
        {
            int tries = 3;
            Console.WriteLine($"\n{message}");
            foreach (var value in Enum.GetValues<T>())
            {
                Console.WriteLine($"{Convert.ToInt32(value)}. {value}");
            }

            string input = Console.ReadLine() ?? string.Empty;
            int integer;
            while (!int.TryParse(input, out integer) || !Enum.IsDefined(typeof(T), integer))
            {
                if (tries == 1)
                {
                    throw new InvalidDataException("No attempt left, Please try again." + Environment.NewLine);
                }

                Console.WriteLine($"Tries left: {--tries}, Enter the valid integer");
                Console.WriteLine($"{message}");
                input = Console.ReadLine() ?? string.Empty;
            }

            return (T)Enum.ToObject(typeof(T), integer);
        }

        /// <summary>
        /// Clears the console messages
        /// </summary>
        public void ClearConsole()
        {
            // Erases the entire scroll back buffer history
            Console.Write("\x1b[3J");
            Console.Clear();
        }

        /// <summary>
        /// Pause the console and clear
        /// </summary>
        public void PauseAndClear()
        {
            Console.WriteLine("Press a key to continue...");
            Console.ReadKey();
            this.ClearConsole();
        }

        /// <summary>
        /// Prints the message in the console.
        /// </summary>
        /// <param name="message">The message to be printed</param>
        public void PrintInfo(string message)
        {
            Console.WriteLine($"{message}");
        }

        /// <summary>
        /// Gets a valid integer from the user.
        /// </summary>
        /// <param name="message">Message to be printed</param>
        /// <returns>An integer value</returns>
        public int GetInteger(string message)
        {
            string input = this.GetString(message);
            int integer;
            while (!int.TryParse(input, out integer))
            {
                Console.WriteLine("Enter a valid input");
                input = this.GetString(message);
            }

            return integer;
        }
    }
}
