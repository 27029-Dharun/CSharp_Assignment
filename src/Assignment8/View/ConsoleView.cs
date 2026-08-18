using Assignment8.CustomExceptions;
using Assignment8.Enums;

namespace Assignment8.View;

/// <summary>
/// Contains all the view
/// </summary>
public class ConsoleView
{
    public void PrintColoredText(string message, ConsoleColor color)
    {
        Console.ForegroundColor = color;
        Console.WriteLine(message);
        Console.ResetColor();
    }

    public string GetString(string prompt)
    {
        Console.Write(prompt);
        string input = (Console.ReadLine() ?? string.Empty).Trim();
        return input;
    }

    public void PrintInfo(string message)
    {
        Console.WriteLine(message);
    }

    public void PrintWarning(string message)
    {
        this.PrintColoredText(message, ConsoleColor.Yellow);
    }

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

    internal MenuOption GetMenuOption()
    {
        Console.WriteLine(
            "1. Divide integers\n" +
            "2. Array\n" +
            "3. Custom Exception\n + " +
            "4. Global Unhandled exception\n +" +
            "5. ");

        return (MenuOption)this.GetInteger("Select an operation to perform: ");
    }
}
