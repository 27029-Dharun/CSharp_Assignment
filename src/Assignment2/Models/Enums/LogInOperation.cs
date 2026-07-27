namespace Assignment2.Models.Enums
{
    /// <summary>
    /// This enum represents the LogIn Operations that are done after LogIn
    /// </summary>
    internal enum LogInOperation
    {
        /// <summary>
        /// This select the check Balance Operation
        /// </summary>
        CheckBalance = 1,

        /// <summary>
        /// This select withdrawn operation from a account
        /// </summary>
        Withdraw = 2,

        /// <summary>
        /// This deposits amount into the account
        /// </summary>
        Deposit = 3,

        /// <summary>
        /// Exit from the LogIn
        /// </summary>
        Exit = 4,
    }
}
