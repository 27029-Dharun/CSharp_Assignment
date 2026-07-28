using Assignment3.Models;
using Assignment3.Services;
using Assignment3.Utility;
using Assignment3.View;

namespace Assignment3.Controllers
{
    /// <summary>
    /// Inventory Controller
    /// </summary>
    internal class InventoryController : IController
    {
        private InventoryService _inventoryService;
        private ConsoleView _consoleView;

        /// <summary>
        /// Initializes a new instance of the <see cref="InventoryController"/> class.
        /// </summary>
        /// <param name="inventoryService">Service object</param>
        /// <param name="view">View object</param>
        public InventoryController(InventoryService inventoryService, ConsoleView view)
        {
            this._inventoryService = inventoryService;
            this._consoleView = view;
        }

        /// <summary>
        /// Add Product operation
        /// </summary>
        public void AddProduct()
        {
            string name = IOUtility.GetString("Enter the Product Name: ");
            decimal price = IOUtility.GetDecimal("Enter the Price of the Product: ");
            int quantity = IOUtility.GetInteger("Enter the Quantity of the Product: ");
            IOUtility.PrintInfo(this._inventoryService.CreateInventoryProduct(name, price, quantity));
        }

        /// <summary>
        /// View product
        /// </summary>
        public void ViewProduct()
        {
            List<Inventory> inventories = this._inventoryService.GetInventoryProducts();
            if (inventories.Any())
            {
                IOUtility.PrintInfo("Products in Inventory");
                this._consoleView.PrintInventory(inventories);
            }
            else
            {
                IOUtility.PrintInfo("Inventort is Empty");
            }
        }

        /// <summary>
        /// Deletes product from the Inventory
        /// </summary>
        public void DeleteProduct()
        {
            List<Inventory> inventories = this._inventoryService.GetInventoryProducts();
            if (inventories.Count() == 0)
            {
                IOUtility.PrintInfo("Nothing to Delete.");
                return;
            }

            int id = this.GetProductID(inventories, "delete");
            IOUtility.PrintInfo(this._inventoryService.DeleteProductById(id));
        }

        /// <summary>
        /// Edit product
        /// </summary>
        public void EditProduct()
        {
            List<Inventory> inventories = this._inventoryService.GetInventoryProducts();
            if (inventories.Count() == 0)
            {
                IOUtility.PrintInfo("Nothing to Delete.");
                return;
            }

            int id = this.GetProductID(inventories, "edit");

            string name = IOUtility.GetOptionalString("Enter the Product Name: ");
            decimal price = IOUtility.GetOptinalDecimal("Enter the Price of the Product: ");
            int quantity = IOUtility.GetOptinalInteger("Enter the Quanity of the Product: ");

            IOUtility.PrintInfo(this._inventoryService.EditProductById(id, name, price, quantity));
        }

        /// <summary>
        /// Gets the product index by displaying
        /// </summary>
        /// <param name="inventories">List of inventory product</param>
        /// <returns>Index value that user entered</returns>
        private int GetProductID(List<Inventory> inventories, string option)
        {
            IOUtility.PrintInfo("Select the Product by ID");
            this._consoleView.PrintInventoryLinear(inventories);

            return IOUtility.GetInteger($"Enter the ID to {option}: ");
        }
    }
}
