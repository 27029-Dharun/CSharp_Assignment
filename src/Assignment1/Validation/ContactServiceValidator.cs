namespace Assignment1.Validation;

/// <summary>
/// Contains all view level validation logic
/// </summary>
internal static class ContactServiceValidator
{
    /// <summary>
    /// Checks if mobile number is unique
    /// </summary>
    /// <param name="number">Number</param>
    /// <param name="phoneNumbers">List of phone number that are saved</param>
    /// <param name="existingPhone">Existing number required only when editing</param>
    /// <returns>boolean value</returns>
    internal static bool IsUniqueContactNumber(string number, IReadOnlyList<string> phoneNumbers, string? existingPhone = null)
    {
        foreach (string phoneNumber in phoneNumbers)
        {
            if (phoneNumber == number && existingPhone != phoneNumber)
            {
                return false;
            }
        }

        return true;
    }

    /// <summary>
    /// Checks if the availableName is unique
    /// </summary>
    /// <param name="name">Name of the names</param>
    /// <param name="names">List of names that are saved</param>
    /// <param name="existingName">Existing name required only when editing</param>
    /// <returns>Returns boolean</returns>
    internal static bool IsUniqueContactName(string name, IReadOnlyList<string> names, string? existingName = null)
    {
        foreach (string availableName in names)
        {
            if (availableName == name && existingName != availableName)
            {
                return false;
            }
        }

        return true;
    }
}
