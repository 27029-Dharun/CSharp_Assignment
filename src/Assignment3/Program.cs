using Assignment3.Controllers;
using Assignment3.Repository;
using Assignment3.Services;
using Assignment3.View;

namespace Assignment3
{
    /// <summary>
    /// Application entry point and composition root. Wires up the dependencies once.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Application entry point for the inventory management.
        /// </summary>
        public static void Main()
        {
            try
            {
                InventoryRepository repository = new InventoryRepository();
                ConsoleView view = new ConsoleView();
                InventoryService inventoryService = new InventoryService(repository);
                InventoryController controller = new InventoryController(inventoryService, view);
                InventoryMenuController inventoryManager = new InventoryMenuController(controller, view);

                inventoryManager.Starter();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}