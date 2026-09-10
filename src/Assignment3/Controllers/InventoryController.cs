using Assignment3.Constants;
using Assignment3.Models;
using Assignment3.Services;
using Assignment3.View;

namespace Assignment3.Controllers;

/// <summary>
/// Coordinates user interactions between view and service.
/// </summary>
public class InventoryController
{
    private readonly IInventoryService _service;
    private readonly ConsoleView _view;

    /// <summary>
    /// Initializes a new instance of the <see cref="InventoryController"/> class.
    /// </summary>
    /// <param name="service">Instance of service handling inventory data operations and business rules.</param>
    /// <param name="view">Instance of view used to display data and capture user input. </param>
    public InventoryController(IInventoryService service, ConsoleView view)
    {
        this._service = service;
        this._view = view;
    }

    /// <summary>
    /// Displays the menu option and gets a option as input continuously until the user exits.
    /// </summary>
    public void Run()
    {
        bool isRunning = true;
        while (isRunning)
        {
            try
            {
                this._view.PrintInfo("Inventory Management Application");
                isRunning = this.ProcessMenuSelection();
            }
            catch (Exception ex)
            {
                this._view.PrintInfo(ex.Message);
            }
            finally
            {
                this._view.PauseAndContinue();
            }
        }
    }

    /// <summary>
    /// Collects product details from the user, creates a new inventory item, and displays a success confirmation.
    /// </summary>
    private void AddProduct()
    {
        string name = this._view.GetProductName();
        decimal price = this._view.GetProductPrice() !.Value;
        int quantity = this._view.GetProductQuantity() !.Value;

        Product product = this._service.AddProduct(name, price, quantity);

        this._view.PrintProduct(product);
        this._view.PrintInfo("Product added successfully.");
    }

    /// <summary>
    /// Displays all current inventory products in the console, or outputs a warning if the inventory is empty.
    /// </summary>
    private void ViewProduct()
    {
        if (!this._service.HasProducts())
        {
            this._view.PrintInfo(MessageConstants.EmptyInventoryMessage);
            return;
        }

        List<Product> products = this._service.GetProducts();

        this._view.PrintInfo("Products in inventory");
        this._view.PrintInventory(products);
    }

    /// <summary>
    /// Deletes a product from the inventory by ID of the product.
    /// </summary>
    private void DeleteProduct()
    {
        if (!this._service.HasProducts())
        {
            this._view.PrintInfo(MessageConstants.EmptyInventoryMessage);
            return;
        }

        int id = this.GetProductId("delete");
        Product product = this._service.DeleteProductById(id);

        this._view.PrintProduct(product);
        this._view.PrintInfo("Product deleted successfully.");
    }

    /// <summary>
    /// Gets the detail to edit the product, and updates the product.
    /// </summary>
    private void EditProduct()
    {
        if (!this._service.HasProducts())
        {
            this._view.PrintInfo(MessageConstants.EmptyInventoryMessage);
            return;
        }

        int id = this.GetProductId("edit");

        if (!this._service.ValidateProductId(id))
        {
            this._view.PrintInfo($"Entered product ID - {id} is not valid");
            return;
        }

        this._view.DisplayEditInstruction();

        string name = this._view.GetProductName(true);
        decimal? price = this._view.GetProductPrice(true);
        int? quantity = this._view.GetProductQuantity(true);

        Product product = this._service.EditProductById(id, name, price, quantity);

        this._view.PrintProduct(product);
        this._view.PrintInfo("Product edited successfully.");
    }

    /// <summary>
    /// Search the product in inventory by matching the name and product id.
    /// </summary>
    private void SearchProduct()
    {
        if (!this._service.HasProducts())
        {
            this._view.PrintInfo(MessageConstants.EmptyInventoryMessage);
            return;
        }

        string searchQuery = this._view.GetSearchQuery();
        List<Product> filteredProducts = this._service.SearchProductByNameOrId(searchQuery);

        if (!filteredProducts.Any())
        {
            this._view.PrintInfo("No product matched");
            return;
        }

        this._view.PrintInfo("Products matched are: ");
        this._view.PrintInventory(filteredProducts);
    }

    /// <summary>
    /// Displays product in sorted order.
    /// </summary>
    private void SortProduct()
    {
        if (!this._service.HasProducts())
        {
            this._view.PrintInfo(MessageConstants.EmptyInventoryMessage);
            return;
        }

        SortOption option = this._view.GetEnumOption<SortOption>(MessageConstants.SortOptionsPrompt);
        List<Product> products = this._service.SortProducts(option).ToList();
        this._view.PrintInventory(products);
    }

    /// <summary>
    /// Gets the product Id from the list the products in the inventory.
    /// </summary>
    /// <param name="operation">Indicates the operation for which the product is selected.</param>
    /// <returns>The index of the product.</returns>
    private int GetProductId(string operation)
    {
        List<Product> products = this._service.GetProducts();
        this._view.PrintInventory(products);

        return this._view.GetInteger($"Enter the product Id to {operation}: ");
    }

    /// <summary>
    /// Processes the user's menu selection and executes the corresponding operation.
    /// Returns true if the application should continue running, false if user selected exit.
    /// </summary>
    /// <returns>Boolean indicating whether to continue the application loop.< /returns>
    private bool ProcessMenuSelection()
    {
        InventoryOperation option = this._view.GetEnumOption<InventoryOperation>(MessageConstants.MainMenuPrompt);
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
                this._view.PrintInfo("Enter an option in range 1 - 7");
                break;
        }

        return true;
    }
}
