using Assignment3.Models;

namespace Assignment3.Repository;

/// <summary>
/// Defines centralized data repository for storing, retrieving product in the inventory.
/// Contract for the repository.
/// </summary>
public interface IInventoryRepository
{
    /// <summary>
    /// Gets the inventory objects and returns it.
    /// </summary>
    /// <returns>List of products in the inventory.</returns>
    public IReadOnlyList<Product> GetInventory();

    /// <summary>
    /// Remove a product from the inventory.
    /// </summary>
    /// <param name="product">Product to delete.</param>
    public void RemoveProduct(Product product);

    /// <summary>
    /// Gets the product by id from the inventory.
    /// </summary>
    /// <param name="id">Unique identifier of the Product.</param>
    /// <returns>Product with matching ID.</returns>
    public Product GetById(int id);

    /// <summary>
    /// Adds a product to the inventory.
    /// </summary>
    /// <param name="product">Adds a new product to the inventory.</param>
    public void AddProduct(Product product);

    /// <summary>
    /// Gets the product names of all the product in the inventory.
    /// </summary>
    /// <returns>List of all the product names in the inventory.</returns>
    public List<string> GetProductName();
}
