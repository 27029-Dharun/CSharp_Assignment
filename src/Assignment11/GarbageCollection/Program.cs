using ValueAndReferenceTypes;

namespace GarbageCollection;

/// <summary>
/// Program class which acts as the entry point of the application.
/// </summary>
internal class Program
{
    private static List<Person>? _person = new List<Person>();

    /// <summary>
    /// Application entry point.
    /// </summary>
    public static void Main()
    {
        Console.WriteLine("=======Garbage Collection=======" + Environment.NewLine);

        Console.WriteLine($"Total memory before creating all objects: {GetMemoryInKB()} KB");
        CreateObjects();

        Console.WriteLine($"Total memory after creating all objects: {GetMemoryInKB()} KB");

        // Force garbage collection (even though objects are still referenced)
        GC.Collect();
        Console.WriteLine($"Total memory after triggering garbage collector(object still referred): {GetMemoryInKB()} KB");

        // Made the list null now all the objects created are unreachable.
        _person = null;

        // Force garbage collection again (now objects can be collected)
        GC.Collect();
        Console.WriteLine($"Total memory after triggering garbage collector(objects unreachable): {GetMemoryInKB()} KB");

        Console.WriteLine("Press any key to exit");
        Console.ReadKey();
    }

    private static long GetMemoryInKB()
    {
        long memory = GC.GetAllocatedBytesForCurrentThread();
        return memory / 1024;
    }

    private static void CreateObjects(int objectCount = 10_00_000)
    {
        for (int i = 0; i < objectCount; i++)
        {
            Person person = new Person();
            _person?.Add(person);
        }
    }
}