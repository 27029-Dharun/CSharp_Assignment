using Assignment3.Controllers;
using Assignment3.Repository;
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
            try
            {
                InventoryValidator validator = new InventoryValidator();
                InventoryRepository repository = new InventoryRepository();
                ConsoleView view = new ConsoleView();
                InventoryService inventoryService = new InventoryService(validator, repository);
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