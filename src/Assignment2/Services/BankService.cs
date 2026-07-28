using Assignment2.Models.BankingSystem;
using Assignment2.Repository;
using Assignment2.Validators;
using Assignment2.Views;

namespace Assignment2.Services
{
    /// <summary>
    /// This class contains the banking system services
    /// </summary>
    internal class BankService
    {
        private static long accountNum = 100000000000;
        private readonly BankRepository _repository = new ();

        /// <summary>
        /// This method creates a checking account object
        /// </summary>
        /// <param name="name">Name of the Account Holder</param>
        /// <param name="initialAmount">Initial Amount when creating the account</param>
        /// <returns>String account number that is created</returns>
        internal string CreateCheckingAccount(string name, decimal initialAmount)
        {
            string nameValidator = Validator.IsAllAlphabet(name);
            string initialAmountValidator = Validator.IsValidAmount(initialAmount);
            if (nameValidator != string.Empty || initialAmountValidator != string.Empty)
            {
                return nameValidator + initialAmountValidator;
            }

            CheckingAccount checkingAccount = new CheckingAccount()
            {
                Name = name,
                AccountNumber = (string)(accountNum++).ToString(),
                Balance = initialAmount,
            };

            this._repository.CreateAccount(checkingAccount);
            return (string)(accountNum - 1).ToString();
        }

        /// <summary>
        /// This creates the account object and send to the RepositoryN
        /// </summary>
        /// <param name="name">Name of the Account Holder</param>
        /// <param name="initialAmount">Initial Amount when creating the account</param>
        /// <returns>String account number that is created</returns>
        internal string CreateSavingsAccount(string name, decimal initialAmount)
        {
            string nameValidator = Validator.IsAllAlphabet(name);
            string initialAmountValidator = Validator.IsValidAmount(initialAmount);
            if (nameValidator != string.Empty || initialAmountValidator != string.Empty)
            {
                return nameValidator + initialAmountValidator;
            }

            SavingsAccount savings = new SavingsAccount()
            {
                Name = name,
                AccountNumber = (string)(accountNum++).ToString(),
                Balance = initialAmount,
            };

            this._repository.CreateAccount(savings);
            return (string)(accountNum - 1).ToString();
        }

        /// <summary>
        /// This method deposits amount into a Account with account number
        /// </summary>
        /// <param name="accountNumber">This contains the account number where amount is to be deposited</param>
        /// <param name="depositAmount">This contains the amount to be deposited</param>
        /// <returns>string that tell the status of the operation</returns>
        internal string DepositAmount(string accountNumber, decimal depositAmount)
        {
            if (Validator.IsValidAmount(depositAmount) != string.Empty)
            {
                return Validator.IsValidAmount(depositAmount);
            }

            return this._repository.DepositAmount(accountNumber, depositAmount);
        }

        /// <summary>
        /// This contains the account number where balance must be checked
        /// </summary>
        /// <param name="accountNumber">Account number of the withdraw operation</param>
        /// <returns>this returns the string </returns>
        internal BankAccount? GetBalance(string accountNumber)
        {
            if (accountNumber == null)
            {
                return null;
            }

            return this._repository.GetAccountByAccountNumber(accountNumber);
        }

        /// <summary>
        /// This fetchs and returns the user name
        /// </summary>
        /// <param name="accountNumber">Account number to find the user name</param>
        /// <returns>Name of the Account holder</returns>
        internal string GetName(string accountNumber)
        {
            BankAccount? bankAccount = this._repository.GetAccountByAccountNumber(accountNumber);
            if (bankAccount != null && bankAccount.Name != null)
            {
                return bankAccount.Name;
            }

            return string.Empty;
        }

        /// <summary>
        /// This methos the account existance in the List
        /// </summary>
        /// <param name="accountNumber">Account number that is to be checked</param>
        /// <returns>returns boolean value</returns>
        internal bool IsAccountExist(string accountNumber)
        {
            return this._repository.CheckAccount(accountNumber);
        }

        /// <summary>
        /// LogIn to account
        /// </summary>
        /// <param name="accountNumber">Account number to LogIn</param>
        /// <returns>String output</returns>
        internal string LogInAccount(string accountNumber)
        {
            string validateAccountNumber = Validator.IsValidAccountNumber(accountNumber);
            if (validateAccountNumber != string.Empty)
            {
                return validateAccountNumber;
            }

            // check if account exists
            if (!this.IsAccountExist(accountNumber))
            {
                return "Account doesn't exist";
            }

            return string.Empty;
        }

        /// <summary>
        /// This method withdraws amount into a Account with account number
        /// </summary>
        /// <param name="accountNumber">This contains the account number where amount is to be withdrawed.</param>
        /// <param name="amount">This contains the amount to be withdrawed.</param>
        /// <returns>This returns the string that tell the status of the operations</returns>
        internal string WithdrawAmount(string accountNumber, decimal amount)
        {
            if (Validator.IsValidAmount(amount) != string.Empty)
            {
                return Validator.IsValidAmount(amount);
            }

            return this._repository.WithdrawAmount(accountNumber, amount);
        }
    }
}
