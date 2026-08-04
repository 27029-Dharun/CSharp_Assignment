namespace Assignment4.Models.Enums
{
    /// <summary>
    /// Contains the transaction menu operations
    /// </summary>
    internal enum TransactionMenu
    {
        /// <summary>
        /// Add new transaction
        /// </summary>
        AddTransaction = 1,

        /// <summary>
        /// Edit existing transaction
        /// </summary>
        EditTransaction = 2,

        /// <summary>
        /// Delete a transaction
        /// </summary>
        DeleteTransaction = 3,

        /// <summary>
        /// View summary
        /// </summary>
        ViewSummary = 4,

        /// <summary>
        /// View expense alone
        /// </summary>
        ViewExpense = 5,

        /// <summary>
        /// View Income
        /// </summary>
        ViewIncome = 6,

        /// <summary>
        /// Exit from the application
        /// </summary>
        Exit = 7,
    }
}
