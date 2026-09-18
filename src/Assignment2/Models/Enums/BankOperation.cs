namespace Assignment2.Models.Enums
{
    /// <summary>
    /// Specifies all the bank operation that are available
    /// </summary>
    internal enum BankOperation
    {
        /// <summary>
        /// Represents a option to creates a new account
        /// </summary>
        Add = 1,

        /// <summary>
        /// Represents a option to login into an existing account
        /// </summary>
        LogIn = 2,

        /// <summary>
        /// Represents a option to exit from the Banking Operation
        /// </summary>
        Back = 3,
    }
}
