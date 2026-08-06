namespace Assignment4.Validation
{
    /// <summary>
    /// contains all the validator methods to validate the object
    /// </summary>
    internal class TransactionValidator
    {
        /// <summary>
        /// Validates the amount used in the transaction
        /// </summary>
        /// <param name="amount">Amount to validate</param>
        /// <returns>returns the validation output</returns>
        internal string ValidateAmount(decimal amount)
        {
            if (amount < 0)
            {
                return "Amount should be positive\n";
            }

            return string.Empty;
        }

        /// <summary>
        /// Validates the date used in the transaction
        /// </summary>
        /// <param name="date">Date of the transaction</param>
        /// <returns>returns the validation output</returns>
        internal string ValidateDate(DateTime date)
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
        /// <param name="name">Title of the transaction</param>
        /// <returns>returns the validation output</returns>
        internal string ValidateTitle(string name)
        {
            if (name == null || name.Length < 3)
            {
                return "Title should have at least 3 Characters\n";
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
