using Assignment2.Models.BankingSystem;
using Assignment2.Validators;

namespace Assignment2.Views;

/// <summary>
/// Contains all the console operations
/// </summary>
internal class ConsoleView
{
    /// <summary>
    /// Prints the info on the console.
    /// </summary>
    /// <param name="message">String to be printed</param>
    internal void PrintInfo(string message)
    {
        Console.WriteLine(message);
    }

    /// <summary>
    /// Displays the notes to make a note of the account number.
    /// </summary>
    internal void DisplayNote()
    {
        Console.WriteLine(
            "-------------------------\n" +
            "Note the account number to perform further transactions\n" +
            "-------------------------\n");
    }

    /// <summary>
    /// Gets a string input from the user until the input is a valid string.
    /// </summary>
    /// <param name="prompt"> Prompt to be displayed to the user. </param>
    /// <returns> The string entered by user. </returns>
    internal string GetString(string prompt)
    {
        Console.Write(prompt);
        string input = (Console.ReadLine() ?? string.Empty).Trim();
        return input;
    }

    /// <summary>
    /// Gets a integer input from the user until the input is a valid integer number.
    /// </summary>
    /// <param name="prompt"> Prompt to be displayed to the user. </param>
    /// <returns> The integer value entered by user. </returns>
    internal int GetInteger(string prompt)
    {
        Console.Write(prompt);
        int input;
        while (!int.TryParse(Console.ReadLine(), out input))
        {
            Console.WriteLine("Enter a valid integer");
        }

        return input;
    }

    /// <summary>
    /// This prints the balance and account of the Account.
    /// </summary>
    /// <param name="account"> Instance of the account. </param>
    internal void PrintBalance(BankAccount account)
    {
        Console.WriteLine($"Account Number: {account.AccountNumber}");
        Console.WriteLine($"Balance: {account.Balance}");
    }

    /// <summary>
    /// Pause the flow until a key is entered.
    /// </summary>
    internal void PauseAndReturn()
    {
        Console.WriteLine("Press any key to return to main menu.");
        Console.ReadKey();

        // Erases the entire scroll back buffer history
        Console.Write("\x1b[3J");
        Console.Clear();
    }

    /// <summary>
    /// Gets the name
    /// </summary>
    /// <param name="message">Message to be displayed to get the name</param>
    /// <returns>Name entered by the user.</returns>
    internal string GetName(string message)
    {
        string input = this.GetString(message);
        while (!Validator.IsAllAlphabet(input))
        {
            Console.WriteLine("Name should only contain alphabets.");
            input = this.GetString(message);
        }

        return input;
    }

    /// <summary>
    /// Gets the valid dimension
    /// </summary>
    /// <param name="message">Prompt to be displayed</param>
    /// <returns>A double input entered by the user</returns>
    internal double GetDimension(string message)
    {
        double dimension;
        string input = this.GetString(message);
        while ((!double.TryParse(input, out dimension)) || (!Validator.IsValidDimension(dimension)))
        {
            Console.WriteLine("Dimension must be a valid non-negative number.");
            input = this.GetString(message);
        }

        return dimension;
    }

    /// <summary>
    /// Gets the valid amount from the user.
    /// </summary>
    /// <param name="message">Prompt to be displayed</param>
    /// <returns>A decimal input entered by the user</returns>
    internal decimal GetAmount(string message)
    {
        decimal amount;
        string input = this.GetString(message);

        while ((!decimal.TryParse(input, out amount)) || (!Validator.IsValidAmount(amount)))
        {
            Console.WriteLine("Amount must be a valid non-negative number.");
            input = this.GetString(message);
        }

        return amount;
    }

    /// <summary>
    /// Get the account number from the user
    /// </summary>
    /// <param name="message">Message to be displayed to the user.</param>
    /// <returns>A string containing the account number</returns>
    internal string GetAccountNumber(string message)
    {
        string input = this.GetString(message);
        while (!Validator.IsValidAccountNumber(input))
        {
            Console.WriteLine("Account number must be a valid 12 digit number.");
            input = this.GetString(message);
        }

        return input;
    }
}
