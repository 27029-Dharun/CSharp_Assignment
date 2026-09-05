namespace Assignment12;

/// <summary>
/// Application entry point.
/// </summary>
internal class Program
{
    private static void Main()
    {
        MemoryEater memoryEater = new MemoryEater();
        memoryEater.Allocate();
        Console.ReadKey();
    }
}