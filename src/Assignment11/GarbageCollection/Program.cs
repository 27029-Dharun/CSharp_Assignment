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

        List<Person> persons = CreateObjects();

        Console.WriteLine($"Total memory after creating all objects: {GetManagedMemoryInBytes()} KB");

        // Force garbage collection (even though objects are still referenced)
        GC.Collect();
        Console.WriteLine($"Total memory after triggering garbage collector(object still referred): {GetManagedMemoryInBytes()} KB");

        // Made the list null now all the objects created are unreachable.
        persons = null;

        // Force garbage collection again (now objects can be collected)
        GC.Collect();
        Console.WriteLine($"Total memory after triggering garbage collector(objects unreachable): {GetManagedMemoryInBytes()} KB");

        Console.WriteLine("Press any key to exit");
        Console.ReadKey();
    }

    private static long GetManagedMemoryInBytes()
    {
        long memory = GC.GetTotalMemory(false);
        return memory / 1024;
    }

    private static List<Person> CreateObjects(int objectCount = 1_000_000)
    {
        List<Person> persons = new List<Person>();

        for (int i = 0; i < objectCount; i++)
        {
            Person person = new Person();
            persons.Add(person);
        }

        return persons;
    }
}