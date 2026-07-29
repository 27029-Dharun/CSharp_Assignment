using InventoryManager.Models;

namespace InventoryManager.Services
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

        /// <summary>
        /// Sort the product by Name, Price, Quantity and Id
        /// </summary>
        /// <param name="option">Option</param>
        /// <returns>sorted product</returns>
        List<Product> SortProducts(int option);

        /// <summary>
        /// Checks the product existance in the product
        /// </summary>
        /// <param name="id">Id of product to check</param>
        void CheckProductId(int id);

        /// <summary>
        /// Search Product by Id or name entered by the User
        /// </summary>
        /// <param name="search_query">Name or ID entered By user</param>
        /// <returns>list of filtered products</returns>
        List<Product> SearchProductByNameOrId(string search_query);
    }
}
