using System.Text;

namespace FilesAndStreams.Task4;

/// <summary>
/// Logger file.
/// </summary>
internal class Logger
{
    private static readonly SemaphoreSlim _semaphore = new SemaphoreSlim(1, 1);
    private static readonly string _logFilePath = "log.txt";

    /// <summary>
    /// Logs the error details in the file.
    /// </summary>
    /// <param name="errorMessage">The message to be logged.</param>
    /// <returns>A asynchronous task.</returns>
    internal async Task LogError(string errorMessage)
    {
        string logMessage = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} - ERROR - {errorMessage}\n";
        Console.WriteLine("Logging error ...");
        await _semaphore.WaitAsync();
        try
        {
            using (FileStream stream = new FileStream(_logFilePath, FileMode.Append, FileAccess.Write))
            {
                byte[] buffer = Encoding.UTF8.GetBytes(logMessage);
                await stream.WriteAsync(buffer, 0, buffer.Length);
            }
        }
        finally
        {
            _semaphore.Release();
        }

        Console.WriteLine("Completed logging.");
    }

    /// <summary>
    /// Logs the error details in the file.
    /// </summary>
    /// <param name="errorMessage">The message to be logged.</param>
    /// <param name="userId">User ID of the user facing the error.</param>
    internal void LogErrorForEachUser(string errorMessage, string userId)
    {
        if (!Directory.Exists("Logs"))
        {
            Directory.CreateDirectory("Logs");
        }

        string filePath = Path.Combine("Logs", $"User{userId}Log.txt");

        string logMessage = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} - {errorMessage}\n";
        Console.WriteLine("Logging error ...");
        using (FileStream stream = new FileStream(filePath, FileMode.Append, FileAccess.Write))
        {
            byte[] buffer = Encoding.UTF8.GetBytes(logMessage);
            stream.Write(buffer, 0, buffer.Length);
        }

        Console.WriteLine("Completed logging.");
    }

    /// <summary>
    /// Logs error from different user at a time.
    /// </summary>
    internal void LogErrors()
    {
        Console.WriteLine("Writing log in same file for all users");
        Parallel.For(0, 20, i =>
        {
            Task.Run(() => this.LogError("Database connection failed"));
        });
    }

    /// <summary>
    /// Logs error from different user at a time in separate file.
    /// </summary>
    internal void LogErrorsAtDifferentTask()
    {
        Console.WriteLine("Writing log in different file for each users");
        Parallel.For(0, 20, i =>
        {
            Task.Run(() => this.LogErrorForEachUser("Database connection failed", $"{i}"));
        });
    }
}
