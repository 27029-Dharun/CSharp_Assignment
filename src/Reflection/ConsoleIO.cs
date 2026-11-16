namespace Reflection;

/// <summary>
/// Contains the view level operations
/// </summary>
public static class ConsoleIO
{
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
    /// Clears the console.
    /// </summary>
    public static void ClearConsole()
    {
        Console.ReadKey();
        Console.Clear();
    }
}