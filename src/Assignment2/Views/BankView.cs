using Assignment2.Models.BankingSystem;

namespace Assignment2.Views
{
    /// <summary>
    /// This class contains a bank view
    /// </summary>
    internal class BankView
    {
        /// <summary>
        /// Gets the option of operation to be performed
        /// </summary>
        /// <returns>Integer value telling the operation</returns>
        public int GetOption()
        {
            int option;
            Console.WriteLine("Enter the Operation to Continue");
            Console.WriteLine("1. Create Bank Account");
            Console.WriteLine("2. Log In to An Existing Account");
            Console.WriteLine("3. Exit");

            while (!int.TryParse(Console.ReadLine(), out option))
            {
                Console.WriteLine("Invalid Option");
            }

            return option;
        }

        /// <summary>
        /// This is the method to get the account details for creating an account
        /// </summary>
        /// <param name="name">Name of the Account Holder</param>
        /// <param name="type">Account Type</param>
        /// <param name="initialAmount">Initial aamount used when creating an account</param>
        public void GetAccountInfo(out string name, out int type, out decimal initialAmount)
        {
            Console.WriteLine("Select Your Account Type\n1. Saving Account\n2. Checking Account\n");

            while (!int.TryParse(Console.ReadLine(), out type))
            {
                Console.WriteLine("Enter a Valid Input");
            }

            Console.Write("Enter Your Name: ");
            name = (Console.ReadLine() ?? string.Empty).Trim();
            while (name == string.Empty)
            {
                Console.WriteLine("Name can't be Empty");
                name = (Console.ReadLine() ?? string.Empty).Trim();
            }

            Console.Write("Enter the Initial Amount: ");
            while (!decimal.TryParse(Console.ReadLine(), out initialAmount))
            {
                Console.WriteLine("Enter a Valid Input");
            }
        }

        /// <summary>
        /// This class Logs Into an Bank Account
        /// </summary>
        /// <param name="accountNumber">Account Number</param>
        internal void GetLogInDetails(out string accountNumber)
        {
            Console.WriteLine("Enter the Account Number to Log In");
            accountNumber = (Console.ReadLine() ?? string.Empty).Trim();
            while (accountNumber == string.Empty)
            {
                Console.WriteLine("Name can't be Empty");
                accountNumber = (Console.ReadLine() ?? string.Empty).Trim();
            }
        }

        /// <summary>
        /// This gets the operation that is to be done after login
        /// </summary>
        /// <returns>Int value to represent operation</returns>
        internal int GetOperation()
        {
            int input;
            Console.WriteLine("Enter an Operation to Continue: ");
            Console.WriteLine("1. Check Balance");
            Console.WriteLine("2. Withdraw Amount");
            Console.WriteLine("3. Deposit Amount");
            Console.WriteLine("4. Exit");

            while (!int.TryParse(Console.ReadLine(), out input))
            {
                Console.WriteLine("Please enter a Valid Input");
            }

            return input;
        }

        /// <summary>
        /// This prints the balance and other info of the Account
        /// </summary>
        /// <param name="account">The account object that is to be Printed</param>
        internal void DisplayBalance(BankAccount account)
        {
            Console.WriteLine($"Account Number: {account.AccountNumber}");
            Console.WriteLine($"Balance: {account.Balance}");
        }

        /// <summary>
        /// This Method gets the Amount that is to be deposited or withdrawed
        /// </summary>
        /// <param name="operation">Tell withdraw or deposit operation</param>
        /// <returns>Amount to be withdrawed or deposited</returns>
        internal decimal GetAmount(string operation)
        {
            decimal amount;
            Console.WriteLine($"Enter the Amount to {operation}");
            while (!decimal.TryParse(Console.ReadLine(), out amount))
            {
                Console.WriteLine("Please enter a Valid Input");
            }

            return amount;
        }

        /// <summary>
        /// This prints the message passed from the controller
        /// </summary>
        /// <param name="info">This parameter contains the string to be printed</param>
        internal void PrintInfo(string info)
        {
            Console.WriteLine(info);
        }
    }
}
