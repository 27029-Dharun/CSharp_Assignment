using UtilityApp;

namespace DisplayApp;

/// <summary>
/// Contains the display methods for the calculator app/.
/// </summary>
public static class Display
{
    /// <summary>
    /// Displays the title.
    /// </summary>
    /// <param name="title">The title to be displayed.</param>
    public static void DisplayTitle(string title) => ConsoleHelper.DisplayHeader(title);

    /// <summary>
    /// Displays the result of the operation.
    /// </summary>
    /// <param name="op">The mathematical operation to be performed.</param>
    /// <param name="a">The first number.</param>
    /// <param name="b">The second number.</param>
    /// <param name="result">The result of the arithmetic operation.</param>
    public static void DisplayResult(string op, double a, double b, double result)
    {
        Console.WriteLine($"{a} {op} {b} = {result}", ConsoleColor.Green);
    }
}