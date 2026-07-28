using Assignment3.Controllers;
using Assignment3.Services;
using Assignment3.Validation;
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
            InventoryValidator validator = new InventoryValidator();
            ConsoleView view = new ConsoleView();
            InventoryService inventoryService = new InventoryService(validator);
            InventoryController controller = new InventoryController(inventoryService, view);
            InventoryManager inventoryManager = new InventoryManager(controller);
            inventoryManager.Run();
        }
    }
}