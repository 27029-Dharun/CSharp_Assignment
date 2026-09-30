using System.Text.Json;

namespace AsynchronousProgramming.Tasks;

/// <summary>
/// Contains the multilayered async operation.
/// </summary>
internal class MultiLayeredAsync
{
    /// <summary>
    /// Gets the length of the key value pair.
    /// </summary>
    /// <returns>A asynchronous task parse the response form the url.</returns>
    public async Task<int> MethodC()
    {
        string response = await this.MethodB();
        Console.WriteLine(response);

        using JsonDocument json = JsonDocument.Parse(response);
        JsonElement root = json.RootElement;

        return root.EnumerateObject().Count();
    }

    private async Task<string> MethodB()
    {
        int sequence = await this.MethodA();

        string url = $"https://jsonplaceholder.typicode.com/todos/{sequence}";

        using HttpClient httpClient = new HttpClient();

        string response = await httpClient.GetStringAsync(url);
        return response;
    }

    private async Task<int> MethodA()
    {
        await Task.Run(() =>
        {
            Thread.Sleep(1000);
        });
        return 100;
    }
}
