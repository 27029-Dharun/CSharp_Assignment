using Collections.Controllers;

namespace Collections;

/// <summary>
/// Application entry point.
/// </summary>
internal class Program
{
    private static void Main()
    {
        Controller controller = new Controller();
        controller.HandleTaskMenu();
    }
}
