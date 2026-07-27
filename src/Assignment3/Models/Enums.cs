using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3.Models
{
    /// <summary>
    /// Contains Enums
    /// </summary>
    internal static class Enums
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
            /// Exit from the application
            /// </summary>
            Exit = 5,
        }
    }
}
