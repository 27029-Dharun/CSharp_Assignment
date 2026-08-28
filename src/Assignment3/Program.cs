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
                IInventoryRepository repository = new InventoryRepository();
                ConsoleView view = new ConsoleView();
                IInventoryService inventoryService = new InventoryService(repository);
                InventoryController controller = new InventoryController(inventoryService, view);

                controller.InventoryManagement();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}