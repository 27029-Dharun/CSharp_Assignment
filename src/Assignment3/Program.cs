using Assignment3.Controllers;
using Assignment3.Services;

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
            InventoryManager inventoryManager = new InventoryManager(controller);
            inventoryManager.Run();
        }
    }
}