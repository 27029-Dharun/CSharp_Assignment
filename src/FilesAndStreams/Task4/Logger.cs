namespace FilesAndStreams.Task4;

/// <summary>
/// Logger file
/// </summary>
public static class Logger
{
    private static readonly SemaphoreSlim _semaphore = new SemaphoreSlim(1, 1);
    private static readonly string _logFilePath = "log.txt";

    /// <summary>
    /// Logs the error details in the file.
    /// </summary>
    /// <param name="errorMessage">The message to be logged</param>
    /// <returns>A task</returns>
    public static async Task LogError(string errorMessage)
    {
        string logMessage = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} - ERROR - {errorMessage}\n";

        await _semaphore.WaitAsync();
        try
        {
            await File.AppendAllTextAsync(_logFilePath, logMessage);
        }
        finally
        {
            _semaphore.Release();
        }
    }
}
