using System.Globalization;
using System.Text.RegularExpressions;
using ExpenseTracker.Constants;

namespace ExpenseTracker.Validators
{
    /// <summary>
    /// Contains all the validator methods to validate the transaction data.
    /// </summary>
    public static class ViewValidator
    {
        /// <summary>
        /// Validates the amount used in the transaction.
        /// </summary>
        /// <param name="input">Amount to validate.</param>
        /// <returns>True if valid; otherwise false.</returns>
        public static bool IsValidAmount(string input)
        {
            return decimal.TryParse(input, out _);
        }

        /// <summary>
        /// Validates the date used in the transaction.
        /// </summary>
        /// <param name="date">Date of the transaction.</param>
        /// <returns>True if valid; otherwise false.</returns>
        public static bool IsValidDate(string date)
        {
            return DateTime.TryParseExact(date, Configurable.DateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out _);
        }

        /// <summary>
        /// Validates the description of the transaction.
        /// </summary>
        /// <param name="name">Description of the transaction.</param>
        /// <returns>True if valid; otherwise false.</returns>
        public static bool IsValidDescription(string name)
        {
            return !string.IsNullOrWhiteSpace(name);
        }

        /// <summary>
        /// Validates the category of the transaction.
        /// </summary>
        /// <param name="category"> The category of the transaction.</param>
        /// <returns>True if valid; otherwise false.</returns>
        public static bool IsValidCategory(string category)
        {
            if (string.IsNullOrWhiteSpace(category))
            {
                return false;
            }

            foreach (char character in category)
            {
                if (!char.IsLetter(character) && !char.IsWhiteSpace(character))
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Validates the id format entered by the user.
        /// </summary>
        /// <param name="id">The transaction ID entered by the user.</param>
        /// <returns>True if valid; otherwise false.</returns>
        public static bool IsValidId(string id)
        {
            return Regex.IsMatch(id, Configurable.IdPattern);
        }
    }
}