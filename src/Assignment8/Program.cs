using Assignment8.Controllers;
using Assignment8.View;

namespace Assignments;

public class Program
{
    public static void Main(string[] args)
    {
        AppDomain domain = AppDomain.CurrentDomain;
        domain.UnhandledException += new UnhandledExceptionEventHandler(HandleException);

        ConsoleView view = new ConsoleView();
        Controller controller = new Controller(view);

        controller.HandleMenu();
        Console.ReadKey();
    }

    public static void HandleException()
    {
        Console.WriteLine($"Unhandled exception caught, {}");
    }
}