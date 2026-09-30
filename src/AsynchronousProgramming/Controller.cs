using AsynchronousProgramming.Tasks;

namespace AsynchronousProgramming;

/// <summary>
/// Controls the flow between the different tasks.
/// </summary>
internal class Controller
{
    /// <summary>
    /// Controls the flow between the different tasks.
    /// </summary>
    /// <returns>A asynchronous task representing the operation to get user input.</returns>
    public async Task Run()
    {
        string menuMessage = "     Asynchronous Programming        \n" +
            "1. Implementing Async/Await\n" +
            "2. Understanding Task Parallel Library\n" +
            "3. Multi-Threading\n" +
            "4. Multi-Layered Async/Await Operations\n" +
            "5. Fixing Deadlock Conditions\n" +
            "6. ConfigureAwait\n" +
            "7. Difference between Async Void and Async Task with Exceptions\n" +
            "8. Exit\n";

        while (true)
        {
            int option = ConsoleIO.GetInteger(menuMessage);

            switch (option)
            {
                case 1:
                    AsyncAwait httpClient = new AsyncAwait();
                    string content = await httpClient.DownloadContentAsync();
                    Console.WriteLine(content);
                    break;

                case 2:
                    TaskParallelLibrary taskParallelLibrary = new TaskParallelLibrary();
                    taskParallelLibrary.Run();
                    break;

                case 3:
                    MultiThreading multiThreading = new MultiThreading();
                    multiThreading.CalculateAverage();
                    break;

                case 4:
                    MultiLayeredAsync multiLayeredAsync = new MultiLayeredAsync();
                    Task<int> task = multiLayeredAsync.MethodC();
                    Console.WriteLine("Number of key-value pairs: " + task.Result);
                    break;

                case 5:
                    break;

                case 6:
                    ConfigureAwait configureAwait = new ConfigureAwait();
                    await configureAwait.Run();
                    break;

                case 7:
                    ErrorHandling errorHandling = new ErrorHandling();

                    try
                    {
                        await errorHandling.TaskMethod();
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Exception is handled");
                    }

                    try
                    {
                        errorHandling.VoidMethod();
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Exception is unhandled");
                    }

                    break;

                case 8:
                    return;

                default:
                    Console.WriteLine("Enter a valid option");
                    break;
            }

            ConsoleIO.PauseAndClear();
        }
    }
}
