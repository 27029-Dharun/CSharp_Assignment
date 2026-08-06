using Assignment3.Models;
using Assignment3.Repository;
using Assignment3.Validation;

namespace Assignment3.Services
{
    /// <summary>
    /// Inventory services
    /// </summary>
    internal class InventoryService : IService
    {
        private readonly InventoryRepository _inventoryRepository;
        private readonly InventoryValidator _validator;
        private int _id = 1;

        /// <summary>
        /// Initializes a new instance of the <see cref="InventoryService"/> class.
        /// </summary>
        /// <param name="validator">Validator object injected from the origin</param>
        /// <param name="repository">repository object injected from origin</param>
        public InventoryService(InventoryValidator validator, InventoryRepository repository)
        {
            this._validator = validator;
            this._inventoryRepository = repository;
        }

        /// <summary>
        /// Creates a product object to inventory
        /// </summary>
        /// <param name="name">Name of the product</param>
        /// <param name="price">Price of the product</param>
        /// <param name="quantity">Quantity of the product</param>
        /// <returns>Product object created is returned</returns>
        public Product CreateInventoryProduct(string name, decimal price, int quantity)
        {
            if (!this._validator.IsValidateName(name))
            {
                throw new ArgumentException("Invalid Name: Name should contain more than 3 character");
            }

            if (!this.IsUniqueName(name))
            {
                throw new ArgumentException("Invalid Name: Name should be unique");
            }

            if (!this._validator.IsValidatePrice(price))
            {
                throw new ArgumentException("Invalid Price: Price should be positive");
            }

            if (!this._validator.IsValidateQuantity(quantity))
            {
                throw new ArgumentException("Invalid Quantity: Quantity can't be Negative");
            }

            Product product = new Product(this._id++, name, price, quantity);
            this._inventoryRepository.AddProduct(product);
            return product;
        }

        /// <summary>
        /// Returns inventory products
        /// </summary>
        /// <returns>Lists of all the inventory Objects</returns>
        public List<Product> GetInventoryProducts()
        {
            return this._inventoryRepository.GetInventory().ToList();
        }

        /// <summary>
        /// Delete the product
        /// </summary>
        /// <param name="id">Id of the product</param>
        /// <returns>Product object</returns>
        public Product DeleteProductById(int id)
        {
            Product product = this._inventoryRepository.GetProductById(id);
            this._inventoryRepository.RemoveProduct(product);
            return product;
        }

        /// <summary>
        /// Edit product by id
        /// </summary>
        /// <param name="id">Product Id to be edited</param>
        /// <param name="name">Name of the product to update</param>
        /// <param name="price">Price of the product to update</param>
        /// <param name="quantity">Quantity of the Product to update</param>
        /// <returns>Updated Product object</returns>
        public Product EditProductById(int id, string name, decimal price, int quantity)
        {
            Product product = this._inventoryRepository.GetProductById(id);

            // If all the fields are Empty throws an Exception
            if (name == string.Empty && price == -1 && quantity == -1)
            {
                throw new Exception("Nothing to Edit");
            }

            // If name is not empty the name is updated
            if (name != string.Empty)
            {
                this._validator.IsValidateName(name);
                product.Name = name;
            }

            // If the price is not -1 the price is edited
            if (price != -1)
            {
                if (!this._validator.IsValidatePrice(price))
                {
                    throw new ArgumentException("Invalid Price: Price can't be Negative");
                }

                product.Price = price;
            }

            // If the quantity is not -1 the quantity is edited
            if (quantity != -1)
            {
                if (!this._validator.IsValidateQuantity(quantity))
                {
                    throw new ArgumentException("Invalid Quantity: Quanity can't be Negative");
                }

                product.Quantity = quantity;
            }

            return product;
        }

        /// <summary>
        /// Sort the products in the inventory
        /// </summary>
        /// <param name="option">Option to search</param>
        /// <returns>Sorted list of products in inventory</returns>
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

        /// <summary>
        /// Search product by name
        /// </summary>
        /// <param name="search_query">Name or id to search product</param>
        /// <returns>List of product matched with the string</returns>
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

        /// <summary>
        /// Checks the id is valid
        /// </summary>
        /// <param name="id">Product id entered by user</param>
        public void ValidateProductId(int id)
        {
            // Throws exception if the id is not present
            this._inventoryRepository.GetProductById(id);
        }

        /// <summary>
        /// Checks if inventory is empty
        /// </summary>
        /// <returns>True if empty</returns>
        internal bool IsInventoryEmpty()
        {
            return !this._inventoryRepository.GetInventory().Any();
        }

        private bool IsUniqueName(string name, string? exisitingName = null)
        {
            List<Product> products = this._inventoryRepository.GetInventory().ToList();
            foreach (Product product in products)
            {
                if (product.Name == name && exisitingName != null)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
