using System.Diagnostics;
using Assignment9AdvancedLINQ.Models;
using Assignment9AdvancedLINQ.Models.Enums;
using Assignment9AdvancedLINQ.Repository;
using Assignment9AdvancedLINQ.Views;
using ConsoleTables;

namespace Assignment9AdvancedLINQ.Tasks;

/// <summary>
/// Contains the task1.
/// </summary>
public class QueryOptimization
{
    private readonly Database _database;

    /// <summary>
    /// Initializes a new instance of the <see cref="QueryOptimization"/> class.
    /// </summary>
    /// <param name="database">Instance of the database.</param>
    public QueryOptimization(Database database)
    {
        this._database = database;
    }

    /// <summary>
    /// Gets the average price of the product.
    /// </summary>
    public void GetBooksCategory()
    {
        List<Product> products = this._database.GetAllProduct();

        Stopwatch stopwatch = Stopwatch.StartNew();

        IEnumerable<Product> booksSortedByPrice = products
            .Where(product => product.Category == ProductCategory.Books)
            .OrderBy(product => product.Price);

        ConsoleIO.PrintInfo("Books sorted in ascending order");

        DisplayProductNameAndPrice(booksSortedByPrice);
        stopwatch.Stop();
        ConsoleIO.PrintInfo($"Timer before optimization: {stopwatch.Elapsed.TotalMilliseconds}");

        // Optimized version
        stopwatch.Restart();

        ConsoleTable table = new ConsoleTable("Product Name", "Price");

        // Streaming foreach when you want to process query results immediately, avoid unnecessary memory usage, and ensure the query runs only once
        // Project only the required variables
        // Ensure filtering is done before sorting
        foreach (var product in products
            .Where(product => product.Category == ProductCategory.Books)
            .OrderBy(product => product.Price)
            .Select(product => new { product.ProductName, product.Price }))
        {
            table.AddRow(product.ProductName, product.Price);
        }

        table.Options.EnableCount = false;
        table.Write();

        stopwatch.Stop();
        ConsoleIO.PrintInfo($"With streaming foreach method: {stopwatch.Elapsed.TotalMilliseconds}");
    }

    private static void DisplayProductNameAndPrice(IEnumerable<Product> booksSortedByPrice)
    {
        ConsoleTable table = new ConsoleTable("Product Name", "Price");
        foreach (var book in booksSortedByPrice)
        {
            table.AddRow(book.ProductName, book.Price);
        }

        table.Options.EnableCount = false;
        table.Write();
    }
}