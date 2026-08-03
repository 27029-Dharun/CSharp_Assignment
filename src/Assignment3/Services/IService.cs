using InventoryManager.Models;

namespace InventoryManager.Services
{
    /// <summary>
    /// Service interface
    /// </summary>
    internal interface IService
    {
        /// <summary>
        /// Creates a product
        /// </summary>
        /// <param name="name">Name of the product</param>
        /// <param name="price">Price of the product</param>
        /// <param name="quantity">Quantity of the product</param>
        /// <returns>Product created</returns>
        Product CreateInventoryProduct(string name, decimal price, int quantity);

        /// <summary>
        /// Gets the inventory product
        /// </summary>
        /// <returns>Returns the product</returns>
        List<Product> GetInventoryProducts();

        /// <summary>
        /// Deletes the product by id
        /// </summary>
        /// <param name="id">Id of the product to be deleted</param>
        /// <returns>product deleted</returns>
        Product DeleteProductById(int id);

        /// <summary>
        /// Edit the product by id
        /// </summary>
        /// <param name="id">Id of the product to be deleted</param>
        /// <param name="name">Name of the product</param>
        /// <param name="price">Price of the product</param>
        /// <param name="quantity">Quantity of the product</param>
        /// <returns>Product edited</returns>
        Product EditProductById(int id, string name, decimal price, int quantity);

        /// <summary>
        /// Sort the product by name, price, quantity
        /// </summary>
        /// <param name="option">option to sort by</param>
        /// <returns>sorted product</returns>
        List<Product>? SortProducts(int option);

        /// <summary>
        /// Checks the product existence in the product
        /// </summary>
        /// <param name="id">Id of product to check</param>
        void ValidateProductId(int id);

        /// <summary>
        /// Search Product by id or name entered by the user
        /// </summary>
        /// <param name="search_query">Name or id entered by user</param>
        /// <returns>list of filtered products</returns>
        List<Product> SearchProductByNameOrId(string search_query);
    }
}
