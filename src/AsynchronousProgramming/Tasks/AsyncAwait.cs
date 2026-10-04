namespace AsynchronousProgramming.Tasks;

/// <summary>
/// Contains the implementation of downloading from http client.
/// </summary>
internal class AsyncAwait
{
    /// <summary>
    /// Fetches th content from the url.
    /// </summary>
    /// <returns>A asynchronous operation, that download content from the url.</returns>
    public async Task<string> DownloadContentAsync()
    {
        using HttpClient client = new HttpClient();

        string content = await client.GetStringAsync("https://www.example.com");

        return content;
    }
}
