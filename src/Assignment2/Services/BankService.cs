using Assignment2.Models.BankingSystem;
using Assignment2.Repository;
using Assignment2.Validators;

namespace Assignment2.Services
{
    /// <summary>
    /// Provides core business logic for managing bank accounts, processing transactions, and interacting with the account repository
    /// </summary>
    internal class BankService
    {
        private static long accountNum = 100000000000;
        private readonly BankRepository _repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="BankService"/> class.
        /// </summary>
        /// <param name="repository">An instance of repository</param>
        public BankService(BankRepository repository)
        {
            this._repository = repository;
        }

        /// <summary>
        /// Creates a checking account and add it to the repository.
        /// </summary>
        /// <param name="name">Name of the Account Holder</param>
        /// <param name="initialAmount">Initial Amount when creating the account</param>
        /// <returns>A string value with account number that is created</returns>
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

            this._repository.Add(checkingAccount);
            return (accountNum - 1).ToString();
        }

        /// <summary>
        /// Creates a account object and send to the repository.
        /// </summary>
        /// <param name="name"> Name of the account Holder. </param>
        /// <param name="initialAmount"> Initial amount deposited by the user when creating the account. </param>
        /// <returns> A string value with account number that is created. </returns>
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
                AccountNumber = (accountNum++).ToString(),
                Balance = initialAmount,
            };

            this._repository.Add(savings);
            return (accountNum - 1).ToString();
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
        /// Gets a bank account from the repository
        /// </summary>
        /// <param name="accountNumber">Account number of the account. </param>
        /// <returns> A instance of the bank account that matches the account number. </returns>
        internal BankAccount? GetAccountByAccountNumber(string accountNumber)
        {
            return this._repository.GetByAccountNumber(accountNumber);
        }

        /// <summary>
        /// Fetches and returns the user name
        /// </summary>
        /// <param name="accountNumber">Account number to find the user name</param>
        /// <returns>Name of the account holder</returns>
        internal string GetName(string accountNumber)
        {
            BankAccount? bankAccount = this._repository.GetByAccountNumber(accountNumber);
            if (bankAccount != null && bankAccount.Name != null)
            {
                return bankAccount.Name;
            }

            return string.Empty;
        }

        /// <summary>
        /// Checks if the account exists in the record
        /// </summary>
        /// <param name="accountNumber"> The account number entered by the user. </param>
        /// <returns> A Boolean value true if the account is exists; otherwise false. </returns>
        internal bool IsAccountExist(string accountNumber)
        {
            return this._repository.GetByAccountNumber(accountNumber) is not null;
        }

        /// <summary>
        /// Login to an existing account
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
        /// Withdraws amount from a account.
        /// </summary>
        /// <param name="accountNumber"> The account number where amount is to be withdrawn. </param>
        /// <param name="amount"> A sum amount to be withdrawn. </param>
        /// <returns> A string representing the status of the operations. </returns>
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
