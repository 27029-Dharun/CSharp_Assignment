namespace AdvancedFeatures.IO;

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
    /// Gets and validates an enum option selected by the user.
    /// </summary>
    /// <typeparam name="T">Generics type parameter which accepts all Enum type.</typeparam>
    /// <param name="prompt">Prompt displayed to the user.</param>
    /// <returns>The enum type to parse and validate.</returns>
    internal static T GetEnumOption<T>(string prompt)
        where T : struct, Enum
    {
        while (true)
        {
            string input = GetString(prompt);
            if (Enum.TryParse(input, out T result) && Enum.IsDefined(result))
            {
                return result;
            }

            Console.Clear();
            Console.WriteLine("Enter a valid option");
        }
    }

    /// <summary>
    /// Prints the a center aligned text in the console.
    /// </summary>
    /// <param name="message">Message to be printed</param>
    internal static void PrintHeader(string message)
    {
        int width = Console.WindowWidth;
        int padding = Math.Max((width - message.Length) / 2, 0);
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine(new string(' ', padding) + message);
        Console.ResetColor();
        Console.WriteLine();
    }

    /// <summary>
    /// Prints the message in the console.
    /// </summary>
    /// <param name="message">The message to be printed</param>
    internal static void PrintInfo(string message)
    {
        Console.WriteLine($"{message}");
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