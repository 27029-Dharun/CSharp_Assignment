using Assignment3.Models;
using Assignment3.Models.Enums;

namespace Assignment3.Services
{
    /// <summary>
    /// Defines business logic operations for managing product in inventory.
    /// </summary>
    public interface IInventoryService
    {
        /// <summary>
        /// Validates a product and create a product instance
        /// </summary>
        /// <param name="name">Name of the product</param>
        /// <param name="price">Price of the product</param>
        /// <param name="quantity">Quantity of the product</param>
        /// <returns>Product created</returns>
        Product CreateInventoryProduct(string name, decimal price, int quantity);

        /// <summary>
        /// Gets the all the product inventory.
        /// </summary>
        /// <returns>Returns the product</returns>
        List<Product> GetInventoryProducts();

        /// <summary>
        /// Deletes the product in inventory by using a unique identifier.
        /// </summary>
        /// <param name="id"> Id of the product to be deleted. </param>
        /// <returns>product product instance</returns>
        Product DeleteProductById(int id);

        /// <summary>
        /// Edit the product by id
        /// </summary>
        /// <param name="id">Id of the product to be deleted</param>
        /// <param name="name">Name of the product</param>
        /// <param name="price">Price of the product</param>
        /// <param name="quantity">Quantity of the product</param>
        /// <returns>Product edited instance</returns>
        Product EditProductById(int id, string name, decimal? price, int? quantity);

        /// <summary>
        /// Sort the product by name, price, quantity
        /// </summary>
        /// <param name="option">option to sort by</param>
        /// <returns>sorted product list</returns>
        List<Product> SortProducts(SortOption option);

        /// <summary>
        /// Checks the product existence in the inventory
        /// </summary>
        /// <param name="id">Id of product to check</param>
        void ValidateProductId(int id);

        /// <summary>
        /// Search product by id or name entered by the user
        /// </summary>
        /// <param name="search_query">Name or id entered by user</param>
        /// <returns>List of filtered products</returns>
        List<Product> SearchProductByNameOrId(string search_query);

        /// <summary>
        /// Checks if inventory is empty
        /// </summary>
        /// <returns>True if empty</returns>
        public bool IsInventoryEmpty();
    }
}
