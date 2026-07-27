using System.ComponentModel.DataAnnotations;
using System.Transactions;
using Assignment3.Models;
using Assignment3.Services;
using Assignment3.Validation;
using Assignment3.View;

namespace Assignment3.Controllers
{
    /// <summary>
    /// Inventory Controller
    /// </summary>
    internal class InventoryController
    {
        private InventoryService _inventoryService;
        private InventoryValidator _validator;

        /// <summary>
        /// Initializes a new instance of the <see cref="InventoryController"/> class.
        /// </summary>
        /// <param name="inventoryService">Service object</param>
        /// <param name="validator">Validation object</param>
        public InventoryController(InventoryService inventoryService, InventoryValidator validator)
        {
            this._inventoryService = inventoryService;
            this._validator = validator;
        }

        /// <summary>
        /// Add Product operation
        /// </summary>
        internal void AddProduct()
        {
            string name = this.GetValidString("Enter the Product Name: ");
            if (name == string.Empty)
            {
                ConsoleView.PrintInfo("Name not valid, Try Again");
            }

            decimal price = this.GetValidDecimal("Enter the Price of the Product: ");
            if (price == -1)
            {
                ConsoleView.PrintInfo("Price can't be Negative, Try Again");
            }

            int quantity = this.GetValidInteger("Enter the Quantity of the Product: ");
            if (quantity == -1)
            {
                ConsoleView.PrintInfo("Quantity can't be Negative, Try Again");
            }

            this._inventoryService.CreateInventoryProduct(name, price, quantity);
        }

        /// <summary>
        /// View product
        /// </summary>
        internal void ViewProduct()
        {
            List<Inventory> inventories = this._inventoryService.GetInventoryProducts();
            if (inventories.Any())
            {
                ConsoleView.PrintInfo("Products in Inventory");
                ConsoleView.PrintInventory(inventories);
            }
            else
            {
                ConsoleView.PrintInfo("Inventort is Empty");
            }
        }

        /// <summary>
        /// Deletes product from the Inventory
        /// </summary>
        internal void DeleteProduct()
        {
            List<Inventory> inventories = this._inventoryService.GetInventoryProducts();
            if (inventories.Count() == 0)
            {
                ConsoleView.PrintInfo("Nothing to Delete.");
                return;
            }

            ConsoleView.PrintInfo("Select the Product by Index to Delete");
            ConsoleView.PrintInventoryLinear(inventories);
            int index = ConsoleView.GetInteger("Enter the Index");
            int tries = 3;
            while (!this._validator.ValidateIndex(index, inventories.Count()))
            {
                if (tries < 0)
                {
                    ConsoleView.PrintInfo("Please Try Again");
                    return;
                }

                tries--;
                index = ConsoleView.GetInteger("Enter the Index");
                ConsoleView.PrintInfo("Enter a Valid Index");
            }

            Inventory product = inventories[index - 1];
            this._inventoryService.DeleteProductById(product);
        }

        /// <summary>
        /// gets and validates the string input
        /// </summary>
        /// <param name="message">Message to be printed</param>
        /// <returns>string to display the error message</returns>
        private string GetValidString(string message)
        {
            int tries = 3;
            string name = ConsoleView.GetString(message);
            while (!this._validator.ValidateName(name) && tries > 0)
            {
                ConsoleView.PrintInfo("Invalid Name");
                ConsoleView.PrintInfo($"Tries Left: {tries}");
                tries--;
                name = ConsoleView.GetString(message);
            }

            if (!this._validator.ValidateName(name))
            {
                ConsoleView.PrintInfo("Invalid Name");
                return string.Empty;
            }

            return name;
        }

        /// <summary>
        /// gets and validates the decimal input
        /// </summary>
        /// <param name="message">Message to be printed</param>
        /// <returns>string to display the error message</returns>
        private decimal GetValidDecimal(string message)
        {
            int tries = 3;
            decimal input = ConsoleView.GetDecimal(message);
            while (!this._validator.ValidatePrice(input))
            {
                ConsoleView.PrintInfo("Invalid Price");
                ConsoleView.PrintInfo($"Tries Left: {tries}");
                tries--;
                input = ConsoleView.GetDecimal(message);
            }

            if (!this._validator.ValidatePrice(input))
            {
                ConsoleView.PrintInfo("Invalid Price");
                return -1;
            }

            return input;
        }

        /// <summary>
        /// gets and validates the input input
        /// </summary>
        /// <param name="message">Message to be printed</param>
        /// <returns>integer Input</returns>
        private int GetValidInteger(string message)
        {
            int tries = 3;
            int input = ConsoleView.GetInteger(message);
            while (!this._validator.ValidateQuantity(input))
            {
                ConsoleView.PrintInfo("Invalid Quantity");
                ConsoleView.PrintInfo($"Tries Left: {tries}");
                tries--;
                input = ConsoleView.GetInteger(message);
            }

            if (!this._validator.ValidateQuantity(input))
            {
                ConsoleView.PrintInfo("Invalid Quantity");
                return -1;
            }

            return input;
        }
    }
}
