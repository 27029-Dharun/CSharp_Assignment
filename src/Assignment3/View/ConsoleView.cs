using Assignment3.Models;
using Assignment3.Validation;
using ConsoleTables;

namespace Assignment3.View
{
    /// <summary>
    /// Handles console operation like display, get user inputs.
    /// </summary>
    internal class ConsoleView
    {
        /// <summary>
        /// A value the represents an option to assign existing value to the inventory product.
        /// </summary>
        public const int AssignExistingValue = -1;

        private const int Tries = 3;

        /// <summary>
        /// Reads a key
        /// </summary>
        internal void ReadKey()
        {
            Console.ReadKey();
        }

        /// <summary>
        /// Gets the string from the user.
        /// </summary>
        /// <param name="message">Message to be displayed</param>
        /// <returns>String given as input</returns>
        internal string GetString(string message)
        {
            Console.Write(message);
            return Console.ReadLine() ?? string.Empty;
        }

        /// <summary>
        /// Gets an integer input.
        /// </summary>
        /// <param name="message">Message to be printed</param>
        /// <param name="tries">Tries left to enter a valid Integer</param>
        /// <returns>Integer input</returns>
        internal int GetInteger(string message, int tries = Tries)
        {
            Console.Write(message);
            int input;
            while (!int.TryParse(Console.ReadLine(), out input))
            {
                if (tries <= 0)
                {
                    throw new InvalidCastException("Enter a valid integer");
                }

                Console.WriteLine($"Tries left: {--tries}");
                Console.WriteLine("Enter a valid integer\n");
                Console.Write(message);
            }

            return input;
        }

        /// <summary>
        /// Gets the product quantity from the user
        /// </summary>
        /// <param name="message">Message to be displayed to user before getting the quantity</param>
        /// <param name="optional"> Optional indicates that the price can be empty used for edited the amount. </param>
        /// <param name="tries">Tries left to enter a valid decimal</param>
        /// <returns>An integer value that is enter by user</returns>
        internal int GetProductQuantity(string message, bool optional = false, int tries = Tries)
        {
            string input = this.GetString(message);

            // Can be used for edit if it is empty the already existing value can be assigned
            if (optional)
            {
                if (input.Equals(string.Empty))
                {
                    return AssignExistingValue;
                }
            }

            int quantity;
            while ((!int.TryParse(input, out quantity)) || !InventoryValidator.IsValidateQuantity(quantity))
            {
                if (tries <= 0)
                {
                    throw new InvalidCastException("Enter a valid quantity that is greater than or equal to zero");
                }

                Console.WriteLine($"Tries Left: {tries--}");
                Console.WriteLine("Enter a valid quantity that is greater than or equal to zero\n");
                input = this.GetString(message);
            }

            return quantity;
        }

        /// <summary>
        /// Gets the name of the product from the user.
        /// </summary>
        /// <param name="message">Message to be displayed</param>
        /// <param name="optional"> Optional indicates that the price can be empty used for edited the amount. </param>
        /// <param name="tries">Tries left to enter a valid decimal</param>
        /// <returns>A string containing product name</returns>
        internal string GetProductName(string message, bool optional = false, int tries = Tries)
        {
            string productName = this.GetString(message);

            if (optional)
            {
                if (productName.Equals(string.Empty))
                {
                    return AssignExistingValue.ToString();
                }
            }

            while (productName == string.Empty || !InventoryValidator.IsValidateName(productName))
            {
                if (tries <= 0)
                {
                    throw new ArgumentException("Product name should have minimum three character, and all the characters should be alphabets");
                }

                Console.WriteLine("Product name should have minimum three character, and all the characters should be alphabets\n");
                Console.WriteLine($"Tries Left: {--tries}");
                productName = this.GetString(message);
            }

            return productName;
        }

        /// <summary>
        /// Gets decimal product price from the user.
        /// </summary>
        /// <param name="message"> Message to be displayed. </param>
        /// <param name="optional"> Optional indicates that the price can be empty used for edited the amount. </param>
        /// <param name="tries"> Tries left to enter a valid decimal. </param>
        /// <returns> A decimal value containing the price of the product. </returns>
        internal decimal GetProductPrice(string message, bool optional = false, int tries = Tries)
        {
            string input = this.GetString(message);

            // Can be used for edit if it is empty the already existing value can be assigned
            if (optional)
            {
                if (input.Equals(string.Empty))
                {
                    return AssignExistingValue;
                }
            }

            decimal price;
            while ((!decimal.TryParse(input, out price)) || !InventoryValidator.IsValidatePrice(price))
            {
                if (tries <= 0)
                {
                    throw new InvalidCastException("Enter a valid amount greater than zero");
                }

                Console.WriteLine($"Tries Left: {--tries}");
                Console.WriteLine("Enter a valid amount greater than zero\n");
                input = this.GetString(message);
            }

            return price;
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
        /// Prints empty line
        /// </summary>
        internal void PrintEmptyLine()
        {
            Console.WriteLine();
        }

        /// <summary>
        /// Prints the product object in console
        /// </summary>
        /// <param name="product">Product object to be printed</param>
        internal void PrintProduct(Product product)
        {
            Console.WriteLine("\nProduct Id: " + product.Id);
            Console.WriteLine("Product name: " + product.Name);
            Console.WriteLine("Product price: " + product.Price);
            Console.WriteLine("Product quantity: " + product.Quantity + "\n");
        }

        /// <summary>
        /// Displays the list of the inventory object
        /// </summary>
        /// <param name="inventories">List of inventory objects</param>
        internal void PrintInventory(List<Product> inventories)
        {
            var table = new ConsoleTable("Product Id", "Product Name", "Product Price", "Product Quantity");

            foreach (Product inventory in inventories)
            {
                table.AddRow(inventory.Id, inventory.Name, inventory.Price, inventory.Quantity);
            }

            table.Write();
        }
    }
}
