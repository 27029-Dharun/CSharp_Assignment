namespace Assignment2.Validators;

/// <summary>
/// Contains the validation logic that are required.
/// </summary>
internal class Validator
{
    /// <summary>
    /// Validates the string and check if all the character is alphabets.
    /// </summary>
    /// <param name="input"> A string to be validated. </param>
    /// <returns> True if all the letter or alphabets; otherwise false </returns>
    public static bool IsAllAlphabet(string input)
    {
        foreach (char c in input)
        {
            if (!char.IsLetter(c) && !char.IsWhiteSpace(c))
            {
                return false;
            }
        }

        return true;
    }

    /// <summary>
    /// Validates the account number
    /// </summary>
    /// <param name="number">The account number to be validated</param>
    /// <returns> True if the account number is valid; otherwise false </returns>
    public static bool IsValidAccountNumber(string number)
    {
        if (number.Length != 12)
        {
            return false;
        }

        foreach (char c in number)
        {
            if (!char.IsDigit(c))
            {
                return false;
            }
        }

        return true;
    }

    /// <summary>
    /// This validates the amount to be added
    /// </summary>
    /// <param name="amount">Amount to be validated</param>
    /// <returns> True if the amount is greater than zero; otherwise false. </returns>
    public static bool IsValidAmount(decimal amount)
    {
        return amount > 0;
    }

    /// <summary>
    /// Validates the dimension of the shape
    /// </summary>
    /// <param name="dimension">Dimension of the shape</param>
    /// <returns> True if the dimension greater than zero; otherwise false. </returns>
    internal static bool IsValidDimension(double dimension)
    {
        return dimension > 0;
    }
}
