using Assignment3.Models;
using Assignment3.Validation;
using ConsoleTables;

namespace Assignment3.View
{
    /// <summary>
    /// Handles console operation like display, get user inputs.
    /// </summary>
    public class ConsoleView
    {
        /// <summary>
        /// A value the represents an option to assign existing value to the inventory product.
        /// </summary>
        public const int AssignExistingValue = -1;

        private const int Tries = 3;

        /// <summary>
        /// Gets the string from the user.
        /// </summary>
        /// <param name="message">Message to be displayed</param>
        /// <returns>String given as input</returns>
        public string GetString(string message)
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
        public int GetInteger(string message, int tries = Tries)
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
        /// Gets the enum value, validates and return an enum value
        /// </summary>
        /// <typeparam name="T">Generics type parameter which accepts all Enum type.</typeparam>
        /// <param name="prompt">Prompt displayed to the user.</param>
        /// <returns>A Enum option selected by the user.</returns>
        public T GetEnumOption<T>(string prompt)
            where T : struct, Enum
        {
            string input = this.GetString(prompt);
            T result;
            while ((!Enum.TryParse<T>(input, true, out result)) || (!Enum.IsDefined(typeof(T), result)))
            {
                Console.Clear();
                Console.WriteLine("Enter a valid input");
                input = this.GetString(prompt);
            }

            return result;
        }

        /// <summary>
        /// Gets the name of the product from the user.
        /// </summary>
        /// <param name="message">Message to be displayed</param>
        /// <param name="optional"> Optional indicates that the price can be empty used for edited the amount. </param>
        /// <param name="tries">Tries left to enter a valid decimal</param>
        /// <returns>A string containing product name</returns>
        public string GetProductName(string message, bool optional = false, int tries = Tries)
        {
            return this.GetValidatedInput(message, optional, InventoryViewValidator.IsValidateName, "Name must atleast contain 3 characters");
        }

        /// <summary>
        /// Gets the product quantity from the user
        /// </summary>
        /// <param name="message">Message to be displayed to user before getting the quantity</param>
        /// <param name="optional"> Optional indicates that the price can be empty used for edited the amount. </param>
        /// <param name="tries">Tries left to enter a valid decimal</param>
        /// <returns>An integer value that is enter by user</returns>
        public int GetProductQuantity(string message, bool optional = false, int tries = Tries)
        {
            string input = this.GetValidatedInput(message, optional, InventoryViewValidator.IsValidateQuantity, "Quantity can't be negative");

            return int.Parse(input);
        }

        /// <summary>
        /// Gets decimal product price from the user.
        /// </summary>
        /// <param name="message"> Message to be displayed. </param>
        /// <returns> A decimal value containing the price of the product. </returns>
        public decimal GetProductPrice(string message)
        {
            string input = this.GetValidatedInput(message, false, InventoryViewValidator.IsValidatePrice, "Price must a valid positive integer.");
            return decimal.Parse(input);
        }

        /// <summary>
        /// Gets decimal product price from the user.
        /// </summary>
        /// <param name="message"> Message to be displayed. </param>
        /// <returns> A decimal value containing the price of the product. </returns>
        public decimal? GetOptionalProductPrice(string message)
        {
            string input = this.GetValidatedInput(message, true, InventoryViewValidator.IsValidatePrice, "Price must a valid positive integer.");

            if (string.IsNullOrWhiteSpace(input))
            {
                return null;
            }

            return decimal.Parse(input);
        }

        /// <summary>
        /// Gets the product quantity from the user
        /// </summary>
        /// <param name="message">Message to be displayed to user before getting the quantity</param>
        /// <returns>An integer value that is enter by user</returns>
        public int? GetOptionalProductQuantity(string message)
        {
            string input = this.GetValidatedInput(message, true, InventoryViewValidator.IsValidateQuantity, "Quantity must a valid non negative integer.");

            if (string.IsNullOrWhiteSpace(input))
            {
                return null;
            }

            return int.Parse(input);
        }

        /// <summary>
        /// Print the message in console
        /// </summary>
        /// <param name="message">Message to be printed</param>
        public void PrintInfo(string message)
        {
            Console.WriteLine(message);
        }

        /// <summary>
        /// Prints the product object in console
        /// </summary>
        /// <param name="product">Product object to be printed</param>
        public void PrintProduct(Product product)
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
        public void PrintInventory(List<Product> inventories)
        {
            var table = new ConsoleTable("Product Id", "Product Name", "Product Price", "Product Quantity");

            foreach (Product inventory in inventories)
            {
                table.AddRow(inventory.Id, inventory.Name, inventory.Price, inventory.Quantity);
            }

            table.Write();
        }

        /// <summary>
        /// Pauses and waits for the user to enter a value.
        /// </summary>
        public void PauseAndContinue()
        {
            Console.WriteLine("Enter a key to return to main menu");
            Console.ReadKey();
            Console.Clear();
        }

        private string GetValidatedInput(string prompt, bool optional, Func<string, bool> isValidField, string errorMessage)
        {
            int tries = Tries;
            string input = this.GetString(prompt);
            if (optional && string.IsNullOrWhiteSpace(input))
            {
                return string.Empty;
            }

            while (!isValidField(input))
            {
                if (tries == 1)
                {
                    throw new InvalidDataException("No attempt left, Please try again." + Environment.NewLine);
                }

                Console.WriteLine(errorMessage);
                Console.WriteLine($"Tries left: {--tries}\n");
                input = this.GetString(prompt);
            }

            return input;
        }
    }
}
