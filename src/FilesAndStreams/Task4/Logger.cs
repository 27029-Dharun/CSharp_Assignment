namespace FilesAndStreams.Task4;

/// <summary>
/// Logger file
/// </summary>
internal class Logger
{
    private static readonly SemaphoreSlim _semaphore = new SemaphoreSlim(1, 1);
    private static readonly string _logFilePath = "log.txt";

    /// <summary>
    /// Logs the error details in the file.
    /// </summary>
    /// <param name="errorMessage">The message to be logged</param>
    /// <returns>A task</returns>
    internal async Task LogError(string errorMessage)
    {
        string logMessage = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} - ERROR - {errorMessage}\n";
        Console.WriteLine("Logging error ...");
        await _semaphore.WaitAsync();
        try
        {
            await File.AppendAllTextAsync(_logFilePath, logMessage);
        }
        finally
        {
            _semaphore.Release();
        }

        Console.WriteLine("Completed logging.");
    }

    /// <summary>
    /// Logs error from different user at a time.
    /// </summary>
    /// <returns>A asynchronous task that writes into logger file.</returns>
    internal async Task LogErrors()
    {
        await Task.WhenAll(
             this.LogError("Database connection failed"),
             this.LogError("Invalid user input"),
             this.LogError("File not found"));
    }
}
