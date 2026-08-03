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
            try
            {
                InventoryValidator validator = new InventoryValidator();
                ConsoleView view = new ConsoleView();
                InventoryService inventoryService = new InventoryService(validator);
                InventoryController controller = new InventoryController(inventoryService, view);
                InventoryMenuController inventoryManager = new InventoryMenuController(controller, view);

                inventoryManager.Run();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}