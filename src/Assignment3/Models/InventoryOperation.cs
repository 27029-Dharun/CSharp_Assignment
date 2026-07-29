namespace InventoryManager.Models
{
    /// <summary>
    /// Inventory Operation Enums
    /// </summary>
    public enum InventoryOperation
    {
        /// <summary>
        /// Add new Product
        /// </summary>
        Add = 1,

        /// <summary>
        /// View all Available product
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
        /// Search the Products in inventory by Name or Id
        /// </summary>
        Search = 5,

        /// <summary>
        /// Sort the Products in Inventory
        /// </summary>
        Sort = 6,

        /// <summary>
        /// Exit from the application
        /// </summary>
        Exit = 7,
    }
}
