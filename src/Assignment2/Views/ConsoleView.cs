using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2.Views
{
    /// <summary>
    /// THis class contains all the console operations
    /// </summary>
    internal class ConsoleView
    {
        /// <summary>
        /// Get Task to Perform
        /// </summary>
        /// <returns>A task presented by int</returns>
        public int GetTask()
        {
            int input;
            Console.WriteLine();
            Console.WriteLine("Enter the number to Continue with a Task");
            Console.WriteLine("1. Shape Hierarchy");
            Console.WriteLine("2. Employee Hierarchy");
            Console.WriteLine("3. Banking System");
            Console.WriteLine("4. Exit");

            while (!int.TryParse(Console.ReadLine(), out input))
            {
                Console.WriteLine("Please enter a Valid Input");
            }

            return input;
        }
    }
}
