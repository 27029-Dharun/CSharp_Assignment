using ExpenseTracker.Constants;

namespace ExpenseTracker.Validators
{
    /// <summary>
    /// Contains all the business validation logics.
    /// </summary>
    internal class ServiceValidator
    {
        /// <summary>
        /// Validates the amount used in the transaction.
        /// </summary>
        /// <param name="amount">Amount to validate.</param>
        /// <returns>True if valid; otherwise false.</returns>
        public static bool IsValidAmount(decimal amount)
        {
            return amount >= Configurable.MinimumAmount;
        }

        /// <summary>
        /// Validates the date used in the transaction.
        /// </summary>
        /// <param name="date">Date of the transaction.</param>
        /// <returns>True if valid; otherwise false.</returns>
        public static bool IsValidDate(DateTime date)
        {
            return date <= DateTime.Today;
        }

        /// <summary>
        /// Validates the description of the transaction.
        /// </summary>
        /// <param name="name">Description of the transaction.</param>
        /// <returns>True if valid; otherwise false.</returns>
        public static bool IsValidDescription(string name)
        {
            return name.Length >= Configurable.MinimumCharacter && name.Length <= Configurable.MaximumCharacter;
        }

        /// <summary>
        /// Validates the category of the transaction.
        /// </summary>
        /// <param name="category"> The category of the transaction.</param>
        /// <returns>True if valid; otherwise false.</returns>
        public static bool IsValidCategory(string category)
        {
            return category.Length >= Configurable.MinimumCharacter && category.Length <= Configurable.MaximumCategoryCharacter;
        }
    }
}
