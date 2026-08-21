using Assignment8.Controllers;
using Assignment8.View;

namespace Assignment8;

/// <summary>
/// Application entry point and composition root. Wires up the dependencies once and hands control to the controller.
/// </summary>
internal class Program
{
    /// <summary>
    /// Execution of flow begins from here.
    /// </summary>
    internal static void Main()
    {
        AppDomain domain = AppDomain.CurrentDomain;
        domain.UnhandledException += DomainUnhandledException;

        ConsoleView view = new ConsoleView();
        Controller controller = new Controller(view);

        controller.HandleMenu();
    }

    private static void DomainUnhandledException(object sender, UnhandledExceptionEventArgs e)
    {
        Console.WriteLine("\nGlobal exception handled");
        Console.WriteLine(e.IsTerminating);
        Exception ex = (Exception)e.ExceptionObject;
        Console.WriteLine(ex.Message);
    }
}
