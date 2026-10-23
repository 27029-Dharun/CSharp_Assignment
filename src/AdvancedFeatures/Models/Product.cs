namespace AdvancedFeatures.Models;

/// <summary>
/// Represents a product.
/// </summary>
internal class Product
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Product"/> class.
    /// </summary>
    /// <param name="name">The name of the product.</param>
    /// <param name="category">The category of the product.</param>
    /// <param name="price">The price of the product.</param>
    internal Product(string name, string category, decimal price)
    {
        this.Name = name;
        this.Category = category;
        this.Price = price;
    }

    /// <summary>
    /// Gets or sets the name of the product.
    /// </summary>
    /// <value>The name of the product.</value>
    internal string Name { get; set; }

    /// <summary>
    /// Gets or sets the category of the product.
    /// </summary>
    /// <value>The category of the product.</value>
    internal string Category { get; set; }

    /// <summary>
    /// Gets or sets the price of the product.
    /// </summary>
    /// <value>The price of the product.</value>
    internal decimal Price { get; set; }
}
