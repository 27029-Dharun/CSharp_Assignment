namespace AsynchronousProgramming.Tasks;

/// <summary>
/// Contains the implementation of async void and async task method to understand their difference.
/// </summary>
internal class ErrorHandling
{
    /// <summary>
    /// Throws a exception from the async void method.
    /// </summary>
    /// <exception cref="Exception">The exception that can't be handled.</exception>
    public async void VoidMethod()
    {
        Console.WriteLine("Async void method");

        await Task.Delay(1);
        throw new Exception();
    }

    /// <summary>
    /// Throws a exception from the async task method.
    /// </summary>
    /// <returns>A asynchronous task that represent an operation to throw an error.</returns>
    /// <exception cref="Exception">The exception that can be handled.</exception>
    public async Task TaskMethod()
    {
        Console.WriteLine("Async task method");

        await Task.Delay(1);
        throw new Exception();
    }
}
