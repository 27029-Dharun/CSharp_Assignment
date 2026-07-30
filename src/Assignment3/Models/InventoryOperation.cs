namespace InventoryManager.Models
{
    /// <summary>
    /// Inventory Operation Enums
    /// </summary>
    public enum InventoryOperation
    {
        /// <summary>
        /// Add new product
        /// </summary>
        Add = 1,

        /// <summary>
        /// View all available product
        /// </summary>
        View = 2,

        /// <summary>
        /// Update a product
        /// </summary>
        Update = 3,

        /// <summary>
        /// Delete a product
        /// </summary>
        Delete = 4,

        /// <summary>
        /// Search the products in inventory by name or id
        /// </summary>
        Search = 5,

        /// <summary>
        /// Sort the products in inventory
        /// </summary>
        Sort = 6,

        /// <summary>
        /// Exit from the application
        /// </summary>
        Exit = 7,
    }
}
