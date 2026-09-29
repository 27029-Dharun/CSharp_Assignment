using Assignment8.CustomExceptions;

namespace Assignment8.View;

/// <summary>
/// Contains all the view
/// </summary>
internal class ConsoleView
{
    /// <summary>
    /// Displays the text in the color requested by the user and resets the color.
    /// </summary>
    /// <param name="message">Message to be printed by the user.</param>
    /// <param name="color">Color of the text</param>
    internal void PrintColoredText(string message, ConsoleColor color)
    {
        Console.ForegroundColor = color;
        Console.WriteLine(message);
        Console.ResetColor();
    }

    /// <summary>
    /// Gets a string input from the user.
    /// </summary>
    /// <param name="prompt">Prompt to be displayed to the user.</param>
    /// <returns>A non null string value entered by the user.</returns>
    internal string GetString(string prompt)
    {
        Console.Write(prompt);
        string input = (Console.ReadLine() ?? string.Empty).Trim();
        return input;
    }

    /// <summary>
    /// Displays message to the user.
    /// </summary>
    /// <param name="message">Prompt to be displayed to the user.</param>
    internal void PrintInfo(string message)
    {
        Console.WriteLine(message);
    }

    /// <summary>
    /// Displays an yellow colored text.
    /// </summary>
    /// <param name="message">Message to be displayed to the user.</param>
    internal void PrintWarning(string message)
    {
        this.PrintColoredText(message, ConsoleColor.Yellow);
    }

    /// <summary>
    /// Get the integer value from the user by displaying the prompt
    /// </summary>
    /// <param name="prompt">Prompt to be displayed to the user.</param>
    /// <returns>A integer value entered by the user.</returns>
    /// <exception cref="InvalidUserInputException">Throws if the user input is not parsed.</exception>
    internal int GetInteger(string prompt)
    {
        string input = this.GetString(prompt);
        int value;
        if (!int.TryParse(input, out value))
        {
            throw new InvalidUserInputException("Enter a valid integer");
        }

        return value;
    }

    /// <summary>
    /// Display and gets the menu option from the user
    /// </summary>
    /// <returns>An integer value representing the option</returns>
    internal int GetMenuOption()
    {
        Console.WriteLine(
            "1. Task 1 -  Divide by zero\n" +
            "2. Task 2 - Index out of bound\n" +
            "3. Task 3 - Custom exception\n" +
            "4. Task 4 - Global exception handling\n" +
            "5. Task 5 - View stack trace\n" +
            "6. Exit");

        return this.GetInteger("Select an operation to perform: ");
    }

    /// <summary>
    /// Clears the console.
    /// </summary>
    internal void ClearConsole()
    {
        Console.Clear();
    }

    /// <summary>
    /// Pause until a key is read and clear the console.
    /// </summary>
    internal void PauseAndReturn()
    {
        Console.WriteLine("Press any key to return to menu");
        Console.ReadKey();
        Console.Clear();
    }

    /// <summary>
    /// Displays message to the user in the same line.
    /// </summary>
    /// <param name="message">Prompt to be displayed to the user.</param>
    internal void Print(string message)
    {
        Console.Write(message);
    }
}
