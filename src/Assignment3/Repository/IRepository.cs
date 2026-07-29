using InventoryManager.Models;

namespace InventoryManager.Repository
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
        public IReadOnlyList<Product> GetInventory();

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
        public void AddProduct(Product product);
    }
}
