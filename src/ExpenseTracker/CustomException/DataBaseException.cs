namespace ExpenseTracker.CustomException
{
    /// <summary>
    /// Exception thrown when an error occurred in file handling operations.
    /// </summary>
    internal class DataBaseException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DataBaseException"/> class.
        /// </summary>
        public DataBaseException()
            : base("Failed to load the data - Try again")
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DataBaseException"/> class.
        /// </summary>
        /// <param name="message">The error message to be displayed.</param>
        public DataBaseException(string message)
            : base(message)
        {
        }
    }
}
