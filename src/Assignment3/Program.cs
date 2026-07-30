using InventoryManager.Controllers;
using InventoryManager.Services;
using InventoryManager.Validation;
using InventoryManager.View;

namespace InventoryManager
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
            Controllers.InventoryMenuController inventoryManager = new Controllers.InventoryMenuController(controller, view);
            try
            {
                inventoryManager.Run();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}