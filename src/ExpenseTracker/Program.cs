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
                // View instance for performing the console operations.
                ConsoleView view = new ConsoleView();

                // Transaction id generator instance
                TransactionIdGenerator idGenerator = new TransactionIdGenerator("transactionId.json");

                JsonFileManager jsonFileManager = new JsonFileManager();

                // Repository instance for add the transactions in the list.
                ITransactionRepository repository = new TransactionRepository("transactions.json", jsonFileManager, idGenerator);

                // Service instance that contains business logic, performs validation, and create product instance.
                TransactionService service = new TransactionService(repository);

                // Controller instance that coordinates the view and service.
                TransactionController controller = new TransactionController(service, view);

                controller.Run();
            }
            catch (DataBaseException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
            }
            finally
            {
                Console.ReadKey();
            }
        }
    }
}