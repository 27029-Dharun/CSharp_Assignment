namespace Assignment2.Models.BankingSystem
{
    /// <summary>
    /// Represents the checking account that allows withdrawal without any restrictions.
    /// </summary>
    internal class CheckingAccount : BankAccount
    {
        /// <summary>
        /// Withdraws a sum of amount from the account if the enough fund is available.
        /// </summary>
        /// <param name="amount"> A sum of amount to be withdrawn. </param>
        /// <returns> A string representing the status of the withdrawal. </returns>
        public override string Withdraw(decimal amount)
        {
            // checks balance if it is less than amount
            if (this.Balance >= amount)
            {
                this.Balance -= amount;
                return $"Rupees: {amount} withdrawn successfully";
            }

            return $"Insufficient balance";
        }

        /// <summary>
        /// Prints the balance with the account number.
        /// </summary>
        /// <returns> String containing account number And Balance. </returns>
        public override string PrintDetails() => $"Your checking account with account number: {this.AccountNumber} has Balance Rs. {this.Balance}";
    }
}
