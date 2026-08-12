namespace Assignment2.Models.Enums
{
    /// <summary>
    /// Specifies the type of the account that are available
    /// </summary>
    internal enum AccountType
    {
        /// <summary>
        /// Represents a savings account which has constraints in amount withdrawal.
        /// </summary>
        SavingsAccount = 1,

        /// <summary>
        /// Represents a checking account which has no withdrawal limit.
        /// </summary>
        CheckingsAccount = 2,
    }
}
