namespace Assignment1.Validation;

/// <summary>
/// Contains all view level validation logic
/// </summary>
internal static class ContactServiceValidator
{
    /// <summary>
    /// Checks if a field is unique.
    /// </summary>
    /// <param name="field">Number</param>
    /// <param name="availableField">List of phone number that are saved</param>
    /// <param name="existingField">Existing number required only when editing</param>
    /// <returns>boolean value</returns>
    internal static bool IsUniqueField(string field, IReadOnlyList<string> availableField, string? existingField = null)
    {
        foreach (string phoneNumber in availableField)
        {
            if (phoneNumber == field && existingField != phoneNumber)
            {
                return false;
            }
        }

        return true;
    }
}
