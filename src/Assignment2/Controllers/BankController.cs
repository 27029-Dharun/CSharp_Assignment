using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Assignment2.Models.BankingSystem;
using Assignment2.Services;
using Assignment2.Views;

namespace Assignment2.Controllers
{
    /// <summary>
    /// This enum contais the Bank OPerations
    /// </summary>
    internal enum BankOperation
    {
        /// <summary>
        /// This Option creates a New account
        /// </summary>
        Add = 1,

        /// <summary>
        /// This Option logs into an existing account
        /// </summary>
        View = 2,

        Exit = 3,
    }

    internal enum LogInOperation
    {
        CheckBalance = 1,

        Withdraw = 2,

        Deposit = 3,

        Exit = 4,
    }

    /// <summary>
    /// This is the controller of the Banking System
    /// </summary>
    internal class BankController
    {
        private readonly BankView _bankView = new();
        private readonly BankService _bankService = new();

        /// <summary>
        /// This method is the starting point of the Banking System
        /// </summary>
        public void Run()
        {
            int option;
            do
            {
                option = this._bankView.GetOption();
                switch (option)
                {
                    case (int)BankOperation.Add:
                        this.CreateNewAccount();
                        break;

                    case (int)BankOperation.View:
                        this.LogIn();
                        break;

                    default:
                        break;
                }
            }
            while (option != (int)BankOperation.Exit);
        }

        private void CreateNewAccount()
        {
            this._bankView.GetAccountInfo(out string name, out int type, out decimal initialAmount);
            if (type == 1)
            {
                this._bankService.CreateSavingsAccount(name, initialAmount);
            }
            else if (type == 2)
            {
                this._bankService.CreateCheckingAccount(name, initialAmount);
            }
        }

        private void LogIn()
        {
            this._bankView.GetLogInDetails(out string accountNumber);
            int option;
            do
            {
                option = this._bankView.GetOperation();
                switch (option)
                {
                    case (int)LogInOperation.CheckBalance:
                        this.CheckBalance(accountNumber);
                        break;

                    case (int)LogInOperation.Withdraw:
                        this.WithdrawAmount(accountNumber);
                        break;

                    case (int)LogInOperation.Deposit:
                        this.DepositAmount(accountNumber);
                        break;

                    case (int)LogInOperation.Exit:
                        return;

                    default: return;
                }
            }
            while (option != (int)LogInOperation.Exit);
        }

        private void DepositAmount(string accountNumber)
        {
            decimal depositAmount = this._bankView.GetAmount("deposit");
            Console.WriteLine(this._bankService.DepositAmount(accountNumber, depositAmount));
        }

        private void WithdrawAmount(string accountNumber)
        {
            decimal withdrawAmount = this._bankView.GetAmount("withdraw");
            Console.WriteLine(this._bankService.WithdrawAmount(accountNumber, withdrawAmount));
        }

        private void CheckBalance(string accountNumber)
        {
            BankAccount account = this._bankService.GetBalance(accountNumber);
            this._bankView.DisplayBalance(account);
        }
    }
}
