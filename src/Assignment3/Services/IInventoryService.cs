using Assignment3.Models;

namespace Assignment3.Services;

/// <summary>
/// Defines business logic operations for managing product in inventory.
/// </summary>
public interface IInventoryService
{
    /// <summary>
    /// Creates a new product with the specified details.
    /// </summary>
    /// <param name="name">Name of the product.</param>
    /// <param name="price">Price of the product.</param>
    /// <param name="quantity">Quantity of the product.</param>
    /// <returns>The newly created product.</returns>
    Product AddProduct(string name, decimal price, int quantity);

    /// <summary>
    /// Gets the all the product inventory.
    /// </summary>
    /// <returns>Returns the product.</returns>
    List<Product> GetProducts();

    /// <summary>
    /// Deletes the product in inventory by using a unique identifier.
    /// </summary>
    /// <param name="id"> Id of the product to be deleted. </param>
    /// <returns>The deleted product.</returns>
    Product DeleteProductById(int id);

    /// <summary>
    /// Edit the product by id.
    /// </summary>
    /// <param name="id">Id of the product to be deleted.</param>
    /// <param name="name">Name of the product.</param>
    /// <param name="price">Price of the product.</param>
    /// <param name="quantity">Quantity of the product.</param>
    /// <returns>Product edited instance.</returns>
    Product EditProductById(int id, string name, decimal? price, int? quantity);

    /// <summary>
    /// Sort the product by name, price, quantity.
    /// </summary>
    /// <param name="option">Option to sort the products.</param>
    /// <returns>Sorted list of inventory products.</returns>
    List<Product> SortProducts(SortOption option);

    /// <summary>
    /// Checks the product existence in the inventory.
    /// </summary>
    /// <param name="id">Id of product to check.</param>
    void ValidateProductId(int id);

    /// <summary>
    /// Search product by id or name entered by the user.
    /// </summary>
    /// <param name="search_query">Name or id entered by user.</param>
    /// <returns>List of filtered products.</returns>
    List<Product> SearchProductByNameOrId(string search_query);

    /// <summary>
    /// Checks if inventory is empty.
    /// </summary>
    /// <returns>True if the inventory have products; otherwise, false</returns>
    public bool HasProducts();
}
