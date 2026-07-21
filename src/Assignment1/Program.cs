using Assignment1.Controllers;

namespace Assignment1
{
    /// <summary>
    /// Program class.
    /// </summary>
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Contact Manager Application");
            ContactController contactController = new ContactController();
            contactController.Run();
            Console.WriteLine("Exited ...");
            Console.ReadKey();
        }
    }
}
