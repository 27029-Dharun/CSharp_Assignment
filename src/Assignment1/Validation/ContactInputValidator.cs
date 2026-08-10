using System.Text.RegularExpressions;

namespace Assignment1.Validation;

/// <summary>
/// Contains contact validation methods
/// </summary>
internal static class ContactInputValidator
{
    /// <summary>
    /// Minimum length of the name.
    /// </summary>
    internal const int MinimumNameLength = 5;

    /// <summary>
    /// Length of the phone number.
    /// </summary>
    internal const int PhoneNumberLength = 10;

    /// <summary>
    /// Maximum allowed characters for notes.
    /// </summary>
    internal const int MaximumNotesLength = 150;

    /// <summary>
    /// Validate phone number
    /// </summary>
    /// <param name="number">Phone number of the contact.</param>
    /// <returns>True if phone number is  valid; otherwise false </returns>
    internal static bool IsValidPhoneNumber(string number)
    {
        number = number.Trim();
        if (string.IsNullOrEmpty(number))
        {
            return false;
        }

        return number.All(char.IsDigit) && number.Length == PhoneNumberLength;
    }

    /// <summary>
    /// Validates email.
    /// </summary>
    /// <param name="email"> Email of the contact. </param>
    /// <returns>True if email is valid; otherwise false </returns>
    internal static bool IsValidEmail(string email)
    {
        email = email.Trim();
        if (string.IsNullOrEmpty(email))
        {
            return false;
        }

        return Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
    }

    /// <summary>
    /// Validates optional parameter notes.
    /// </summary>
    /// <param name="notes">Notes </param>
    /// <returns>True if the notes is valid; otherwise false</returns>
    internal static bool IsValidNotes(string notes)
    {
        notes = notes.Trim();
        if (notes.Length > MaximumNotesLength)
        {
            return false;
        }

        return true;
    }

    /// <summary>
    /// validates the name of the contact.
    /// </summary>
    /// <param name="name">Input received from the user</param>
    /// <returns>True if valid name; otherwise false</returns>
    internal static bool IsValidName(string name)
    {
        name = name.Trim();
        if (string.IsNullOrEmpty(name))
        {
            return false;
        }

        if (name.Length < MinimumNameLength)
        {
            return false;
        }

        if (name.Any(char.IsDigit))
        {
            return false;
        }

        return true;
    }
}
