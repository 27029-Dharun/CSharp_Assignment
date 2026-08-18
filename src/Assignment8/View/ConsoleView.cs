using Assignment8.CustomExceptions;
using Assignment8.Enums;
using Assignment8.Helpers;

namespace Assignment8.View;

/// <summary>
/// Contains all the view
/// </summary>
public class ConsoleView
{
    public void PrintInfo(string message)
    {
        Console.WriteLine(message);
    }

    public void PrintError(string message)
    {
        ConsoleHelper.PrintColoredText(message, ConsoleColor.Red);
    }

    public void PrintSuccess(string message)
    {
        ConsoleHelper.PrintColoredText(message, ConsoleColor.Green);
    }

    public void PrintWarning(string message)
    {
        ConsoleHelper.PrintColoredText(message, ConsoleColor.Yellow);
    }

    internal int GetInteger(string prompt)
    {
        string input = ConsoleHelper.GetString(prompt);
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
            "3. Custom Exception\n");

        return (MenuOption)this.GetInteger("Select an operation to perform: ");
    }
}
