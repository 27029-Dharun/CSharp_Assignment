using Assignment3.Models;

namespace Assignment3.Repository
{
    /// <summary>
    /// Contract for the repository.
    /// </summary>
    public interface IRepository
    {
        /// <summary>
        /// Gets the inventory objects and returns it.
        /// </summary>
        /// <returns> List of inventory objects. </returns>
        public IReadOnlyList<Product> GetInventory();

        /// <summary>
        /// Remove a product from the inventory.
        /// </summary>
        /// <param name="product">Product object to be deleted</param>
        public void RemoveProduct(Product product);

        /// <summary>
        /// Gets the product by id from the repository.
        /// </summary>
        /// <param name="id"> Unique identifier of the Product. </param>
        /// <returns>Instance of the product.</returns>
        public Product GetProductById(int id);

        /// <summary>
        /// Adds a product to the repository.
        /// </summary>
        /// <param name="product"> Instance of a product to be added. </param>
        public void AddProduct(Product product);
    }
}
