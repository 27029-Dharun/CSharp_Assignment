using Assignment10.Enums;
using Assignment10.IO;

namespace Assignment10.Views
{
    /// <summary>
    /// Contains the console operations that prints and gets input from user
    /// </summary>
    public class ConsoleView
    {
        /// <summary>
        /// Gets the input number from the user
        /// </summary>
        /// <param name="prompt">Prompt to be displayed</param>
        /// <returns>A integer value entered by the user.</returns>
        public int GetNumber(string prompt)
        {
            string input = ConsoleIO.GetString(prompt);
            int integer;
            if (!int.TryParse(input, out integer))
            {
                throw new FormatException("No attempt left - Please enter a valid integer." + Environment.NewLine);
            }

            return integer;
        }

        /// <summary>
        /// Get a valid menu option from the user.
        /// </summary>
        /// <returns>A menu option to perform</returns>
        public MenuOption GetMenu()
        {
            ConsoleIO.PrintHeader("Basic Calculator Application");
            ConsoleIO.PrintInfo("1. Add two integer\n" +
                "2. Subtract two integer\n" +
                "3. Multiply two integer\n" +
                "4. Divide two integer\n" +
                "5. Exit");
            ConsoleIO.PrintInfo("Select an option to proceed");
            return ConsoleIO.GetEnumValue<MenuOption>();
        }

        /// <summary>
        /// Prints the header in center alignment
        /// </summary>
        /// <param name="header">Header to be printed</param>
        public void PrintHeader(string header)
        {
            ConsoleIO.PrintHeader(header);
        }

        /// <summary>
        /// Prints the message in console
        /// </summary>
        /// <param name="message">Header to be printed</param>
        public void Print(string message)
        {
            ConsoleIO.PrintInfo(message);
        }

        /// <summary>
        /// Clears the console messages
        /// </summary>
        public void PauseAndClear()
        {
            ConsoleIO.PrintInfo("Enter a key to return to main menu");
            Console.ReadKey();

            // Erases the entire scroll back buffer history
            ConsoleIO.PrintInfo("\x1b[3J");
            Console.Clear();
        }

        /// <summary>
        /// Clears the console messages
        /// </summary>
        public void ClearConsole()
        {
            // Erases the entire scroll back buffer history
            ConsoleIO.PrintInfo("\x1b[3J");
            Console.Clear();
        }
    }
}
