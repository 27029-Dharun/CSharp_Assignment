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
                return "Amount should be positive";
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
                return "Date should not be ";
            }

            return string.Empty;
        }

        /// <summary>
        /// Validates the name of the transaction
        /// </summary>
        /// <param name="name">Title of the transaction</param>
        /// <returns>returns the validation output</returns>
        internal string ValidateName(string name)
        {
            if (name == null || name.Length < 3)
            {
                return "Name should have at least 3 Characters";
            }

            foreach (char c in name)
            {
                if (!char.IsLetter(c) && !char.IsWhiteSpace(c))
                {
                    return "Name should only contain Alphabets";
                }
            }

            return string.Empty;
        }
    }
}
