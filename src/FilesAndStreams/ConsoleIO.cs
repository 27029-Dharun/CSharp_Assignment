namespace FilesAndStreams;

/// <summary>
/// Contains the view level operations
/// </summary>
internal static class ConsoleIO
{
    /// <summary>
    /// Displays the message and gets the input from the user.
    /// </summary>
    /// <param name="message">Message to be printed.</param>
    /// <returns>A string value entered by the user.</returns>
    internal static string GetString(string message)
    {
        Console.Write(message);
        string input = (Console.ReadLine() ?? string.Empty).Trim();
        return input;
    }

    /// <summary>
    /// Gets the integer from the user with attempts.
    /// </summary>
    /// <param name="prompt">The message to be display to get the integer</param>
    /// <returns>A integer value enter by the user.</returns>
    /// <exception cref="InvalidDataException">Thrown when the enter input is not a valid integer.</exception>
    internal static int GetInteger(string prompt)
    {
        int attemptsLeft = 3;
        while (attemptsLeft > 0)
        {
            string input = GetString(prompt);
            if (int.TryParse(input, out int grade))
            {
                return grade;
            }

            Console.WriteLine("Enter a valid integer, Attempt left: " + attemptsLeft);
            attemptsLeft--;
        }

        throw new InvalidDataException("No attempt left, Please try again.\n");
    }

    /// <summary>
    /// Pause and clear the console after entering a key
    /// </summary>
    internal static void PauseAndClear()
    {
        Console.WriteLine("Press any key to clear");
        Console.ReadKey();

        // Erases the entire scroll back buffer history
        Console.Write("\x1b[3J");
        Console.Clear();
    }
}
