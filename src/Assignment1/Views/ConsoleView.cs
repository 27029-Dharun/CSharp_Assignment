using Assignment1.Models;
using Assignment1.Validation;

namespace Assignment1.Views;

/// <summary>
/// Ui methods are listed in UI class
/// </summary>
internal static class ConsoleView
{
    /// <summary>
    /// Prints the empty line
    /// </summary>
    internal static void PrintEmptyLine() => Console.WriteLine();

    /// <summary>
    /// Prints the input string
    /// </summary>
    /// <param name="message">The string to be printed</param>
    internal static void PrintInfo(string message)
    {
        Console.WriteLine(message);
    }

    /// <summary>
    /// Gets the string input from the user.
    /// </summary>
    /// <param name="message">Message to be printed</param>
    /// <returns>int value that we got as input</returns>
    internal static string GetString(string message)
    {
        Console.Write(message);
        string input = (Console.ReadLine() ?? string.Empty).Trim();

        return input;
    }

    /// <summary>
    /// Gets the Integer input
    /// </summary>
    /// <param name="message">Message to be printed</param>
    /// <returns>int value that we got as input</returns>
    internal static int GetInteger(string message)
    {
        int input;
        Console.Write(message);
        while (!int.TryParse(Console.ReadLine(), out input))
        {
            Console.WriteLine("Please enter a integer");
        }

        return input;
    }

    /// <summary>
    /// Gets the name of the contact.
    /// </summary>
    /// <param name="prompt">Prompt to be displayed</param>
    /// <returns>A string value containing the name</returns>
    internal static string GetContactName(string prompt)
    {
        string input = GetString(prompt);
        while (!ContactInputValidator.IsValidName(input))
        {
            Console.WriteLine("Name can't be empty and should contain at least 5 characters");
            input = GetString(prompt);
        }

        return input;
    }

    /// <summary>
    /// Gets the name of the contact.
    /// </summary>
    /// <param name="prompt">Prompt to be displayed</param>
    /// <returns>A string value containing the name</returns>
    internal static string GetPhoneNumber(string prompt)
    {
        string input = GetString(prompt);
        while (!ContactInputValidator.IsValidPhoneNumber(input))
        {
            Console.WriteLine("Phone number can't be empty and should contain 10 digits");
            input = GetString(prompt);
        }

        return input;
    }

    /// <summary>
    /// Gets the notes for the contacts
    /// </summary>
    /// <param name="prompt">Prompt to be displayed</param>
    /// <returns>A string value containing notes.</returns>
    internal static string GetEmail(string prompt)
    {
        string input = GetString(prompt);

        while (!ContactInputValidator.IsValidEmail(input))
        {
            Console.WriteLine("Email is required and should be in correct format.");
            Console.WriteLine("Follow the format name@example.com");
            input = GetString(prompt);
        }

        return input;
    }

    /// <summary>
    /// Gets the notes for the contacts
    /// </summary>
    /// <param name="prompt">Prompt to be displayed</param>
    /// <returns>A string value containing notes.</returns>
    internal static string GetNotes(string prompt)
    {
        string input = GetString(prompt);
        if (input.Equals(string.Empty))
        {
            input = "Not specified";
            return input;
        }

        while (!ContactInputValidator.IsValidNotes(input))
        {
            Console.WriteLine($"Notes should not have more than {ContactInputValidator.MaximumNotesLength} characters.");
            input = GetString(prompt);
        }

        return input;
    }

    /// <summary>
    /// Gets the name of the contact.
    /// </summary>
    /// <param name="prompt">Prompt to be displayed</param>
    /// <returns>A string value containing the name</returns>
    internal static string GetOptionalContactName(string prompt)
    {
        string input = GetString(prompt);
        if (string.IsNullOrEmpty(input))
        {
            return input;
        }

        while (!ContactInputValidator.IsValidName(input))
        {
            Console.WriteLine($"Name can't be empty and should contain at least {ContactInputValidator.MinimumNameLength} characters");
            input = GetString(prompt);
        }

        return input;
    }

    /// <summary>
    /// Gets the name of the contact.
    /// </summary>
    /// <param name="prompt">Prompt to be displayed</param>
    /// <returns>A string value containing the name</returns>
    internal static string GetOptionalPhoneNumber(string prompt)
    {
        string input = GetString(prompt);
        if (string.IsNullOrEmpty(input))
        {
            return input;
        }

        while (!ContactInputValidator.IsValidPhoneNumber(input))
        {
            Console.WriteLine($"Phone number can't be empty and should contain {ContactInputValidator.PhoneNumberLength} digits");
            input = GetString(prompt);
        }

        return input;
    }

    /// <summary>
    /// Gets the notes for the contacts
    /// </summary>
    /// <param name="prompt">Prompt to be displayed</param>
    /// <returns>A string value containing notes.</returns>
    internal static string GetOptionalEmail(string prompt)
    {
        string input = GetString(prompt);
        if (string.IsNullOrEmpty(input))
        {
            return input;
        }

        while (!ContactInputValidator.IsValidEmail(input))
        {
            Console.WriteLine("Email is required and should be in correct format.");
            input = GetString(prompt);
        }

        return input;
    }

    /// <summary>
    /// Prints all the contact list
    /// </summary>
    /// <param name="contacts">Contacts list</param>
    internal static void PrintContact(IReadOnlyList<Contact> contacts)
    {
        if (contacts.Count > 0)
        {
            Console.WriteLine("The Contacts list");
            var i = 1;
            foreach (Contact contact in contacts)
            {
                Console.WriteLine($"{i++}. {contact.Name} , {contact.PhoneNumber} , {contact.Email} , {contact.Notes} ");
            }

            Console.WriteLine();
        }
        else
        {
            Console.WriteLine("The contacts list is empty\n");
        }
    }

    /// <summary>
    /// Gets valid contact index
    /// </summary>
    /// <param name="count">Count of the contacts available</param>
    /// <returns>Integer value</returns>
    internal static int GetValidContactIndex(int count)
    {
        while (true)
        {
            int input = ConsoleView.GetInteger("Select the contact: ");
            int zeroBasedIndex = input - 1;
            if (zeroBasedIndex >= 0 && count > zeroBasedIndex)
            {
                return zeroBasedIndex;
            }

            Console.WriteLine("Enter a valid index. Maximum Value: " + (count - 1));
        }
    }

    /// <summary>
    /// Clears the console
    /// </summary>
    internal static void Clear()
    {
        Console.Clear();
    }
}