using ValueAndReferenceTypes.Model;

namespace ValueAndReferenceTypes;

/// <summary>
/// Program class which acts as the entry point of the application.
/// </summary>
public class Program
{
    /// <summary>
    /// Application entry point.
    /// </summary>
    public static void Main()
    {
        int count = 10;

        Person person = new Person()
        {
            Name = "Dharun",
            Age = 20,
        };

        Console.WriteLine("Value And Reference type" + Environment.NewLine);
        Console.WriteLine($"The value of value type variable before incrementing: {count}");
        Console.WriteLine($"The value of reference type variable before incrementing: {person.Age}" + Environment.NewLine);

        Increment(person, count);
        Console.WriteLine($"The value of value type variable after incrementing: {count}");
        Console.WriteLine($"The value of reference type variable after incrementing: {person.Age}" + Environment.NewLine);

        Console.WriteLine("Creating memory for reference type in heap");
        CreateArray();

        Console.WriteLine("Press any key to exit");
        Console.ReadKey();
    }

    private static void CreateArray()
    {
        // create a array with all values as zero.
        int[] array = new int[100];
    }

    private static void Increment(Person person, int count)
    {
        person.Age++;
        count++;
    }
}