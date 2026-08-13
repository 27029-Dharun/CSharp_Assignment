namespace Assignment4.Models.Enums
{
    /// <summary>
    /// Specifies all the transaction menu operations
    /// </summary>
    internal enum TransactionMenu
    {
        /// <summary>
        /// Represents an option to  add new transaction.
        /// </summary>
        AddTransaction = 1,

        /// <summary>
        /// Represents an option to edit existing transaction.
        /// </summary>
        EditTransaction = 2,

        /// <summary>
        /// Represents an option to delete a transaction.
        /// </summary>
        DeleteTransaction = 3,

        /// <summary>
        /// Represents an option to view summary.
        /// </summary>
        ViewSummary = 4,

        /// <summary>
        /// Represents an option to view all the transactions by expense, income and all transactions.
        /// </summary>
        ViewTransaction = 5,

        /// <summary>
        /// Represents an option to search all the transactions by date and category.
        /// </summary>
        SearchTransaction = 6,

        /// <summary>
        /// Represents an option to sort all the transactions by amount.
        /// </summary>
        SortTransaction = 7,

        /// <summary>
        /// Represents an option to exit from the application.
        /// </summary>
        Exit = 8,
    }
}
