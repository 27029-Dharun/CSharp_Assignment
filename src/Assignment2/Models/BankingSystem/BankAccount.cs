namespace Assignment2.Models.BankingSystem
{
    /// <summary>
    /// Serves as a base blueprint for all bank account types.
    /// </summary>
    internal abstract class BankAccount
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BankAccount"/> class.
        /// </summary>
        /// <param name="name">Name of the account holder.</param>
        /// <param name="accountNumber">Account number of the user.</param>
        /// <param name="initialAmount">Initial amount deposited.</param>
        internal BankAccount(string name, string accountNumber, decimal initialAmount)
        {
            this.Name = name;
            this.AccountNumber = accountNumber;
            this.Balance = initialAmount;
        }

        /// <summary>
        /// Gets or sets name of the account holder.
        /// </summary>
        /// <value>
        /// A string containing customers full name.
        /// </value>
        internal string Name { get; set; }

        /// <summary>
        /// Gets or sets Account Number.
        /// </summary>
        /// <value>
        /// A string containing account number that acts as a unique identifier.
        /// </value>
        internal string AccountNumber { get; set; }

        /// <summary>
        /// Gets or sets the balance.
        /// </summary>
        /// <value>
        /// Decimal value tracking the current balance of the account.
        /// </value>
        internal decimal Balance { get; set; }

        /// <summary>
        /// Adds a specific sum of amount to the current balance.
        /// </summary>
        /// <param name="amount">A sum of amount to be deposited.</param>
        internal void Deposit(decimal amount)
        {
            this.Balance = this.Balance + amount;
        }

        /// <summary>
        /// Deducts a specified sum of money from the account balance.
        /// Must be customized by specific account types to handle unique withdrawal rules.
        /// </summary>
        /// <param name="amount">A amount to deduct from the account.</param>
        /// <returns>A status message explaining if the withdrawal succeeded or failed.</returns>
        internal abstract bool Withdraw(decimal amount);

        /// <summary>
        /// This method prints the detail of the Account.
        /// </summary>
        /// <returns>String containing account number And Balance.</returns>
        internal virtual string PrintDetails() => $"Account number: {this.AccountNumber}, has balance {this.Balance}";
    }
}
