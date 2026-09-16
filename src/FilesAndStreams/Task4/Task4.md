
# Task 4 - Thread-Safe Logging

## Objective

The objective of this task is to make the logging system thread-safe when multiple users try to write error messages to the same file at the same time.

## Problem

Multiple users may call `LogError()` simultaneously.

If multiple threads write to the same file at the same time, it can cause file access conflicts

## Solution

A `lock` is used to allow only one thread at a time to write to the file.

```csharp
lock (_lock)
{
    File.AppendAllText(LogFileName, logMessage);
}
```

## Logger Class

```csharp

public class Logger
{
    private static readonly object _lock = new object();
    private static string _logFilePath = "log.txt";

    public static async Task LogError(string errorMessage)
    {
        string logMessage = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} - ERROR - {errorMessage}{Environment.NewLine}";

        lock (_lock)
        {
            File.AppendAllTextAsync(_logFilePath, logMessage);
        }
    }
}
```

### Example Usage

```csharp
logger logger = new logger();
logger.LogError("Database connection failed");
logger.LogError("Invalid user input");
logger.LogError("File not found");
```

### Why Use a Static Lock?

```csharp
private static readonly object _lock = new object();
```

`static` means all instances of `logger` share the same lock. For example:

```csharp
logger logger1 = new logger();
logger logger2 = new logger();
```

Both objects use the same `_lock`. This is important because both objects are accessing the same physical file.

It directly appends the new message to the end of the file. We do not need an intermediary `MemoryStream`.

## Key Learning

* Multiple threads can execute `LogError()` at the exact same time.
* `lock` protects the file-writing operation from race conditions.
* Only one thread can enter the scoped `lock` block at any given instance.
* Other threads wait in a queue until the current execution thread finishes.
* `static` ensures all logger class instances reference a unified global lock.
* `File.AppendAllText()` writes directly to the disk subsystem.
* An intermediate `MemoryStream` buffer is not required for simple line logging.

## Conclusion

The logging system is now completely thread-safe for concurrent writes targeting the same log file. Utilizing a `lock` block blocks simultaneous disk access attempts, safely circumventing cross-thread conflicts and ensuring data integrity.
