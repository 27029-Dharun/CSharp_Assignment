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
            Guid id = new Guid();
            Inventory product = new (id, name, price, quantity);
            this._inventoryRepository.AddProduct(product);
        }

        public List<Inventory> GetInventoryProducts()
        {
            return _inventoryRepository.GetInventories();
        }
    }
}
