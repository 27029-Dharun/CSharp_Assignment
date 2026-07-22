using Assignment2.Models.BankingSystem;

namespace Assignment2.Repository
{
    /// <summary>
    /// This class contains the Bank Repository
    /// </summary>
    internal class BankRepository
    {
        private List<BankAccount> _accounts = new List<BankAccount>();

        /// <summary>
        /// This creates the Account for a new customer
        /// </summary>
        /// <param name="bankAccount">Account object</param>
        /// <returns>Returns the string output</returns>
        internal string CreateAccount(BankAccount bankAccount)
        {
            if (bankAccount == null)
            {
                return "Bank Account object can't be Null";
            }

            this._accounts.Add(bankAccount);
            return "Account created Successfully";
        }

        /// <summary>
        /// This method creates the copy of all the accounts and returns it
        /// </summary>
        /// <returns>This returns the copy of contact list</returns>
        internal List<BankAccount> GetAllAccounts()
        {
            List<BankAccount> copy = new List<BankAccount>();
            foreach (BankAccount a in this._accounts)
            {
                copy.Add(new SavingsAccount { AccountNumber = a.AccountNumber, Balance = a.Balance });
            }

            return copy;
        }

        internal BankAccount? GetAccountByAccountNumber(string accountNumber)
        {
            foreach (BankAccount bankAccount in this._accounts)
            {
                if (bankAccount.AccountNumber == accountNumber)
                {
                    return bankAccount;
                }
            }

            return null;
        }

        internal string WithdrawAmount(string accountNumber, decimal amount)
        {
            BankAccount account = GetAccountByAccountNumber(accountNumber);
            if (account == null)
            {
                return "Account not Found";
            }

            return account.Withdraw(amount);
        }

        internal string DepositAmount(string accountNumber, decimal amount)
        {
            BankAccount account = GetAccountByAccountNumber(accountNumber);
            if (account == null)
            {
                return "Account not Found";
            }

            return account.Deposit(amount);
        }
    }
}
