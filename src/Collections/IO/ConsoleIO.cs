namespace Collections.IO;

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
        T result;
        while (!Enum.TryParse(input, out result) || !Enum.IsDefined(result))
        {
            Console.WriteLine("Enter a valid option");
            input = Console.ReadLine() ?? string.Empty;
        }

        return result;
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

    /// <summary>
    /// Gets the character from user.
    /// </summary>
    /// <returns>A character entered by the user.</returns>
    internal static char GetCharacter()
    {
        while (true)
        {
            string input = GetString("Enter a character: ");
            if (input.Length == 1)
            {
                return input[0];
            }

            Console.WriteLine("Enter a valid character.");
        }
    }
}