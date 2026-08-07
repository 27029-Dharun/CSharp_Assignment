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
    /// <returns>A string output stating why the string is not valid. </returns>
    public static string IsAllAlphabet(string input)
    {
        if (string.IsNullOrEmpty(input))
        {
            return "String can't be empty";
        }

        foreach (char c in input)
        {
            if (!char.IsLetter(c) && !char.IsWhiteSpace(c))
            {
                return "Name can't have symbols other than alphabets";
            }
        }

        return string.Empty;
    }

    /// <summary>
    /// Validates the account number
    /// </summary>
    /// <param name="number">The account number to be validated</param>
    /// <returns> A string output stating why the account number is not valid. </returns>
    public static string IsValidAccountNumber(string number)
    {
        if (number.Length != 12)
        {
            return "Account number must contain twelve digits";
        }

        foreach (char c in number)
        {
            if (!char.IsDigit(c))
            {
                return "Account number can't have characters";
            }
        }

        return string.Empty;
    }

    /// <summary>
    /// This validates the amount to be added
    /// </summary>
    /// <param name="amount">Amount to be validated</param>
    /// <returns>A string output stating why the amount is not valid. </returns>
    public static string IsValidAmount(decimal amount)
    {
        if (amount > 0)
        {
            return string.Empty;
        }

        return "Amount should be Positive";
    }
}
