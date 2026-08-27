using Assignment9AdvancedLINQ.Models;
using Assignment9AdvancedLINQ.Models.Enums;

namespace Assignment9AdvancedLINQ.Repository;

/// <summary>
/// Database containing all the data to perform linq operations
/// </summary>
public class Database
{
    private readonly List<Product> _products = new List<Product>();

    private readonly List<Supplier> _suppliers = new List<Supplier>();

    /// <summary>
    /// Initialize all the data
    /// </summary>
    public void InitializeData()
    {
        this._products.Add(new Product("P001", "Smartphone", 20000, ProductCategory.Electronics));
        this._products.Add(new Product("P002", "T Shirt", 800, ProductCategory.Clothing));
        this._products.Add(new Product("P003", "Microwave Oven", 8500, ProductCategory.HomeAppliances));
        this._products.Add(new Product("P004", "Atomic Habits", 500, ProductCategory.Books));
        this._products.Add(new Product("P005", "Rice", 700, ProductCategory.Groceries));
        this._products.Add(new Product("P006", "Laptop", 70000, ProductCategory.Electronics));
        this._products.Add(new Product("P007", "Jeans", 1500, ProductCategory.Clothing));
        this._products.Add(new Product("P008", "Refrigerator", 36000, ProductCategory.HomeAppliances));
        this._products.Add(new Product("P009", "Ikigai", 900, ProductCategory.Books));
        this._products.Add(new Product("P010", "Dal", 160, ProductCategory.Groceries));

        this._suppliers.Add(new Supplier("S001", "Dharun", "P001"));
        this._suppliers.Add(new Supplier("S002", "Dharanish", "P002"));
        this._suppliers.Add(new Supplier("S003", "Vasanth", "P003"));
        this._suppliers.Add(new Supplier("S004", "Sanjeevi", "P004"));
        this._suppliers.Add(new Supplier("S005", "Prabha", "P005"));
        this._suppliers.Add(new Supplier("S006", "Diwas", "P006"));
        this._suppliers.Add(new Supplier("S007", "Dave", "P007"));
        this._suppliers.Add(new Supplier("S008", "Hemanth", "P008"));
        this._suppliers.Add(new Supplier("S009", "Dharani", "P009"));
        this._suppliers.Add(new Supplier("S010", "Dharwin", "P010"));
    }

    /// <summary>
    /// Gets all the product available in the database
    /// </summary>
    /// <returns>A list of products available.</returns>
    public List<Product> GetAllProduct()
    {
        return this._products;
    }

    /// <summary>
    /// Gets all the supplier available in the database
    /// </summary>
    /// <returns>A list of suppliers available.</returns>
    public List<Supplier> GetAllSuppliers()
    {
        return this._suppliers;
    }
}
