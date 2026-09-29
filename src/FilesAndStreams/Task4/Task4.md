
# Task 4 - Thread-Safe Logging

## Objective

The objective of this task is to make the logging system thread-safe when multiple users try to write error messages to the same file at the same time.

## Problem

Multiple users may call `LogError()` simultaneously.

If multiple threads write to the same file at the same time, it can cause file access conflicts

## Solution

Using `SemaphoreSlim` allows us to use File.AppendAllTextAsync safely without blocking threads.

```csharp

    private static readonly SemaphoreSlim _semaphore = new SemaphoreSlim(1, 1);
```

## Logger Class

```csharp

public class Logger
{
    
    private static readonly SemaphoreSlim _semaphore = new SemaphoreSlim(1, 1);
    private static readonly string _logFilePath = "log.txt";

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
```

### Example Usage

```csharp
Logger logger = new Logger();
logger.LogError("Database connection failed");
logger.LogError("Invalid user input");
logger.LogError("File not found");
```

### Why Use a Static?

```csharp
    private static readonly SemaphoreSlim _semaphore = new SemaphoreSlim(1, 1);
```

`static` ensures all instances of `logger` share the same semaphore. For example:

```csharp
Logger logger1 = new Logger();
Logger logger2 = new Logger();
```

Both objects use the same `_semaphore`. This is important because both objects are accessing the same physical file.

It directly appends the new message to the end of the file. We do not need an intermediary `MemoryStream`.

## Key Learning

* Multiple threads can execute LogError() at the exact same time.
* SemaphoreSlim protects the file-writing operation from race conditions without blocking OS threads.
* Only one thread can enter the scoped _semaphore block at any given instance.
* Other threads asynchronously wait in a queue until the current execution thread finishes.
* File.AppendAllTextAsync() writes directly to the disk subsystem.
* An intermediate MemoryStream buffer is not required for single-line logging.
* Callers should await the LogError method to ensure the log is successfully written before the application continues.

## Conclusion

The logging system is now completely thread-safe for concurrent writes targeting the same log file. Utilizing a `_semaphore` block blocks simultaneous disk access attempts, safely circumventing cross-thread conflicts and ensuring data integrity.
