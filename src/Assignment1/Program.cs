using Assignment1.Controllers;
using Assignment1.Repository;
using Assignment1.Services;

namespace Assignment1;

/// <summary>
/// Application entry point and composition root. Wires up the dependencies once
/// </summary>
internal class Program
{
    /// <summary>
    /// Entry point of the contact manager application.
    /// </summary>
    internal static void Main()
    {
        ContactRepository repository = new ContactRepository();
        ContactService service = new ContactService(repository);
        ContactController contactController = new ContactController(service);

        contactController.HandleMenuOption();
    }
}
