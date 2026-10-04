namespace AsynchronousProgramming.Tasks;

/// <summary>
/// Contains the method for demonstrating and preventing the deadlock condition.
/// </summary>
internal class DeadlockDebugger
{
    /// <summary>
    /// Executes an asynchronous operation and displays its result.
    /// </summary>
    /// <returns>A task representing the asynchronous execution of the methods.</returns>
    public async Task DeadlockMethod()
    {
        string result = await this.SomeAsyncOperation();

        Console.WriteLine(result);
    }

    /// <summary>
    /// Results an result after one second.
    /// </summary>
    /// <returns>A task containing the string result of the asynchronous operation.</returns>
    public async Task<string> SomeAsyncOperation()
    {
        await Task.Delay(1000);

        return "Hello, World!";
    }
}
