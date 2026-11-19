using System.Diagnostics;
using FilesAndStreams.Task1;

namespace FilesAndStreams.Task2;

/// <summary>
/// Controls the flow of the application.
/// </summary>
internal class AsyncFileHandler
{
    private const string FirstSourcePath = "file1.txt";
    private const string SecondSourcePath = "file2.txt";
    private const string ThirdSourcePath = "file3.txt";

    private const string FirstOutputPath = "result1.txt";
    private const string SecondOutputPath = "result2.txt";
    private const string ThirdOutputPath = "result3.txt";

    private const int LineCount = 2_50_00_000;

    private const string MenuOptions = "1. Create 3 large file with 1 GB\n" +
        "2. Read files\n" +
        "3. Read and process all file\n" +
        "4. Back\n" +
        "Enter an option to proceed: ";

    private readonly AsyncFileDataProcessor _asyncFileProcessor;
    private readonly FileDataProcessor _fileProcessor;

    /// <summary>
    /// Initializes a new instance of the <see cref="AsyncFileHandler"/> class.
    /// </summary>
    /// <param name="dataProcessor">Instance of synchronous data processor.</param>
    /// <param name="asyncDataProcessor">Instance of asynchronous data processor.</param>
    internal AsyncFileHandler(FileDataProcessor dataProcessor, AsyncFileDataProcessor asyncDataProcessor)
    {
        this._fileProcessor = dataProcessor;
        this._asyncFileProcessor = asyncDataProcessor;
    }

    /// <summary>
    /// Shows the asynchronous menu until the user goes back.
    /// </summary>
    /// <returns>A task is returned.</returns>
    internal async Task RunAsync()
    {
        while (true)
        {
            int option = ConsoleIO.GetInteger(MenuOptions);

            switch (option)
            {
                case 1:
                    await this.GenerateAllAsync();
                    break;

                case 2:
                    await this.ReadAllAsync();
                    break;

                case 3:
                    await this.ProcessAllAsync();
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

    private async Task GenerateAllAsync()
    {
        Stopwatch stopwatch = new Stopwatch();

        Console.WriteLine("Generating file synchronously");
        stopwatch.Start();
        this._fileProcessor.GenerateFile(FirstSourcePath, LineCount);
        this._fileProcessor.GenerateFile(SecondSourcePath, LineCount);
        this._fileProcessor.GenerateFile(ThirdSourcePath, LineCount);

        stopwatch.Stop();

        Console.WriteLine($"Time taken to create 3 file synchronously: {stopwatch.ElapsedMilliseconds} ms\n");

        Console.WriteLine("Generating file asynchronously");

        stopwatch.Restart();
        Task firstFile = this._asyncFileProcessor.GenerateFileAsync(FirstSourcePath, LineCount);
        Task secondFile = this._asyncFileProcessor.GenerateFileAsync(SecondSourcePath, LineCount);
        Task thirdFile = this._asyncFileProcessor.GenerateFileAsync(ThirdSourcePath, LineCount);

        await Task.WhenAll(firstFile, secondFile, thirdFile);
        stopwatch.Stop();

        Console.WriteLine($"Time taken to create 3 file {stopwatch.ElapsedMilliseconds} ms\n");
    }

    private async Task ReadAllAsync()
    {
        Stopwatch stopwatch = new Stopwatch();
        Console.WriteLine("Read file synchronously");

        stopwatch.Start();

        this._fileProcessor.ReadWithBufferedStream(FirstSourcePath);
        this._fileProcessor.ReadWithBufferedStream(SecondSourcePath);
        this._fileProcessor.ReadWithBufferedStream(ThirdSourcePath);

        stopwatch.Stop();

        Console.WriteLine($"Time taken to read 3 file synchronously: {stopwatch.ElapsedMilliseconds} ms\n");

        Console.WriteLine("Read file asynchronously");
        stopwatch.Restart();

        Task firstFileReadBuffer = this._asyncFileProcessor.ReadWithLargeBufferAsync(FirstSourcePath);
        Task secondFileReadBuffer = this._asyncFileProcessor.ReadWithLargeBufferAsync(SecondSourcePath);
        Task thirdFileReadBuffer = this._asyncFileProcessor.ReadWithLargeBufferAsync(ThirdSourcePath);

        await Task.WhenAll(firstFileReadBuffer, secondFileReadBuffer, thirdFileReadBuffer);
        stopwatch.Stop();
        Console.WriteLine($"Time taken to read file asynchronously: {stopwatch.ElapsedMilliseconds} ms\n");
    }

    private async Task ProcessAllAsync()
    {
        try
        {
            Stopwatch stopwatch = new Stopwatch();
            Console.WriteLine("Processing file synchronously");

            stopwatch.Start();

            this._fileProcessor.ProcessAndWrite(FirstSourcePath, FirstOutputPath);
            this._fileProcessor.ProcessAndWrite(SecondSourcePath, SecondOutputPath);
            this._fileProcessor.ProcessAndWrite(ThirdSourcePath, ThirdOutputPath);

            stopwatch.Stop();

            Console.WriteLine($"Time taken to process 3 file synchronously: {stopwatch.ElapsedMilliseconds} ms\n");

            Console.WriteLine("Processing file asynchronously");
            stopwatch.Restart();

            Task firstFileProcess = this._asyncFileProcessor.ProcessAndWriteAsync(FirstSourcePath, FirstOutputPath);
            Task secondFileProcess = this._asyncFileProcessor.ProcessAndWriteAsync(SecondSourcePath, SecondOutputPath);
            Task thirdFileProcess = this._asyncFileProcessor.ProcessAndWriteAsync(ThirdSourcePath, ThirdOutputPath);

            await Task.WhenAll(firstFileProcess, secondFileProcess, thirdFileProcess);
            stopwatch.Stop();
            Console.WriteLine($"Time taken to process and write 3 file asynchronously: {stopwatch.ElapsedMilliseconds} ms\n");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
