using Assignment3.Models;
using Assignment3.Repository;
using Assignment3.Validation;

namespace Assignment3.Services
{
    /// <summary>
    /// Contains business logics for adding product, viewing, updating, deleting product from the inventory.
    /// </summary>
    public class InventoryService : IService
    {
        private const int AssignExistingValue = -1;
        private readonly InventoryRepository _inventoryRepository;
        private int _id = 1;

        /// <summary>
        /// Initializes a new instance of the <see cref="InventoryService"/> class.
        /// </summary>
        /// <param name="repository">Instance of repository injected from origin</param>
        public InventoryService(InventoryRepository repository)
        {
            this._inventoryRepository = repository;
        }

        /// <inheritdoc />
        public Product CreateInventoryProduct(string name, decimal price, int quantity)
        {
            List<string> productNames = this._inventoryRepository.GetProductName();
            if (!InventoryServiceValidator.IsUniqueProductName(name, productNames))
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
        public Product EditProductById(int id, string name, decimal price, int quantity)
        {
            Product product = this._inventoryRepository.GetProductById(id);

            // If all the fields are Empty throws an Exception
            if (name == AssignExistingValue.ToString() && price == AssignExistingValue && quantity == AssignExistingValue)
            {
                throw new Exception("Nothing to Edit");
            }

            // If name is not -1 the name is updated
            if (name != AssignExistingValue.ToString())
            {
                List<string> productNames = this._inventoryRepository.GetProductName();
                if (!InventoryServiceValidator.IsUniqueProductName(name, productNames, product.Name))
                {
                    throw new Exception(" The name of the product should be unique. ");
                }

                product.Name = name;
            }

            // If the price is not -1 the price is edited
            if (price is not AssignExistingValue)
            {
                product.Price = price;
            }

            // If the quantity is not -1 the quantity is edited
            if (quantity is not AssignExistingValue)
            {
                product.Quantity = quantity;
            }

            return product;
        }

        /// <inheritdoc />
        public List<Product> SortProducts(int option)
        {
            switch (option)
            {
                case 1:
                    return this._inventoryRepository.GetInventory().OrderBy(x => x.Name).ToList();

                case 2:
                    return this._inventoryRepository.GetInventory().OrderBy(x => x.Price).ToList();

                case 3:
                    return this._inventoryRepository.GetInventory().OrderBy(x => x.Quantity).ToList();

                default:
                    throw new InvalidOperationException();
            }
        }

        /// <inheritdoc />
        public List<Product> SearchProductByNameOrId(string search_query)
        {
            List<Product> products = this._inventoryRepository.GetInventory().ToList();
            List<Product> filtered = new List<Product>();
            foreach (Product product in products)
            {
                if (product.Name != null && product.Name.ToLower().Contains(search_query.ToLower()))
                {
                    filtered.Add(product);
                }
                else if (product.Id.ToString().Contains(search_query))
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

        /// <summary>
        /// Checks if inventory is empty
        /// </summary>
        /// <returns>True if empty</returns>
        public bool IsInventoryEmpty()
        {
            return !this._inventoryRepository.GetInventory().Any();
        }
    }
}
