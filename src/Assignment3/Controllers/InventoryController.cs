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

        /// <summary>
        /// Initializes a new instance of the <see cref="InventoryController"/> class.
        /// </summary>
        /// <param name="inventoryService">Service object</param>
        /// <param name="validator">Validation object</param>
        public InventoryController(InventoryService inventoryService)
        {
            this._inventoryService = inventoryService;
        }

        /// <summary>
        /// Add Product operation
        /// </summary>
        internal void AddProduct()
        {
            string name = ConsoleView.GetString("Enter the Product Name: ");
            decimal price = ConsoleView.GetDecimal("Enter the Price of the Product: ");
            int quantity = ConsoleView.GetInteger("Enter the Quantity of the Product: ");
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
    }
}
