using ExpenseTracker.Controllers;
using ExpenseTracker.Helper;
using ExpenseTracker.Repository;
using ExpenseTracker.Services;
using ExpenseTracker.View;

namespace ExpenseTracker
{
    /// <summary>
    /// Application entry point and composition root. Wires up the dependencies once and hands control to the controller.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Execution of flow begins from here.
        /// </summary>
        public static void Main()
        {
            try
            {
                ConsoleView view = new ConsoleView();
                TransactionIdGenerator idGenerator = new TransactionIdGenerator();
                IRepository repository = new TransactionRepository(idGenerator);
                TransactionService service = new TransactionService(repository);
                TransactionController controller = new TransactionController(service, view);

                controller.Run();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}