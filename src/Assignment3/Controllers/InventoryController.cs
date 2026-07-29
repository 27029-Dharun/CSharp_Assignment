using InventoryManager.Models;
using InventoryManager.Services;
using InventoryManager.View;

namespace InventoryManager.Controllers
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
        public InventoryController(InventoryService inventoryService, View.ConsoleView view)
        {
            this._inventoryService = inventoryService;
            this._consoleView = view;
        }

        /// <summary>
        /// Add Product operation
        /// </summary>
        public void AddProduct()
        {
            string name = this._consoleView.GetString("Enter the Product Name: ");
            decimal price = this._consoleView.GetDecimal("Enter the Price of the Product: ");
            int quantity = this._consoleView.GetInteger("Enter the Quantity of the Product: ");
            this._inventoryService.CreateInventoryProduct(name, price, quantity);
            this._consoleView.PrintInfo("Product Added Successfully");
        }

        /// <summary>
        /// View product
        /// </summary>
        public void ViewProduct()
        {
            List<Product> inventories = this._inventoryService.GetInventoryProducts();
            if (inventories.Any())
            {
                this._consoleView.PrintInfo("Products in Inventory");
                this._consoleView.PrintInventory(inventories);
            }
            else
            {
                this._consoleView.PrintInfo("Inventory is Empty");
            }
        }

        /// <summary>
        /// Deletes product from the Inventory
        /// </summary>
        public void DeleteProduct()
        {
            List<Product> inventories = this._inventoryService.GetInventoryProducts();
            if (inventories.Count == 0)
            {
                this._consoleView.PrintInfo("Nothing to Delete.");
                return;
            }

            int id = this.GetProductID(inventories, "delete");
            this._inventoryService.CheckProductId(id);
            this._consoleView.PrintInfo(this._inventoryService.DeleteProductById(id));
        }

        /// <summary>
        /// Edit product
        /// </summary>
        public void EditProduct()
        {
            List<Product> inventories = this._inventoryService.GetInventoryProducts();
            if (inventories.Count == 0)
            {
                this._consoleView.PrintInfo("Nothing to Edit.");
                return;
            }

            int id = this.GetProductID(inventories, "edit");
            this._inventoryService.CheckProductId(id);
            this._consoleView.PrintInfo("Enter value for field that you only want to Edit");
            string name = this._consoleView.GetOptionalString("Enter the Product Name: ");
            decimal price = this._consoleView.GetOptinalDecimal("Enter the Price of the Product: ");
            int quantity = this._consoleView.GetOptinalInteger("Enter the Quanity of the Product: ");
            this._inventoryService.EditProductById(id, name, price, quantity);
            this._consoleView.PrintInfo("Product Edited Successfully");
        }

        /// <summary>
        /// Search the product in inventory by matching the name and product id
        /// </summary>
        public void SearchProduct()
        {
            string search_query = this._consoleView.GetString("Enter the Name or Product Id to search: ");
            List<Product> filteredProducts = this._inventoryService.SearchProductByNameOrId(search_query);
            if (filteredProducts.Any())
            {
                this._consoleView.PrintInfo("Products Matched Are: ");
                this._consoleView.PrintInventory(filteredProducts);
            }
            else
            {
                this._consoleView.PrintInfo("No Products Matched");
            }
        }

        /// <summary>
        /// Sort the products in Inventory
        /// </summary>
        internal void SortProduct()
        {
            this._consoleView.PrintInfo("Sort Product By\n1. Id\n2. Name\n3. Price\n4. Quantity");
            int option = this._consoleView.GetInteger("Enter the Option to Sort By: ");
            List<Product> products = this._inventoryService.SortProducts(option);
            this._consoleView.PrintInventory(products);
        }

        /// <summary>
        /// Gets the product index by displaying
        /// </summary>
        /// <param name="inventories">List of inventory product</param>
        /// <returns>Index value that user entered</returns>
        private int GetProductID(List<Product> inventories, string option)
        {
            this._consoleView.PrintInfo("Select the Product by ID");
            this._consoleView.PrintInventoryLinear(inventories);

            return this._consoleView.GetInteger($"Enter the Id to {option}: ");
        }
    }
}
