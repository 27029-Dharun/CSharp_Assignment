using Assignment3.Models;

namespace Assignment3.Services
{
    /// <summary>
    /// Service Interface
    /// </summary>
    internal interface IService
    {
        /// <summary>
        /// Creates a Inventory
        /// </summary>
        /// <param name="name">Name of the Product</param>
        /// <param name="price">Price of the product</param>
        /// <param name="quantity">Quantity of the Product</param>
        void CreateInventoryProduct(string name, decimal price, int quantity);

        /// <summary>
        /// Gets the Inventory Product
        /// </summary>
        /// <returns>Returns the Product</returns>
        List<Product> GetInventoryProducts();

        /// <summary>
        /// Deletes the Product By ID
        /// </summary>
        /// <param name="id">Id of the product to be Deleted</param>
        /// <returns>returns the string output</returns>
        string DeleteProductById(int id);

        /// <summary>
        /// Edit the Product By Id
        /// </summary>
        /// <param name="id">Id of the Product to be deleted</param>
        /// <param name="name">Name of the Product</param>
        /// <param name="price">Price of the product</param>
        /// <param name="quantity">Quantity of the Product</param>
        void EditProductById(int id, string name, decimal price, int quantity);
    }
}
