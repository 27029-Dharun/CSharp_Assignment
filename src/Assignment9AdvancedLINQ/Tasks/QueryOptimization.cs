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

        table.Options.EnableCount = false;
        table.Write();
        stopwatch.Stop();
        ConsoleIO.PrintInfo($"Timer before optimization: {stopwatch.Elapsed.TotalMilliseconds}");

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

        table1.Write();
        stopwatch.Stop();
        ConsoleIO.PrintInfo($"After materialization: {stopwatch.Elapsed.TotalMilliseconds}");

        // reducing the column and use only the required column
        List<(string Name, decimal Price)> sortBooks = product
           .Where(product => product.Category == ProductCategory.Books)
           .Select(product => (product.ProductName, product.Price))
           .OrderBy(product => product.Price).ToList();

        ConsoleTable list = new ConsoleTable("Product Name", "Price");
        foreach (var book in sortBooks)
        {
            list.AddRow(book.Name, book.Price);
        }

        ConsoleIO.PrintInfo($"Selecting only the required parameter before ordering reduces the memory usage");
        list.Options.EnableCount = false;
        list.Write();
    }
}