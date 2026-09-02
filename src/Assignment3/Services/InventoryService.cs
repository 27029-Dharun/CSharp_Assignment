using Assignment3.Models;
using Assignment3.Models.Enums;
using Assignment3.Repository;
using Assignment3.Validation;

namespace Assignment3.Services
{
    /// <summary>
    /// Contains business logics for adding product, viewing, updating, deleting product from the inventory.
    /// </summary>
    public class InventoryService : IInventoryService
    {
        private readonly IInventoryRepository _inventoryRepository;
        private int _id = 1;

        /// <summary>
        /// Initializes a new instance of the <see cref="InventoryService"/> class.
        /// </summary>
        /// <param name="repository">Instance of repository injected from origin</param>
        public InventoryService(IInventoryRepository repository)
        {
            this._inventoryRepository = repository;
        }

        /// <inheritdoc />
        public Product CreateInventoryProduct(string name, decimal price, int quantity)
        {
            List<string> productNames = this._inventoryRepository.GetProductName();
            if (!InventoryValidator.IsUniqueProductName(name, productNames))
            {
                throw new ArgumentException("Invalid Name: Name should be unique");
            }

            Product product = new Product(this._id++, name, price, quantity);
            this._inventoryRepository.AddProduct(product);
            return product;
        }

        /// <inheritdoc />
        public List<Product> GetInventoryProducts()
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

            // If name is not null the name is updated
            if (!string.IsNullOrWhiteSpace(name))
            {
                List<string> productNames = this._inventoryRepository.GetProductName();
                if (!InventoryValidator.IsUniqueProductName(name, productNames, product.Name))
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

            switch (option)
            {
                case SortOption.Name:
                    return products.OrderBy(x => x.Name).ToList();

                case SortOption.Price:
                    return products.OrderBy(x => x.Price).ToList();

                case SortOption.Quantity:
                    return products.OrderBy(x => x.Quantity).ToList();

                default:
                    throw new ArgumentOutOfRangeException(nameof(option), option, "Unsupported sort option");
            }
        }

        /// <inheritdoc />
        public List<Product> SearchProductByNameOrId(string searchQuery)
        {
            List<Product> products = this._inventoryRepository.GetInventory().ToList();
            List<Product> filtered = new List<Product>();
            foreach (Product product in products)
            {
                if (product.Name != null && product.Name.ToLower().Contains(searchQuery.ToLower()))
                {
                    filtered.Add(product);
                }
                else if (product.Id.ToString().Contains(searchQuery))
                {
                    filtered.Add(product);
                }
            }

            return filtered;
        }

        /// <inheritdoc />
        public void ValidateProductId(int id)
        {
            // Throws exception if the id is not present
            this._inventoryRepository.GetProductById(id);
        }

        /// <inheritdoc />
        public bool IsInventoryEmpty()
        {
            return !this._inventoryRepository.GetInventory().Any();
        }
    }
}
