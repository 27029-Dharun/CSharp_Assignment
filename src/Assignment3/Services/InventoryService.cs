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
        /// <returns>Returns string product</returns>
        public string CreateInventoryProduct(string name, decimal price, int quantity)
        {
            if (!this._validator.IsValidateName(name))
            {
                return "Invalid Name";
            }

            if (!this._validator.IsValidatePrice(price))
            {
                return "Invalid Price: Price can't be Negative";
            }

            Product product = new Product(this._id++, name, price, quantity);
            return this._inventoryRepository.AddProduct(product);
        }

        /// <summary>
        /// returns Inventory Products
        /// </summary>
        /// <returns>Lists of all the inventory Objects</returns>
        public List<Product> GetInventoryProducts()
        {
            return this._inventoryRepository.GetInventories();
        }

        /// <summary>
        /// Delete the product
        /// </summary>
        /// <param name="id">Id of the Product</param>
        /// <returns>String output</returns>
        public string DeleteProductById(int id)
        {
            Product? product = this._inventoryRepository.GetProductById(id);
            if (product == null)
            {
                return "Product Id is Invalid";
            }

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
        /// <returns>String output</returns>
        public string EditProductById(int id, string name, decimal price, int quantity)
        {
            Product? product = this._inventoryRepository.GetProductById(id);
            if (product == null)
            {
                return "Product Id is Invalid";
            }

            // If name is Empty the Name is Not Edited
            if (name != string.Empty)
            {
                if (!this._validator.IsValidateName(name))
                {
                    return "Invalid Name";
                }

                product.Name = name;
            }

            // If the Price is -1 the Price is not Edited
            if (price != -1)
            {
                if (!this._validator.IsValidatePrice(price))
                {
                    return "Invalid Price: Price can't be Negative";
                }

                product.Price = price;
            }

            // If the quanity is -1 the Quantity is not Edited
            if (quantity != -1)
            {
                if (!this._validator.ValidateQuantity(quantity))
                {
                    return "Invalid Quanity: Quantity can't be negative";
                }

                product.Quantity = quantity;
            }

            return "Product Edited Successfully";
        }
    }
}
