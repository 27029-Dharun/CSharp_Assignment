namespace AsynchronousProgramming.Tasks;

/// <summary>
/// Contains the implementation of downloading from http client.
/// </summary>
internal class AsyncAwait
{
    /// <summary>
    /// Fetches th content from the url.
    /// </summary>
    /// <returns>A asynchronous task contenting the string content in the url.</returns>
    public async Task<string> DownloadContentAsync()
    {
        using HttpClient client = new HttpClient();

        Console.WriteLine($"Thread Id before calling await: {Thread.CurrentThread.ManagedThreadId}");

        string content = await client.GetStringAsync("https://www.example.com").ConfigureAwait(false);

        Console.WriteLine($"Thread Id after calling await: {Thread.CurrentThread.ManagedThreadId}");

        return content;
    }
}
