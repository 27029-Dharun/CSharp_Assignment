using Assignment2.Models.BankingSystem;
using Assignment2.Models.Enums;
using Assignment2.Services;
using Assignment2.Views;

namespace Assignment2.Controllers
{
    /// <summary>
    /// Controller coordinating between view and service layer.
    /// </summary>
    internal class BankController
    {
        private readonly BankService _bankService;

        /// <summary>
        /// Initializes a new instance of the <see cref="BankController"/> class.
        /// </summary>
        /// <param name="bankService"> Instance of bank service. </param>
        public BankController(BankService bankService)
        {
            this._bankService = bankService;
        }

        /// <summary>
        /// Starting point of the bank system.
        /// </summary>
        public void RunBankOperations()
        {
            int option;
            do
            {
                option = ConsoleView.GetInteger("Select Option to continue\n1. Create Bank Account\n2. LogIn to an existing Account\n3. Exit\n");
                switch (option)
                {
                    case (int)BankOperation.Add:
                        this.CreateNewAccount();
                        break;

                    case (int)BankOperation.View:
                        this.LogIn();
                        break;

                    case (int)BankOperation.Exit:
                        return;

                    default:
                        ConsoleView.PrintInfo("Enter a valid input in range 1-3");
                        break;
                }

                ConsoleView.PauseAndReturn();
            }
            while (option != (int)BankOperation.Exit);
        }

        /// <summary>
        /// Gets input from user and creates bank account.
        /// </summary>
        private void CreateNewAccount()
        {
            string name = ConsoleView.GetString("Enter your Name: ");
            int type = ConsoleView.GetInteger("Select Your Account Type\n1. Saving Account\n2. Checking Account\n");
            decimal initialAmount = ConsoleView.GetDecimal("Enter Initial Amount to create a account: ");
            if (type == 1)
            {
                ConsoleView.PrintInfo("Account created Successfully with account Number: " + this._bankService.CreateSavingsAccount(name, initialAmount));
            }
            else if (type == 2)
            {
                ConsoleView.PrintInfo("Account created Successfully with account Number: " + this._bankService.CreateCheckingAccount(name, initialAmount));
            }
            else
            {
                ConsoleView.PrintInfo("Invalid Type of Account");
            }
        }

        /// <summary>
        /// Login into user account.
        /// </summary>
        private void LogIn()
        {
            string accountNumber = ConsoleView.GetString("Enter the account number to LogIn: ");
            string validateLogIn = this._bankService.LogInAccount(accountNumber);

            if (validateLogIn != string.Empty)
            {
                ConsoleView.PrintInfo(validateLogIn);
                return;
            }

            ConsoleView.PrintInfo("Hello, " + this._bankService.GetName(accountNumber));
            int option;
            do
            {
                option = ConsoleView.GetInteger("Select the operation to continue\n1. Check Balance\n2. Withdraw Amount\n3. Deposit Amount\n4. Exit\n");
                switch (option)
                {
                    case (int)LogInOperation.CheckBalance:
                        this.DisplayBalance(accountNumber);
                        break;

                    case (int)LogInOperation.Withdraw:
                        this.WithdrawAmount(accountNumber);
                        break;

                    case (int)LogInOperation.Deposit:
                        this.DepositAmount(accountNumber);
                        break;

                    case (int)LogInOperation.Exit:
                        return;

                    default:
                        ConsoleView.PrintInfo("The number should be in range 1-4");
                        break;
                }
            }
            while (option != (int)LogInOperation.Exit);
        }

        /// <summary>
        /// Performs deposit operation.
        /// </summary>
        /// <param name="accountNumber"> Account number of the account. </param>
        private void DepositAmount(string accountNumber)
        {
            decimal depositAmount = ConsoleView.GetDecimal("Enter amount to deposit: ");
            ConsoleView.PrintInfo(this._bankService.DepositAmount(accountNumber, depositAmount));
        }

        /// <summary>
        /// Perform withdraw operation.
        /// </summary>
        /// <param name="accountNumber"> Account number of the account. </param>
        private void WithdrawAmount(string accountNumber)
        {
            decimal withdrawAmount = ConsoleView.GetDecimal("Enter amount to withdraw: ");
            ConsoleView.PrintInfo(this._bankService.WithdrawAmount(accountNumber, withdrawAmount));
        }

        /// <summary>
        /// Displays bank account balance.
        /// </summary>
        /// <param name="accountNumber"> Account number. </param>
        private void DisplayBalance(string accountNumber)
        {
            BankAccount? account = this._bankService.GetBalance(accountNumber);
            if (account is null)
            {
                ConsoleView.PrintInfo("Account not Found");
                return;
            }

            ConsoleView.PrintBalance(account);
        }
    }
}
