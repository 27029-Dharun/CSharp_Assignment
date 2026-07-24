namespace Assignment2.Models.BankingSystem
{
    /// <summary>
    /// This class contains Bank Account details and basic operations
    /// </summary>
    internal abstract class BankAccount
    {
        /// <summary>
        /// gets or sets Name of the Account Holder
        /// </summary>
        /// <value>
        /// Name of the customer
        /// </value>
        public string? Name { get; set; }

        /// <summary>
        /// gets or sets Account Number
        /// </summary>
        /// <value>
        /// Account Number of the customer
        /// </value>
        public string? AccountNumber { get; set; }

        /// <summary>
        /// Gets or sets ts Balance
        /// </summary>
        /// <value>
        /// Balance of the Account
        /// </value>
        public decimal Balance { get; set; }

        /// <summary>
        /// Deposits amount to the Account
        /// </summary>
        /// <param name="amount">Amount to be Deposited</param>
        /// <returns>Result of Operation</returns>
        public string Deposit(decimal amount)
        {
            if (amount < 0)
            {
                return "Invalid Amount : Amount should be positive";
            }

            this.Balance = this.Balance + amount;
            return $"Rupees: {amount} Deposited Successfully";
        }

        /// <summary>
        /// Withdraws amount from the account
        /// </summary>
        /// <param name="amount">Amount to be Withdrawn</param>
        /// <returns>Result of the Operation</returns>
        public abstract string Withdraw(decimal amount);

        /// <summary>
        /// This method prints the detail of the Account
        /// </summary>
        /// <returns>String containing account number And Balance</returns>
        public virtual string PrintDetails() => $"Account Number {this.AccountNumber} Balance {this.Balance}";
    }
}
