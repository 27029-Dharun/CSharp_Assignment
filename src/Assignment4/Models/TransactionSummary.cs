namespace Assignment4.Models
{
    /// <summary>
    /// DTO to transfer the summary data
    /// </summary>
    internal class TransactionSummary
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TransactionSummary"/> class.
        /// </summary>
        /// <param name="income">Total income recorded</param>
        /// <param name="expense">Total expense recorded</param>
        /// <param name="monthlyExpense">Total expense recorded in the current month</param>
        /// <param name="monthlyIncome">Total income recorded in the current month</param>
        public TransactionSummary(decimal income, decimal expense, decimal monthlyIncome, decimal monthlyExpense)
        {
            this.Income = income;
            this.Expense = expense;
            this.MonthlyIncome = monthlyExpense;
            this.MonthlyExpense = monthlyExpense;
        }

        /// <summary>
        /// Gets or sets total income recorded.
        /// </summary>
        /// <value>
        /// Total income recorded.
        /// </value>
        public decimal Income { get; set; }

        /// <summary>
        /// Gets or sets total expense recorded.
        /// </summary>
        /// <value>
        /// Total expense recorded.
        /// </value>
        public decimal Expense { get; set; }

        /// <summary>
        /// Gets or sets monthly income recorded.
        /// </summary>
        /// <value>
        /// Monthly income recorded.
        /// </value>
        public decimal MonthlyIncome { get; set; }

        /// <summary>
        /// Gets or sets monthly expense recorded.
        /// </summary>
        /// <value>
        /// Monthly expense recorded.
        /// </value>
        public decimal MonthlyExpense { get; set; }

        /// <summary>
        /// calculates the balance of the user
        /// </summary>
        /// <returns>returns the balance</returns>
        public decimal GetBalance() => this.Income - this.Expense;
    }
}
