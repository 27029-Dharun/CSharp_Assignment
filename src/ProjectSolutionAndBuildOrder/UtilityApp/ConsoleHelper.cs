namespace UtilityApp;

/// <summary>
/// Contains the console helper methods.
/// </summary>
public static class ConsoleHelper
{
    /// <summary>
    /// Print the header by aligning in the center.
    /// </summary>
    /// <param name="title">The title to be printed.</param>
    public static void DisplayHeader(string title)
    {
        int width = Console.WindowWidth;
        int padding = (width - title.Length) / 2;
        Console.Write(new string(' ', padding));
        DisplayColoredText(title, ConsoleColor.Blue);
    }

    /// <summary>
    /// Prints the colored text.
    /// </summary>
    /// <param name="text">The text to be printed.</param>
    /// <param name="color">Color to be printed.</param>
    private static void DisplayColoredText(string text, ConsoleColor color)
    {
        Console.ForegroundColor = color;
        Console.WriteLine(text);
        Console.ResetColor();
    }
}