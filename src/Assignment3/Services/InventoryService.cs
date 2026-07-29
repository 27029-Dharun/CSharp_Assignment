using InventoryManager.Models;
using InventoryManager.Repository;
using InventoryManager.Validation;

namespace InventoryManager.Services
{
    /// <summary>
    /// Inventory services
    /// </summary>
    internal class InventoryService : IService
    {
        private InventoryRepository _inventoryRepository = new InventoryRepository();
        private InventoryValidator _validator;
        private int _id = 1;

        /// <summary>
        /// Initializes a new instance of the <see cref="InventoryService"/> class.
        /// </summary>
        /// <param name="validator">Validator object</param>
        public InventoryService(InventoryValidator validator)
        {
            this._validator = validator;
        }

        /// <summary>
        /// Creates a product object to inventory
        /// </summary>
        /// <param name="name">Name of the Product</param>
        /// <param name="price">Price</param>
        /// <param name="quantity">Quantity of the Product</param>
        public void CreateInventoryProduct(string name, decimal price, int quantity)
        {
            this._validator.IsValidateName(name);

            if (!this._validator.IsValidatePrice(price))
            {
                throw new ArgumentException("Invalid Price: Price can't be Negative");
            }

            if (!this._validator.IsValidateQuantity(quantity))
            {
                throw new ArgumentException("Invalid Quantity: Quantity can't be Negative");
            }

            Product product = new Product(this._id++, name, price, quantity);
            this._inventoryRepository.AddProduct(product);
        }

        /// <summary>
        /// returns Inventory Products
        /// </summary>
        /// <returns>Lists of all the inventory Objects</returns>
        public List<Product> GetInventoryProducts()
        {
            return this._inventoryRepository.GetInventory().ToList();
        }

        /// <summary>
        /// Delete the product
        /// </summary>
        /// <param name="id">Id of the Product</param>
        /// <returns>String output</returns>
        public string DeleteProductById(int id)
        {
            Product product = this._inventoryRepository.GetProductById(id);
            this._inventoryRepository.RemoveProduct(product);
            return "Product Deleted Successfully";
        }

        /// <summary>
        /// Edit Product By Id
        /// </summary>
        /// <param name="id">Product Id to be edited</param>
        /// <param name="name">Name of the product to update</param>
        /// <param name="price">Price of the product to update</param>
        /// <param name="quantity">Quantity of the Product</param>
        public void EditProductById(int id, string name, decimal price, int quantity)
        {
            Product product = this._inventoryRepository.GetProductById(id);

            // If all the fields are Empty throws an Exception
            if (name == string.Empty && price == -1 && quantity == -1)
            {
                throw new Exception("Noting to Edit");
            }

            // If name is Empty the Name is Not Edited
            if (name != string.Empty)
            {
                this._validator.IsValidateName(name);
                product.Name = name;
            }

            // If the Price is -1 the Price is not Edited
            if (price != -1)
            {
                if (!this._validator.IsValidatePrice(price))
                {
                    throw new ArgumentException("Invalid Price: Price can't be Negative");
                }

                product.Price = price;
            }

            // If the quanity is -1 the Quantity is not Edited
            if (quantity != -1)
            {
                if (!this._validator.IsValidateQuantity(quantity))
                {
                    throw new ArgumentException("Invalid Quantity: Quanity can't be Negative");
                }

                product.Quantity = quantity;
            }
        }

        /// <summary>
        /// Sort the Products in the Inventory
        /// </summary>
        /// <param name="option">Option to search</param>
        /// <returns>Sorted list of products in Inventory</returns>
        public List<Product> SortProducts(int option)
        {
            switch (option)
            {
                case 1:
                    return this._inventoryRepository.GetInventory().OrderBy(x => x.Id).ToList();

                case 2:
                    return this._inventoryRepository.GetInventory().OrderBy(x => x.Name).ToList();

                case 3:
                    return this._inventoryRepository.GetInventory().OrderBy(x => x.Price).ToList();

                case 4:
                    return this._inventoryRepository.GetInventory().OrderBy(x => x.Quantity).ToList();

                default:
                    throw new InvalidOperationException();
            }
        }

        /// <summary>
        /// Search Product By Name
        /// </summary>
        /// <param name="search_query">Name or Id to search Product</param>
        /// <returns>List of product matched with the String</returns>
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
        /// Checks the Id is valid
        /// </summary>
        /// <param name="id">Product Id entered by User</param>
        public void CheckProductId(int id)
        {
            this._inventoryRepository.GetProductById(id);
        }
    }
}
