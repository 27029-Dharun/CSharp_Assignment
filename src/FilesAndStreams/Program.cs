using FilesAndStreams.Task1;
using FilesAndStreams.Task2;

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
        string menuOptions = "1. Synchronous file processing\n" +
            "2. Asynchronous file processing\n" +
            "4. Exit\n" +
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
                    break;

                case 4:
                    return;

                case 5:
                    Console.WriteLine("Enter a valid option");
                    break;
            }

            ConsoleIO.PauseAndClear();
        }
    }
}