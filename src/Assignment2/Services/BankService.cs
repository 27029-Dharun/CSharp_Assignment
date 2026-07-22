using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment2.Models.BankingSystem;
using Assignment2.Repository;
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
        internal void CreateCheckingAccount(string name, decimal initialAmount)
        {
            CheckingAccount checkingAccount = new CheckingAccount()
            {
                Name = name,
                AccountNumber = (string)(accountNum++).ToString(),
                Balance = initialAmount,
            };

            this._repository.CreateAccount(checkingAccount);
        }

        /// <summary>
        /// This creates the account object and send to the RepositoryN
        /// </summary>
        /// <param name="name">Name of the Account Holder</param>
        /// <param name="initialAmount">Initial Amount when creating the account</param>
        internal void CreateSavingsAccount(string name, decimal initialAmount)
        {
            SavingsAccount savings = new SavingsAccount()
            {
                Name = name,
                AccountNumber = (string)(accountNum++).ToString(),
                Balance = initialAmount,
            };

            this._repository.CreateAccount(savings);
        }

        internal string DepositAmount(string accountNumber, decimal depositAmount)
        {
            return _repository.DepositAmount(accountNumber, depositAmount);
        }

        internal BankAccount GetBalance(string accountNumber)
        {
            return _repository.GetAccountByAccountNumber(accountNumber);
        }

        internal string WithdrawAmount(string accountNumber, decimal amount)
        {
            return _repository.WithdrawAmount(accountNumber, amount);
        }
    }
}
