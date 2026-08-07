namespace Assignment2.Models.BankingSystem
{
    /// <summary>
    /// Serves as a base blueprint for all bank account types.
    /// </summary>
    internal abstract class BankAccount
    {
        /// <summary>
        /// Gets or sets name of the account holder.
        /// </summary>
        /// <value>
        /// A string containing customers full name.
        /// </value>
        public string? Name { get; set; }

        /// <summary>
        /// Gets or sets Account Number.
        /// </summary>
        /// <value>
        /// A string containing account number that acts as a unique identifier.
        /// </value>
        public string? AccountNumber { get; set; }

        /// <summary>
        /// Gets or sets the balance.
        /// </summary>
        /// <value>
        /// Decimal value tracking the current balance of the account.
        /// </value>
        public decimal Balance { get; set; }

        /// <summary>
        /// Adds a specific sum of amount to the current balance.
        /// </summary>
        /// <param name="amount"> A sum of amount to be deposited. </param>
        /// <returns> A message confirming the amount deposited to the account. </returns>
        public string Deposit(decimal amount)
        {
            this.Balance = this.Balance + amount;
            return $"Rs. {amount} deposited successfully";
        }

        /// <summary>
        /// Deducts a specified sum of money from the account balance.
        /// Must be customized by specific account types to handle unique withdrawal rules.
        /// </summary>
        /// <param name="amount"> A amount to deduct from the account. </param>
        /// <returns> A status message explaining if the withdrawal succeeded or failed. </returns>
        public abstract string Withdraw(decimal amount);

        /// <summary>
        /// This method prints the detail of the Account.
        /// </summary>
        /// <returns> String containing account number And Balance. </returns>
        public virtual string PrintDetails() => $"Account Number {this.AccountNumber} Balance {this.Balance}";
    }
}
