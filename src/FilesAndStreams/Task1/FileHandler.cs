namespace FilesAndStreams.Task1;

/// <summary>
/// Handles file data synchronously.
/// </summary>
internal class FileHandler
{
    private const string SourceFilePath = "file.txt";
    private const string ResultFilePath = "data.txt";

    private const string MenuOption =
        "1. Read the file\n" +
        "2. Process file and write\n" +
        "3. Back\n" +
        "Enter an option to proceed\n";

    private readonly FileDataProcessor _dataProcessor;

    /// <summary>
    /// Initializes a new instance of the <see cref="FileHandler"/> class.
    /// </summary>
    /// <param name="dataProcessor">Instance of file data processor.</param>
    internal FileHandler(FileDataProcessor dataProcessor)
    {
        this._dataProcessor = dataProcessor;
    }

    /// <summary>
    /// Shows the synchronous menu until the user goes back.
    /// </summary>
    internal void Run()
    {
        while (true)
        {
            int option = ConsoleIO.GetInteger(MenuOption);

            switch (option)
            {
                case 1:
                    this.ReadData();
                    break;

                case 2:
                    this.ProcessData();
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

    private void ReadData()
    {
        try
        {
            Console.WriteLine("Reading with FileStream");
            long timeTakenWithFileStream = this._dataProcessor.ReadWithFileStream(SourceFilePath);
            Console.WriteLine($"Time taken to read with file stream: {timeTakenWithFileStream} ms\n");

            Console.WriteLine("Reading with Buffered Stream");
            long timeTakenWithBufferedStream = this._dataProcessor.ReadWithBufferedStream(SourceFilePath);
            Console.WriteLine($"Time taken to read with buffered stream: {timeTakenWithBufferedStream} ms\n");

            long difference = Math.Abs(timeTakenWithFileStream - timeTakenWithBufferedStream);

            if (timeTakenWithBufferedStream < timeTakenWithFileStream)
            {
                Console.WriteLine($"Buffered stream is {difference} ms faster");
            }
            else if (timeTakenWithFileStream < timeTakenWithBufferedStream)
            {
                Console.WriteLine($"File stream is {difference} ms faster");
            }
            else
            {
                Console.WriteLine("There is no difference between file stream and buffered stream.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    private void ProcessData()
    {
        try
        {
            string report = this._dataProcessor.ProcessAndWrite(SourceFilePath, ResultFilePath);
            Console.WriteLine("Processed data\n" +
                report +
                $"\nResult stored in the path {ResultFilePath}\n");
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine($"File:{SourceFilePath} not found");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
