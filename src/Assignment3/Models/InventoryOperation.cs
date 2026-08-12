namespace Assignment3.Models
{
    /// <summary>
    /// Specifies the inventory operation available
    /// </summary>
    internal enum InventoryOperation
    {
        /// <summary>
        /// Represents an option to add a new product
        /// </summary>
        Add = 1,

        /// <summary>
        /// Represents an option to view all available product
        /// </summary>
        View = 2,

        /// <summary>
        /// Represents an option to update an existing product
        /// </summary>
        Update = 3,

        /// <summary>
        /// Represents an option to delete an existing product
        /// </summary>
        Delete = 4,

        /// <summary>
        /// Represents an option to search the products in inventory by name or id
        /// </summary>
        Search = 5,

        /// <summary>
        /// Represents an option to sort the products in inventory
        /// </summary>
        Sort = 6,

        /// <summary>
        /// Represents an option to exit from the application
        /// </summary>
        Exit = 7,
    }
}
