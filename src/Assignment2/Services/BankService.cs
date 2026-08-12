using Assignment2.Models.BankingSystem;
using Assignment2.Repository;

namespace Assignment2.Services
{
    /// <summary>
    /// Provides core business logic for managing bank accounts, processing transactions, and interacting with the account repository
    /// </summary>
    internal class BankService
    {
        private readonly BankRepository _repository;
        private long _accountNum = 100000000000;
        private decimal _minimumBalance = 1000;

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
            string accountNumber = (this._accountNum++).ToString();
            CheckingAccount checkingAccount = new CheckingAccount(name, accountNumber, initialAmount);

            this._repository.Add(checkingAccount);
            return $"Account created successfully with account number: {accountNumber}";
        }

        /// <summary>
        /// Creates a account object and send to the repository.
        /// </summary>
        /// <param name="name"> Name of the account Holder. </param>
        /// <param name="initialAmount"> Initial amount deposited by the user when creating the account. </param>
        /// <returns> A string value with account number that is created. </returns>
        internal string CreateSavingsAccount(string name, decimal initialAmount)
        {
            if (initialAmount < this._minimumBalance)
            {
                return "Initial amount should be greater than minimum balance.";
            }

            string accountNumber = (this._accountNum++).ToString();
            SavingsAccount savings = new SavingsAccount(name, accountNumber, initialAmount);

            this._repository.Add(savings);
            return $"Account created successfully with account number: {accountNumber}";
        }

        /// <summary>
        /// This method deposits amount into a Account with account number
        /// </summary>
        /// <param name="accountNumber">This contains the account number where amount is to be deposited</param>
        /// <param name="depositAmount">This contains the amount to be deposited</param>
        /// <returns>string that tell the status of the operation</returns>
        internal string DepositAmount(string accountNumber, decimal depositAmount)
        {
            BankAccount? account = this._repository.GetByAccountNumber(accountNumber);
            if (account is null)
            {
                return "Account not found";
            }

            account.Deposit(depositAmount);
            return $"Rs.{depositAmount} deposited successfully";
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
        /// <returns> A Boolean value true if the login operation is success; otherwise false. </returns>
        internal bool LoginToAccount(string accountNumber)
        {
            return this._repository.GetByAccountNumber(accountNumber) is not null;
        }

        /// <summary>
        /// Withdraws amount from a account.
        /// </summary>
        /// <param name="accountNumber"> The account number where amount is to be withdrawn. </param>
        /// <param name="amount"> A sum amount to be withdrawn. </param>
        /// <returns> A string representing the status of the operations. </returns>
        internal string WithdrawAmount(string accountNumber, decimal amount)
        {
            BankAccount? account = this._repository.GetByAccountNumber(accountNumber);
            if (account is null)
            {
                return "Account not found.";
            }

            if (account.Withdraw(amount))
            {
                return $"Rs.{amount} withdrawn successfully";
            }

            return "Insufficient balance.";
        }
    }
}