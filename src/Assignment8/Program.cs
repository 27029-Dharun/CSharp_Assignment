using Assignment8.Controllers;
using Assignment8.View;

namespace Assignments;

public class Program
{
    public static void Main(string[] args)
    {
        ConsoleView view = new ConsoleView();
        Controller controller = new Controller(view);

        controller.HandleMenu();
    }
}