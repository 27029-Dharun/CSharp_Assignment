using System.Diagnostics;
using FilesAndStreams.Task1;

namespace FilesAndStreams.Task2;

/// <summary>
/// Controls the flow of the application.
/// </summary>
internal class AsyncFileHandler
{
    private const string _firstPath = "file1.txt";
    private const string _secondPath = "file2.txt";
    private const string _thirdPath = "file3.txt";

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
            "4. Exit\n" +
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

        string data1 = this._fileProcessor.ProcessData(_firstPath);
        string data2 = this._fileProcessor.ProcessData(_secondPath);
        string data3 = this._fileProcessor.ProcessData(_thirdPath);

        stopwatch.Stop();

        Console.WriteLine($"Time taken to process 3 file synchronously: {stopwatch.ElapsedMilliseconds} ms\n");

        Console.WriteLine("Processing file synchronously");
        stopwatch.Restart();

        Task<string> firstFileProcess = this._asyncFileProcessor.ProcessDataAsync(_firstPath);
        Task<string> secondFileProcess = this._asyncFileProcessor.ProcessDataAsync(_secondPath);
        Task<string> thirdFileProcess = this._asyncFileProcessor.ProcessDataAsync(_thirdPath);

        await Task.WhenAll(firstFileProcess, secondFileProcess, thirdFileProcess);
        stopwatch.Stop();
        Console.WriteLine($"Time taken to process 3 file asynchronously: {stopwatch.ElapsedMilliseconds} ms\n");

        Console.WriteLine("Writing 3 file synchronously");

        stopwatch.Restart();

        this._fileProcessor.WriteProcessedString("result1.txt", data1);
        this._fileProcessor.WriteProcessedString("result2.txt", data2);
        this._fileProcessor.WriteProcessedString("result3.txt", data3);

        stopwatch.Stop();

        Console.WriteLine($"Time taken to write 3 file synchronously: {stopwatch.ElapsedMilliseconds} ms\n");

        stopwatch.Restart();

        Task firstFile = this._asyncFileProcessor.WriteProcessedString("result1.txt", firstFileProcess.Result);
        Task secondFile = this._asyncFileProcessor.WriteProcessedString("result2.txt", secondFileProcess.Result);
        Task thirdFile = this._asyncFileProcessor.WriteProcessedString("result3.txt", thirdFileProcess.Result);

        await Task.WhenAll(firstFile, secondFile, thirdFile);
        stopwatch.Stop();
        Console.WriteLine($"Time taken to write 3 file asynchronously: {stopwatch.ElapsedMilliseconds} ms");
    }

    private async Task ReadAll()
    {
        Stopwatch stopwatch = new Stopwatch();
        Console.WriteLine("Read file synchronously");

        stopwatch.Start();

        this._fileProcessor.ReadWithBufferedStream(_firstPath);
        this._fileProcessor.ReadWithBufferedStream(_secondPath);
        this._fileProcessor.ReadWithBufferedStream(_thirdPath);

        stopwatch.Stop();

        Console.WriteLine($"Time taken to read 3 file synchronously: {stopwatch.ElapsedMilliseconds} ms\n");

        Console.WriteLine("Read file asynchronously");
        stopwatch.Restart();

        Task firstFileReadBuffer = this._asyncFileProcessor.ReadWithBufferedStream(_firstPath);
        Task secondFileReadBuffer = this._asyncFileProcessor.ReadWithBufferedStream(_secondPath);
        Task thirdFileReadBuffer = this._asyncFileProcessor.ReadWithBufferedStream(_thirdPath);

        await Task.WhenAll(firstFileReadBuffer, secondFileReadBuffer, thirdFileReadBuffer);
        stopwatch.Stop();
        Console.WriteLine($"Time taken to read file asynchronously: {stopwatch.ElapsedMilliseconds} ms\n");
    }

    private async Task GenerateAll()
    {
        Stopwatch stopwatch = new Stopwatch();

        Console.WriteLine("Generating file synchronously");
        stopwatch.Start();
        this._fileProcessor.GenerateFile(_firstPath, 1_00_00_000);
        this._fileProcessor.GenerateFile(_secondPath, 1_00_00_000);
        this._fileProcessor.GenerateFile(_thirdPath, 1_00_00_000);

        stopwatch.Stop();

        Console.WriteLine($"Time taken to create 3 file synchronously: {stopwatch.ElapsedMilliseconds} ms\n");

        Console.WriteLine("Generating file asynchronously");

        stopwatch.Restart();
        Task firstFile = this._asyncFileProcessor.GenerateFileAsync(_firstPath, 1_00_00_000);
        Task secondFile = this._asyncFileProcessor.GenerateFileAsync(_secondPath, 1_00_00_000);
        Task thirdFile = this._asyncFileProcessor.GenerateFileAsync(_thirdPath, 1_00_00_000);

        await Task.WhenAll(firstFile, secondFile, thirdFile);
        stopwatch.Stop();

        Console.WriteLine($"Time taken to create 3 file {stopwatch.ElapsedMilliseconds} ms\n");
    }
}
