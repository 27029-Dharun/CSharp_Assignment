using Assignment9AdvancedLINQ.Models;
using Assignment9AdvancedLINQ.Models.Enums;

namespace Assignment9AdvancedLINQ.Repository;

/// <summary>
/// Database containing all the data to perform linq operations
/// </summary>
public class Database
{
    private List<Product> _products;

    private List<Supplier> _suppliers;

    private List<Order> _orders;

    /// <summary>
    /// Initializes a new instance of the <see cref="Database"/> class.
    /// </summary>
    public Database()
    {
        this._products = new List<Product>();
        this._suppliers = new List<Supplier>();
        this._orders = new List<Order>();
    }

    /// <summary>
    /// Initialize all the data
    /// </summary>
    public void InitializeData()
    {
        this._products.Add(new Product("P101", "Monitor", 12000, ProductCategory.Electronics));
        this._products.Add(new Product("P102", "Keyboard", 900, ProductCategory.Electronics));
    }

    /// <summary>
    /// Gets all the product available in the database
    /// </summary>
    /// <returns>A list of products available.</returns>
    public List<Product> GetAllProduct()
    {
        return this._products;
    }
}
