namespace Assignment2.Models.BankingSystem
{
    /// <summary>
    /// This class contains CheckingAccount withdraws without any restriction
    /// </summary>
    internal class CheckingAccount : BankAccount
    {
        /// <summary>
        /// Withdraws amount from the account
        /// </summary>
        /// <param name="amount">Amount to be Withdrawn</param>
        /// <returns>Result of the Operation</returns>
        public override string Withdraw(decimal amount)
        {
            if (amount <= 0)
            {
                return "Invalid Amount: Amount can't be Negative or Zero";
            }

            // checks balance if it is less than amount
            if (this.Balance >= amount)
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
        public override string PrintDetails() => $"Your Checking Account with Account Number: {this.AccountNumber} has Balance {this.Balance}";
    }
}
