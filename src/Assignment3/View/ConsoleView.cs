using InventoryManager.Models;

namespace InventoryManager.View
{
    /// <summary>
    /// Console Operations
    /// </summary>
    internal class ConsoleView
    {
        /// <summary>
        /// Prints the list of the inventory object
        /// </summary>
        /// <param name="inventories">List of Inventory objects</param>
        internal void PrintInventory(List<Product> inventories)
        {
            foreach (Product inventory in inventories)
            {
                Console.WriteLine("Product Id: " + inventory.Id);
                Console.WriteLine("Product Name: " + inventory.Name);
                Console.WriteLine("Product Price: " + inventory.Price);
                Console.WriteLine("Product Quantity: " + inventory.Quantity);
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Prints the list of the inventory object linearly
        /// </summary>
        /// <param name="inventories">List of Inventory objects</param>
        internal void PrintInventoryLinear(List<Product> inventories)
        {
            foreach (Product inventory in inventories)
            {
                Console.Write("Id: " + inventory.Id);
                Console.Write(", Name: " + inventory.Name);
                Console.Write(", Price: " + inventory.Price);
                Console.WriteLine(", Quantity: " + inventory.Quantity);
            }
        }

        /// <summary>
        /// Print the message in console
        /// </summary>
        /// <param name="message">Message to be printed</param>
        internal void PrintInfo(string message)
        {
            Console.WriteLine(message);
        }

        /// <summary>
        /// Get the integer
        /// </summary>
        /// <param name="message">Message to be printed</param>
        /// <returns>Integer input</returns>
        internal int GetInteger(string message)
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
        internal string GetString(string message)
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
        internal decimal GetDecimal(string message)
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
        internal string GetOptionalString(string message)
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
        internal decimal GetOptinalDecimal(string message)
        {
            Console.Write(message);
            string input = Console.ReadLine() ?? string.Empty;
            if (input == string.Empty)
            {
                return -1;
            }

            decimal value;
            if (!decimal.TryParse(input, out value))
            {
                throw new FormatException("The input is not in the correct format.");
            }

            return value;
        }

        /// <summary>
        /// Gets the optional Integer value
        /// </summary>
        /// <param name="message">Message to be printed</param>
        /// <returns>Returns the integer value</returns>
        internal int GetOptinalInteger(string message)
        {
            Console.Write(message);
            string input = Console.ReadLine() ?? string.Empty;
            if (input == string.Empty)
            {
                return -1;
            }

            if (!int.TryParse(input, out int value))
            {
                throw new FormatException("The input is not in the correct format.");
            }

            return value;
        }

        /// <summary>
        /// Reads a Key
        /// </summary>
        internal void ReadKey()
        {
            Console.ReadKey();
        }

        /// <summary>
        /// Prints Enpty Line
        /// </summary>
        internal void PrintEmptyLine()
        {
            Console.WriteLine();
        }
    }
}
