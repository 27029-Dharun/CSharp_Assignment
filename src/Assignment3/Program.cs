using Assignment3.Controllers;
using Assignment3.Repository;
using Assignment3.Services;
using Assignment3.View;

namespace Assignment3;

/// <summary>
/// Application entry point and composition root.
/// </summary>
public class Program
{
    private static void Main()
    {
        try
        {
            IInventoryRepository repository = new InventoryRepository();
            ConsoleView view = new ConsoleView();
            IInventoryService service = new InventoryService(repository);
            InventoryController controller = new InventoryController(service, view);

            controller.Run();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An unexpected error occurred: {ex.Message}");
        }
    }
}