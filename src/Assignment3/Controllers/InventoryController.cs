using Assignment3.Models;
using Assignment3.Services;
using Assignment3.View;

namespace Assignment3.Controllers;

/// <summary>
/// Manages the expense tracker, connects view and service
/// </summary>
public class InventoryController
{
    private readonly IService _inventoryService;
    private readonly ConsoleView _consoleView;

    /// <summary>
    /// Initializes a new instance of the <see cref="InventoryController"/> class.
    /// </summary>
    /// <param name="inventoryService">Instance of service handling inventory data operations and business rules.</param>
    /// <param name="view">Instance of view used to display data and capture user input. </param>
    public InventoryController(IService inventoryService, ConsoleView view)
    {
        this._inventoryService = inventoryService;
        this._consoleView = view;
    }

    /// <summary>
    /// Displays the menu option and gets a option as input continuously until the user exits.
    /// </summary>
    public void InventoryManagement()
    {
        this._consoleView.PrintInfo("Welcome to Inventory Management Application");
        bool isRunning = true;
        while (isRunning)
        {
            try
            {
                isRunning = this.InventoryOptions();
            }
            catch (Exception ex)
            {
                this._consoleView.PrintInfo(ex.Message);
            }

            this._consoleView.PauseAndContinue();
        }
    }

    /// <summary>
    /// Collects product details from the user, creates a new inventory item, and displays a success confirmation.
    /// </summary>
    public void AddProduct()
    {
        string name = this._consoleView.GetProductName("Enter the product name: ");
        decimal price = this._consoleView.GetProductPrice("Enter the price of the product: ");
        int quantity = this._consoleView.GetProductQuantity("Enter the quantity of the product: ");
        Product product = this._inventoryService.CreateInventoryProduct(name, price, quantity);
        this._consoleView.PrintProduct(product);
        this._consoleView.PrintInfo("Product added successfully !!");
    }

    /// <summary>
    /// Displays all current inventory products in the console, or outputs a warning if the inventory is empty.
    /// </summary>
    public void ViewProduct()
    {
        List<Product> inventories = this._inventoryService.GetInventoryProducts();
        if (inventories.Any())
        {
            this._consoleView.PrintInfo("Products in inventory");
            this._consoleView.PrintInventory(inventories);
        }
        else
        {
            this._consoleView.PrintInfo("Inventory is empty");
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
            this._consoleView.PrintInfo("No product available to delete");
            return;
        }

        int id = this.GetProductID(inventories, "delete");
        Product? product = this._inventoryService.DeleteProductById(id);
        if (product is null)
        {
            this._consoleView.PrintInfo("Product id is not valid");
            return;
        }

        this._consoleView.PrintProduct(product);
        this._consoleView.PrintInfo("Product deleted successfully !!");
    }

    /// <summary>
    /// Gets the detail to edited and edit the product.
    /// </summary>
    public void EditProduct()
    {
        List<Product> inventories = this._inventoryService.GetInventoryProducts();
        if (inventories.Count == 0)
        {
            this._consoleView.PrintInfo("No product available to edit.");
            return;
        }

        int id = this.GetProductID(inventories, "edit");
        this._inventoryService.ValidateProductId(id);
        this._consoleView.PrintInfo("Enter value for field that you only want to edit");

        string name = this._consoleView.GetProductName("Enter the product name: ", true);
        decimal? price = this._consoleView.GetOptionalProductPrice("Enter the price of the product: ");
        int? quantity = this._consoleView.GetOptionalProductQuantity("Enter the quantity of the product: ");

        Product product = this._inventoryService.EditProductById(id, name, price, quantity);
        this._consoleView.PrintProduct(product);
        this._consoleView.PrintInfo("Product edited successfully !!");
    }

    /// <summary>
    /// Search the product in inventory by matching the name and product id.
    /// </summary>
    public void SearchProduct()
    {
        if (this._inventoryService.IsInventoryEmpty())
        {
            this._consoleView.PrintInfo("Inventory is empty");
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
            this._consoleView.PrintInfo("No product matched");
        }
    }

    /// <summary>
    /// Displays product in sorted order.
    /// </summary>
    public void SortProduct()
    {
        if (this._inventoryService.IsInventoryEmpty())
        {
            this._consoleView.PrintInfo("Inventory is empty");
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

    private bool InventoryOptions()
    {
        InventoryOperation option = this._consoleView.GetEnumOption<InventoryOperation>("1. Add a product\n2. View all product\n3. Edit Product\n4. Delete Product\n5. Search Product\n6. Sort Products\n7. Exit\nChoose an operation to continue: ");
        switch (option)
        {
            case InventoryOperation.Add:
                this.AddProduct();
                break;

            case InventoryOperation.View:
                this.ViewProduct();
                break;

            case InventoryOperation.Update:
                this.EditProduct();
                break;

            case InventoryOperation.Delete:
                this.DeleteProduct();
                break;

            case InventoryOperation.Search:
                this.SearchProduct();
                break;

            case InventoryOperation.Sort:
                this.SortProduct();
                break;

            case InventoryOperation.Exit:
                return false;

            default:
                this._consoleView.PrintInfo("Enter an option in range 1 - 7");
                break;
        }

        return true;
    }
}
