using Assignment3.Models;
using Assignment3.Repository;
using Assignment3.Validators;

namespace Assignment3.Services;

/// <summary>
/// Contains business logics for adding product, viewing, updating, deleting product from the inventory.
/// </summary>
public class InventoryService : IInventoryService
{
    private readonly IInventoryRepository _inventoryRepository;

    /// <summary>
    /// Initializes a new instance of the <see cref="InventoryService"/> class.
    /// </summary>
    /// <param name="repository">The repository instance injected through dependency injection.</param>
    public InventoryService(IInventoryRepository repository)
    {
        this._inventoryRepository = repository;
    }

    /// <inheritdoc />
    public Product AddProduct(string name, decimal price, int quantity)
    {
        List<string> productNames = this._inventoryRepository.GetProductName();

        if (!InventoryValidator.IsProductNameUnique(name, productNames))
        {
            throw new ArgumentException("Invalid Name: Name should be unique");
        }

        Product product = new Product(name, price, quantity);
        this._inventoryRepository.AddProduct(product);
        return product;
    }

    /// <inheritdoc />
    public List<Product> GetProducts()
    {
        return this._inventoryRepository.GetInventory().ToList();
    }

    /// <inheritdoc />
    public Product DeleteProductById(int id)
    {
        Product product = this._inventoryRepository.GetProductById(id);

        this._inventoryRepository.RemoveProduct(product);
        return product;
    }

    /// <inheritdoc />
    public Product EditProductById(int id, string name, decimal? price, int? quantity)
    {
        Product product = this._inventoryRepository.GetProductById(id);

        // If all the fields are Empty throws an Exception
        if (string.IsNullOrWhiteSpace(name) && price is null && quantity is null)
        {
            throw new InvalidOperationException("\nNothing to Edit - invalid call given current state");
        }

        // If name is not empty the name is updated
        if (!string.IsNullOrWhiteSpace(name))
        {
            List<string> productNames = this._inventoryRepository.GetProductName();
            productNames.Remove(product.Name);
            if (!InventoryValidator.IsProductNameUnique(name, productNames))
            {
                throw new ArgumentException("Duplicate name — an invalid argument.");
            }

            product.Name = name;
        }

        // If the price is not null the price is edited
        if (price != null)
        {
            product.Price = (decimal)price;
        }

        // If the quantity is not null the quantity is edited
        if (quantity != null)
        {
            product.Quantity = (int)quantity;
        }

        return product;
    }

    /// <inheritdoc />
    public List<Product> SortProducts(SortOption option)
    {
        List<Product> products = this._inventoryRepository.GetInventory().ToList();

        return option switch
        {
            SortOption.Name => products.OrderBy(x => x.Name).ToList(),
            SortOption.Price => products.OrderBy(x => x.Price).ToList(),
            SortOption.Quantity => products.OrderBy(x => x.Quantity).ToList(),
            _ => throw new ArgumentOutOfRangeException(nameof(option), option, "Unsupported sort option"),
        };
    }

    /// <inheritdoc />
    public List<Product> SearchProductByNameOrId(string searchQuery)
    {
        List<Product> products = this._inventoryRepository.GetInventory().ToList();

        return products
        .Where(product =>
            (product.Name != null && product.Name.Contains(searchQuery, StringComparison.OrdinalIgnoreCase)) ||
            product.Id.ToString().Contains(searchQuery))
        .ToList();
    }

    /// <inheritdoc />
    public void ValidateProductId(int id)
    {
        // Throws exception if the id is not present
        this._inventoryRepository.GetProductById(id);
    }

    /// <inheritdoc />
    public bool HasProducts()
    {
        return this._inventoryRepository.GetInventory().Any();
    }
}
