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
                $"Managed heap estimate before allocation: {GetManagedMemory()} bytes");

        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();

        List<Person> people = CreateObjects();
        Console.WriteLine($"Managed heap estimate after creating all objects: {GetManagedMemory()} bytes");

        people.Clear();

        GC.Collect(GC.MaxGeneration, GCCollectionMode.Forced, blocking: true, compacting: true);
        Console.WriteLine($"Managed heap estimate after triggering garbage collector: {GetManagedMemory()} bytes");

        stopwatch.Stop();

        Console.WriteLine($"The time taken to create objects and perform garbage collection task: {stopwatch.ElapsedMilliseconds}ms\n" +
            $"Press any key to exit");
        Console.ReadKey();
    }

    private static long GetManagedMemory()
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