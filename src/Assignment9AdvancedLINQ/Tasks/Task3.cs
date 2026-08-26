using Assignment9AdvancedLINQ.Models;
using Assignment9AdvancedLINQ.Models.Enums;
using Assignment9AdvancedLINQ.Repository;
using Assignment9AdvancedLINQ.Views;

namespace Assignment9AdvancedLINQ.Tasks;

/// <summary>
/// Contains the task1
/// </summary>
public class Task3
{
    private readonly Database _database;
    private readonly ConsoleView _view;

    /// <summary>
    /// Initializes a new instance of the <see cref="Task3"/> class.
    /// </summary>
    /// <param name="database">Instance of the database</param>
    /// <param name="view">Instance of the view</param>
    public Task3(Database database, ConsoleView view)
    {
        this._database = database;
        this._view = view;
    }

    /// <summary>
    /// Gets the average price of the product
    /// </summary>
    public void GetAveragePrice()
    {
        List<Product> product = this._database.GetAllProduct();
        var filteredProduct = product
            .Where(product => product.Category == ProductCategory.Electronics && product.Price > 500)
            .Select(product => new { product.ProductName, product.Price });

        var orderedByPrice = filteredProduct.OrderByDescending(product => product.Price).ToList();

        decimal averagePrice = orderedByPrice.Average(product => product.Price);

        this._view.PrintInfo($"The average price of the product: {averagePrice}");
    }
}
