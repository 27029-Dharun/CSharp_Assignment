using Assignment8.Controllers;
using Assignment8.View;

namespace Assignments;

public class Program
{
    public static void Main(string[] args)
    {
        AppDomain domain = AppDomain.CurrentDomain;
        domain.UnhandledException += DomainUnhandledException;

        ConsoleView view = new ConsoleView();
        Controller controller = new Controller(view);

        controller.HandleMenu();
        Console.ReadKey();
    }

    private static void DomainUnhandledException(object sender, UnhandledExceptionEventArgs e)
    {
        Console.WriteLine(e.IsTerminating);
        Console.WriteLine(e.ToString());
    }
}