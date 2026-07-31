using InventoryManager.Models;
using InventoryManager.Services;
using InventoryManager.View;

namespace InventoryManager.Controllers
{
    /// <summary>
    /// Inventory Controller
    /// </summary>
    internal class InventoryController
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
        /// Add product operation
        /// </summary>
        public void AddProduct()
        {
            string name = this._consoleView.GetString("Enter the product name: ");
            decimal price = this._consoleView.GetDecimal("Enter the price of the product: ");
            int quantity = this._consoleView.GetInteger("Enter the quantity of the product: ");
            Product product = this._inventoryService.CreateInventoryProduct(name, price, quantity);
            this._consoleView.PrintProduct(product);
            this._consoleView.PrintInfo("PRODUCT ADDED SUCCESSFULLY !!");
        }

        /// <summary>
        /// View product
        /// </summary>
        public void ViewProduct()
        {
            List<Product> inventories = this._inventoryService.GetInventoryProducts();
            if (inventories.Any())
            {
                this._consoleView.PrintInfo("PRODUCTS IN INVENTORY");
                this._consoleView.PrintInventory(inventories);
            }
            else
            {
                this._consoleView.PrintInfo("INVENTORY IS EMPTY");
            }
        }

        /// <summary>
        /// Deletes product from the inventory
        /// </summary>
        public void DeleteProduct()
        {
            List<Product> inventories = this._inventoryService.GetInventoryProducts();
            if (inventories.Count == 0)
            {
                this._consoleView.PrintInfo("NOTHING TO DELETE");
                return;
            }

            int id = this.GetProductID(inventories, "delete");
            this._inventoryService.ValidateProductId(id);
            Product product = this._inventoryService.DeleteProductById(id);
            this._consoleView.PrintProduct(product);
            this._consoleView.PrintInfo("PRODUCT DELETED SUCCESSFULLY !!");
        }

        /// <summary>
        /// Edit product fields
        /// </summary>
        public void EditProduct()
        {
            List<Product> inventories = this._inventoryService.GetInventoryProducts();
            if (inventories.Count == 0)
            {
                this._consoleView.PrintInfo("NOTHING TO EDIT.");
                return;
            }

            int id = this.GetProductID(inventories, "edit");
            this._inventoryService.ValidateProductId(id);
            this._consoleView.PrintInfo("Enter value for field that you only want to Edit");
            string name = this._consoleView.GetOptionalString("Enter the product name: ");
            decimal price = this._consoleView.GetOptinalDecimal("Enter the price of the product: ");
            int quantity = this._consoleView.GetOptinalInteger("Enter the quanity of the product: ");
            Product product = this._inventoryService.EditProductById(id, name, price, quantity);
            this._consoleView.PrintProduct(product);
            this._consoleView.PrintInfo("PRODUCT EDITED SUCCESSFULLY !!");
        }

        /// <summary>
        /// Search the product in inventory by matching the name and product id
        /// </summary>
        public void SearchProduct()
        {
            if (this._inventoryService.IsInventoryEmpty())
            {
                this._consoleView.PrintInfo("INVENTORY IS EMPTY");
                return;
            }

            string search_query = this._consoleView.GetString("Enter the name or product Id to search: ");
            List<Product> filteredProducts = this._inventoryService.SearchProductByNameOrId(search_query);
            if (filteredProducts.Any())
            {
                this._consoleView.PrintInfo("Products matched are: ");
                this._consoleView.PrintInventory(filteredProducts);
            }
            else
            {
                this._consoleView.PrintInfo("NO PRODUCT MATCHED");
            }
        }

        /// <summary>
        /// Sort the products in inventory
        /// </summary>
        internal void SortProduct()
        {
            if (this._inventoryService.IsInventoryEmpty())
            {
                this._consoleView.PrintInfo("INVENTORY IS EMPTY");
                return;
            }

            this._consoleView.PrintInfo("Sort Product By\n1. Name\n2. Price\n3. Quantity");
            int option = this._consoleView.GetInteger("Enter the option to sort: ");
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
            this._consoleView.PrintInventory(inventories);

            return this._consoleView.GetInteger($"Enter the product Id to {option}: ");
        }
    }
}
