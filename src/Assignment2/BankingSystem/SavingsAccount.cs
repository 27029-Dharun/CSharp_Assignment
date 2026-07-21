using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2.BankingSystem
{
    /// <summary>
    /// This class id derived from the BankAccount
    /// </summary>
    internal class SavingsAccount : BankAccount
    {
        /// <summary>
        /// Gets or sets minimum Balance for Savings Account
        /// </summary>
        /// <value>
        /// Minimum Balance value
        /// </value>
        public decimal MinimunBalance { get; set; }

        /// <summary>
        /// THis methods overrides Withdraw from the BankAccount
        /// </summary>
        /// <param name="amount">Amount to withdraw</param>
        /// <returns>Error Message</returns>
        public override string Withdraw(decimal amount)
        {
            if (amount <= 0)
            {
                return "Invalid Amount: Amount can't be Negative or Zero";
            }

            // checks balance if it is less than amount
            if (this.Balance - this.MinimunBalance >= amount)
            {
                this.Balance = this.Balance - amount;
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
