using Assignment1.Controllers;
using Assignment1.Repository;
using Assignment1.Services;
using Assignment1.View;

namespace Assignment1
{
    /// <summary>
    /// Application entry point and composition root. Wires up the dependencies once
    /// </summary>
    internal class Program
    {
        private static void Main()
        {
            ConsoleView view = new ConsoleView();
            ContactRepository repository = new ContactRepository();
            ContactService service = new ContactService(repository);
            ContactController contactController = new ContactController(view, service);

            contactController.RunContactManager();
        }
    }
}
