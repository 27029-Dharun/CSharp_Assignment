namespace Assignment4.Models
{
    internal class TransactionSummary
    {
        public decimal Income { get; set; }

        public decimal Expense { get; set; }

        public decimal GetBalance() => this.Income - this.Expense;
    }
}
