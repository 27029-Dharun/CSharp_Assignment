namespace AsynchronousProgramming;

/// <summary>
/// Application entry point.
/// </summary>
internal class Program
{
    private static async Task Main()
    {
        Controller controller = new Controller();
        await controller.Run();
    }
}