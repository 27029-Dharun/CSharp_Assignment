using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment3.Models;

namespace Assignment3.Repository
{
    /// <summary>
    /// Interface Repository
    /// </summary>
    internal interface IRepository
    {
        /// <summary>
        /// returns the inventory List
        /// </summary>
        /// <returns>List of all product in inventory</returns>
        public List<Product> GetInventories();

        /// <summary>
        /// Remove product from inventory
        /// </summary>
        /// <param name="product">Product to be removed</param>
        public void RemoveProduct(Product product);

        /// <summary>
        /// gets the Product by Id
        /// </summary>
        /// <param name="id">Id of the Product</param>
        /// <returns>Inventory object</returns>
        public Product GetProductById(int id);

        /// <summary>
        /// adds a product to Inventory
        /// </summary>
        /// <param name="product">Product to be added</param>
        /// <returns>returns a string</returns>
        public string AddProduct(Product product);
    }
}
