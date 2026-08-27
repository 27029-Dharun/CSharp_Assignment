using Assignment9AdvancedLINQ.Models;
using Assignment9AdvancedLINQ.Repository;
using Assignment9AdvancedLINQ.Views;
using ConsoleTables;

namespace Assignment9AdvancedLINQ.Tasks;

/// <summary>
/// Contains task2
/// </summary>
public class ComplexLinqQuery
{
    private readonly Database _database;
    private readonly ConsoleView _view;

    /// <summary>
    /// Initializes a new instance of the <see cref="ComplexLinqQuery"/> class.
    /// </summary>
    /// <param name="database">Instance of the database</param>
    /// <param name="view">Instance of the view</param>
    public ComplexLinqQuery(Database database, ConsoleView view)
    {
        this._database = database;
        this._view = view;
    }

    /// <summary>
    /// Executes the linq queries
    /// </summary>
    public void ComplexLinqQueries()
    {
        this.GroupByCategory();
        this.JoinProductAndSuppliers();
    }

    /// <summary>
    /// Gets the average price of the product
    /// </summary>
    public void GroupByCategory()
    {
        List<Product> product = this._database.GetAllProduct();

        var groupByCategory = product.GroupBy(x => x.Category)
            .Select(group => new
            {
                Category = group.Key,
                ExpensiveProduct = group.OrderByDescending(product => product.Price).First().ProductName,
                ExpensiveProductPrice = group.Max(product => product.Price),
                Count = group.Count(),
            });

        ConsoleTable table = new ConsoleTable("Category", "Expensive Product", "Expensive Product Price", "Count of Product");
        foreach (var category in groupByCategory)
        {
            table.AddRow(category.Category, category.ExpensiveProduct, category.ExpensiveProductPrice, category.Count);
        }

        table.Options.EnableCount = false;
        table.Write();
    }

    /// <summary>
    /// Performs inner join operation on product and suppliers.
    /// </summary>
    public void JoinProductAndSuppliers()
    {
        List<Product> products = this._database.GetAllProduct();
        List<Supplier> suppliers = this._database.GetAllSuppliers();

        var joined = products.Join(
            suppliers,
            product => product.Id,
            supplier => supplier.ProductId,
            (product, supplier) => new
            {
                ProductId = product.Id,
                ProductName = product.ProductName,
                ProductPrice = product.Price,
                ProductCategory = product.Category,
                SupplierName = supplier.SupplierName,
            });

        ConsoleTable table = new ConsoleTable("Product Id", "Product Name", "Supplier Name", "Price", "Category");
        foreach (var product in joined)
        {
            table.AddRow(product.ProductId, product.ProductName, product.SupplierName, product.ProductPrice, product.ProductCategory);
        }

        table.Options.EnableCount = false;
        table.Write();
    }
}