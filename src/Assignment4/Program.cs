using Assignment4.Controllers;
using Assignment4.Helper;
using Assignment4.Repository;
using Assignment4.Services;
using Assignment4.View;

namespace Assignment4
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
            try
            {
                // View instance for performing the console operations.
                ConsoleView view = new ConsoleView();

                // Transaction id generator instance
                TransactionIdGenerator idGenerator = new TransactionIdGenerator();

                // Repository instance for add the transactions in the list.
                TransactionRepository repository = new TransactionRepository();

                TransactionInputHandler inputHandler = new TransactionInputHandler();

                // Service instance that contains business logic, performs validation, and create product instance.
                TransactionService service = new TransactionService(idGenerator, repository);

                // Controller instance that coordinates the view and service.
                TransactionController controller = new TransactionController(service, view, inputHandler);

                // Expense tracker instance that contains the entry point for the application.
                ExpenseTracker expenseTracker = new ExpenseTracker(view, controller);

                expenseTracker.ExecuteExpenseTracker();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}