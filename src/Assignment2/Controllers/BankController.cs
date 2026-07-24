using Assignment2.Models.BankingSystem;
using Assignment2.Services;
using Assignment2.Validators;
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

        /// <summary>
        /// Exit from the Banking Operation
        /// </summary>
        Exit = 3,
    }

    /// <summary>
    /// This enum represents the LogIn Operations that are done after LogIn
    /// </summary>
    internal enum LogInOperation
    {
        /// <summary>
        /// This select the check Balance Operation
        /// </summary>
        CheckBalance = 1,

        /// <summary>
        /// This select withdrawn operation from a account
        /// </summary>
        Withdraw = 2,

        /// <summary>
        /// This deposits amount into the account
        /// </summary>
        Deposit = 3,

        /// <summary>
        /// Exit from the LogIn
        /// </summary>
        Exit = 4,
    }

    /// <summary>
    /// This enum represents the Account type
    /// </summary>
    internal enum AccounType
    {
        /// <summary>
        /// Savings account with minimum balance
        /// </summary>
        SavingAccount = 1,

        /// <summary>
        /// Checking account with minimum balance
        /// </summary>
        CheckingAccount = 2,
    }

    /// <summary>
    /// This is the controller of the Banking System
    /// </summary>
    internal class BankController
    {
        private readonly BankService _bankService;

        /// <summary>
        /// Initializes a new instance of the <see cref="BankController"/> class.
        /// </summary>
        /// <param name="bankService">Bank service object</param>
        public BankController(BankService bankService)
        {
            this._bankService = bankService;
        }

        /// <summary>
        /// This method is the starting point of the Banking System
        /// </summary>
        public void Run()
        {
            int option;
            do
            {
                option = ConsoleView.GetInteger("Select Option to continue\n1. Create Bank Account\n2. LogIn to an existing Account\n");
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

        /// <summary>
        /// This creates a new account after getting the input from the user
        /// </summary>
        private void CreateNewAccount()
        {
            string name = ConsoleView.GetString("Enter your Name: ");
            int type = ConsoleView.GetInteger("Select Your Account Type\n1. Saving Account\n2. Checking Account\n");
            decimal initialAmount = ConsoleView.GetDecimal("Enter Initial Amount to create a account: ");
            string namevalidator = Validator.IsAllAlphabet(name);
            string initialAmountValidator = Validator.IsValidAmount(initialAmount);
            if (namevalidator != string.Empty || initialAmountValidator != string.Empty)
            {
                ConsoleView.PrintInfo(namevalidator + initialAmountValidator);
                return;
            }

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
        /// This method logs in into the account if it exists
        /// </summary>
        private void LogIn()
        {
            string accountNumber = ConsoleView.GetString("Enter the account number to LogIn: ");
            string validateAccountNumber = Validator.IsValidAccountNumber(accountNumber);
            if (validateAccountNumber != string.Empty)
            {
                ConsoleView.PrintInfo(validateAccountNumber);
                return;
            }

            if (!this._bankService.IsAccountExist(accountNumber))
            {
                ConsoleView.PrintInfo("Account doesn't exist");
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
        /// This method controls the deposit operation
        /// </summary>
        /// <param name="accountNumber">Account number of the account</param>
        private void DepositAmount(string accountNumber)
        {
            decimal depositAmount = ConsoleView.GetDecimal("Enter amount to deposit: ");
            if (Validator.IsValidAmount(depositAmount) != string.Empty)
            {
                ConsoleView.PrintInfo(Validator.IsValidAmount(depositAmount));
                return;
            }

            ConsoleView.PrintInfo(this._bankService.DepositAmount(accountNumber, depositAmount));
        }

        /// <summary>
        /// This method controls the withdraw operation
        /// </summary>
        /// <param name="accountNumber">Account number of the account</param>
        private void WithdrawAmount(string accountNumber)
        {
            decimal withdrawAmount = ConsoleView.GetDecimal("Enter amount to withdraw: ");
            if (Validator.IsValidAmount(withdrawAmount) != string.Empty)
            {
                ConsoleView.PrintInfo(Validator.IsValidAmount(withdrawAmount));
                return;
            }

            ConsoleView.PrintInfo(this._bankService.WithdrawAmount(accountNumber, withdrawAmount));
        }

        /// <summary>
        /// This checks the balance of the account number given
        /// </summary>
        /// <param name="accountNumber">Account number fr account to check balance</param>
        private void DisplayBalance(string accountNumber)
        {
            BankAccount? account = this._bankService.GetBalance(accountNumber);
            if (account == null)
            {
                ConsoleView.PrintInfo("Account not Found");
                return;
            }

            ConsoleView.PrintBalance(account);
        }
    }
}
