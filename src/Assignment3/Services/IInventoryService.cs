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
    /// Gets all the products in the inventory.
    /// </summary>
    /// <returns>Returns the products list.</returns>
    List<Product> GetProducts();

    /// <summary>
    /// Deletes the product in inventory by using ID.
    /// </summary>
    /// <param name="id"> ID of the product to be deleted. </param>
    /// <returns>The deleted product.</returns>
    Product DeleteProductById(int id);

    /// <summary>
    /// Edit the product by id.
    /// </summary>
    /// <param name="id">ID of the product to be edited.</param>
    /// <param name="name">Name of the product.</param>
    /// <param name="price">Price of the product.</param>
    /// <param name="quantity">Quantity of the product.</param>
    /// <returns>Product edited instance.</returns>
    Product EditProductById(int id, string name, decimal? price, int? quantity);

    /// <summary>
    /// Sort the product by name, price, quantity.
    /// </summary>
    /// <param name="option">Option to sort the products.</param>
    /// <returns>Sorted list of products in the inventory.</returns>
    IOrderedEnumerable<Product> SortProducts(SortOption option);

    /// <summary>
    /// Get the product in the inventory.
    /// </summary>
    /// <param name="id">ID of product to retrieve.</param>
    /// <returns>Product with the unique ID.</returns>
    Product GetProductById(int id);

    /// <summary>
    /// Search product by ID or name entered by the user.
    /// </summary>
    /// <param name="search_query">Name or ID entered by user.</param>
    /// <returns>List of filtered products.</returns>
    List<Product> SearchProductByNameOrId(string search_query);

    /// <summary>
    /// Checks if inventory is empty.
    /// </summary>
    /// <returns>True if the inventory have products; otherwise, false.</returns>
    public bool HasProducts();
}
