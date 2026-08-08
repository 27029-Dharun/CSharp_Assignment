using Assignment3.Models;
using Assignment3.Services;
using Assignment3.View;

namespace Assignment3.Controllers
{
    /// <summary>
    /// Manages the expense tracker, connects view and service
    /// </summary>
    internal class InventoryController
    {
        private readonly InventoryService _inventoryService;
        private readonly ConsoleView _consoleView;

        /// <summary>
        /// Initializes a new instance of the <see cref="InventoryController"/> class.
        /// </summary>
        /// <param name="inventoryService">Instance of service handling inventory data operations and business rules.</param>
        /// <param name="view">Instance of view used to display data and capture user input. </param>
        public InventoryController(InventoryService inventoryService, View.ConsoleView view)
        {
            this._inventoryService = inventoryService;
            this._consoleView = view;
        }

        /// <summary>
        /// Collects product details from the user, creates a new inventory item, and displays a success confirmation.
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
        /// Displays all current inventory products in the console, or outputs a warning if the inventory is empty.
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
        /// Deletes a product from the inventory by the unique product identifier.
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
            Product? product = this._inventoryService.DeleteProductById(id);
            if (product == null)
            {
                this._consoleView.PrintInfo("Product id is not valid");
                return;
            }

            this._consoleView.PrintProduct(product);
            this._consoleView.PrintInfo("PRODUCT DELETED SUCCESSFULLY !!");
        }

        /// <summary>
        /// Gets the detail to edited and edit the product.
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
            decimal price = this._consoleView.GetOptionalDecimal("Enter the price of the product: ");
            int quantity = this._consoleView.GetOptionalInteger("Enter the quanity of the product: ");
            Product product = this._inventoryService.EditProductById(id, name, price, quantity);
            this._consoleView.PrintProduct(product);
            this._consoleView.PrintInfo("PRODUCT EDITED SUCCESSFULLY !!");
        }

        /// <summary>
        /// Search the product in inventory by matching the name and product id.
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
        /// Displays product in sorted order.
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
        /// Gets the product id by displaying all the products
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
