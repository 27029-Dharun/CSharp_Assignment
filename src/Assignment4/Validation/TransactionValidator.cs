using System.Globalization;
using Assignment4.Constants;

namespace Assignment4.Validation
{
    /// <summary>
    /// Contains all the validator methods to validate the transaction data.
    /// </summary>
    public static class TransactionValidator
    {
        /// <summary>
        /// Validates the amount used in the transaction
        /// </summary>
        /// <param name="input">Amount to validate</param>
        /// <returns>A string containing the validation output; empty string if it is valid</returns>
        public static bool IsValidAmount(string input)
        {
            if (!decimal.TryParse(input, out decimal amount))
            {
                return false;
            }

            if (amount < Configurable.MinimumAmount)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Validates the date used in the transaction
        /// </summary>
        /// <param name="date">Date of the transaction</param>
        /// <returns>A string containing the validation output; empty string if it is valid. </returns>
        public static bool IsValidDate(string date)
        {
            if (!DateTime.TryParseExact(date, Configurable.DateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime validDate))
            {
                return false;
            }

            if (validDate > DateTime.Now)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Validates the name of the transaction
        /// </summary>
        /// <param name="name">Description of the transaction</param>
        /// <returns>A string containing the validation output; empty string if it is valid</returns>
        public static bool IsValidDescription(string name)
        {
            if (name is null || name.Length < Configurable.MinimumCharacter || name.Length > Configurable.MaximumCharacter)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Validates the category of the transaction.
        /// </summary>
        /// <param name="category"> The category of the transaction. </param>
        /// <returns>A string containing the category of the product. </returns>
        public static bool IsValidCategory(string category)
        {
            if (category is null || category.Length < Configurable.MinimumCharacter || category.Length > Configurable.MaximumCategoryCharacter)
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
    }
}
