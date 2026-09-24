using System.Diagnostics;
using FilesAndStreams.Task1;

namespace FilesAndStreams.Task2;

/// <summary>
/// Controls the flow of the application.
/// </summary>
internal class AsyncFileHandler
{
    private const string _firstSourcePath = "file1.txt";
    private const string _secondSourcePath = "file2.txt";
    private const string _thirdSourcePath = "file3.txt";

    private readonly AsyncFileDataProcessor _asyncFileProcessor;
    private readonly FileDateProcessor _fileProcessor;

    /// <summary>
    /// Initializes a new instance of the <see cref="AsyncFileHandler"/> class.
    /// </summary>
    /// <param name="dataProcessor">Instance of synchronous data processor.</param>
    /// <param name="asyncDataProcessor">Instance of asynchronous data processor.</param>
    internal AsyncFileHandler(FileDateProcessor dataProcessor, AsyncFileDataProcessor asyncDataProcessor)
    {
        this._fileProcessor = dataProcessor;
        this._asyncFileProcessor = asyncDataProcessor;
    }

    /// <summary>
    /// Reads the file.
    /// </summary>
    /// <returns>A task is returned.</returns>
    internal async Task Run()
    {
        string menuOptions = "1. Create 3 large file with 1 GB\n" +
            "2. Read files\n" +
            "3. Read and process all file\n" +
            "4. Back\n" +
            "Enter an option to proceed: ";

        while (true)
        {
            int option = ConsoleIO.GetInteger(menuOptions);

            switch (option)
            {
                case 1:
                    await this.GenerateAll();
                    break;

                case 2:
                    await this.ReadAll();
                    break;

                case 3:
                    await this.ProcessAll();
                    break;

                case 4:
                    return;

                default:
                    Console.WriteLine("Enter a valid option");
                    break;
            }

            ConsoleIO.PauseAndClear();
        }
    }

    private async Task ProcessAll()
    {
        Stopwatch stopwatch = new Stopwatch();
        Console.WriteLine("Processing file synchronously");

        stopwatch.Start();

        this._fileProcessor.ProcessAndWrite(_firstSourcePath, "result1.txt");
        this._fileProcessor.ProcessAndWrite(_secondSourcePath, "result2.txt");
        this._fileProcessor.ProcessAndWrite(_thirdSourcePath, "result3.txt");

        stopwatch.Stop();

        Console.WriteLine($"Time taken to process 3 file synchronously: {stopwatch.ElapsedMilliseconds} ms\n");

        Console.WriteLine("Processing file synchronously");
        stopwatch.Restart();

        Task firstFileProcess = this._asyncFileProcessor.ProcessAndWriteAsync(_firstSourcePath, "result1.txt");
        Task secondFileProcess = this._asyncFileProcessor.ProcessAndWriteAsync(_secondSourcePath, "result2.txt");
        Task thirdFileProcess = this._asyncFileProcessor.ProcessAndWriteAsync(_thirdSourcePath, "result3.txt");

        await Task.WhenAll(firstFileProcess, secondFileProcess, thirdFileProcess);
        stopwatch.Stop();
        Console.WriteLine($"Time taken to process and write 3 file asynchronously: {stopwatch.ElapsedMilliseconds} ms\n");
    }

    private async Task ReadAll()
    {
        Stopwatch stopwatch = new Stopwatch();
        Console.WriteLine("Read file synchronously");

        stopwatch.Start();

        this._fileProcessor.ReadWithBufferedStream(_firstSourcePath);
        this._fileProcessor.ReadWithBufferedStream(_secondSourcePath);
        this._fileProcessor.ReadWithBufferedStream(_thirdSourcePath);

        stopwatch.Stop();

        Console.WriteLine($"Time taken to read 3 file synchronously: {stopwatch.ElapsedMilliseconds} ms\n");

        Console.WriteLine("Read file asynchronously");
        stopwatch.Restart();

        Task firstFileReadBuffer = this._asyncFileProcessor.ReadWithBufferedStream(_firstSourcePath);
        Task secondFileReadBuffer = this._asyncFileProcessor.ReadWithBufferedStream(_secondSourcePath);
        Task thirdFileReadBuffer = this._asyncFileProcessor.ReadWithBufferedStream(_thirdSourcePath);

        await Task.WhenAll(firstFileReadBuffer, secondFileReadBuffer, thirdFileReadBuffer);
        stopwatch.Stop();
        Console.WriteLine($"Time taken to read file asynchronously: {stopwatch.ElapsedMilliseconds} ms\n");
    }

    private async Task GenerateAll()
    {
        Stopwatch stopwatch = new Stopwatch();

        Console.WriteLine("Generating file synchronously");
        stopwatch.Start();
        this._fileProcessor.GenerateFile(_firstSourcePath, 2_50_00_000);
        this._fileProcessor.GenerateFile(_secondSourcePath, 2_50_00_000);
        this._fileProcessor.GenerateFile(_thirdSourcePath, 2_50_00_000);

        stopwatch.Stop();

        Console.WriteLine($"Time taken to create 3 file synchronously: {stopwatch.ElapsedMilliseconds} ms\n");

        Console.WriteLine("Generating file asynchronously");

        stopwatch.Restart();
        Task firstFile = this._asyncFileProcessor.GenerateFileAsync(_firstSourcePath, 2_50_00_000);
        Task secondFile = this._asyncFileProcessor.GenerateFileAsync(_secondSourcePath, 2_50_00_000);
        Task thirdFile = this._asyncFileProcessor.GenerateFileAsync(_thirdSourcePath, 2_50_00_000);

        await Task.WhenAll(firstFile, secondFile, thirdFile);
        stopwatch.Stop();

        Console.WriteLine($"Time taken to create 3 file {stopwatch.ElapsedMilliseconds} ms\n");
    }
}
