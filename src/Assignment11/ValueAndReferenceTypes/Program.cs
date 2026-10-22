namespace GarbageCollection;

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
        // Task 1
        PersonStruct personStruct = new PersonStruct()
        {
            Name = "Dharun",
            Age = 20,
        };

        Person person = new Person()
        {
            Name = "Dharun",
            Age = 20,
        };

        Console.WriteLine("======= Value And Reference type =======\n\n" +
            $"The value of value type variable before incrementing: {personStruct.Age}.\n" +
            $"The value of reference type variable before incrementing: {person.Age}.\n");

        Increment(person, personStruct);
        Console.WriteLine($"The value of value type variable after incrementing: {personStruct.Age}.\n" +
            $"The value of reference type variable after incrementing: {person.Age}.\n");

        // Task 2
        Console.WriteLine("======= Working with the Stack and the Heap =======\n\n" +
            "Creating memory for reference type\n" +
            $"Managed memory before creating array is {GC.GetTotalMemory(false)} bytes.");

        int[] array = CreateArray();

        Console.WriteLine($"Managed memory after creating array is {GC.GetTotalMemory(false)} bytes.\n");

        // Creating value type variables are performing calculations.
        Console.WriteLine("Calculation with large number of local variables.\n");

        decimal result = CalculateUsingLocalVariables();

        Console.WriteLine($"The result of the calculation is {result}\n" +
            $"The memory usage after the calculation of local variables: {GC.GetTotalMemory(false)} bytes.");

        // Boxing
        int a = 10;
        object obj = a;

        // Unboxing
        int number = (int)obj;

        Console.WriteLine("Boxing is the process of converting a value type into an object type.\n+" +
            "When boxing occurred the value type is been wrapped in an object in the heap.\n" +
            "Unboxing is the process of extracting the value type from a previously boxed object. It requires an explicit cast.\n");

        Console.ReadKey();
    }

    private static decimal CalculateUsingLocalVariables()
    {
        Span<decimal> numbers = stackalloc decimal[]
        {
            10, 20, 30, 40, 50, 60, 70,
        };

        decimal total = 0;
        foreach (decimal number in numbers)
        {
            total += number;
        }

        return total;
    }

    private static int[] CreateArray() => new int[100_000];

    private static void Increment(Person person, PersonStruct personStruct)
    {
        person.Age++;
        personStruct.Age++;
    }
}