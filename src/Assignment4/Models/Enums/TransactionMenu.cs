namespace Assignment4.Models.Enums
{
    /// <summary>
    /// Specifies all the transaction menu operations
    /// </summary>
    internal enum TransactionMenu
    {
        /// <summary>
        /// Represents an option to  add new transaction
        /// </summary>
        AddTransaction = 1,

        /// <summary>
        /// Represents an option to edit existing transaction
        /// </summary>
        EditTransaction = 2,

        /// <summary>
        /// Represents an option to delete a transaction
        /// </summary>
        DeleteTransaction = 3,

        /// <summary>
        /// Represents an option to view summary
        /// </summary>
        ViewSummary = 4,

        /// <summary>
        /// Represents an option to view expense alone
        /// </summary>
        ViewTransaction = 5,

        /// <summary>
        /// Represents an option to exit from the application
        /// </summary>
        Exit = 6,
    }
}
