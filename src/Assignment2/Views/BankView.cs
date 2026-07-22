using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Xml.Linq;
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

            Console.WriteLine("Enter the Account Type");
            while (!int.TryParse(Console.ReadLine(), out type))
            {
                Console.WriteLine("Enter a Valid Input");
            }

            Console.WriteLine("Enter the Name of the Employee");
            name = (Console.ReadLine() ?? string.Empty).Trim();
            while (name == string.Empty)
            {
                Console.WriteLine("Name can't be Empty");
                name = (Console.ReadLine() ?? string.Empty).Trim();
            }

            Console.WriteLine("Enter the Initial Amount");
            while (!decimal.TryParse(Console.ReadLine(), out initialAmount))
            {
                Console.WriteLine("Enter a Valid Input");
            }

            Console.WriteLine("Enter Your Name");
            Console.WriteLine("Enter Your ");
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

        internal int GetOperation()
        {
            int input;
            Console.WriteLine("Enter an Operation to Continue: ");
            Console.WriteLine("1. Check Balance");
            Console.WriteLine("2. Withdraw Amount");
            Console.WriteLine("3. Deposit");
            Console.WriteLine("4. Exit");

            while (!int.TryParse(Console.ReadLine(), out input))
            {
                Console.WriteLine("Please enter a Valid Input");
            }

            return input;
        }

        internal void DisplayBalance(BankAccount account)
        {
            Console.WriteLine($"Account Number: {account.AccountNumber}");
            Console.WriteLine($"Balance: {account.Balance}");
        }

        internal decimal GetAmount(string v)
        {
            decimal amount;
            Console.WriteLine($"Enter the Amount to {v}");
            while (!decimal.TryParse(Console.ReadLine(), out amount))
            {
                Console.WriteLine("Please enter a Valid Input");
            }

            return amount;
        }
    }
}
