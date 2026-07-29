using InventoryManager.Models;

namespace InventoryManager.Repository
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
        public void AddProduct(Product product)
        {
            this._inventories.Add(product);
        }

        /// <summary>
        /// Gets the inventory object by Id
        /// </summary>
        /// <param name="id">Id of the Product</param>
        /// <returns>Inventory object</returns>
        public Product GetProductById(int id)
        {
            foreach (Product item in this._inventories)
            {
                if (item.Id == id)
                {
                    return item;
                }
            }

            throw new KeyNotFoundException("Product Id not Found");
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
        public IReadOnlyList<Product> GetInventory()
        {
            return this._inventories.ToList();
        }
    }
}
