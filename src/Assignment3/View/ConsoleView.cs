using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment3.Models;

namespace Assignment3.View
{
    /// <summary>
    /// Console Operations
    /// </summary>
    internal class ConsoleView
    {
        public static void PrintInfo(string message)
        {
            Console.WriteLine(message);
        }

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
        /// Prints the list of the inventory object
        /// </summary>
        /// <param name="inventories">List of Inventory objects</param>
        internal static void PrintInventory(List<Inventory> inventories)
        {
            foreach (Inventory inventory in inventories)
            {
                Console.WriteLine("Product Id: " + inventory.ProductId);
                Console.WriteLine("Product Name: " + inventory.ProductName);
                Console.WriteLine("Product Price: " + inventory.ProductPrice);
                Console.WriteLine("Product Quantity: " + inventory.ProductQuantity);
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Prints the list of the inventory object linearly
        /// </summary>
        /// <param name="inventories">List of Inventory objects</param>
        internal static void PrintInventoryLinear(List<Inventory> inventories)
        {
            int i = 1;
            foreach (Inventory inventory in inventories)
            {
                Console.Write(i++);
                Console.Write(". Id: " + inventory.ProductId);
                Console.Write(", Name: " + inventory.ProductName);
                Console.Write(", Price: " + inventory.ProductPrice);
                Console.WriteLine(", Quantity: " + inventory.ProductQuantity);
            }
        }
    }
}
