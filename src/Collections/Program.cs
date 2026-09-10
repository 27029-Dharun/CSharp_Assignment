using Collections.Controllers;

namespace Collections;

/// <summary>
/// Application entry point.
/// </summary>
internal class Program
{
    private static void Main(string[] args)
    {
        Console.CancelKeyPress += (sender, e) => { e.Cancel };
        Controller controller = new Controller();
        controller.HandleTaskMenu();
    }
}