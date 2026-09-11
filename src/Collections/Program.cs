using Collections.Controllers;

namespace Collections;

/// <summary>
/// Application entry point.
/// </summary>
internal class Program
{
    private static void Main()
    {
        Console.CancelKeyPress += (sender, e) => { e.Cancel = true; };
        Controller controller = new Controller();
        controller.HandleTaskMenu();
    }
}
