using ExpenseTracker.Controllers;
using ExpenseTracker.CustomException;
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
                TransactionIdGenerator idGenerator = new TransactionIdGenerator("transactionId.json");
                JsonFileManager jsonFileManager = new JsonFileManager();
                ITransactionRepository repository = new TransactionRepository("transactions.json", jsonFileManager, idGenerator);
                TransactionService service = new TransactionService(repository);
                TransactionController controller = new TransactionController(service, view);

                controller.Run();
            }
            catch (DataBaseException ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
                Console.ReadKey();
            }
        }
    }
}