namespace Assignment4.DTOs
{
    /// <summary>
    /// DTO to transfer the summary data
    /// </summary>
    public class TransactionSummary
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TransactionSummary"/> class.
        /// </summary>
        /// <param name="income">Total income recorded.</param>
        /// <param name="expense">Total expense recorded.</param>
        /// <param name="monthlyExpense">Total expense recorded in the current month.</param>
        /// <param name="monthlyIncome">Total income recorded in the current month.</param>
        /// <param name="incomeCategoryTotals">The sum of amount earned in each category.</param>
        /// <param name="expenseCategoryTotals">The sum of amount spent in each category.</param>
        public TransactionSummary(decimal income, decimal expense, decimal monthlyIncome, decimal monthlyExpense, Dictionary<string, decimal> incomeCategoryTotals, Dictionary<string, decimal> expenseCategoryTotals)
        {
            this.Income = income;
            this.Expense = expense;
            this.MonthlyIncome = monthlyIncome;
            this.MonthlyExpense = monthlyExpense;
            this.ExpenseCategoryTotals = expenseCategoryTotals;
            this.IncomeCategoryTotals = incomeCategoryTotals;
        }

        /// <summary>
        /// Gets total income recorded.
        /// </summary>
        /// <value>
        /// Total income recorded.
        /// </value>
        public decimal Income { get; }

        /// <summary>
        /// Gets total expense recorded.
        /// </summary>
        /// <value>
        /// Total expense recorded.
        /// </value>
        public decimal Expense { get; }

        /// <summary>
        /// Gets monthly income recorded.
        /// </summary>
        /// <value>
        /// Monthly income recorded.
        /// </value>
        public decimal MonthlyIncome { get; }

        /// <summary>
        /// Gets monthly expense recorded.
        /// </summary>
        /// <value>
        /// Monthly expense recorded.
        /// </value>
        public decimal MonthlyExpense { get; }

        /// <summary>
        /// Gets the total income from each category
        /// </summary>
        /// <value> Sum of amount earned in each category </value>
        public Dictionary<string, decimal> IncomeCategoryTotals { get; }

        /// <summary>
        /// Gets the total expense from each category
        /// </summary>
        /// <value> Sum of amount spent in each category </value>
        public Dictionary<string, decimal> ExpenseCategoryTotals { get; }

        /// <summary>
        /// calculates the balance of the user
        /// </summary>
        /// <returns> The balance amount present</returns>
        public decimal GetBalance() => this.Income - this.Expense;
    }
}
