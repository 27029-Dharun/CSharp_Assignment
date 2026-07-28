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
    internal class InventoryRepository : IRepository
    {
        private List<Product> _inventories = new List<Product>();

        /// <summary>
        /// Adds the product to the list
        /// </summary>
        /// <param name="product">Product Object</param>
        /// <returns>String output to denote the error</returns>
        public string AddProduct(Product product)
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
        public Product? GetProductById(int id)
        {
            foreach (Product item in this._inventories)
            {
                if (item.Id == id)
                {
                    return item;
                }
            }

            return null;
        }

        /// <summary>
        /// Remove the product from the list
        /// </summary>
        /// <param name="product">Product object to be Deleted</param>
        public void RemoveProduct(Product product)
        {
            this._inventories.Remove(product);
        }

        /// <summary>
        /// Gets the Inventory objects and returns it
        /// </summary>
        /// <returns>List of inventory objects</returns>
        public List<Product> GetInventories()
        {
            return this._inventories;
        }
    }
}
