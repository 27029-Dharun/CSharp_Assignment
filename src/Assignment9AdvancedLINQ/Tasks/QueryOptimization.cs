using System.Diagnostics;
using Assignment9AdvancedLINQ.Models;
using Assignment9AdvancedLINQ.Models.Enums;
using Assignment9AdvancedLINQ.Repository;
using Assignment9AdvancedLINQ.Views;
using ConsoleTables;

namespace Assignment9AdvancedLINQ.Tasks;

/// <summary>
/// Contains the task1
/// </summary>
public class QueryOptimization
{
    private readonly Database _database;

    /// <summary>
    /// Initializes a new instance of the <see cref="QueryOptimization"/> class.
    /// </summary>
    /// <param name="database">Instance of the database</param>
    public QueryOptimization(Database database)
    {
        this._database = database;
    }

    /// <summary>
    /// Gets the average price of the product
    /// </summary>
    public void GetBooksCategory()
    {
        List<Product> product = this._database.GetAllProduct();

        Stopwatch stopwatch = Stopwatch.StartNew();
        IEnumerable<Product> booksSortedByPrice = product
            .Where(product => product.Category == ProductCategory.Books)
            .OrderBy(product => product.Price);

        ConsoleIO.PrintInfo("Books sorted in ascending order");
        ConsoleTable table = new ConsoleTable("Product Name", "Price");
        foreach (var book in booksSortedByPrice)
        {
            table.AddRow(book.ProductName, book.Price);
        }

        stopwatch.Stop();
        ConsoleIO.PrintInfo($"Timer before optimization: {stopwatch.Elapsed.TotalMilliseconds}");
        table.Options.EnableCount = false;
        table.Write();

        // Optimized version
        stopwatch.Restart();
        List<Product> optimizedBooksSort = product
            .Where(product => product.Category == ProductCategory.Books)
            .OrderBy(product => product.Price).ToList();

        ConsoleTable table1 = new ConsoleTable("Product Name", "Price");
        foreach (var book in booksSortedByPrice)
        {
            table1.AddRow(book.ProductName, book.Price);
        }

        stopwatch.Stop();
        ConsoleIO.PrintInfo($"{stopwatch.Elapsed.TotalMilliseconds}");
        table1.Options.EnableCount = false;
        table1.Write();
    }
}
