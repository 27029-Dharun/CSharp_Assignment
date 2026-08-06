using Assignment2.Models.BankingSystem;

namespace Assignment2.Repository
{
    /// <summary>
    /// This class contains the Bank Repository
    /// </summary>
    internal class BankRepository
    {
        private List<BankAccount> _accounts = new();

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

        /// <summary>
        /// This Method gets the Account number and return the object
        /// </summary>
        /// <param name="accountNumber">This contains the account number that is to be returned</param>
        /// <returns>the bank account object with the account number</returns>
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

        /// <summary>
        /// This method withdraw amount into a Account with account number
        /// </summary>
        /// <param name="accountNumber">This contains the account number where amount is to be withdrawn</param>
        /// <param name="amount">This contains the amount to be withdrawed</param>
        /// <returns>this contains the string info of the operation</returns>
        internal string WithdrawAmount(string accountNumber, decimal amount)
        {
            if (!string.IsNullOrEmpty(accountNumber))
            {
                BankAccount? account = this.GetAccountByAccountNumber(accountNumber);
                if (account is null)
                {
                    return "Account not Found";
                }

                return account.Withdraw(amount);
            }

            return "Account number can't be Empty";
        }

        /// <summary>
        /// This method deposits amount into a Account with account number
        /// </summary>
        /// <param name="accountNumber">This contains the account number where amount is to be deposited</param>
        /// <param name="amount">This contains the amount to be deposited</param>
        /// <returns>this contains the string info of the operation</returns>
        internal string DepositAmount(string accountNumber, decimal amount)
        {
            if (!string.IsNullOrEmpty(accountNumber))
            {
                BankAccount? account = this.GetAccountByAccountNumber(accountNumber);
                if (account == null)
                {
                    return "Account not Found";
                }

                return account.Deposit(amount);
            }

            return "Account number can't be Empty";
        }

        /// <summary>
        /// This checks if the account exists
        /// </summary>
        /// <param name="accountNumber">The account number entered by the user</param>
        /// <returns>Boolean true tell the account ispresent and false tells that the account to not present</returns>
        internal bool CheckAccount(string accountNumber)
        {
            foreach (BankAccount bankAccount in this._accounts)
            {
                if (bankAccount.AccountNumber == accountNumber)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
