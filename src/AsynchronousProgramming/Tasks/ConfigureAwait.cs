namespace AsynchronousProgramming.Tasks;

/// <summary>
/// Contains the implementation to configure await.
/// </summary>
internal class ConfigureAwait
{
    /// <summary>
    /// Implements the configure await operation.
    /// </summary>
    /// <returns>A asynchronous operation that perform operation with configure await as false</returns>
    public async Task Run()
    {
        int result = await this.MethodB();
        Console.WriteLine($"Final result: {result}");
    }

    private async Task<int> MethodA()
    {
        Console.WriteLine($"Before calling await from Method A: {Thread.CurrentThread.ManagedThreadId}");
        await Task.Delay(1000).ConfigureAwait(false);
        Console.WriteLine($"After calling await from Method A: {Thread.CurrentThread.ManagedThreadId}");

        return 100;
    }

    private async Task<int> MethodB()
    {
        Console.WriteLine($"Before calling await from Method B: {Thread.CurrentThread.ManagedThreadId}");
        int result = await this.MethodA().ConfigureAwait(false);
        Console.WriteLine($"After calling await from Method B: {Thread.CurrentThread.ManagedThreadId}");

        return result + 100;
    }
}
