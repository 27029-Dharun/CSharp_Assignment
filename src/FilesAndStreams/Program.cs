namespace FilesAndStreams;

/// <summary>
/// Application entry point.
/// </summary>
internal class Program
{
    private static void Main()
    {
        FileDateProcessor fileDateProcessor = new FileDateProcessor();
        fileDateProcessor.Run();
        Console.ReadKey();
    }
}