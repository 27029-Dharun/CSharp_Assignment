using Assignment9AdvancedLINQ.Models;
using Assignment9AdvancedLINQ.Models.DTO;
using Assignment9AdvancedLINQ.Models.Enums;
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

    /// <summary>
    /// Initializes a new instance of the <see cref="ComplexLinqQuery"/> class.
    /// </summary>
    /// <param name="database">Instance of the database</param>
    public ComplexLinqQuery(Database database)
    {
        this._database = database;
    }

    /// <summary>
    /// Executes the linq queries
    /// </summary>
    public void ComplexLinqQueries()
    {
        ConsoleIO.PrintInfo("Expensive product in each category");
        this.GroupByCategory();
        ConsoleIO.PrintInfo("Supplier name of each product");
        this.JoinProductAndSuppliers();
    }

    /// <summary>
    /// Gets the average price of the product
    /// </summary>
    public void GroupByCategory()
    {
        List<Product> product = this._database.GetAllProduct();

        List<(ProductCategory Category, string ExpensiveProduct, decimal ExpensiveProductPrice, int Count)> groupByCategory = product
            .GroupBy(x => x.Category)
            .Select(group =>
            (
                group.Key,
                group.OrderByDescending(product => product.Price).First().ProductName,
                group.Max(product => product.Price),
                group.Count())).ToList();

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

        List<ProductSupplierName> joined = products.Join(
            suppliers,
            product => product.Id,
            supplier => supplier.ProductId,
            (product, supplier) => new ProductSupplierName
            {
                ProductId = product.Id,
                ProductName = product.ProductName,
                ProductPrice = product.Price,
                ProductCategory = product.Category,
                SupplierName = supplier.SupplierName,
            }).ToList();

        ConsoleTable table = new ConsoleTable("Product Id", "Product Name", "Supplier Name", "Price", "Category");
        foreach (var product in joined)
        {
            table.AddRow(product.ProductId, product.ProductName, product.SupplierName, product.ProductPrice, product.ProductCategory);
        }

        table.Options.EnableCount = false;
        table.Write();
    }
}