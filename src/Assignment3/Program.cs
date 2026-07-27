using Assignment3.Controllers;
using Assignment3.Models;
using Assignment3.Services;
using Assignment3.View;

namespace Assignment3
{
    /// <summary>
    /// Inventory management with In-memory storage
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Main method
        /// </summary>
        internal static void Main()
        {
            InventoryService inventoryService = new InventoryService();
            InventoryController controller = new InventoryController(inventoryService);
            RunInventory inventoryManager = new RunInventory(controller);
            inventoryManager.Run();
        }
    }
}