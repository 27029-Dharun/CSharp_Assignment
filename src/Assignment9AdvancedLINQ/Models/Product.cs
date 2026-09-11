using Assignment9AdvancedLINQ.Models.Enums;

namespace Assignment9AdvancedLINQ.Models;

/// <summary>
/// Represent a product entity
/// </summary>
public class Product
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Product"/> class.
    /// </summary>
    /// <param name="id">Unique identifier for the product</param>
    /// <param name="name">Name of the product</param>
    /// <param name="price">Price of the product</param>
    /// <param name="category">Category of the product</param>
    public Product(string id, string name, decimal price, ProductCategory category)
    {
        this.Id = id;
        this.ProductName = name;
        this.Price = price;
        this.Category = category;
    }

    /// <summary>
    /// Gets or sets Unique identifier for the product
    /// </summary>
    /// <value>The unique identifier for the product</value>
    public string Id { get; set; }

    /// <summary>
    /// Gets or sets the product id
    /// </summary>
    /// <value>The name of the product</value>
    public string ProductName { get; set; }

    /// <summary>
    /// Gets or sets the price of the product
    /// </summary>
    /// <value>The price of the product</value>
    public decimal Price { get; set; }

    /// <summary>
    /// Gets or sets the category of the product
    /// </summary>
    /// <value>The category of the product</value>
    public ProductCategory Category { get; set; }
}
