using Assignment3.Models;

namespace Assignment3.Repository;

/// <summary>
/// Provides a centralized data repository for storing, retrieving product in the inventory.
/// </summary>
public class InventoryRepository : IInventoryRepository
{
    private readonly List<Product> _inventories = new List<Product>();
    private int _id = 1;

    /// <inheritdoc />
    public void AddProduct(Product product)
    {
        product.Id = this._id++;
        this._inventories.Add(product);
    }

    /// <inheritdoc />
    public Product GetProductById(int id)
    {
        return this._inventories.FirstOrDefault(product => product.Id == id)
        ?? throw new KeyNotFoundException($"Product with ID {id} was not found.");
    }

    /// <inheritdoc />
    public void RemoveProduct(Product product)
    {
        this._inventories.Remove(product);
    }

    /// <inheritdoc />
    public IReadOnlyList<Product> GetInventory()
    {
        return this._inventories.ToList();
    }

    /// <inheritdoc />
    public List<string> GetProductName()
    {
        return this._inventories.Select(product => product.Name).ToList();
    }

    /// <inheritdoc />
    bool IInventoryRepository.ValidateId(int id)
    {
        return this._inventories.Any(product => product.Id == id);
    }
}
