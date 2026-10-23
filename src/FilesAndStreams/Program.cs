using System.Diagnostics;
using FilesAndStreams.Task1;
using FilesAndStreams.Task2;
using FilesAndStreams.Task3;
using FilesAndStreams.Task4;

namespace FilesAndStreams;

/// <summary>
/// Application entry point.
/// </summary>
internal class Program
{
    private static void Main()
    {
        FileDateProcessor dataProcessor = new FileDateProcessor();
        AsyncFileDataProcessor asyncDataProcessor = new AsyncFileDataProcessor();

        FileHandler fileHandler = new FileHandler(dataProcessor);
        AsyncFileHandler asyncFileHandler = new AsyncFileHandler(dataProcessor, asyncDataProcessor);
        MemoryStreamWriter memoryStream = new MemoryStreamWriter();

        string menuOptions = "1. Synchronous file processing\n" +
            "2. Asynchronous file processing\n" +
            "3. Bug finding\n" +
            "4. Logger\n" +
            "5. Exit\n" +
            "Enter an option to proceed: \n";

        while (true)
        {
            int option = ConsoleIO.GetInteger(menuOptions);

            switch (option)
            {
                case 1:
                    fileHandler.Run();
                    break;

                case 2:
                    asyncFileHandler.Run().GetAwaiter().GetResult();
                    break;

                case 3:
                    memoryStream.WriteAndReadFile();
                    break;

                case 4:
                    Logger logger = new Logger();
                    Stopwatch stopwatch = new Stopwatch();

                    stopwatch.Start();
                    logger.LogErrorsAtSameFile().GetAwaiter().GetResult();
                    stopwatch.Stop();
                    Console.WriteLine($"Time taken to print all the log in same file: {stopwatch.ElapsedMilliseconds} ms");

                    stopwatch.Restart();
                    logger.LogErrorsAtDifferentFile().GetAwaiter().GetResult();
                    stopwatch.Stop();
                    Console.WriteLine($"Time taken to print all the log in different file for each user: {stopwatch.ElapsedMilliseconds} ms");
                    break;

                case 5:
                    return;

                default:
                    Console.WriteLine("Enter a valid option");
                    break;
            }

            ConsoleIO.PauseAndClear();
        }
    }
}