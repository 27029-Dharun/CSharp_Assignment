using Assignment3.Models;

namespace Assignment3.Repository
{
    /// <summary>
    /// Provides a centralized data repository for storing, retrieving product in the inventory.
    /// </summary>
    internal class InventoryRepository : IRepository
    {
        private readonly List<Product> _inventories = new List<Product>();

        /// <inheritdoc />
        public void AddProduct(Product product)
        {
            this._inventories.Add(product);
        }

        /// <inheritdoc />
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

        /// <inheritdoc />
        public void RemoveProduct(Product product)
        {
            this._inventories.Remove(product);
        }

        /// <inheritdoc />
        public IReadOnlyList<Product> GetInventory()
        {
            return this._inventories.ToList();
        }

        /// <summary>
        /// Gets the product names of all the product in the inventory.
        /// </summary>
        /// <returns> List of all the product names in the inventory. </returns>
        public List<string> GetProductName()
        {
            return this._inventories.Select(product => product.Name ?? string.Empty).ToList();
        }
    }
}
