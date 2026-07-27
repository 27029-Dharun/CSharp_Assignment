using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment3.Models;
using Assignment3.Repository;

namespace Assignment3.Services
{
    /// <summary>
    /// Inventory services
    /// </summary>
    internal class InventoryService
    {
        private InventoryRepository _inventoryRepository = new InventoryRepository();

        /// <summary>
        /// Creates a product object to inventory
        /// </summary>
        /// <param name="name">Name of the Product</param>
        /// <param name="price">Price</param>
        /// <param name="quantity">Quantity of the Product</param>
        public void CreateInventoryProduct(string name, decimal price, int quantity)
        {
            Guid id = Guid.NewGuid();
            Inventory product = new (id, name, price, quantity);
            this._inventoryRepository.AddProduct(product);
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
