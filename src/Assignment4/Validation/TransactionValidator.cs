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
        /// <param name="amount">Amount to validate</param>
        /// <returns>A string containing the validation output; empty string if it is valid</returns>
        public static string ValidateAmount(decimal amount)
        {
            if (amount < Configurable.MinimumAmount)
            {
                return "Amount should be positive\n";
            }

            return string.Empty;
        }

        /// <summary>
        /// Validates the date used in the transaction
        /// </summary>
        /// <param name="date">Date of the transaction</param>
        /// <returns>A string containing the validation output; empty string if it is valid. </returns>
        public static string ValidateDate(DateTime date)
        {
            if (date > DateTime.Now)
            {
                return "Future date can't be recorded\n";
            }

            return string.Empty;
        }

        /// <summary>
        /// Validates the name of the transaction
        /// </summary>
        /// <param name="name">Description of the transaction</param>
        /// <returns>A string containing the validation output; empty string if it is valid</returns>
        public static string ValidateTitle(string name)
        {
            if (name is null || name.Length < Configurable.MinimumAmount)
            {
                return $"Title should have at least {Configurable.MinimumAmount} characters\n";
            }

            foreach (char c in name)
            {
                if (!char.IsLetter(c) && !char.IsWhiteSpace(c))
                {
                    return "Title should only contain Alphabets\n";
                }
            }

            return string.Empty;
        }
    }
}
