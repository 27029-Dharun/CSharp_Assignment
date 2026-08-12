namespace Assignment2.Models.BankingSystem
{
    /// <summary>
    /// Represents the savings account details
    /// </summary>
    internal class SavingsAccount : BankAccount
    {
        public decimal _minimumBalance = 1000m;

        /// <summary>
        /// Initializes a new instance of the <see cref="SavingsAccount"/> class.
        /// </summary>
        /// <param name="name">Name of the account holder</param>
        /// <param name="accountNumber">Account number of the checkings account.</param>
        /// <param name="initialAmount">Initial account deposited by user while creating the account. </param>
        public SavingsAccount(string name, string accountNumber, decimal initialAmount)
            : base(name, accountNumber, initialAmount)
        {
        }

        /// <summary>
        /// Withdraws a sum of amount from the account if the balance is greater than the minimum balance and the amount to be withdrawn.
        /// </summary>
        /// <param name="amount"> A sum of amount to withdrawn. </param>
        /// <returns> A string representing the status of the withdrawal operation. </returns>
        public override bool Withdraw(decimal amount)
        {
            if (this.Balance - this._minimumBalance >= amount)
            {
                this.Balance -= amount;
                return true;
            }

            return false;
        }

        /// <summary>
        /// Creates a detailed text containing the current balance and the account number
        /// </summary>
        /// <returns>A formatted string displaying the checking account number and its current balance. </returns>
        public override string PrintDetails() => $"Your Savings Account with Account Number: {this.AccountNumber} has Balance {this.Balance}";
    }
}
