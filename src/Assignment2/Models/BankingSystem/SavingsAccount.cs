namespace Assignment2.Models.BankingSystem
{
    /// <summary>
    /// This class id derived from the BankAccount
    /// </summary>
    internal class SavingsAccount : BankAccount
    {
        private decimal _minimumBalance = 1000m;

        /// <summary>
        /// Gets minimum Balance for Savings Account
        /// </summary>
        /// <value>
        /// Minimum Balance value
        /// </value>
        public decimal MinimumBalance
        {
            get
            {
                return this._minimumBalance;
            }

            private set
            {
                if (value >= 0)
                {
                    this._minimumBalance = value;
                }
            }
        }

        /// <summary>
        /// THis methods overrides Withdraw from the BankAccount
        /// </summary>
        /// <param name="amount">Amount to withdraw</param>
        /// <returns>Error Message</returns>
        public override string Withdraw(decimal amount)
        {
            if (this.Balance - this.MinimumBalance >= amount)
            {
                this.Balance -= amount;
                return $"Rupees: {amount} withdrawn Successfully";
            }

            return $"Insufficient Balance";
        }

        /// <summary>
        /// This method prints the detail of the Account
        /// </summary>
        /// <returns>String containing account number And Balance</returns>
        public override string PrintDetails() => $"Your Savings Account with Account Number: {this.AccountNumber} has Balance {this.Balance}";
    }
}
