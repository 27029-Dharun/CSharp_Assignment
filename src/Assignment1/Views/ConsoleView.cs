using Assignment1.Models;
using Assignment1.Validation;

namespace Assignment1.Views;

/// <summary>
/// Ui methods are listed in UI class
/// </summary>
internal class ConsoleView
{
    /// <summary>
    /// Prints the empty line
    /// </summary>
    internal void PrintEmptyLine() => Console.WriteLine();

    /// <summary>
    /// Prints the input string
    /// </summary>
    /// <param name="message">The string to be printed</param>
    internal void PrintInfo(string message)
    {
        Console.WriteLine(message);
    }

    /// <summary>
    /// Gets the string input from the user.
    /// </summary>
    /// <param name="message">Message to be printed</param>
    /// <returns>int value that we got as input</returns>
    internal string GetString(string message)
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
    internal int GetInteger(string message)
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
    internal string GetContactName(string prompt)
    {
        return this.GetValidatedInput(
            prompt,
            false,
            ContactInputValidator.IsValidName,
            $"Name can't be empty and should contain at least {ContactInputValidator.MinimumNameLength} characters");
    }

    /// <summary>
    /// Gets the name of the contact.
    /// </summary>
    /// <param name="prompt">Prompt to be displayed</param>
    /// <returns>A string value containing the name</returns>
    internal string GetPhoneNumber(string prompt)
    {
        return this.GetValidatedInput(
            prompt,
            false,
            ContactInputValidator.IsValidPhoneNumber,
            $"Phone number can't be empty and should contain {ContactInputValidator.PhoneNumberLength} digits");
    }

    /// <summary>
    /// Gets the notes for the contacts
    /// </summary>
    /// <param name="prompt">Prompt to be displayed</param>
    /// <returns>A string value containing notes.</returns>
    internal string GetEmail(string prompt)
    {
        return this.GetValidatedInput(
            prompt,
            false,
            ContactInputValidator.IsValidEmail,
            $"Email should be in the correct format\nex. dharun@example.com");
    }

    /// <summary>
    /// Gets the notes for the contacts
    /// </summary>
    /// <param name="prompt">Prompt to be displayed</param>
    /// <returns>A string value containing notes.</returns>
    internal string GetOptionalNotes(string prompt)
    {
        return this.GetValidatedInput(
           prompt,
           true,
           ContactInputValidator.IsValidNotes,
           $"Notes should not have more than {ContactInputValidator.MaximumNotesLength} characters.");
    }

    /// <summary>
    /// Gets the name of the contact.
    /// </summary>
    /// <param name="prompt">Prompt to be displayed</param>
    /// <returns>A string value containing the name</returns>
    internal string GetOptionalContactName(string prompt)
    {
        return this.GetValidatedInput(
            prompt,
            true,
            ContactInputValidator.IsValidName,
            $"Name can't be empty and should contain at least {ContactInputValidator.MinimumNameLength} characters");
    }

    /// <summary>
    /// Gets the name of the contact.
    /// </summary>
    /// <param name="prompt">Prompt to be displayed</param>
    /// <returns>A string value containing the name</returns>
    internal string GetOptionalPhoneNumber(string prompt)
    {
        return this.GetValidatedInput(
            prompt,
            true,
            ContactInputValidator.IsValidPhoneNumber,
            $"Phone number can't be empty and should contain {ContactInputValidator.PhoneNumberLength} digits");
    }

    /// <summary>
    /// Gets the notes for the contacts
    /// </summary>
    /// <param name="prompt">Prompt to be displayed</param>
    /// <returns>A string value containing notes.</returns>
    internal string GetOptionalEmail(string prompt)
    {
        return this.GetValidatedInput(
            prompt,
            true,
            ContactInputValidator.IsValidEmail,
            $"Email should be in the correct format\nex. dharun@example.com");
    }

    /// <summary>
    /// Prints all the contact list
    /// </summary>
    /// <param name="contacts">Contacts list</param>
    internal void PrintContact(IReadOnlyList<Contact> contacts)
    {
        if (contacts.Count > 0)
        {
            Console.WriteLine("The Contacts list");
            var i = 1;
            foreach (Contact contact in contacts)
            {
                Console.WriteLine($"{i++}. {contact.Name}, {contact.PhoneNumber}, {contact.Email}, {contact.Notes}");
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
    internal int GetValidContactIndex(int count)
    {
        while (true)
        {
            int input = this.GetInteger("Select the contact: ");
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
    internal void Clear()
    {
        Console.Clear();
    }

    private string GetValidatedInput(string prompt, bool optional, Func<string, bool> isValidField, string errorMessage)
    {
        string input = this.GetString(prompt);
        if (optional && string.IsNullOrWhiteSpace(input))
        {
            return string.Empty;
        }

        while (!isValidField(input))
        {
            Console.WriteLine(errorMessage);
            input = this.GetString(prompt);
        }

        return input;
    }
}