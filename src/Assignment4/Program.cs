using Assignment4.Controllers;
using Assignment4.Helper;
using Assignment4.Services;
using Assignment4.Validation;
using Assignment4.View;

namespace Assignments
{
    /// <summary>
    /// Application entry point and composition root. Wires up the dependencies once and hands control to the controller.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Execution of flow begins from here.
        /// </summary>
        public static void Main()
        {
            TransactionValidator validator = new TransactionValidator();
            ConsoleView view = new ConsoleView();
            TransactionIdGenerator idGenerator = new TransactionIdGenerator();
            TransactionService service = new TransactionService(validator, idGenerator);
            TransactionController controller = new TransactionController(service, view);

            controller.RunExpenseTracker();
        }
    }
}