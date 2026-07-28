using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3.Utility
{
    /// <summary>
    /// Io Utilities
    /// </summary>
    internal class IOUtility
    {
        /// <summary>
        /// Print the message in console
        /// </summary>
        /// <param name="message">Message to be printed</param>
        public static void PrintInfo(string message)
        {
            Console.WriteLine(message);
        }

        /// <summary>
        /// Get the integer
        /// </summary>
        /// <param name="message">Message to be printed</param>
        /// <returns>Integer input</returns>
        public static int GetInteger(string message)
        {
            Console.Write(message);
            int input;
            while (!int.TryParse(Console.ReadLine(), out input))
            {
                Console.WriteLine("Enter a valid integer");
                Console.Write(message);
            }

            return input;
        }

        /// <summary>
        /// Gets the string
        /// </summary>
        /// <param name="message">Message to be displayed</param>
        /// <returns>String given as input</returns>
        public static string GetString(string message)
        {
            Console.Write(message);
            string input = Console.ReadLine() ?? string.Empty;

            while (input == string.Empty)
            {
                Console.WriteLine("Entered String can't be Empty");
                input = Console.ReadLine() ?? string.Empty;
            }

            return input;
        }

        /// <summary>
        /// Gets decimal input
        /// </summary>
        /// <param name="message">Message to be printed</param>
        /// <returns>deecimal input</returns>
        internal static decimal GetDecimal(string message)
        {
            Console.Write(message);
            decimal input;
            while (!decimal.TryParse(Console.ReadLine(), out input))
            {
                Console.WriteLine("Enter a valid integer");
                Console.Write(message);
            }

            return input;
        }

        /// <summary>
        /// Gets the string input and returns string.Empty if null
        /// </summary>
        /// <param name="message">message to Print</param>
        /// <returns>string input</returns>
        internal static string GetOptionalString(string message)
        {
            Console.Write(message);
            string input = Console.ReadLine() ?? string.Empty;
            return input;
        }

        /// <summary>
        /// Get the Optional Decimal Value
        /// </summary>
        /// <param name="message">Message to print</param>
        /// <returns>Returns the decimal input</returns>
        internal static decimal GetOptinalDecimal(string message)
        {
            Console.Write(message);
            string input = Console.ReadLine() ?? string.Empty;
            if (input == string.Empty)
            {
                return -1;
            }

            if (decimal.TryParse(input, out decimal value))
            {
                Console.WriteLine("Enter a valid decimal value");
            }

            return value;
        }

        /// <summary>
        /// Gets the optional Integer value
        /// </summary>
        /// <param name="message">Message to be printed</param>
        /// <returns>Returns the integer value</returns>
        internal static int GetOptinalInteger(string message)
        {
            Console.Write(message);
            string input = Console.ReadLine() ?? string.Empty;
            if (input == string.Empty)
            {
                return -1;
            }

            if (int.TryParse(input, out int value))
            {
                Console.WriteLine("Enter a valid Integer value");
            }

            return value;
        }
    }
}
