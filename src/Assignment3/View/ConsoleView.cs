using Assignment3.Models;
using Assignment3.Utility;

namespace Assignment3.View
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
        /// Get index of the product with the Maximum value
        /// </summary>
        /// <param name="count">Count of product</param>
        /// <returns>Integer value</returns>
        internal int GetIndexValue(int count)
        {
            int index = IOUtility.GetInteger("Enter the Index");
            int tries = 3;
            while (index < 0 && index >= count)
            {
                if (tries < 0)
                {
                    IOUtility.PrintInfo("Index range 1 - " + count);
                    return -1;
                }

                tries--;
                index = IOUtility.GetInteger("Enter the Index");
                IOUtility.PrintInfo("Enter a Valid Index");
            }

            return index;
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
    }
}
