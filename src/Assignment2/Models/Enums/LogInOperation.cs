namespace Assignment2.Models.Enums
{
    /// <summary>
    /// Specifies all the LogIn operations that can be done after login
    /// </summary>
    internal enum LogInOperation
    {
        /// <summary>
        /// Represents an option to check the bank balance.
        /// </summary>
        CheckBalance = 1,

        /// <summary>
        /// Represents an option to withdraw a sum of amount from the account.
        /// </summary>
        Withdraw = 2,

        /// <summary>
        /// Represents an option to deposit a sum of amount from the account.
        /// </summary>
        Deposit = 3,

        /// <summary>
        /// Represents an option to return to the main menu.
        /// </summary>
        Exit = 4,
    }
}
