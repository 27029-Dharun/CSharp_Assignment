using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public int GetAccountInfo()
        {
            Console.WriteLine("Enter Your Name");

        }
    }
}
