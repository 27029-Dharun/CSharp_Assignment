namespace Assignment10.IO
{
    /// <summary>
    /// Contains the view level operations
    /// </summary>
    public static class ConsoleIO
    {
        /// <summary>
        /// Displays the message and gets the input from the user.
        /// </summary>
        /// <param name="message">Message to be printed.</param>
        /// <returns>A string value entered by the user.</returns>
        public static string GetString(string message)
        {
            Console.Write(message);
            string input = (Console.ReadLine() ?? string.Empty).Trim();
            return input;
        }

        /// <summary>
        /// Displays the enum value and gets input from the user
        /// </summary>
        /// <typeparam name="T">Type variable that should be struct</typeparam>
        /// <returns>returns a enum value entered by user</returns>
        public static T GetEnumValue<T>()
           where T : struct, Enum
        {
            string input = Console.ReadLine() ?? string.Empty;
            int integer;
            while (!int.TryParse(input, out integer) || !Enum.IsDefined(typeof(T), integer))
            {
                Console.WriteLine("Enter a valid option");
                input = Console.ReadLine() ?? string.Empty;
            }

            return (T)Enum.ToObject(typeof(T), integer);
        }

        /// <summary>
        /// Prints the a center aligned text in the console.
        /// </summary>
        /// <param name="message">Message to be printed</param>
        public static void PrintHeader(string message)
        {
            int width = Console.WindowWidth;
            int padding = Math.Max((width - message.Length) / 2, 0);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(new string(' ', padding) + message);
            Console.ResetColor();
        }

        /// <summary>
        /// Prints the message in the console.
        /// </summary>
        /// <param name="message">The message to be printed</param>
        public static void PrintInfo(string message)
        {
            Console.WriteLine($"{message}");
        }
    }
}