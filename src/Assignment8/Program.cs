using Assignment8.Controllers;
using Assignment8.View;

namespace Assignment8;

/// <summary>
/// Application entry point and composition root. Wires up the dependencies once and hands control to the controller.
/// </summary>
internal class Program
{
    static Program()
    {
        AppDomain.CurrentDomain.UnhandledException += OnUnhandledException;
    }

    /// <summary>
    /// Execution of flow begins from here.
    /// </summary>
    internal static void Main()
    {
        ConsoleView view = new ConsoleView();
        ErrorHandlingController controller = new ErrorHandlingController(view);

        controller.HandleMenu();
    }

    private static void OnUnhandledException(object sender, UnhandledExceptionEventArgs e)
    {
        Console.WriteLine("A fatal error occurred and the application is closing.");

        if (e.ExceptionObject is Exception ex)
        {
            Console.Error.WriteLine(ex.ToString());
        }

        Environment.Exit(1);
    }
}