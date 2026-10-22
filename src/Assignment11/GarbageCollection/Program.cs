using System.Diagnostics;

namespace GarbageCollection;

/// <summary>
/// Program class which acts as the entry point of the application.
/// </summary>
internal class Program
{
    /// <summary>
    /// Application entry point.
    /// </summary>
    public static void Main()
    {
        Console.WriteLine("======= Garbage Collection =======\n" +
                $"Managed heap estimate before allocation: {GetManagedMemoryInBytes()} bytes");

        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();

        List<Person> people = CreateObjects();
        Console.WriteLine($"Managed heap estimate after creating all objects: {GetManagedMemoryInBytes()} bytes");

        people.Clear();

        GC.Collect(GC.MaxGeneration, GCCollectionMode.Forced, true, true);
        Console.WriteLine($"Managed heap estimate after triggering garbage collector: {GetManagedMemoryInBytes()} bytes");

        stopwatch.Stop();

        Console.WriteLine($"The time taken to create objects and perform garbage collection: {stopwatch.ElapsedMilliseconds}ms\n");
        Console.ReadKey();
    }

    private static long GetManagedMemoryInBytes()
    {
        long memory = GC.GetTotalMemory(false);
        return memory;
    }

    private static List<Person> CreateObjects(int objectCount = 1_000_000)
    {
        List<Person> people = new List<Person>();

        for (int i = 0; i < objectCount; i++)
        {
            Person person = new Person();
            people.Add(person);
        }

        return people;
    }
}