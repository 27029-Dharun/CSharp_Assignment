using Assignment3.Controllers;
using Assignment3.Repository;
using Assignment3.Services;
using Assignment3.Validation;
using Assignment3.View;

namespace Assignment3
{
    /// <summary>
    /// Application entry point and composition root. Wires up the dependencies once.
    /// </summary>
    internal class Program
    {
        private static void Main()
        {
            try
            {
                InventoryValidator validator = new InventoryValidator();
                InventoryRepository repository = new InventoryRepository();
                ConsoleView view = new ConsoleView();
                InventoryService inventoryService = new InventoryService(validator, repository);
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