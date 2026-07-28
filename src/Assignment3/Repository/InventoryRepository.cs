using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment3.Models;

namespace Assignment3.Repository
{
    /// <summary>
    /// Inventory Repository
    /// </summary>
    internal class InventoryRepository
    {
        private List<Inventory> _inventories = new List<Inventory>();

        /// <summary>
        /// Adds the product to the list
        /// </summary>
        /// <param name="product">Product Object</param>
        /// <returns>String output to denote the error</returns>
        public string AddProduct(Inventory product)
        {
            if (product == null)
            {
                throw new ArgumentNullException();
            }

            this._inventories.Add(product);
            return "Product Added Successfully";
        }

        /// <summary>
        /// Gets the inventory object by Id
        /// </summary>
        /// <param name="id">Id of the Product</param>
        /// <returns>Inventory object</returns>
        public Inventory GetProductById(Guid id)
        {
            foreach (Inventory item in this._inventories)
            {
                if (item.ProductId == id)
                {
                    return item;
                }
            }

            throw new NotImplementedException();
        }

        /// <summary>
        /// Remove the product from the list
        /// </summary>
        /// <param name="product">Product object to be Deleted</param>
        public void RemoveProduct(Inventory product)
        {
            this._inventories.Remove(product);
        }

        /// <summary>
        /// Gets the Inventory objects and returns it
        /// </summary>
        /// <returns>List of inventory objects</returns>
        public List<Inventory> GetInventories()
        {
            return this._inventories;
        }
    }
}
