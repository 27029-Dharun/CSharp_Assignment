using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment3.Models;
using Assignment3.Repository;
using Assignment3.Validation;

namespace Assignment3.Services
{
    /// <summary>
    /// Inventory services
    /// </summary>
    internal class InventoryService
    {
        private InventoryRepository _inventoryRepository = new InventoryRepository();
        private InventoryValidator _validator;

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
        public string CreateInventoryProduct(string name, decimal price, int quantity)
        {
            if (this._validator.ValidateName(name))
            {
                return "Invalid Name";
            }

            if (this._validator.ValidatePrice(price))
            {
                return "Invalid Price: Price can't be Negative";
            }

            Guid id = Guid.NewGuid();
            Inventory product = new (id, name, price, quantity);
            return this._inventoryRepository.AddProduct(product);
        }

        /// <summary>
        /// returns Inventory Products
        /// </summary>
        /// <returns>Lists of all the inventory Objects</returns>
        public List<Inventory> GetInventoryProducts()
        {
            return this._inventoryRepository.GetInventories();
        }

        /// <summary>
        /// Delete the product
        /// </summary>
        /// <param name="product">Product to be deleted</param>
        internal void DeleteProductById(Inventory product)
        {
            this._inventoryRepository.RemoveProduct(product);
        }
    }
}
