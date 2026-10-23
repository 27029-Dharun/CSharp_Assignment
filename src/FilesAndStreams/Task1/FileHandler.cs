namespace FilesAndStreams.Task1;

/// <summary>
/// Handles file data synchronously.
/// </summary>
internal class FileHandler
{
    private const string _path = "file.txt";
    private readonly FileDateProcessor _dateProcessor;

    /// <summary>
    /// Initializes a new instance of the <see cref="FileHandler"/> class.
    /// </summary>
    /// <param name="dataProcessor">Instance of file data processor.</param>
    internal FileHandler(FileDateProcessor dataProcessor)
    {
        this._dateProcessor = dataProcessor;
    }

    /// <summary>
    /// Reads the file.
    /// </summary>
    internal void Run()
    {
        string menuOptions =
            "1. Read the file\n" +
            "2. Process file and write\n" +
            "3. Back\n" +
            "Enter an option to proceed\n";

        while (true)
        {
            int option = ConsoleIO.GetInteger(menuOptions);

            switch (option)
            {
                case 1:
                    Console.WriteLine("Reading with FileStream");
                    long timeTakenWithFileStream = this._dateProcessor.ReadWithFileStream(_path);
                    Console.WriteLine($"Time taken to read with file stream: {timeTakenWithFileStream}\n");

                    Console.WriteLine("Reading with Buffered Stream");
                    long timeTakenWithBufferedStream = this._dateProcessor.ReadWithBufferedStream(_path);
                    Console.WriteLine($"Time taken to read with buffered stream: {timeTakenWithBufferedStream}\n");

                    Console.WriteLine($"Buffer stream is {timeTakenWithFileStream - timeTakenWithBufferedStream} ms faster\n");
                    break;

                case 2:
                    this._dateProcessor.ProcessAndWrite(_path, "data.txt");
                    break;

                case 3:
                    return;

                default:
                    Console.WriteLine("Enter a valid option");
                    break;
            }

            ConsoleIO.PauseAndClear();
        }
    }
}
