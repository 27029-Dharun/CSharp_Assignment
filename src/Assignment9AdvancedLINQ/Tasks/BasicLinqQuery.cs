using Assignment9AdvancedLINQ.Models;
using Assignment9AdvancedLINQ.Models.Enums;
using Assignment9AdvancedLINQ.Repository;
using Assignment9AdvancedLINQ.Views;
using ConsoleTables;

namespace Assignment9AdvancedLINQ.Tasks;

/// <summary>
/// Contains the basic linq operations.
/// </summary>
public class BasicLinqQuery
{
    private readonly Database _database;

    /// <summary>
    /// Initializes a new instance of the <see cref="BasicLinqQuery"/> class.
    /// </summary>
    /// <param name="database">Instance of the database.</param>
    public BasicLinqQuery(Database database)
    {
        this._database = database;
    }

    /// <summary>
    /// Gets the average price of the product.
    /// </summary>
    public void ProcessElectronicProducts()
    {
        // Gets all the products.
        List<Product> products = this._database.GetAllProduct();

        // Filter the electronics product with price more than 500.
        IEnumerable<(string ProductName, decimal Price)> filteredElectronics =
            products
                .Where(product => product.Category == ProductCategory.Electronics && product.Price > 500)
                .Select(product => (product.ProductName, product.Price));

        // Order the product in descending order.
        List<(string ProductName, decimal Price)> sortedElectronics = filteredElectronics.OrderByDescending(product => product.Price).ToList();

        ConsoleIO.PrintInfo($"Electronics product greater than 500:");
        ConsoleTable table = new ConsoleTable("Product Name", "Price");
        foreach (var product in sortedElectronics)
        {
            table.AddRow(product.ProductName, product.Price);
        }

        table.Options.EnableCount = false;
        table.Write();

        // Find and print average price of the product.
        decimal averagePrice = filteredElectronics.Average(product => product.Price);
        ConsoleIO.PrintInfo($"The average price of the product: {averagePrice}");
    }
}