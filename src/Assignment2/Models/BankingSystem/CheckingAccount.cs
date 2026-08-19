namespace Assignment2.Models.BankingSystem
{
    /// <summary>
    /// Represents the checking account that allows withdrawal without any restrictions.
    /// </summary>
    internal class CheckingAccount : BankAccount
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CheckingAccount"/> class.
        /// </summary>
        /// <param name="name">Name of the account holder</param>
        /// <param name="accountNumber">Account number of the checkings account.</param>
        /// <param name="initialAmount">Initial account deposited by user while creating the account.</param>
        internal CheckingAccount(string name, string accountNumber, decimal initialAmount)
            : base(name, accountNumber, initialAmount)
        {
        }

        /// <summary>
        /// Withdraws a sum of amount from the account if the enough fund is available.
        /// </summary>
        /// <param name="amount">A sum of amount to be withdrawn.</param>
        /// <returns>A string representing the status of the withdrawal.</returns>
        internal override bool Withdraw(decimal amount)
        {
            // checks balance if it is less than amount
            if (this.Balance >= amount)
            {
                this.Balance -= amount;
                return true;
            }

            return false;
        }

        /// <summary>
        /// Prints the balance with the account number.
        /// </summary>
        /// <returns>String containing account number And Balance.</returns>
        internal override string PrintDetails() => $"Your checking account with account number: {this.AccountNumber} has Balance Rs. {this.Balance}";
    }
}
